namespace DreamAIMusic.Web.ViewModels.User.SongModels
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongViewModel : IMapFrom<Song>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
