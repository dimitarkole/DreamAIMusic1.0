﻿// ReSharper disable VirtualMemberCallInConstructor
namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Songs = new HashSet<Song>();
            this.Orders = new HashSet<Order>();
            this.Playlists = new HashSet<Playlist>();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Settings = new List<UserSetting>();
        }

        public virtual string ImageUrl { get; set; }

        public virtual string FirstName { get; set; }

        public int Age { get; set; }

        public VisabilityType VisabilityAge { get; set; }

        public string Phone { get; set; }

        public VisabilityType VisabilityPhone { get; set; }

        public DateTime Birtday { get; set; }

        public VisabilityType VisabilityBirtday { get; set; }

        public virtual string LastName { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }

        public string TimeZoneId { get; set; }

        public ICollection<UserSetting> Settings { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
    }
}
