﻿using DreamAIMusic.Common;
using DreamAIMusic.Services.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DreamAIMusic.Web.Infrastucture
{
    public class PermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly PermissionType permissionType;

        public PermissionAttribute(PermissionType permissionType)
        {
            this.permissionType = permissionType;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsPrincipal user = context.HttpContext.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                string id = user.GetUserId();
                IProfileService userService = context.HttpContext.RequestServices.GetRequiredService<IProfileService>();

                /*if (!userService.HasPermissions(id, this.permissionType))
                {
                    context.Result = new ForbidResult();
                }*/
            }
        }
    }
}
