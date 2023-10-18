using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Models.Models
{
    public class Fulent_Book
    {
        //[Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        //[MaxLength(20)]
        //[Required]
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        //[NotMapped]
        public string PriceRange { get; set; }
        public virtual Fulent_BookDetails BookDetails { get; set; }

        //[ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }
        public virtual Fulent_Publisher Publisher { get; set; }
        //public List<Fulent_Authors> Authors { get; set; }

        public virtual List<Fulent_BookAuthorMap> BookAuthorsMap { get; set; }
    }
}
