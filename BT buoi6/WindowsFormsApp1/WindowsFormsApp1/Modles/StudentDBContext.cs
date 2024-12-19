using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp1.Modles
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
            : base("name=StudentDBContext")
        {
        }

        public virtual DbSet<FACULTY> FACULTies { get; set; }
        public virtual DbSet<STUDENT> STUDENTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
