using System.ComponentModel.DataAnnotations;

namespace PrinterApi.Entities
{
    public class Printer
    {
        [Key]
        public required int PrinterId { get; set; }
        public required string PrinterName { get; set; }
        public required string IpAddress { get; set; }
        public bool? IsActive { get; set; }
    }
}
