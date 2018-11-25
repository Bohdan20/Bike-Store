namespace StagesCycling.DAL.Context
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using StagesCycling.DAL.Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using StagesCycling.DAL.Entities.Accessories;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region "CycleDetails"

        public DbSet<Model> Models { get; set; }
        public DbSet<ArtworkBeltGuard> ArtworkBeltGuards { get; set; }
        public DbSet<ArtworkFlywheel> ArtworkFlywheels { get; set; }
        public DbSet<ArtworkFrameFork> ArtworkFrameForks { get; set; }
        public DbSet<ConsoleType> ConsoleTypes { get; set; }
        public DbSet<HandlebarType> HandlebarTypes { get; set; }
        public DbSet<PaintColor> PaintColors { get; set; }
        public DbSet<PedalType> PedalTypes { get; set; }
        public DbSet<PlasticsColorType> PlasticsColorTypes { get; set; }
        public DbSet<PowerMeterType> PowerMeterTypes { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<SprintShiftType> SprintShiftTypes { get; set; }
        #endregion

        #region "Accessories"
        public DbSet<Aerobar> Aerobars { get; set; }
        public DbSet<StagesBikeNumberPlate> StagesBikeNumberPlates { get; set; }
        public DbSet<HandlebarPost> HandlebarPosts { get; set; }
        public DbSet<MediaShelf> MediaShelfs { get; set; }
        public DbSet<PhoneHolder> PhoneHolders { get; set; }
        public DbSet<SeatPost> SeatPosts { get; set; }
        public DbSet<StagesDumbbellHolder> StagesDumbbellHolders { get; set; }
        public DbSet<TabletHolder> TabletHolders { get; set; }

        #endregion
    
        public DbSet<BasePrice> BasePrices { get; set; }
        public DbSet<Cycle> OrderedCycles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderConfiguration> OrderConfigurations { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity <Cycle> ().Property(c => c.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<OrderDetail>().Property(c => c.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<OrderDetail>()
                .Property(f => f.DateTimeAdded)
                .HasColumnType("datetime2");

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.ApplicationUser)
                .HasForeignKey(e => e.ApplicationUserId)
                .WillCascadeOnDelete(true);
        }
    }
}
