using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TaskManagerPostgresDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "developerid");

            migrationBuilder.CreateSequence(
                name: "employerid");

            migrationBuilder.CreateSequence(
                name: "programlanguageid");

            migrationBuilder.CreateSequence(
                name: "stageid");

            migrationBuilder.CreateSequence(
                name: "taskid");

            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullnameofdeveloper = table.Column<string>(maxLength: 255, nullable: false),
                    developerposition = table.Column<string>(maxLength: 255, nullable: false),
                    workexperience = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullnameofemployer = table.Column<string>(maxLength: 255, nullable: false),
                    employerlogin = table.Column<string>(nullable: false),
                    employerpassword = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "programlanguages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    languagename = table.Column<string>(maxLength: 255, nullable: false),
                    languagedescription = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programlanguages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    taskname = table.Column<string>(maxLength: 255, nullable: false),
                    taskstartdate = table.Column<DateTime>(type: "date", nullable: false),
                    taskfinishdate = table.Column<DateTime>(type: "date", nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    employerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                    table.ForeignKey(
                        name: "employerid_fkey",
                        column: x => x.employerid,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "developer_programlanguage",
                columns: table => new
                {
                    developerid = table.Column<int>(nullable: false),
                    programlanguageid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("developer_programlanguage_pkey", x => new { x.developerid, x.programlanguageid });
                    table.ForeignKey(
                        name: "developerid_fkey",
                        column: x => x.developerid,
                        principalTable: "developers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "programlanguageid_fkey",
                        column: x => x.programlanguageid,
                        principalTable: "programlanguages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stagedescription = table.Column<string>(maxLength: 255, nullable: false),
                    stagestartdate = table.Column<DateTime>(type: "date", nullable: false),
                    stagefinishdate = table.Column<DateTime>(type: "date", nullable: true),
                    iscomplited = table.Column<bool>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stages", x => x.id);
                    table.ForeignKey(
                        name: "taskid_fkey",
                        column: x => x.TaskId,
                        principalTable: "tasks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stage_developer",
                columns: table => new
                {
                    stageid = table.Column<int>(nullable: false),
                    developerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stage_developer_pkey", x => new { x.stageid, x.developerid });
                    table.ForeignKey(
                        name: "developerid_fkey",
                        column: x => x.developerid,
                        principalTable: "developers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "stageid_fkey",
                        column: x => x.stageid,
                        principalTable: "stages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_developer_programlanguage_programlanguageid",
                table: "developer_programlanguage",
                column: "programlanguageid");

            migrationBuilder.CreateIndex(
                name: "IX_stage_developer_developerid",
                table: "stage_developer",
                column: "developerid");

            migrationBuilder.CreateIndex(
                name: "IX_stages_TaskId",
                table: "stages",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_employerid",
                table: "tasks",
                column: "employerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "developer_programlanguage");

            migrationBuilder.DropTable(
                name: "stage_developer");

            migrationBuilder.DropTable(
                name: "programlanguages");

            migrationBuilder.DropTable(
                name: "developers");

            migrationBuilder.DropTable(
                name: "stages");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "employers");

            migrationBuilder.DropSequence(
                name: "developerid");

            migrationBuilder.DropSequence(
                name: "employerid");

            migrationBuilder.DropSequence(
                name: "programlanguageid");

            migrationBuilder.DropSequence(
                name: "stageid");

            migrationBuilder.DropSequence(
                name: "taskid");
        }
    }
}
