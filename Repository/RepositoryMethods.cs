using App.Domain.DTOs;
using App.Domain.Entities;
using DataStorage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Test
{
    public class RepositoryMethods : IRepositoryMethods
    {
        private readonly LibraryDbContext _context;

        public RepositoryMethods(LibraryDbContext context)
        {
            _context = context;
        }

        public List<StatesMembers> GetMembers()
        {
            return _context.States.Select(x => new StatesMembers
            {
                Members = x.City.Address.Member,
                State = x
            }).ToList();
        }

        public List<Member> GetMembersBooks()
        {
            return _context.Members.Include(x => x.MembersBooks).ThenInclude(x => x.Book).ToList();
        }

        public List<State> BorrowedInState()
        {
            return _context.States.Include(x => x.City).ThenInclude(x => x.Address).ThenInclude(x => x.Member).ThenInclude(x => x.MembersBooks).
                ThenInclude(x => x.Book).ToList();
        }
    }
}
