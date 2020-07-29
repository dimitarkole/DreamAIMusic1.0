using AutoMapper;
using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.UserModels.SongModels
{
    public class SongViewModel : IMapFrom<Song>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string MusicCategoryId { get; set; }

        public string MusicCategoryName { get; set; }

        public string Text { get; set; }

        public string CountViews { get; set; }

        public long CountLikes { get; set; }

        public long CountDisLikes { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
