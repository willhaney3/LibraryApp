using System.Linq;
using LibraryApp.EntityFramework;
using LibraryApp.MultiTenancy;

namespace LibraryApp.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly LibraryAppDbContext _context;

        public DefaultTenantCreator(LibraryAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
