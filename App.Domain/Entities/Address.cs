using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string FullAddress { get; set; }

        public virtual Member Member { get; set; }

        public virtual City City { get; set; }
    }
}
