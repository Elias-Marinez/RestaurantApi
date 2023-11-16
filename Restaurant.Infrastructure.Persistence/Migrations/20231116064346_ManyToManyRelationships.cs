using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.CreateTable(
                name: "DishesIngredients",
                columns: table => new
                {
                    DishesDishId = table.Column<int>(type: "int", nullable: false),
                    IngredientsIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesIngredients", x => new { x.DishesDishId, x.IngredientsIngredientId });
                    table.ForeignKey(
                        name: "FK_DishesIngredients_Dishes_DishesDishId",
                        column: x => x.DishesDishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishesIngredients_Ingredients_IngredientsIngredientId",
                        column: x => x.IngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishesIngredients_IngredientsIngredientId",
                table: "DishesIngredients",
                column: "IngredientsIngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishesIngredients");

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishesDishId = table.Column<int>(type: "int", nullable: false),
                    IngredientsIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishesDishId, x.IngredientsIngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishesDishId",
                        column: x => x.DishesDishId,
                        principalTable: "Dishes",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientsIngredientId",
                        column: x => x.IngredientsIngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientsIngredientId",
                table: "DishIngredients",
                column: "IngredientsIngredientId");
        }
    }
}
