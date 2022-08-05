using System.Collections.Generic;

namespace Authentication.Models
{
    public class UserRoleResponse
    {
        public string UserName { get; set; }
        public List<UserRole> userRoles { get; set; }
    }
}
