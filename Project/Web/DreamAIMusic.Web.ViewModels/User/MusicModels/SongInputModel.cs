namespace DreamAIMusic.Web.ViewModels.UserModels.MusicModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongInputModel : IMapTo<Song>
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string MusicTypeId { get; set; }

        public string Text { get; set; }
    }
}