using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMartketMaker.MVCUser
{
    public partial class oyntch_nONf6RNContext : DbContext
    {
        public oyntch_nONf6RNContext()
        {
        }

        public oyntch_nONf6RNContext(DbContextOptions<oyntch_nONf6RNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mostactive> Mostactives { get; set; } = null!;
        public virtual DbSet<StoreEquipment> StoreEquipments { get; set; } = null!;
        public virtual DbSet<StoreItem> StoreItems { get; set; } = null!;
        public virtual DbSet<StoreLog> StoreLogs { get; set; } = null!;
        public virtual DbSet<StoreMenu> StoreMenus { get; set; } = null!;
        public virtual DbSet<StorePlayer> StorePlayers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=185.26.144.175;uid=oyntch_unzJaPm;pwd=KiD*dV5d;database=oyntch_nONf6RN", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Mostactive>(entity =>
            {
                entity.HasKey(e => e.Steamid)
                    .HasName("PRIMARY");

                entity.ToTable("mostactive");

                entity.Property(e => e.Steamid)
                    .HasMaxLength(32)
                    .HasColumnName("steamid");

                entity.Property(e => e.LastAccountuse)
                    .HasColumnType("int(64)")
                    .HasColumnName("last_accountuse");

                entity.Property(e => e.Playername)
                    .HasMaxLength(128)
                    .HasColumnName("playername");

                entity.Property(e => e.TimeCt)
                    .HasColumnType("int(16)")
                    .HasColumnName("timeCT");

                entity.Property(e => e.TimeSpe)
                    .HasColumnType("int(16)")
                    .HasColumnName("timeSPE");

                entity.Property(e => e.TimeTt)
                    .HasColumnType("int(16)")
                    .HasColumnName("timeTT");

                entity.Property(e => e.TimeWa)
                    .HasColumnType("int(16)")
                    .HasColumnName("timeWA");

                entity.Property(e => e.Total)
                    .HasColumnType("int(16)")
                    .HasColumnName("total");
            });

            modelBuilder.Entity<StoreEquipment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("store_equipment");

                entity.Property(e => e.PlayerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("player_id");

                entity.Property(e => e.Slot)
                    .HasColumnType("int(11)")
                    .HasColumnName("slot");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .HasColumnName("type");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(256)
                    .HasColumnName("unique_id");
            });

            modelBuilder.Entity<StoreItem>(entity =>
            {
                entity.ToTable("store_items");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOfExpiration)
                    .HasColumnType("int(11)")
                    .HasColumnName("date_of_expiration");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("int(11)")
                    .HasColumnName("date_of_purchase");

                entity.Property(e => e.PlayerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("player_id");

                entity.Property(e => e.PriceOfPurchase)
                    .HasColumnType("int(11)")
                    .HasColumnName("price_of_purchase");

                entity.Property(e => e.Type)
                    .HasMaxLength(16)
                    .HasColumnName("type");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(256)
                    .HasColumnName("unique_id");
            });

            modelBuilder.Entity<StoreLog>(entity =>
            {
                entity.ToTable("store_logs");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Credits)
                    .HasColumnType("int(11)")
                    .HasColumnName("credits");

                entity.Property(e => e.Date)
                    .HasColumnType("int(11)")
                    .HasColumnName("date");

                entity.Property(e => e.PlayerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("player_id");

                entity.Property(e => e.Reason)
                    .HasMaxLength(256)
                    .HasColumnName("reason");
            });

            modelBuilder.Entity<StoreMenu>(entity =>
            {
                entity.ToTable("store_menu");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AdditionalInfo)
                    .HasColumnType("text")
                    .HasColumnName("additional_info");

                entity.Property(e => e.ItemFlag)
                    .HasMaxLength(64)
                    .HasColumnName("item_flag");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(64)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("int(32)")
                    .HasColumnName("item_price");

                entity.Property(e => e.ItemStatus).HasColumnName("item_status");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(64)
                    .HasColumnName("item_type");

                entity.Property(e => e.ParentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.SupportedGame)
                    .HasMaxLength(64)
                    .HasColumnName("supported_game");
            });

            modelBuilder.Entity<StorePlayer>(entity =>
            {
                entity.ToTable("store_players");

                entity.HasIndex(e => e.Authid, "authid")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Authid)
                    .HasMaxLength(32)
                    .HasColumnName("authid");

                entity.Property(e => e.Credits)
                    .HasColumnType("int(11)")
                    .HasColumnName("credits");

                entity.Property(e => e.DateOfJoin)
                    .HasColumnType("int(11)")
                    .HasColumnName("date_of_join");

                entity.Property(e => e.DateOfLastJoin)
                    .HasColumnType("int(11)")
                    .HasColumnName("date_of_last_join");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
