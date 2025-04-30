using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseModel.Infra.Data.Migrations.Auth
{
    /// <inheritdoc />
    public partial class AddProfessionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConnectionString", "Name", "TenantUrl" },
                values: new object[] { "Host=localhost;Database=new_erp_client_a_dotnet;Username=postgres;Password=postgres", "ClientA", "client-a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.UpdateData(
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "ConnectionString", "Name", "TenantUrl" },
                values: new object[] { "Host=localhost;Database=yann_dotnet;Username=postgres;Password=postgres", "TenantA", "http://tenant-a.com" });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "ConnectionString", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "Name", "TenantUrl", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Host=localhost;Database=tenant_b;Username=postgres;Password=postgres", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, true, "TenantB", "http://tenant-b.com", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Host=localhost;Database=tenant_c;Username=postgres;Password=postgres", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null, null, true, "TenantC", "http://tenant-c.com", null, null }
                });
        }
    }
}
