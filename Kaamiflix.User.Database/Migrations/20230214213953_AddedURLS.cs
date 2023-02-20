using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kaamiflix.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedURLS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "FilmGenres",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "SimilarFilms",
                keyColumns: new[] { "FilmId", "SimilarFilmId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Films",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MarqueeImageUrl",
                table: "Films",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "MarqueeImageUrl",
                table: "Films");

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Frank Gold" },
                    { 2, "Stephan Manberg" },
                    { 3, "Charlie Night" },
                    { 4, "Jane Fresh" },
                    { 5, "Hera Gomu" },
                    { 6, "Nadia Naka" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Sci-Fi" },
                    { 3, "Thriller" },
                    { 4, "Horror" },
                    { 5, "Comedy" },
                    { 6, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DirectorId", "FilmUrl", "Free", "Released", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem", 1, "YOUTUBE", true, new DateTime(2010, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spiderman" },
                    { 2, "Ipsum", 2, "YOUTUBE", true, new DateTime(2012, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batman" },
                    { 3, "Campins", 3, "YOUTUBE", true, new DateTime(2005, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hulk" },
                    { 4, "Changer", 4, "YOUTUBE", false, new DateTime(1990, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shining" },
                    { 5, "Krens", 5, "YOUTUBE", false, new DateTime(1970, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Godzilla" },
                    { 6, "Hegerd", 6, "YOUTUBE", false, new DateTime(2018, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ring" }
                });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 4 },
                    { 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "SimilarFilms",
                columns: new[] { "FilmId", "SimilarFilmId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 6 },
                    { 5, 3 },
                    { 6, 4 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Films_FilmId",
                table: "FilmGenres",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmGenres_Genres_GenreId",
                table: "FilmGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
