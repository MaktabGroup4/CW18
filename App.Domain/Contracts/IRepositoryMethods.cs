using App.Domain.DTOs;
using App.Domain.Entities;

namespace Repository.Test
{
    public interface IRepositoryMethods
    {
        List<Book> BorrowedInState();
        List<StatesMembers> GetMembers();
        List<Member> GetMembersBooks();
    }
}