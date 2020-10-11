namespace DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public CommentUserViewModel User { get; set; }

        // public int CommentDislikesCount { get; set; }

        // public int CommentLikesCount { get; set; }

        public virtual ICollection<CommentViewModel> CommentsChildren { get; set; }

        public DateTime CreatedOn { get; set; }

        // public bool IsUserDislikeComment { get; set; }
        // public bool IsUserLikeComment { get; set; }
    }
}
