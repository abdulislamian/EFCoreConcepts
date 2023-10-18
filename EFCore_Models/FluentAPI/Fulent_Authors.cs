using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Models.Models
{
    //[Table("Fulent_Authors")]
    public class Fulent_Authors
    {
        //[Key]
        public int Author_Id { get; set; }
        //[Required]
        //[MaxLength(50)]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Location { get; set; }
        [NotMapped]

        public string FullName 
        { 
            get
            {
                //return string.Concat(FirstName, " ", LastName);
                return $"{FirstName} {LastName}";
            } 
        } 
        //public List<Fulent_Book> Books { get; set; }
        public virtual List<Fulent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
