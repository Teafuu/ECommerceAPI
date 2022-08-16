using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models.Dto.Request.User
{
    public class CreateUserRequest
    {
        [Required] public string? Email { get; set; }
        [Required] public string? Password { get; set; }
    }
}
