using AutoMapper;
using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    public class UserFullNameViewModel : IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserFullNameViewModel>()
                .ForMember(m => m.FullName, y => y.MapFrom(u => $"{u.FirstName} {u.LastName}"));
        }
    }
}
