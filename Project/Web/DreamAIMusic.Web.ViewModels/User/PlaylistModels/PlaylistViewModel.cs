namespace DreamAIMusic.Web.ViewModels.User.PlaylistModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class PlaylistViewModel : IMapFrom<Playlist>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int PlaylistSongsCount { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
