using MediaTracking.BLL.DTOs.Abstraction;

namespace MediaTracking.BLL.DTOs
{
    public class UserDTO : IDTOEntity
    {
        public string Id {get;set;}
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive {get;set;}
        public RoleDTO Role { get; set; }
    }
}