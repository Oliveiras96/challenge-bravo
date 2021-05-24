using System.ComponentModel.DataAnnotations;

namespace src.Models
{
    public class EntriesModelInput
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ISOCode { get; set; }

        [Required]
        public string Name { get; set; }

        public double Quotation { get; set; }
    }
}