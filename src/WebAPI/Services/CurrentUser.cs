﻿using Application.Common.Interfaces;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
