using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantRater.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    PriceBracket = table.Column<int>(type: "INTEGER", nullable: false),
                    Style = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodScore = table.Column<int>(type: "INTEGER", nullable: false),
                    DrinksScore = table.Column<int>(type: "INTEGER", nullable: false),
                    DessertScore = table.Column<int>(type: "INTEGER", nullable: false),
                    SettingScore = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueScore = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ChildFriendlyScore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.CheckConstraint("CK_Restaurant_PriceBracket", "PriceBracket BETWEEN 1 AND 5");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
