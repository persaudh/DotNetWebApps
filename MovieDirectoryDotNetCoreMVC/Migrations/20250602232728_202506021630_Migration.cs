using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDirectoryDotNetCoreMVC.Migrations
{
    /// <inheritdoc />
    public partial class _202506021630_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePoster_Movies_Id",
                table: "MoviePoster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviePoster",
                table: "MoviePoster");

            migrationBuilder.RenameTable(
                name: "MoviePoster",
                newName: "MoviePosters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviePosters",
                table: "MoviePosters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePosters_Movies_Id",
                table: "MoviePosters",
                column: "Id",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePosters_Movies_Id",
                table: "MoviePosters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviePosters",
                table: "MoviePosters");

            migrationBuilder.RenameTable(
                name: "MoviePosters",
                newName: "MoviePoster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviePoster",
                table: "MoviePoster",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePoster_Movies_Id",
                table: "MoviePoster",
                column: "Id",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
