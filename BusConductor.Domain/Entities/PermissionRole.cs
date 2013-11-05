using System;
using BusConductor.Domain.Common;

namespace BusConductor.Domain.Entities
{
    public class PermissionRole : Entity<Guid>
    {
        public virtual Permission Permission { get; set; }
    }
}
