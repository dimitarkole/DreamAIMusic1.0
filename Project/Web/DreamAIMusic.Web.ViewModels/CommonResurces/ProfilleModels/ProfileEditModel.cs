namespace DreamAIMusic.Web.ViewModels.CommonResurces.ProfilleModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class ProfileEditModel : ProfileInputModel, IMapTo<ApplicationUser>
    {
        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }
    }
}
