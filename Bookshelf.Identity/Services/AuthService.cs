﻿using Bookshelf.Application.Contracts.Identity;
using Bookshelf.Application.Contracts.Persistence;
using Bookshelf.Application.Exceptions;
using Bookshelf.Application.Models.Identity;
using Bookshelf.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bookshelf.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }
    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            throw new NotFoundException($"User with {request.Email} not found.",request.Email);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);

        if (result.Succeeded == false)
        {
            throw new Exception($"Credentials for {request.Email} aren't valid.");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        var res = new AuthResponse()
        {
            Id= user.Id,
            Token= new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email=user.Email,
            UserName=user.UserName
        };
        return res;
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaims= await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(q=> new Claim(ClaimTypes.Role,q)).ToList();

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim("uid",user.Id)
        }.Union(userClaims).Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            claims:claims,
            expires:DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials:signingCredentials);
        return jwtSecurityToken;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        var user = new ApplicationUser()
        {
            Email=request.Email,
            Name= request.Name,
            UserName= request.UserName,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(user,request.Password);
        if(result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user,"user");
            return new RegistrationResponse()
            {
                UserId= user.Id,

            };
            }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var err in result.Errors)
            {
                stringBuilder.AppendFormat("- {0}\n",err.Description);
            }
            throw new Exception(stringBuilder.ToString());
        }
    }
}
