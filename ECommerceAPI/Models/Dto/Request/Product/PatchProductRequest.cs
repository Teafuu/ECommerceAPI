namespace ECommerceAPI.Models.Dto.Request.Product
{
    public class PatchProductRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Base64Image { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
