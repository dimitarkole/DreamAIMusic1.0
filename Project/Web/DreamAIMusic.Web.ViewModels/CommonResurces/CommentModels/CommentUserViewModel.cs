namespace DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CommentUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public virtual string Avatar { get; set; }

        public virtual string UserName { get; set; }
    }
}
