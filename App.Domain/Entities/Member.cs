using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }

        public virtual Address Address { get; set; }
        public virtual List<MembersBook> MembersBooks { get; set; }
    }
}
