using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class ItemAuthor
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
