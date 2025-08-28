using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Models;

namespace MinhaApi.Data;

public partial class DishBoardProdContext : DbContext
{
    public DishBoardProdContext()
    {
    }

    public DishBoardProdContext(DbContextOptions<DishBoardProdContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<StatusProduct> StatusProducts { get; set; }

    public virtual DbSet<StatusReservation> StatusReservations { get; set; }

    public virtual DbSet<StatusTable> StatusTables { get; set; }

    public virtual DbSet<StatusWorker> StatusWorkers { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=RodrigoPc;Database=DishBoard_PROD;Trusted_Connection=True;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__D54EE9B4A35B9CB2");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__5A6073FC45A2EBF6");

            entity.ToTable("Manager");

            entity.Property(e => e.ManagerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("manager_id");
            entity.Property(e => e.StatusWorkerId)
                .HasDefaultValue(1)
                .HasColumnName("statusWorker_id");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.StatusWorker).WithMany(p => p.Managers)
                .HasForeignKey(d => d.StatusWorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Status_Manager");

            entity.HasOne(d => d.User).WithOne(u => u.Manager)
            .HasForeignKey<Manager>(d => d.UserId)
            .HasConstraintName("FK_Manager_User");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__46596229D218A3A4");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("order_id");
            entity.Property(e => e.Details)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.ServerId).HasColumnName("server_id");
            entity.Property(e => e.ShiftsId).HasColumnName("shifts_id");
            entity.Property(e => e.StatusOrderId)
                .HasDefaultValue(1)
                .HasColumnName("statusOrder_id");
            entity.Property(e => e.TableId).HasColumnName("table_id");
            entity.Property(e => e.TableNumber).HasColumnName("tableNumber");

            entity.HasOne(d => d.Server).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServerId)
                .HasConstraintName("Fk_Order_Server");

            entity.HasOne(d => d.Shifts).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShiftsId)
                .HasConstraintName("Fk_Order_Shifts");

            entity.HasOne(d => d.StatusOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Order_Status");

            entity.HasOne(d => d.Table).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("Fk_Order_Table");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__47027DF590DB390B");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.StatusProductId)
                .HasDefaultValue(1)
                .HasColumnName("statusProduct_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Category");

            entity.HasOne(d => d.StatusProduct).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Product_Status");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Report__779B7C582E54BC95");

            entity.ToTable("Report");

            entity.Property(e => e.ReportId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("report_id");
            entity.Property(e => e.ShiftsId).HasColumnName("shifts_id");
            entity.Property(e => e.TotalOrders).HasColumnName("totalOrders");
            entity.Property(e => e.TotalRevenue)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("totalRevenue");

            entity.HasOne(d => d.Shifts).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ShiftsId)
                .HasConstraintName("Fk_Report_Shifts");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__31384C29AC28F909");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("reservation_id");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerLastName");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("customerPhone");
            entity.Property(e => e.EstimatedDuration).HasColumnName("estimatedDuration");
            entity.Property(e => e.NumberOfPeople).HasColumnName("numberOfPeople");
            entity.Property(e => e.ReservationTime)
                .HasColumnType("datetime")
                .HasColumnName("reservationTime");
            entity.Property(e => e.StatusReservationId).HasColumnName("statusReservation_id");
            entity.Property(e => e.TableId).HasColumnName("table_id");

            entity.HasOne(d => d.StatusReservation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.StatusReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservation_Status");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK_Reservation_Table");
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.ServerId).HasName("PK__Server__ED5B5C58C632AB4E");

            entity.ToTable("Server");

            entity.Property(e => e.ServerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("server_id");
            entity.Property(e => e.MaxTables)
                .HasDefaultValue(5)
                .HasColumnName("max_tables");
            entity.Property(e => e.StatusWorkerId)
                .HasDefaultValue(1)
                .HasColumnName("statusWorker_id");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.StatusWorker).WithMany(p => p.Servers)
                .HasForeignKey(d => d.StatusWorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Status_Server");

            entity.HasOne(d => d.User).WithOne(u => u.Server)
                .HasForeignKey<Server>(d => d.UserId)
                .HasConstraintName("FK_Server_User");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftsId).HasName("PK__Shifts__0A178FA6C2723C91");

            entity.Property(e => e.ShiftsId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("shifts_id");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("endTime");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.ServerId).HasColumnName("server_id");
            entity.Property(e => e.ShiftType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("shiftType");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("startTime");

            entity.HasOne(d => d.Manager).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_Shifts_Manager");

            entity.HasOne(d => d.Server).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.ServerId)
                .HasConstraintName("FK_Shifts_Server");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.StatusOrderId).HasName("PK__Status_O__AA35989905435809");

            entity.ToTable("Status_Order");

            entity.Property(e => e.StatusOrderId).HasColumnName("statusOrder_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
            entity.Property(e => e.ProductNote)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("productNote");
        });

        modelBuilder.Entity<StatusProduct>(entity =>
        {
            entity.HasKey(e => e.StatusProductId).HasName("PK__Status_P__CB89D3F9CFFA8A65");

            entity.ToTable("Status_Product");

            entity.Property(e => e.StatusProductId).HasColumnName("statusProduct_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
            entity.Property(e => e.ProductNote)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("productNote");
        });

        modelBuilder.Entity<StatusReservation>(entity =>
        {
            entity.HasKey(e => e.StatusReservationId).HasName("PK__Status_R__A4DECAE2FCDEF152");

            entity.ToTable("Status_Reservation");

            entity.Property(e => e.StatusReservationId).HasColumnName("statusReservation_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<StatusTable>(entity =>
        {
            entity.HasKey(e => e.StatusTableId).HasName("PK__Status_T__7BF8BE51287CC3CF");

            entity.ToTable("Status_Table");

            entity.Property(e => e.StatusTableId).HasColumnName("statusTable_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<StatusWorker>(entity =>
        {
            entity.HasKey(e => e.StatusWorkerId).HasName("PK__Status_W__FFAC7B7DD6295859");

            entity.ToTable("Status_Worker");

            entity.Property(e => e.StatusWorkerId).HasColumnName("statusWorker_id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nameStatus");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Table__B21E8F242B645FB2");

            entity.ToTable("Table");

            entity.HasIndex(e => e.TableNumber, "UQ__Table__21B232CE14F5110F").IsUnique();

            entity.Property(e => e.TableId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("table_id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.ServerId).HasColumnName("server_id");
            entity.Property(e => e.StatusTableId)
                .HasDefaultValue(1)
                .HasColumnName("statusTable_id");
            entity.Property(e => e.TableNumber).HasColumnName("table_number");

            entity.HasOne(d => d.Server).WithMany(p => p.Tables)
                .HasForeignKey(d => d.ServerId)
                .HasConstraintName("FK_Table_Server");

            entity.HasOne(d => d.StatusTable).WithMany(p => p.Tables)
                .HasForeignKey(d => d.StatusTableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_Status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83FAB6B53FD");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__AB6E616456746B30").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC5723D4255A0").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.ProfileImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("profile_image");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_password");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
