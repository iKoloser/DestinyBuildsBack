﻿using DestinyBuildsBack.DTOs.Account;
using DestinyBuildsBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DestinyBuildsBack.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;

    public AccountController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email
            };

            var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            
            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                
                if (roleResult.Succeeded)
                {
                    return Ok("User created successfully");
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createUser.Errors);
            }
            
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }


    }
}