﻿namespace DreamAIMusic.Web.Infrastucture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Common;
    using DreamAIMusic.Data.Common.Repositories;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Data.Repositories;
    using DreamAIMusic.Services.Administration;
    using DreamAIMusic.Services.Common;
    using DreamAIMusic.Services.Contracts.Administration;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Services.Data;
    using DreamAIMusic.Services.Messaging;
    using DreamAIMusic.Services.User;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            ApplicationSettings appSetings)
        {
            var key = Encoding.ASCII.GetBytes(appSetings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false,
               };
           });

            return services;
        }

        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
            => services
                .AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>))
                .AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
                .AddScoped<IDbQueryRunner, DbQueryRunner>()
                .AddTransient<IEmailSender, SendGridEmailSender>()
                .AddTransient<ISettingsService, SettingsService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<ISongService, SongService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IPlaylistService, PlaylistService>()
                .AddTransient<ISongReactionService, SongReactionService>()
                .AddTransient<ISongViewHistoryService, SongViewHistoryService>()
                .AddTransient<ICommentReactionService, CommentReactionService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
           => services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "My custum Api", Version = "v1" });
               c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
               {
                   Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                   Name = "Authorization",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.ApiKey,
                   Scheme = "Bearer",
               });

               c.AddSecurityRequirement(new OpenApiSecurityRequirement()
               {
                   {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                   }
               });
           });
    }
}
