using DreamAIMusic.Common;

namespace DreamAIMusic.Data.Models
{
    public class RolePermission : Entity<int>
    {
        public string RoleId { get; set; }
        
        public Role Role { get; set; }
        
        public int PermissionId { get; set; }
        
        public Permission Permission { get; set; }
    }
}