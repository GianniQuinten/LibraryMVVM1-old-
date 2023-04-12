using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Middlename { get; set; } = null!;

        public string? Lastname { get; set; } 
        
        public string Adress { get; set; } = null!;

        public string City { get; set; } = null!;

        public int Housenumber { get; set; } 

        public string Postalcode { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Password { get; set; }

    }

    
}
