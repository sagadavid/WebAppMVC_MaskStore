using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaskDemo.Models
{
    public class Mask
    {
        public int Id { get; set; }
      
        [Required(ErrorMessage = "note a description please")]
        [StringLength(256,ErrorMessage ="longer than 256 character")]
        public string Description { get; set; }

        [Required(ErrorMessage = "name a price please")]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(9,2)")]
        public decimal Price { get; set; }

        [Display(Name = "mask genre")]
        [Required(ErrorMessage = "select a type please")]
        public int MaskTypeId { get; set; }
        public MaskType MaskType { get; set; }

       

    }
}
 