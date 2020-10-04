using MediaTracking.BLL.DTOs.Abstraction;

namespace MediaTracking.BLL.DTOs
{
    public class TokenDTO : IDTOEntity
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
    }
}