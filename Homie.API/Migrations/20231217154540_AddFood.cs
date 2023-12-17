using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homie.API.Migrations
{
    /// <inheritdoc />
    public partial class AddFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<float>(type: "float", nullable: false),
                    Carbs = table.Column<float>(type: "float", nullable: false),
                    Fat = table.Column<float>(type: "float", nullable: false),
                    Protein = table.Column<float>(type: "float", nullable: false),
                    ServingAmount = table.Column<float>(type: "float", nullable: false),
                    ServingDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GramsPerServing = table.Column<float>(type: "float", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Food");
        }
    }
}
