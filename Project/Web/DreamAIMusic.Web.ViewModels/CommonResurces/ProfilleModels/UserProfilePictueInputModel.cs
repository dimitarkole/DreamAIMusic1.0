namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class UserProfilePictueInputModel : IMapTo<ApplicationUser>
    {
        [Required]
        public string ImageUrl { get; set; }
    }
}
