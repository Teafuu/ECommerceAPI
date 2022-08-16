namespace ECommerceAPI.Models.Dto.Request.Order
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public ICollection<int>? ProductIds { get; set; }
        public string? Address { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
    }

 
}
