using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutPlanExercises");

            migrationBuilder.CreateTable(
                name: "ExerciseInstructions",
                columns: table => new
                {
                    ExerciseInstructionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkoutSectionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkoutId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ExerciseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseInstructions", x => new { x.WorkoutSectionId, x.WorkoutId, x.ExerciseInstructionId });
                    table.ForeignKey(
                        name: "FK_ExerciseInstructions_WorkoutPlanSections_WorkoutSectionId_Wo~",
                        columns: x => new { x.WorkoutSectionId, x.WorkoutId },
                        principalTable: "WorkoutPlanSections",
                        principalColumns: new[] { "WorkoutSectionId", "WorkoutPlanId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseInstructions");

            migrationBuilder.CreateTable(
                name: "WorkoutPlanExercises",
                columns: table => new
                {
                    WorkoutSectionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkoutId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkoutPlanExerciseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExerciseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Reps = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPlanExercises", x => new { x.WorkoutSectionId, x.WorkoutId, x.WorkoutPlanExerciseId });
                    table.ForeignKey(
                        name: "FK_WorkoutPlanExercises_WorkoutPlanSections_WorkoutSectionId_Wo~",
                        columns: x => new { x.WorkoutSectionId, x.WorkoutId },
                        principalTable: "WorkoutPlanSections",
                        principalColumns: new[] { "WorkoutSectionId", "WorkoutPlanId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
