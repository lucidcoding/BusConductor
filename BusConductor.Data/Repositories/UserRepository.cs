using System;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public User GetByUsername(string username)
        {
            //todo: fix
            //var user = Session.CreateQuery(
            //    "select user " +
            //    "from User as user " +
            //    "where user.Username = :username ")
            //    .SetString("username", username)
            //    .UniqueResult<User>();

            //return user;
            return null;
        }
    }
}
