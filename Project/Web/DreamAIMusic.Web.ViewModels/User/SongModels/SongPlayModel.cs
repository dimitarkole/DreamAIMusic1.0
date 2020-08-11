namespace DreamAIMusic.Web.ViewModels.UserModels.SongModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;

    public class SongPlayModel : IMapFrom<Song>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string Image { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Text { get; set; }

        public string CountViews { get; set; }

        public long CountLikes { get; set; }

        public long CountDisLikes { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
