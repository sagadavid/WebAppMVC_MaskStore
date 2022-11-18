using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaskDemo.Models
{
    public class MaskType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "note a type please")]
        [Display(Name="Type of mask")]
        [StringLength(64, ErrorMessage = "longer than 64 character")]
        public string Name { get; set; }
        //for not to let null
        public ICollection<Mask> Masks { get; set; } = new HashSet<Mask>();//new List<Mask>();
            
            

    }
}
