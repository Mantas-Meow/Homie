using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homie.API.Migrations
{
    /// <inheritdoc />
    public partial class Recipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrepTime = table.Column<float>(type: "real", nullable: true),
                    CookTime = table.Column<float>(type: "real", nullable: true),
                    Portions = table.Column<float>(type: "real", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: true),
                    Dish = table.Column<int>(type: "int", nullable: true),
                    RecipeTypes = table.Column<int>(type: "int", nullable: true),
                    TotalCalories = table.Column<float>(type: "real", nullable: true),
                    TotalCarbs = table.Column<float>(type: "real", nullable: true),
                    TotalFat = table.Column<float>(type: "real", nullable: true),
                    TotalProtein = table.Column<float>(type: "real", nullable: true),
                    Directions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    RecipesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipesId",
                table: "RecipeIngredient",
                column: "RecipesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
