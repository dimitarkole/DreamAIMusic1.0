namespace DreamAIMusic.Web.ViewModels.User.PlaylistModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongToPlaylistCreateModel : IMapTo<PlaylistSong>
    {
        public string PlaylistId { get; set; }

        public string SongId { get; set; }
    }
}
