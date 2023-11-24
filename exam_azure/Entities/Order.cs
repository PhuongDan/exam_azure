using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam_azure.Entities
{
    [Table ("order")]
    public class Order
    {
        [Key]
        public int id { get; set; }

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
