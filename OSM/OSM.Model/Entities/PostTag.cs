﻿/***********************************
**** Online Shopping Store v0.1 ****
*** Team: Hung Ly, Thuong Truong ***
*** Ref:                         ***
***********************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSM.Model.Entities
{
    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        [Column(Order = 1)]
        public int PostID { get; set; }

        [Key]
        [MaxLength(50)]
        [Column(Order = 2)]
        public string TagID { get; set; }

        [ForeignKey("PostID")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { get; set; }
    }
}