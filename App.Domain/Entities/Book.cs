using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public virtual List<MembersBook> MembersBooks { get; set; }
    }
}
