
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FigureShopSharedLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(0.1, 999999)]
        public decimal Price { get; set; }
        [Required,DisplayName("Product Image")]

        public string? Img { get; set; }

        public int Quality { get; set; } 
        public bool Featured { get; set; }
        public DateTime? DateUpload { get; set; } = DateTime.Now;

    }
}
