﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<RentalSystems.Models.QRCode> QRCode { get; set; }
        public string WebRootPath { get; internal set; }
    }
}
