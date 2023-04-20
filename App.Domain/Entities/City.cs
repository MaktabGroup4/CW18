using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Address Address { get; set; }
        public virtual State State { get; set; }
    }
}
