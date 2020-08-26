// ReSharper disable VirtualMemberCallInConstructor
using DreamAIMusic.Common;
using System;

namespace DreamAIMusic.Data.Models
{
    public class ApplicationTimeZone
    {
        public ApplicationTimeZone()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public virtual string Id { get; set; }

        public string Alias { get; set; }

        public string DisplayName { get; set; }
    }
}