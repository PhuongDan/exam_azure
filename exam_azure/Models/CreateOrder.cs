using System.ComponentModel.DataAnnotations;

namespace exam_azure.Models
{
    public class CreateOrder
    {
        [Required]
        [StringLength(200)]
        public string item_name { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public DateTime delivery_time { get; set; }
        [Required]
        public string delivery_address { get; set; }
        [Required]
        public int contact_phone { get; set; }
    }
}
