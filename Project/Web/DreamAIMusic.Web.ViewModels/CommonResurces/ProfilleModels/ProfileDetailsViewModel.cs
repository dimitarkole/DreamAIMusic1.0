namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    using System;

    public class ProfileDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public virtual string ImageUrl { get; set; }

        public virtual string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public DateTime Birtday { get; set; }

        public virtual int SongsCount { get; set; }

        public virtual int PlaylistsCount { get; set; }
    }
}
