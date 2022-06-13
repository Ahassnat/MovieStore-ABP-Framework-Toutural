using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStore.Migrations
{
    public partial class EditMoveActorCPKActorIdandMovieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor");

            migrationBuilder.DropIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieActor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieActor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor",
                columns: new[] { "MovieId", "ActorId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "MovieActor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieActor",
                table: "MovieActor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieActor",
                column: "MovieId");
        }
    }
}
