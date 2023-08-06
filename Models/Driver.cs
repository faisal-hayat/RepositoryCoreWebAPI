using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int DriverNumber { get; set; }
        public string Team { get; set; }
    }
}
