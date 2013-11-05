using System;
using NHibernate;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }

        public User GetByUsername(string username)
        {
            var user = Session.CreateQuery(
                "select user " +
                "from User as user " +
                "where user.Username = :username ")
                .SetString("username", username)
                .UniqueResult<User>();

            return user;
        }
    }
}
