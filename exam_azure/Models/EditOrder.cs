using System.ComponentModel.DataAnnotations;

namespace exam_azure.Models
{
    public class EditOrder
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime delivery_time { get; set; }
        [Required]
        public string delivery_address { get; set; }
   
    }
}
