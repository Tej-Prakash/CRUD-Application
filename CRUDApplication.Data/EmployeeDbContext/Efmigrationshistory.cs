using System;
using System.Collections.Generic;

#nullable disable

namespace CRUDApplication.Data.EmployeeDbContext
{
    public partial class Efmigrationshistory
    {
        public string MigrationId { get; set; }
        public string ProductVersion { get; set; }
    }
}
