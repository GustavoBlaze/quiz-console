using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz_console.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    userId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.id);
                    table.ForeignKey(
                        name: "FK_quizzes_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "asks",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quizId = table.Column<long>(type: "INTEGER", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asks", x => x.id);
                    table.ForeignKey(
                        name: "FK_asks_quizzes_quizId",
                        column: x => x.quizId,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoryQuizzes",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    categoryId = table.Column<long>(type: "INTEGER", nullable: false),
                    quizId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryQuizzes", x => x.id);
                    table.ForeignKey(
                        name: "FK_categoryQuizzes_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryQuizzes_quizzes_quizId",
                        column: x => x.quizId,
                        principalTable: "quizzes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizResponse",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guestId = table.Column<string>(type: "TEXT", nullable: true),
                    Quizid = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResponse", x => x.id);
                    table.ForeignKey(
                        name: "FK_QuizResponse_quizzes_Quizid",
                        column: x => x.Quizid,
                        principalTable: "quizzes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_QuizResponse_users_guestId",
                        column: x => x.guestId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "alternatives",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    askId = table.Column<long>(type: "INTEGER", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    isCorrect = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternatives", x => x.id);
                    table.ForeignKey(
                        name: "FK_alternatives_asks_askId",
                        column: x => x.askId,
                        principalTable: "asks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quizResponseId = table.Column<long>(type: "INTEGER", nullable: false),
                    askId = table.Column<long>(type: "INTEGER", nullable: false),
                    alternativeId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.id);
                    table.ForeignKey(
                        name: "FK_Answer_alternatives_alternativeId",
                        column: x => x.alternativeId,
                        principalTable: "alternatives",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_asks_askId",
                        column: x => x.askId,
                        principalTable: "asks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_QuizResponse_quizResponseId",
                        column: x => x.quizResponseId,
                        principalTable: "QuizResponse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alternatives_askId",
                table: "alternatives",
                column: "askId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_alternativeId",
                table: "Answer",
                column: "alternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_askId",
                table: "Answer",
                column: "askId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_quizResponseId",
                table: "Answer",
                column: "quizResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_asks_quizId",
                table: "asks",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryQuizzes_categoryId",
                table: "categoryQuizzes",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryQuizzes_quizId",
                table: "categoryQuizzes",
                column: "quizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_guestId",
                table: "QuizResponse",
                column: "guestId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_Quizid",
                table: "QuizResponse",
                column: "Quizid");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_userId",
                table: "quizzes",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "categoryQuizzes");

            migrationBuilder.DropTable(
                name: "alternatives");

            migrationBuilder.DropTable(
                name: "QuizResponse");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "asks");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
