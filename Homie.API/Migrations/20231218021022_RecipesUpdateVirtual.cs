using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homie.API.Migrations
{
    /// <inheritdoc />
    public partial class RecipesUpdateVirtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipesId",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_RecipesId",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipesId",
                table: "RecipeIngredient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipesId1",
                table: "RecipeIngredient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipesId1",
                table: "RecipeIngredient",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipesId1",
                table: "RecipeIngredient",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipesId1",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_RecipesId1",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "RecipesId1",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipesId",
                table: "RecipeIngredient",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipesId",
                table: "RecipeIngredient",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipesId",
                table: "RecipeIngredient",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
