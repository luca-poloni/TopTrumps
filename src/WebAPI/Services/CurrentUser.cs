﻿using Application.Common.Interfaces;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
    {
        public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
