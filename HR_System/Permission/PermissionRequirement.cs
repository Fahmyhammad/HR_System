using Microsoft.AspNetCore.Authorization;

namespace HR_System.Permission
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string _Permission { get;private set; }
        public PermissionRequirement(string Permission)
        {
            _Permission = Permission;   
        }
    }
}
