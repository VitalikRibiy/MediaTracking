using MediaTracking.BLL.DTOs.Abstraction;

namespace MediaTracking.BLL.DTOs
{
    public class LoginDTO: IDTOEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}