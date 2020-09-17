using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    public class ProfileInputModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        //public string[] Roles { get; set; }
    }
}
