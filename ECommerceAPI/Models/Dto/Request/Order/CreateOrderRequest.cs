namespace ECommerceAPI.Models.Dto.Request.Order
{
    public class CreateOrderRequest
    {
        public int UserId { get; set; }
        public ICollection<int>? ProductIds { get; set; }
        public string? Address { get; set; }
        public bool Approved { get; set; }
    }
}
