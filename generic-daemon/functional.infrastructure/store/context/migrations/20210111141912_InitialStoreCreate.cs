using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace functional.infrastructure.store.context.migrations
{
    public partial class InitialStoreCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    EntityId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStore", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventStore_EntityId",
                table: "EventStore",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStore_MessageType",
                table: "EventStore",
                column: "MessageType");

            migrationBuilder.CreateIndex(
                name: "IX_EventStore_Timestamp",
                table: "EventStore",
                column: "Timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventStore");
        }
    }
}
