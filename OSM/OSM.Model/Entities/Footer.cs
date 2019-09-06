/***********************************
**** Online Shopping Store v0.1 ****
*** Team: Hung Ly, Thuong Truong ***
*** Ref:                         ***
***********************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSM.Model.Entities
{
    [Table("Footers")]
    public class Footer
    {
        [Key]
        [MaxLength(50)]
        public string ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}