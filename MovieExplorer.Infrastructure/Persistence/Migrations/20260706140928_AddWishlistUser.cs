using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieExplorer.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWishlistUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "WishlistItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WishlistItems");
        }
    }
}
