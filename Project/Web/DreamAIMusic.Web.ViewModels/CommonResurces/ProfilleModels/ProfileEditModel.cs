namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProfileEditModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        [Required]
        [MinLength(GlobalConstants.FirstNameMinLength)]
        [MaxLength(GlobalConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(GlobalConstants.LastNameMinLength)]
        [MaxLength(GlobalConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public virtual DateTime Birthday { get; set; }
    }
}
