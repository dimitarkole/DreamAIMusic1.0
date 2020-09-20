namespace DreamAIMusic.Web.ViewModels.User.PlaylistModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class PlaylistSearchModel : IMapTo<Playlist>
    {
        public string Name { get; set; }
    }
}
