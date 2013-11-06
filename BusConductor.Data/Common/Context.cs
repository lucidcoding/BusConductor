using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BusConductor.Domain.Entities;

namespace BusConductor.Data.Common
{
    public class Context : DbContext
    {
        //todo: put in config
        public Context()
            : base(@"Data Source=localhost\sql2008r2;Initial Catalog=BusConductor;User Id=intranetuser;Password=intuspas;")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Bus> Busses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<PricingPeriod> PricingPeriods { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Bus>().ToTable("Bus");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<PermissionRole>().ToTable("PermissionRole");
            modelBuilder.Entity<PricingPeriod>().ToTable("PricingPeriod");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Task>().ToTable("Task");
            modelBuilder.Entity<TaskType>().ToTable("TaskType");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Voucher>().ToTable("Voucher");

            //Configure domain classes using Fluent API here
            //modelBuilder.Entity<Task>()
            //    .HasMany<Activity>(task => task.Activites)
            //    .WithRequired(activity => activity.Task)
            //    .HasForeignKey(activity => activity.TaskId);

            modelBuilder.Entity<Bus>()
                .HasRequired<User>(bus => bus.CreatedBy);

            modelBuilder.Entity<Bus>()
                .HasMany<Booking>(bus => bus.Bookings)
                .WithRequired(booking => booking.Bus)
                .HasForeignKey(booking => booking.BusId);

            modelBuilder.Entity<User>()
                .HasRequired<User>(x => x.CreatedBy);

            base.OnModelCreating(modelBuilder);
        }
    }
}
