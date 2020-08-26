namespace DreamAIMusic.Web.ViewModels.CommonResurces.TimeZoneModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class TimeZoneViewModel : IMapFrom<ApplicationTimeZone>
    {
        public int Id { get; set; }

        public string Alias { get; set; }

        public string DisplayName { get; set; }
    }
}
