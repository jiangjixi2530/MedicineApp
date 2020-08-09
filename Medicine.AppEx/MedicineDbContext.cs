using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;

namespace Medicine.AppEx
{
    public class MedicineDbContext : DbContext
    {
        public DbSet<MedicineInfo> MedicineInfo { get; set; }
    }
}
