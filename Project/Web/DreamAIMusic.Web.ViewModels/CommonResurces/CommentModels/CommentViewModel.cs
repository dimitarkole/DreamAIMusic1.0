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

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public CommentUserViewModel User { get; set; }

        public virtual ICollection<CommentViewModel> CommentsChildren { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
              .ForMember(
                  m => m.LikesCount,
                  y => y.MapFrom(
                      s => s.CommentReactions.Where(
                          r => r.Reaction == Common.Reaction.Like)
                      .Count()))
            .ForMember(
                m => m.DislikesCount,
                y => y.MapFrom(
                    s => s.CommentReactions.Where(
                        r => r.Reaction == Common.Reaction.Dislike)
                    .Count()));
        }
    }
}
