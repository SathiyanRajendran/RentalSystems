using Microsoft.EntityFrameworkCore;
using RentalSystems.Models;

namespace RentalSystems.Models
{
    public class OwnerDbContext : DbContext
    {
        public OwnerDbContext() { }
        public OwnerDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Owner> owners { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Admintable> admintables { get; set; }
        public DbSet<Registrationtable> registrationtables { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<RentalPayment> rentalPayments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=AY1KPKYG2U1G;Database=OwnerDb;User Id=sa; Password=!Morning1;MultipleActiveResultSets=true");
            }
        }
    }
}
