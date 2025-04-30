using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseModel.Domain.Entities
{
    public sealed class Tenant  : EntityBase
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ConnectionString { get; private set; }
        public string TenantUrl { get; private set; }
        public bool IsActive { get; private set; } = true;

        public Tenant(Guid id, string name, string connectionString, string tenantUrl)
        {
            Id = id;
            Name = name;
            ConnectionString = connectionString;
            TenantUrl = tenantUrl;
            IsActive = true;
        }

        public void Update(string name, string connectionString, string tenantUrl)
        {
            Name = name;
            ConnectionString = connectionString;
            TenantUrl = tenantUrl;
        }
    }
}