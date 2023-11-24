using System.ComponentModel.DataAnnotations;

namespace exam_azure.DTOs
{
    public class OrderDTO
    {
        public int id { get; set; }
    
        public string item_name { get; set; }
     
        public int quantity { get; set; }
      
        public DateTime delivery_time { get; set; }
       
        public string delivery_address { get; set; }
       
        public int contact_phone { get; set; }
    }
}
