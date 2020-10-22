namespace DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CommentReactionCreateModel : IMapTo<CommentReaction>
    {
        public Reaction Reaction { get; set; }

        public string CommentId { get; set; }
    }
}
