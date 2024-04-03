using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TaxiAPI.Models
{
    public partial class TaxiContext : DbContext
    {
        public TaxiContext()
        {
        }

        public TaxiContext(DbContextOptions<TaxiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drivercar> Drivercars { get; set; }

        public virtual DbSet<Driverimage> Driverimages { get; set; }

        public virtual DbSet<Driverlocation> Driverlocations { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Passengerrequest> Passengerrequests { get; set; }

        public virtual DbSet<Rating> Ratings { get; set; }

        public virtual DbSet<Ride> Rides { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=12345;database=Taxi");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drivercar>(entity =>
            {
                entity.HasKey(e => e.CarId).HasName("PRIMARY");

                entity.ToTable("drivercars");

                entity.HasIndex(e => e.DriverId, "DriverID");

                entity.Property(e => e.CarId).HasColumnName("CarID");
                entity.Property(e => e.CarColor).HasMaxLength(50);
                entity.Property(e => e.CarModel).HasMaxLength(100);
                entity.Property(e => e.CarPlateNumber).HasMaxLength(20);
                entity.Property(e => e.DriverId).HasColumnName("DriverID");
            });

            modelBuilder.Entity<Driverimage>(entity =>
            {
                entity.HasKey(e => e.DriverImagesId).HasName("PRIMARY");

                entity.ToTable("driverimages");

                entity.HasIndex(e => e.DriverId, "FK_DriverImages_Driver");

                entity.Property(e => e.DriverImagesId).HasColumnName("DriverImagesID");
                entity.Property(e => e.DriverId).HasColumnName("DriverID");

            });

            modelBuilder.Entity<Driverlocation>(entity =>
            {
                entity.HasKey(e => e.DriverId).HasName("PRIMARY");

                entity.ToTable("driverlocation");

                entity.Property(e => e.DriverId).HasColumnName("driverID");
                entity.Property(e => e.Latitude).HasColumnName("latitude");
                entity.Property(e => e.Longitude).HasColumnName("longitude");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'Свободен'")
                    .HasColumnName("status");

            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.MessageId).HasName("PRIMARY");

                entity.ToTable("messages");

                entity.HasIndex(e => e.ReceiverId, "ReceiverID");

                entity.HasIndex(e => e.SenderId, "SenderID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");
                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
                entity.Property(e => e.SenderId).HasColumnName("SenderID");
                entity.Property(e => e.Text).HasMaxLength(255);

            });

            modelBuilder.Entity<Passengerrequest>(entity =>
            {
                entity.HasKey(e => e.RequestId).HasName("PRIMARY");

                entity.ToTable("passengerrequests");

                entity.HasIndex(e => e.PassengerId, "passengerID");

                entity.Property(e => e.RequestId).HasColumnName("requestID");
                entity.Property(e => e.EndPointLat).HasColumnName("endPoint_lat");
                entity.Property(e => e.EndPointLng).HasColumnName("endPoint_lng");
                entity.Property(e => e.PassengerId).HasColumnName("passengerID");
                entity.Property(e => e.RequestTime)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasColumnType("timestamp")
                    .HasColumnName("requestTime");
                entity.Property(e => e.StartPointLat).HasColumnName("startPoint_lat");
                entity.Property(e => e.StartPointLng).HasColumnName("startPoint_lng");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'Поиск'")
                    .HasColumnName("status");

            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RatingId).HasName("PRIMARY");

                entity.ToTable("ratings");

                entity.HasIndex(e => e.UserId, "userID");

                entity.Property(e => e.RatingId).HasColumnName("ratingID");
                entity.Property(e => e.Rating1).HasColumnName("rating");
                entity.Property(e => e.RatingSize).HasColumnName("ratingSize");
                entity.Property(e => e.UserId).HasColumnName("userID");

            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.HasKey(e => e.RideId).HasName("PRIMARY");

                entity.ToTable("rides");

                entity.HasIndex(e => e.DriverId, "driverID");

                entity.HasIndex(e => e.PassengerId, "passengerID");

                entity.Property(e => e.RideId).HasColumnName("rideID");
                entity.Property(e => e.DriverId).HasColumnName("driverID");
                entity.Property(e => e.PassengerId).HasColumnName("passengerID");


            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userID");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone");
                entity.Property(e => e.UserType)
                    .HasColumnType("enum('Driver','Passenger','Support','Admin')")
                    .HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
