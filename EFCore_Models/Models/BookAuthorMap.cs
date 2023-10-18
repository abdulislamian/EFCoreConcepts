using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Models.Models
{
    public class BookAuthorMap
    {
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Authors")]
        public int AuthorId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Authors Authors { get; set; }
    }
}
