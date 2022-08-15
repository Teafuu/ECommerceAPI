namespace ECommerceAPI.Models.Dto.Request.User
{
    public class ValidateCredentialsRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
