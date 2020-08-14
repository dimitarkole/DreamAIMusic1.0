namespace DreamAIMusic.Web.ViewModels.User.SongModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public virtual string Avatar { get; set; }

        public virtual string UserName { get; set; }
    }
}
