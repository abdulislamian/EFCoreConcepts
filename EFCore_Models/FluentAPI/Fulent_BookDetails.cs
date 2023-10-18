using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Models.Models
{
    public class Fulent_BookDetails
    {
        //[Key]
        public int BookDetails_Id { get; set; }

        //[Required]
        public int NoOfChapters { get; set; }
        public int NoOfPages { get; set; }
        public double Weight { get; set; }

        //[ForeignKey("Book")]
        public int Fulent_BookId { get; set; }
        public virtual Fulent_Book Book { get; set; }
    }
}
