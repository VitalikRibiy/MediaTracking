using MediaTracking.BLL.DTOs.Abstraction;

namespace MediaTracking.BLL.DTOs
{
    public class RoleDTO : IDTOEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}