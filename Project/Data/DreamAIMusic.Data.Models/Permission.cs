using DreamAIMusic.Common;
using System.Collections.Generic;

namespace DreamAIMusic.Data.Models
{
    public class Permission : Entity<string>
    {
        public Permission()
        {
            Roles = new List<RolePermission>();
        }

        public PermissionType Type { get; set; }

        public string Description { get; set; }

        public ICollection<RolePermission> Roles { get; set; }
    }
}