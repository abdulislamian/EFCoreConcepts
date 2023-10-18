using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Models.Models
{
    [Table("Categories")]
    public class Category
    {
        public int categoryId { get; set; }
        [Column("Name")]
        [Required]
        public string CategoryName { get; set; }
        //public int DisplayOrder { get; set; }
    }
}
