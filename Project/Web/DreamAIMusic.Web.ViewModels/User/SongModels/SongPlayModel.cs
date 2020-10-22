namespace DreamAIMusic.Web.ViewModels.User.SongModels
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using DreamAIMusic.Web.ViewModels.User.SongModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using NHibernate.Type;

    public class SongPlayModel : IMapFrom<Song>, IHaveCustomMappings
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string UniqueSongFilesName { get; set; }

        public string ImageExtension { get; set; }

        public string Mp3Extension { get; set; }

        public virtual string CategoryId { get; set; }

        public virtual string CategoryName { get; set; }

        public string Text { get; set; }

        // public string CountViews { get; set; }

        public int CountLikes { get; set; }

        public int CountDislikes { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public SongUserViewModel User { get; set; }

        public string LogUserId { get; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Song, SongPlayModel>()
                .ForMember(
                    m => m.CountLikes,
                    y => y.MapFrom(
                        s => s.SongReactions.Where(
                            r => r.Reaction == Common.Reaction.Like)
                        .Count()))
              .ForMember(
                  m => m.CountDislikes,
                  y => y.MapFrom(
                      s => s.SongReactions.Where(
                          r => r.Reaction == Common.Reaction.Dislike)
                      .Count()));
        }
    }
}
