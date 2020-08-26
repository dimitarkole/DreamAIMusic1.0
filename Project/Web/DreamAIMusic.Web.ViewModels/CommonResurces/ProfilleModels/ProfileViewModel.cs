namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfileViewModel : IMapFrom<ApplicationUser>
    {
        public virtual string Avatar { get; set; }

        public virtual string Name { get; set; }

        public virtual string Family { get; set; }
    }
}
