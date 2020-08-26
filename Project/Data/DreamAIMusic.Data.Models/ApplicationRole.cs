// ReSharper disable VirtualMemberCallInConstructor
namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using DreamAIMusic.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
            Permissions = new List<RolePermission>();
            Users = new List<UserRole>();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<RolePermission> Permissions { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}
