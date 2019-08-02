using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace studentapp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcourses",
                columns: table => new
                {
                    CrseCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CrseTitle = table.Column<string>(nullable: false),
                    CrsCredits = table.Column<int>(nullable: false),
                    CrsDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcourses", x => x.CrseCode);
                });

            migrationBuilder.CreateTable(
                name: "tbllecturers",
                columns: table => new
                {
                    LecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LecFname = table.Column<string>(nullable: false),
                    LecLname = table.Column<string>(nullable: false),
                    Lecemail = table.Column<string>(nullable: false),
                    Lecgender = table.Column<string>(nullable: false),
                    lecphone = table.Column<int>(nullable: false),
                    Lectitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbllecturers", x => x.LecID);
                });

            migrationBuilder.CreateTable(
                name: "tblstudents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fname = table.Column<string>(nullable: false),
                    Lname = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    phone = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblstudents", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblcourses");

            migrationBuilder.DropTable(
                name: "tbllecturers");

            migrationBuilder.DropTable(
                name: "tblstudents");
        }
    }
}
