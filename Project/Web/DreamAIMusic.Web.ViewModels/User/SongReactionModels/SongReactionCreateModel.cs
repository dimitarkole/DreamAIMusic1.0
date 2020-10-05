namespace DreamAIMusic.Web.ViewModels.User.SongReactionModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongReactionCreateModel : IMapTo<SongReaction>
    {
        public Reaction Reaction { get; set; }

        public string SongId { get; set; }
    }
}
