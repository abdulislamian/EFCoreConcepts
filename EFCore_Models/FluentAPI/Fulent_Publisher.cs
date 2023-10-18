using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Models.Models
{
    //[Table("Fulent_Publisher")]
    public class Fulent_Publisher
    {
        //[Key]
        public int Publisher_Id { get; set; }
        //[Required]
        public string Name { get; set; }
        
        public string Location { get; set; }
        public virtual List<Fulent_Book> Books { get; set; }
    }
}
