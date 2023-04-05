using EcommerceBackend.Data.Context;
using EcommerceBackend.Data.Models;

namespace EcommerceBackend.Data.Repository;

public class UserRepository : GenericRepository<User>
{
    public UserRepository(DataContext context) : base(context)
    {
    }
}