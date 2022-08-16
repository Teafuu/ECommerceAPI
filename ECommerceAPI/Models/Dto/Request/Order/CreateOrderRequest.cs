using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models.Dto.Request.Order
{
    public class CreateOrderRequest
    {
        [Required] public Guid Token { get; set; }
        [Required] public ICollection<int>? ProductIds { get; set; }
        [Required] public string? Address { get; set; }
        [Required] public string CardNumber { get; set; }
        [Required] public string ExpiryMonth { get; set; }
        [Required] public string ExpiryYear { get; set; }
        [Required] public string Cvv { get; set; }
    }

 
}
