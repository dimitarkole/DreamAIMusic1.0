using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Web.ViewModels.UserModels.MusicModels
{
    public class SongViewModel : IMapFrom<Song>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string MusicTypeId { get; set; }

        public string MusicTypeName { get; set; }

        public string Text { get; set; }
    }
}
