using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using BusConductor.Data.Common;
using BusConductor.Domain.Entities;
using BusConductor.Domain.RepositoryContracts;

namespace BusConductor.Data.Repositories
{
    public class VoucherRepository : Repository<Voucher, Guid>, IVoucherRepository
    {
        public VoucherRepository(ISessionFactory sessionFactory) :
            base(sessionFactory)
        {
        }

        public Voucher GetByCode(string code)
        {
            var voucher = Session
                .Query<Voucher>()
                .Where(x => x.Code == code)
                .SingleOrDefault();

            return voucher;
        }
    }
}
