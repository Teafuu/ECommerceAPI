using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Models.Dto.Request.Product
{
    public class CreateProductRequest
    {

        [Required] public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Base64Image { get; set; }
        public int Quantity { get; set; }
        [Required] public int Price { get; set; }
    }
}
