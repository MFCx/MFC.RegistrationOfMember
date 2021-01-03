using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationOfMember.DataAccess.Concrete.EntityFramework.Mapping;
using RegistrationOfMember.Entities.Concrete;

namespace RegistrationOfMember.DataAccess.Concrete.EntityFramework
{
    public class MembershipContext:DbContext
    {
        public MembershipContext()
        {
            Database.SetInitializer<MembershipContext>(null);
        }

        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberMap());
        }
    }
}
