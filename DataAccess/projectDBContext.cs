using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class projectDBContext : DbContext
    {
        public projectDBContext()
        {
        }

        public projectDBContext(DbContextOptions<projectDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryContent> CategoryContents { get; set; } = null!;
        public virtual DbSet<CategoryFile> CategoryFiles { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentRate> CommentRates { get; set; } = null!;
        public virtual DbSet<Content> Contents { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<GroupMedium> GroupMedia { get; set; } = null!;
        public virtual DbSet<MediaFile> MediaFiles { get; set; } = null!;
        public virtual DbSet<MediaType> MediaTypes { get; set; } = null!;
        public virtual DbSet<Medium> Media { get; set; } = null!;
        public virtual DbSet<MessagesUser> MessagesUsers { get; set; } = null!;
        public virtual DbSet<MyRating> MyRatings { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentUser> PaymentUsers { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomsUser> RoomsUsers { get; set; } = null!;
        public virtual DbSet<StatusMessage> StatusMessages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = DESKTOP-CJMJ3I2; Database = projectDBWork; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryContent>(entity =>
            {
                entity.ToTable("CategoryContent");

                entity.Property(e => e.CategoryContentId).HasColumnName("CategoryContentID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<CategoryFile>(entity =>
            {
                entity.ToTable("CategoryFile");

                entity.Property(e => e.CategoryFileId).HasColumnName("CategoryFileID");

                entity.Property(e => e.CategoryFileName).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Comments_UserID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentText).HasMaxLength(1000);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__UserID__693CA210");
            });

            modelBuilder.Entity<CommentRate>(entity =>
            {
                entity.HasIndex(e => e.CommentId, "IX_CommentRates_CommentID");

                entity.HasIndex(e => e.UserId, "IX_CommentRates_UserID");

                entity.Property(e => e.CommentRateId).HasColumnName("CommentRateID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentRates)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_CommentRates_Comments");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentRates)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CommentRa__UserI__6C190EBB");
            });

            modelBuilder.Entity<Content>(entity =>
            {
                entity.ToTable("Content");

                entity.HasIndex(e => e.CategoryContentId, "IX_Content_CategoryContentID");

                entity.HasIndex(e => e.CreatedBy, "IX_Content_CreatedBy");

                entity.HasIndex(e => e.DeletedBy, "IX_Content_DeletedBy");

                entity.HasIndex(e => e.UpdatedBy, "IX_Content_UpdatedBy");

                entity.HasIndex(e => e.MediaId, "IX_Relationship13");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.CategoryContentId).HasColumnName("CategoryContentID");

                entity.Property(e => e.ContentText).IsUnicode(false);

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryContent)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.CategoryContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Content__Categor__778AC167");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ContentCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Content__Created__787EE5A0");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ContentDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Content__Deleted__7A672E12");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.Contents)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship13");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.ContentUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Content__Updated__797309D9");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("File");

                entity.HasIndex(e => e.CategoryFileId, "IX_File_CategoryFileID");

                entity.HasIndex(e => e.CreatedBy, "IX_File_CreatedBy");

                entity.HasIndex(e => e.DeletedBy, "IX_File_DeletedBy");

                entity.HasIndex(e => e.UpdatedBy, "IX_File_UpdatedBy");

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.CategoryFileId).HasColumnName("CategoryFileID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FileUrl)
                    .HasMaxLength(500)
                    .HasColumnName("FileURL");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryFile)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CategoryFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship12");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.FileCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Files__CreatedBy__4AB81AF0");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.FileDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Files__DeletedBy__4CA06362");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.FileUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Files__UpdatedBy__4BAC3F29");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.GenreName).HasMaxLength(255);
            });

            modelBuilder.Entity<GroupMedium>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupDescrip).HasMaxLength(1000);

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.HasMany(d => d.Media)
                    .WithMany(p => p.Groups)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelatedMedium",
                        l => l.HasOne<Medium>().WithMany().HasForeignKey("MediaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship2"),
                        r => r.HasOne<GroupMedium>().WithMany().HasForeignKey("GroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship1"),
                        j =>
                        {
                            j.HasKey("GroupId", "MediaId");

                            j.ToTable("RelatedMedia");

                            j.HasIndex(new[] { "MediaId" }, "IX_RelatedMedia_MediaID");

                            j.IndexerProperty<int>("GroupId").HasColumnName("GroupID");

                            j.IndexerProperty<int>("MediaId").HasColumnName("MediaID");
                        });
            });

            modelBuilder.Entity<MediaFile>(entity =>
            {
                entity.HasKey(e => new { e.MediaId, e.MediaFileId, e.FileId })
                    .HasName("PK__MoviesFi__54324C2672BE071C");

                entity.ToTable("MediaFile");

                entity.HasIndex(e => e.FileId, "IX_MediaFile_FileID");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.MediaFileId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MediaFileID");

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.MediaFileName).HasMaxLength(100);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.MediaFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MoviesFil__FileI__5070F446");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.MediaFiles)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MoviesFil__Media__4F7CD00D");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.Property(e => e.MediaTypeId).HasColumnName("MediaTypeID");

                entity.Property(e => e.MediaTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.MediaId)
                    .HasName("PK__Media__B2C2B5AFF301C78A");

                entity.HasIndex(e => e.CreatedBy, "IX_Media_CreatedBy");

                entity.HasIndex(e => e.DeletedBy, "IX_Media_DeletedBy");

                entity.HasIndex(e => e.MediaTypeId, "IX_Media_MediaTypeID");

                entity.HasIndex(e => e.UpdatedBy, "IX_Media_UpdatedBy");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.ImdbRating)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("IMDbRating");

                entity.Property(e => e.MediaTypeId).HasColumnName("MediaTypeID");

                entity.Property(e => e.Plot).HasMaxLength(1500);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MediumCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Media__CreatedBy__440B1D61");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.MediumDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Media__DeletedBy__45F365D3");

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Media)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Media__ContentTy__4316F928");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.MediumUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Media__UpdatedBy__44FF419A");

                entity.HasMany(d => d.Comments)
                    .WithMany(p => p.Media)
                    .UsingEntity<Dictionary<string, object>>(
                        "CommentMedium",
                        l => l.HasOne<Comment>().WithMany().HasForeignKey("CommentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CommentMe__Comme__70DDC3D8"),
                        r => r.HasOne<Medium>().WithMany().HasForeignKey("MediaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__CommentMe__Media__6FE99F9F"),
                        j =>
                        {
                            j.HasKey("MediaId", "CommentId").HasName("PK__CommentM__0EF9F855E39D6785");

                            j.ToTable("CommentMedia");

                            j.HasIndex(new[] { "CommentId" }, "IX_CommentMedia_CommentID");

                            j.IndexerProperty<int>("MediaId").HasColumnName("MediaID");

                            j.IndexerProperty<int>("CommentId").HasColumnName("CommentID");
                        });

                entity.HasMany(d => d.Genres)
                    .WithMany(p => p.Media)
                    .UsingEntity<Dictionary<string, object>>(
                        "MediaGenre",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MediaGenr__Genre__5629CD9C"),
                        r => r.HasOne<Medium>().WithMany().HasForeignKey("MediaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__MediaGenr__Media__5535A963"),
                        j =>
                        {
                            j.HasKey("MediaId", "GenreId").HasName("PK__MediaGen__42FAE5FA05E52893");

                            j.ToTable("MediaGenres");

                            j.HasIndex(new[] { "GenreId" }, "IX_MediaGenres_GenreID");

                            j.IndexerProperty<int>("MediaId").HasColumnName("MediaID");

                            j.IndexerProperty<int>("GenreId").HasColumnName("GenreID");
                        });
            });

            modelBuilder.Entity<MessagesUser>(entity =>
            {
                entity.HasKey(e => e.MessageId)
                    .HasName("PK__Messages__C87C037CCA0314D6");

                entity.ToTable("Messages_users");

                entity.HasIndex(e => e.DeletedBy, "IX_Messages_users_DeletedBy");

                entity.HasIndex(e => e.RoomId, "IX_Messages_users_RoomID");

                entity.HasIndex(e => e.StatusMessageId, "IX_Messages_users_StatusMessageID");

                entity.HasIndex(e => e.UserId, "IX_Messages_users_UserID");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.MessageText).HasMaxLength(500);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SendingDate).HasColumnType("datetime");

                entity.Property(e => e.StatusMessageId).HasColumnName("StatusMessageID");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.MessagesUserDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Messages___Delet__0C85DE4D");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.MessagesUsers)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship11");

                entity.HasOne(d => d.StatusMessage)
                    .WithMany(p => p.MessagesUsers)
                    .HasForeignKey(d => d.StatusMessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Messages___Statu__0D7A0286");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MessagesUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship10");
            });

            modelBuilder.Entity<MyRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__MyRating__FCCDF85CB1473DD3");

                entity.HasIndex(e => e.MediaId, "IX_MyRatings_MediaID");

                entity.HasIndex(e => e.UserId, "IX_MyRatings_UserID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.MyRatings)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MyRatings__Media__6383C8BA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MyRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MyRatings__UserI__628FA481");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CVV")
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<PaymentUser>(entity =>
            {
                entity.HasKey(e => new { e.PaymentId, e.UserId });

                entity.HasIndex(e => e.UserId, "IX_PaymentUsers_UserID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PaymentUsers)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship14");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship15");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(255);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(e => e.CreatorId, "IX_Rooms_CreatorID");

                entity.HasIndex(e => e.DeletedBy, "IX_Rooms_DeletedBy");

                entity.HasIndex(e => e.MediaId, "IX_Rooms_MediaID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.DeletedDateTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MediaId).HasColumnName("MediaID");

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.RoomCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship4");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.RoomDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("Relationship9");

                entity.HasOne(d => d.Media)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.MediaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship5");
            });

            modelBuilder.Entity<RoomsUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoomId });

                entity.HasIndex(e => e.RoomId, "IX_RoomsUsers_RoomID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.JoinedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomsUsers)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoomsUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship6");
            });

            modelBuilder.Entity<StatusMessage>(entity =>
            {
                entity.ToTable("StatusMessage");

                entity.Property(e => e.StatusMessageId).HasColumnName("StatusMessageID");

                entity.Property(e => e.StatusMessageName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_Users_RoleID");

                entity.HasIndex(e => e.Username, "UQ__Users__536C85E47D398155")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Users__A9D105340127C76C")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserPassword).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__RoleID__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
