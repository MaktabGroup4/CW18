using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTOs
{
    public class StatesMembers
    {
        public State State { get; set; }
        public Member Members { get; set; }
    }
}
