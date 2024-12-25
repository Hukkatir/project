using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryContent",
                columns: table => new
                {
                    CategoryContentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryContent", x => x.CategoryContentID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFile",
                columns: table => new
                {
                    CategoryFileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryFileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFile", x => x.CategoryFileID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "GroupMedia",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupDescrip = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMedia", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    MediaTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.MediaTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CVV = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "StatusMessage",
                columns: table => new
                {
                    StatusMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusMessageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMessage", x => x.StatusMessageID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK__Users__RoleID__3C69FB99",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK__Comments__UserID__693CA210",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryFileID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileID);
                    table.ForeignKey(
                        name: "FK__Files__CreatedBy__4AB81AF0",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Files__DeletedBy__4CA06362",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Files__UpdatedBy__4BAC3F29",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "Relationship12",
                        column: x => x.CategoryFileID,
                        principalTable: "CategoryFile",
                        principalColumn: "CategoryFileID");
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Plot = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Runtime = table.Column<int>(type: "int", nullable: false),
                    IMDbRating = table.Column<decimal>(type: "decimal(2,1)", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Episode = table.Column<int>(type: "int", nullable: true),
                    MediaTypeID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Media__B2C2B5AFF301C78A", x => x.MediaID);
                    table.ForeignKey(
                        name: "FK__Media__ContentTy__4316F928",
                        column: x => x.MediaTypeID,
                        principalTable: "MediaTypes",
                        principalColumn: "MediaTypeID");
                    table.ForeignKey(
                        name: "FK__Media__CreatedBy__440B1D61",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Media__DeletedBy__45F365D3",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Media__UpdatedBy__44FF419A",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "PaymentUsers",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentUsers", x => new { x.PaymentID, x.UserID });
                    table.ForeignKey(
                        name: "Relationship14",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "PaymentID");
                    table.ForeignKey(
                        name: "Relationship15",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "CommentRates",
                columns: table => new
                {
                    CommentRateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRates", x => x.CommentRateID);
                    table.ForeignKey(
                        name: "FK__CommentRa__UserI__6C190EBB",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_CommentRates_Comments",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentMedia",
                columns: table => new
                {
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    CommentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CommentM__0EF9F855E39D6785", x => new { x.MediaID, x.CommentID });
                    table.ForeignKey(
                        name: "FK__CommentMe__Comme__70DDC3D8",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID");
                    table.ForeignKey(
                        name: "FK__CommentMe__Media__6FE99F9F",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ContentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    CategoryContentID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ContentText = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ContentID);
                    table.ForeignKey(
                        name: "FK__Content__Categor__778AC167",
                        column: x => x.CategoryContentID,
                        principalTable: "CategoryContent",
                        principalColumn: "CategoryContentID");
                    table.ForeignKey(
                        name: "FK__Content__Created__787EE5A0",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Content__Deleted__7A672E12",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Content__Updated__797309D9",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "Relationship13",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                });

            migrationBuilder.CreateTable(
                name: "MediaFile",
                columns: table => new
                {
                    MediaFileID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    FileID = table.Column<int>(type: "int", nullable: false),
                    MediaFileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MoviesFi__54324C2672BE071C", x => new { x.MediaID, x.MediaFileID, x.FileID });
                    table.ForeignKey(
                        name: "FK__MoviesFil__FileI__5070F446",
                        column: x => x.FileID,
                        principalTable: "File",
                        principalColumn: "FileID");
                    table.ForeignKey(
                        name: "FK__MoviesFil__Media__4F7CD00D",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                });

            migrationBuilder.CreateTable(
                name: "MediaGenres",
                columns: table => new
                {
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MediaGen__42FAE5FA05E52893", x => new { x.MediaID, x.GenreID });
                    table.ForeignKey(
                        name: "FK__MediaGenr__Genre__5629CD9C",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID");
                    table.ForeignKey(
                        name: "FK__MediaGenr__Media__5535A963",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                });

            migrationBuilder.CreateTable(
                name: "MyRatings",
                columns: table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MyRating__FCCDF85CB1473DD3", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK__MyRatings__Media__6383C8BA",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                    table.ForeignKey(
                        name: "FK__MyRatings__UserI__628FA481",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "RelatedMedia",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedMedia", x => new { x.GroupID, x.MediaID });
                    table.ForeignKey(
                        name: "Relationship1",
                        column: x => x.GroupID,
                        principalTable: "GroupMedia",
                        principalColumn: "GroupID");
                    table.ForeignKey(
                        name: "Relationship2",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MediaID = table.Column<int>(type: "int", nullable: false),
                    CreatorID = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDateTime = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomID);
                    table.ForeignKey(
                        name: "Relationship4",
                        column: x => x.CreatorID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "Relationship5",
                        column: x => x.MediaID,
                        principalTable: "Media",
                        principalColumn: "MediaID");
                    table.ForeignKey(
                        name: "Relationship9",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Messages_users",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    StatusMessageID = table.Column<int>(type: "int", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Messages__C87C037CCA0314D6", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK__Messages___Delet__0C85DE4D",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK__Messages___Statu__0D7A0286",
                        column: x => x.StatusMessageID,
                        principalTable: "StatusMessage",
                        principalColumn: "StatusMessageID");
                    table.ForeignKey(
                        name: "Relationship10",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "Relationship11",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "RoomsUsers",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    JoinedDateTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsUsers", x => new { x.UserID, x.RoomID });
                    table.ForeignKey(
                        name: "Relationship6",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "Relationship7",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentMedia_CommentID",
                table: "CommentMedia",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRates_CommentID",
                table: "CommentRates",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRates_UserID",
                table: "CommentRates",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CategoryContentID",
                table: "Content",
                column: "CategoryContentID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_CreatedBy",
                table: "Content",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Content_DeletedBy",
                table: "Content",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Content_UpdatedBy",
                table: "Content",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship13",
                table: "Content",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_File_CategoryFileID",
                table: "File",
                column: "CategoryFileID");

            migrationBuilder.CreateIndex(
                name: "IX_File_CreatedBy",
                table: "File",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_File_DeletedBy",
                table: "File",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_File_UpdatedBy",
                table: "File",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Media_CreatedBy",
                table: "Media",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Media_DeletedBy",
                table: "Media",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaTypeID",
                table: "Media",
                column: "MediaTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Media_UpdatedBy",
                table: "Media",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFile_FileID",
                table: "MediaFile",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_MediaGenres_GenreID",
                table: "MediaGenres",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_users_DeletedBy",
                table: "Messages_users",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_users_RoomID",
                table: "Messages_users",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_users_StatusMessageID",
                table: "Messages_users",
                column: "StatusMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_users_UserID",
                table: "Messages_users",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MyRatings_MediaID",
                table: "MyRatings",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_MyRatings_UserID",
                table: "MyRatings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentUsers_UserID",
                table: "PaymentUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedMedia_MediaID",
                table: "RelatedMedia",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatorID",
                table: "Rooms",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_DeletedBy",
                table: "Rooms",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_MediaID",
                table: "Rooms",
                column: "MediaID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsUsers_RoomID",
                table: "RoomsUsers",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__536C85E47D398155",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105340127C76C",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentMedia");

            migrationBuilder.DropTable(
                name: "CommentRates");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "MediaFile");

            migrationBuilder.DropTable(
                name: "MediaGenres");

            migrationBuilder.DropTable(
                name: "Messages_users");

            migrationBuilder.DropTable(
                name: "MyRatings");

            migrationBuilder.DropTable(
                name: "PaymentUsers");

            migrationBuilder.DropTable(
                name: "RelatedMedia");

            migrationBuilder.DropTable(
                name: "RoomsUsers");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CategoryContent");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "StatusMessage");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "GroupMedia");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "CategoryFile");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
