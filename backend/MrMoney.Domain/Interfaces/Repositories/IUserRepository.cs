using MrMoney.Domain.Models;

namespace MrMoney.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByUsername(string username);
    }
}
