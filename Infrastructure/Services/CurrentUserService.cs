﻿using Application.Common.Interface;
using Domain.DbEntities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public int UserId
        {
            get
            {
                var context = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
                return Convert.ToInt32(context);
            }
        }

public string UserEmail {
            get
            {
                var context = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                return context;
            }
        }
    }
}
