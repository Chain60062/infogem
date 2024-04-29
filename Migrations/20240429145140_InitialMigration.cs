using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InfoGemApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    IsVendor = table.Column<bool>(type: "boolean", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    DealId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountPercentage = table.Column<short>(type: "smallint", nullable: false),
                    MinimumOrderValue = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountStartsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscountEndsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.DealId);
                });

            migrationBuilder.CreateTable(
                name: "Promos",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    DiscountPercentage = table.Column<short>(type: "smallint", nullable: false),
                    MinimumOrderValue = table.Column<decimal>(type: "numeric", nullable: true),
                    IsCouponValid = table.Column<bool>(type: "boolean", nullable: false),
                    DiscountStartsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscountEndsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    StateCode = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Neighborhood = table.Column<string>(type: "text", nullable: false),
                    HouseNumber = table.Column<string>(type: "text", nullable: false),
                    Complement = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    AvailableUnits = table.Column<int>(type: "integer", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DealId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Deal_DealId",
                        column: x => x.DealId,
                        principalTable: "Deal",
                        principalColumn: "DealId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PromoId = table.Column<long>(type: "bigint", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Shipping = table.Column<decimal>(type: "numeric", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "numeric", nullable: true),
                    PromoCode = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    ShippingMethod = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CartId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_Orders_Promos_PromoCode",
                        column: x => x.PromoCode,
                        principalTable: "Promos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartsCartId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartsCartId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartsCartId",
                        column: x => x.CartsCartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductsProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    AltText = table.Column<string>(type: "text", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.CartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductsProductId = table.Column<long>(type: "bigint", nullable: false),
                    TagsTagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.ProductsProductId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_ProductTag_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AvailableUnits", "DealId", "Description", "Price", "ProductName", "Sku", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "67aab1f4-47d3-4944-a728-58755073c92e", "mock1", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5132) },
                    { 2L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b58e3a76-4b11-4304-b82b-a0e5a74d6655", "mock2", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5210) },
                    { 3L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e9f4f8a1-b08b-490b-8658-3312a7822bda", "mock3", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5223) },
                    { 4L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f0aac7a0-e762-40d4-86a0-38a12361939f", "mock4", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5233) },
                    { 5L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b9b5e82d-1d63-466f-99e8-4ee7a90e8d38", "mock5", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5246) },
                    { 6L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "38cde96a-6031-4b44-9746-11a594555322", "mock6", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5306) },
                    { 7L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "32767ce4-36aa-49db-bfd1-da0027d11d53", "mock7", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5317) },
                    { 8L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "606559e1-8cb0-4fee-aebf-33fdbb7f5e9b", "mock8", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5328) },
                    { 9L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cf7ae2ee-ec85-4556-b6c5-5ecdcba2f7be", "mock9", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5339) },
                    { 10L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e231eaf6-480a-48bb-a4e1-c47c8e8c3c72", "mock10", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5352) },
                    { 11L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "818c15c0-cb56-4a43-b210-6b39b94311e2", "mock11", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5363) },
                    { 12L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5db01d7d-e5be-4a43-87ea-ab1e6bff4364", "mock12", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5375) },
                    { 13L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a74838da-01b0-4cd0-bdaa-f89f7fe55270", "mock13", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5386) },
                    { 14L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "056ef0b6-48d3-479b-8555-286d7b3d711f", "mock14", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5397) },
                    { 15L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c98fc3f1-37df-4a3e-b0de-35ec823085e6", "mock15", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5407) },
                    { 16L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c943fcea-5c3f-4072-9679-e4e69196a9dc", "mock16", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5418) },
                    { 17L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bd2d9e83-e093-4a19-8954-0740a198542b", "mock17", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5430) },
                    { 18L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ec9b66c6-5fb4-4658-b5b4-2124813ce9d1", "mock18", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5507) },
                    { 19L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2984caec-44ef-4004-a049-7aad09db7cdf", "mock19", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5520) },
                    { 20L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fca25523-3438-49e2-a9db-4b6d2becee9e", "mock20", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5531) },
                    { 21L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "73539b82-661d-435b-aa3c-08fd637e8e01", "mock21", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5541) },
                    { 22L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9fcba839-e7c1-4cab-8776-11e22056653e", "mock22", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5552) },
                    { 23L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cdfdd0e5-2860-4c66-942a-e71cb25caaf4", "mock23", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5562) },
                    { 24L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "aa14fbde-9f90-4ae5-8951-aaa16e4489d5", "mock24", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5572) },
                    { 25L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "52e6f301-596b-4572-af69-96ab312f9ce4", "mock25", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5582) },
                    { 26L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e0ceed7a-7dcd-41ca-9aa5-9ad47b9ae465", "mock26", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5593) },
                    { 27L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4ee24bb5-043b-483d-96cd-e65466897357", "mock27", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5603) },
                    { 28L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c1572360-546a-44bc-add2-3c9b9a1da92f", "mock28", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5614) },
                    { 29L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8ee5ebc2-3c85-4f0f-9865-3f51ae704df7", "mock29", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5624) },
                    { 30L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f69e42a3-5629-4562-8a1b-b53ca1c0599c", "mock30", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5675) },
                    { 31L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cbe2b2e1-aa98-4dda-9bbc-c69342b3b7ee", "mock31", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5687) },
                    { 32L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "14965b8e-670a-4a25-99c2-f2b84d68a174", "mock32", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5698) },
                    { 33L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "01ce0cac-1f40-4814-85d5-5a2f9c820cad", "mock33", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5708) },
                    { 34L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "05f8bf40-6f9f-4c0d-8aca-74b88cd3614f", "mock34", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5720) },
                    { 35L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "81b555fc-b6c9-439f-9e3f-8b0f24f4fd37", "mock35", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5731) },
                    { 36L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "684066b5-d4d1-46e3-9293-5ae511180dc8", "mock36", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5741) },
                    { 37L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "48707f21-7dd0-4bd1-885f-2b5c8967824a", "mock37", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5751) },
                    { 38L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "241bfd90-cd54-41b2-b489-185f954fcc71", "mock38", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5762) },
                    { 39L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7f0369fb-0f69-42c3-b162-0d56ca2094a2", "mock39", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5772) },
                    { 40L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "35cf1879-2a84-4c17-964a-a584bc28ea62", "mock40", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5782) },
                    { 41L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0346a920-dc39-43f7-9fc2-d00929b1e4fb", "mock41", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5793) },
                    { 42L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "493d337d-db00-4f0e-9c5a-64b78c9a652c", "mock42", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5825) },
                    { 43L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "10a8793c-2dbf-4103-a8be-e40696127346", "mock43", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5837) },
                    { 44L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cfc0a0cc-9ced-4652-9546-dbf6d611c5d2", "mock44", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5848) },
                    { 45L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b883b8e2-c810-4050-a817-92de19c53f9e", "mock45", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5859) },
                    { 46L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2a9b026b-f2b8-442b-8fcd-cf11fcb79b59", "mock46", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5870) },
                    { 47L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e9de4b60-3e94-4c7e-8f90-f4fbc941c559", "mock47", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5881) },
                    { 48L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f2aaae51-30ac-4168-9adf-67b47265046a", "mock48", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5892) },
                    { 49L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e29791fc-7025-469d-9476-534c817f4a4d", "mock49", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5903) },
                    { 50L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4d8010d9-37f6-4943-bd0e-ab1a727e4278", "mock50", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5913) },
                    { 51L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "49782fef-0d35-4bf3-8a1b-b2696901b751", "mock51", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5924) },
                    { 52L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2674d895-438b-416c-9860-333dd52eadbd", "mock52", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5934) },
                    { 53L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3da92a5f-7a0d-4951-b32e-a3653e5a6fd7", "mock53", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5944) },
                    { 54L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c2b44a2a-1283-41eb-860d-433e862f980b", "mock54", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(5954) },
                    { 55L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2e183629-d861-41a5-9956-ce9071ffc92b", "mock55", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6077) },
                    { 56L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b989fa66-7117-4251-a99f-9767db5307e7", "mock56", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6088) },
                    { 57L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "da27dcdc-7cbd-404b-9d9b-9576786c0886", "mock57", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6098) },
                    { 58L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2702bf21-5ba7-4cc3-aa69-aafc8179a6b7", "mock58", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6108) },
                    { 59L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "aad8a347-5ef9-486f-a53f-41dfd0ad96f3", "mock59", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6118) },
                    { 60L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "369ca172-d64f-4cc4-8be8-ef0b05bda122", "mock60", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6129) },
                    { 61L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9168d6cb-06e4-42f3-be55-33b0f1f65d02", "mock61", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6139) },
                    { 62L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e019debb-c880-4ef6-af6d-bfb6e5916fe0", "mock62", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6150) },
                    { 63L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ad4285d2-0c56-414d-9da9-ddde7200518b", "mock63", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6160) },
                    { 64L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e4338a56-a485-4c97-8fbb-3bb94abfa373", "mock64", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6171) },
                    { 65L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d9d4bc17-5ea6-4ac6-aa51-1fbd9b5876d6", "mock65", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6182) },
                    { 66L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ace69714-8596-41bb-aa48-f674457c6326", "mock66", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6249) },
                    { 67L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "345e44d4-827b-4fb7-9628-23a116950b99", "mock67", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6261) },
                    { 68L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9e5f990b-a1b2-4a70-a440-60986e3279cb", "mock68", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6271) },
                    { 69L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1fd8f871-a26e-4cc4-8ae3-9bc5723470be", "mock69", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6282) },
                    { 70L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3edeaded-d301-452e-8b32-32cdaa4c9eb4", "mock70", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6292) },
                    { 71L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2e756ff5-0155-43f7-a636-363a10416b37", "mock71", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6302) },
                    { 72L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "18517b0a-77c4-47d3-8302-f71374edbbac", "mock72", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6312) },
                    { 73L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eaa3c2d8-eb24-43db-8f54-8ec575d53eca", "mock73", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6323) },
                    { 74L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "47be4429-0f83-4a72-b9d8-ce3a7cb915e6", "mock74", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6333) },
                    { 75L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8d9b10ef-5b14-478e-acc6-726a570b4ce8", "mock75", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6343) },
                    { 76L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b05fb49c-4243-42ed-876f-b22f3ecdb4a8", "mock76", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6353) },
                    { 77L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6b999906-13fb-484b-8535-bb7c8000faa5", "mock77", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6364) },
                    { 78L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4ef2b9cf-30ac-4996-9f7a-68a75606e48a", "mock78", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6413) },
                    { 79L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7506d455-07ed-49a7-acc6-982943e19e26", "mock79", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6424) },
                    { 80L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7bfe2b2a-38aa-4b5e-bd98-6ecac5c2c723", "mock80", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6434) },
                    { 81L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "09474ffc-f1e2-4770-aa90-e6808daa47cb", "mock81", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6444) },
                    { 82L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f10d23cf-136a-4614-9c46-c27e67813454", "mock82", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6454) },
                    { 83L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "95d277a2-054f-43c1-88ac-4e45335b676b", "mock83", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6465) },
                    { 84L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "828fdba1-7b5a-46a3-a28f-2f1876880f4b", "mock84", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6475) },
                    { 85L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d2b4fe93-8b9a-4151-9fcd-f81167ae80ba", "mock85", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6485) },
                    { 86L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0a8bd954-f760-469c-aac4-928cd40e4a4a", "mock86", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6495) },
                    { 87L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2917dfde-260c-4308-8468-3c2bcb9b8adc", "mock87", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6505) },
                    { 88L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e4a758d6-dbe4-47a5-b3a0-0fdc924280ce", "mock88", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6515) },
                    { 89L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b1f3203d-b08e-4202-b5d5-13ab9ca5ef40", "mock89", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6526) },
                    { 90L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "00e198f7-26f0-4566-8ade-89bbaabeb5ff", "mock90", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6536) },
                    { 91L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "17f033d4-8c95-4145-8647-e204f73472fc", "mock91", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6585) },
                    { 92L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f1596949-8e27-4761-9ac7-87bf4051772a", "mock92", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6596) },
                    { 93L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d84426b9-b611-421b-b355-0608b50319ca", "mock93", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6606) },
                    { 94L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d8664f71-0271-4dcd-9ae1-6c927d86d13d", "mock94", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6616) },
                    { 95L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "37984218-2ec2-45c0-a264-2f5ae90b6f1f", "mock95", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6626) },
                    { 96L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2856f3ed-f183-4d92-acb5-4657f61669b0", "mock96", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6637) },
                    { 97L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b9da6584-5842-4c72-8f12-42d6f70dbe0d", "mock97", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6647) },
                    { 98L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c91e46cb-2155-4f37-adf8-1fb737993427", "mock98", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6658) },
                    { 99L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cb94941f-de45-42de-b427-966c6de8e681", "mock99", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6668) },
                    { 100L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "03c38e8e-7551-4c33-85ee-b6ae050761f2", "mock100", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6679) },
                    { 101L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "97ac0e1d-d98e-488c-9cae-29db6cad4164", "mock101", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6690) },
                    { 102L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd9c499a-8512-4c5f-b009-2df073ac04c9", "mock102", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6700) },
                    { 103L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1cc8b348-4149-475e-8980-49a5c36a22b0", "mock103", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6711) },
                    { 104L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bcc64420-8195-4808-979d-a8b1b9c6492b", "mock104", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6761) },
                    { 105L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a39f6721-91f0-429e-b759-4e61b5348a00", "mock105", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6771) },
                    { 106L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f5b8bf7a-41f9-4c98-b73b-0dd4c262bdae", "mock106", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6781) },
                    { 107L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "87e43463-5e14-4541-9d86-df9e0521dba0", "mock107", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6792) },
                    { 108L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "df85ac08-ba0a-4d0c-b6ec-f4045db1e8da", "mock108", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6803) },
                    { 109L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "987b2ace-21a2-4c4a-8224-a11b46f9d388", "mock109", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6813) },
                    { 110L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "73ffb5c3-5032-4af4-a670-60bfe8f50186", "mock110", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6824) },
                    { 111L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "01fa8515-8daa-48ea-b44a-5916964b2d8d", "mock111", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6834) },
                    { 112L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c0cf17d1-b597-49d8-b414-dc0e60e8ee35", "mock112", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6844) },
                    { 113L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3035ae38-b058-4e8d-be7c-a38f8e305fdd", "mock113", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6854) },
                    { 114L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ee238584-4804-4df9-8324-f0cb64e5b1a5", "mock114", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6864) },
                    { 115L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "09542d10-23ee-4180-be6a-4b963dabc75f", "mock115", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6875) },
                    { 116L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4272c138-6565-4f6e-a7f0-c2911583f650", "mock116", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6945) },
                    { 117L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "959e8507-0441-42fa-b1f6-18e51a231077", "mock117", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6956) },
                    { 118L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8a1e2835-ceff-493d-9a16-8d1a6083a110", "mock118", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6967) },
                    { 119L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd389337-82a8-4fd2-9e10-34f664bc9293", "mock119", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6977) },
                    { 120L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "db01a56b-dace-49c2-a1bc-7779852a10aa", "mock120", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6987) },
                    { 121L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3d19dee1-3cd4-4321-b994-1dab08c441ec", "mock121", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(6998) },
                    { 122L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "00437c1e-c87f-4112-b740-318c80fadf92", "mock122", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7008) },
                    { 123L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "03997cff-a8d1-4bab-ac7c-e404bbdde176", "mock123", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7018) },
                    { 124L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "35373583-d634-48bd-8def-bae6ac9be1cb", "mock124", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7029) },
                    { 125L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "097f634f-a4cd-4e62-b911-1187c27271b4", "mock125", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7040) },
                    { 126L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "16bd0b5d-444e-4658-bd03-25b671be5107", "mock126", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7050) },
                    { 127L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "be6a3ff5-e7ba-42ec-9473-d12257536ed2", "mock127", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7061) },
                    { 128L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f1d685f0-057a-4f96-97f2-db0e55642a98", "mock128", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7071) },
                    { 129L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b35fb184-3cf2-4f4a-b91c-8c488fdffeaf", "mock129", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7120) },
                    { 130L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7d5c03d-8a25-4c66-bc94-0710ca164661", "mock130", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7133) },
                    { 131L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "036e4a34-0087-4057-b551-c6dbd0789ef0", "mock131", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7144) },
                    { 132L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1743f123-04f7-4045-be39-1a2fb86403a0", "mock132", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7155) },
                    { 133L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e511393a-6a2d-4243-a20d-fb064f58b52f", "mock133", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7165) },
                    { 134L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6c87f95c-a717-4673-9cc1-5869b859e2d7", "mock134", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7175) },
                    { 135L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d0aa2695-d946-4a98-9d9f-1b318568959e", "mock135", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7185) },
                    { 136L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "06a14ef3-73e5-463f-a441-14ad468429c3", "mock136", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7196) },
                    { 137L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cd9d77be-8a15-4fe8-83ca-e11b6f279b27", "mock137", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7207) },
                    { 138L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "10fbd022-6995-4fc4-a381-b7b735ca143d", "mock138", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7237) },
                    { 139L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a8660995-3d8f-4706-9033-a7e2a4287e94", "mock139", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7248) },
                    { 140L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f843288d-e6e3-48b6-a3b8-5e9c80945b58", "mock140", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7259) },
                    { 141L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c46edca5-96a4-4ae4-bbbd-c9947194909a", "mock141", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7269) },
                    { 142L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8f7179fa-3ccf-4c35-a778-aa5c947c9182", "mock142", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7280) },
                    { 143L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9c2c5e34-0d85-4bbc-afca-169495325828", "mock143", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7290) },
                    { 144L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "920d5c04-4419-45bb-a7d7-9f6bcbe7a0be", "mock144", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7300) },
                    { 145L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c15f80e8-cf2f-4d5e-a347-8546f2adef7f", "mock145", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7310) },
                    { 146L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8ea1e45d-2444-4ef3-8a13-63db2254e0df", "mock146", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7321) },
                    { 147L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3b6a9d87-9487-4aea-a4f1-205aeeed8bc1", "mock147", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7331) },
                    { 148L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "748cb8a4-bcea-4d87-b61f-940ee17df1ec", "mock148", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7341) },
                    { 149L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bed51a63-0f7c-4ac1-836a-bcd1c87ee0f8", "mock149", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7352) },
                    { 150L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "05171a0c-038f-4a16-97aa-89bc2e7d12cf", "mock150", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7363) },
                    { 151L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e6a7fa45-db48-4111-8a58-26d8aabaef87", "mock151", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7467) },
                    { 152L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "53f5ec73-498f-4269-b971-77685d36d52f", "mock152", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7478) },
                    { 153L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "abe8034f-5e1a-4b6e-9799-185b5c91bf43", "mock153", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7488) },
                    { 154L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4e9d0271-e270-4169-b631-d2fec6938634", "mock154", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7499) },
                    { 155L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0c2cb940-69d6-468e-9a36-79464a6923cc", "mock155", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7510) },
                    { 156L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e116a3f6-fd99-4a7d-a931-627c66361f09", "mock156", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7521) },
                    { 157L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "53d7e6b3-eacb-476a-87a1-738d66ac6c46", "mock157", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7532) },
                    { 158L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5fc3180b-9d7c-4a95-9148-d91502f2b41f", "mock158", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7542) },
                    { 159L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fc75c88a-ed3e-4fdf-b096-776f7967917d", "mock159", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7553) },
                    { 160L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "66f1bb90-6336-4577-9d31-e4d5fb28cd5a", "mock160", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7564) },
                    { 161L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cacdfdb1-1323-4ece-8589-74e254a9c7ec", "mock161", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7575) },
                    { 162L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cf906011-1732-43b8-8d52-2a7066a33eae", "mock162", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7586) },
                    { 163L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c1b29505-a4e5-444a-98af-f6e5a6bab1e4", "mock163", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7653) },
                    { 164L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "118337df-39ab-4193-aaec-9b4a227f182d", "mock164", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7665) },
                    { 165L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c096efa7-9c84-4350-bf9e-f00df7a24d01", "mock165", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7676) },
                    { 166L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ac72a029-26c6-41a5-8177-35f17ba81c5d", "mock166", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7686) },
                    { 167L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2c6ccabf-1d31-43c4-8371-b6e9b17c7352", "mock167", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7697) },
                    { 168L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cfb6e392-b15e-4369-84a6-6c3021544c56", "mock168", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7707) },
                    { 169L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6a16bd03-6552-4882-8e24-6e7e74115d19", "mock169", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7717) },
                    { 170L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3c22c45c-b570-4797-a5d3-485f2749eca4", "mock170", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7727) },
                    { 171L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0a0b79ee-d6c2-49b2-b312-0481f632bf0a", "mock171", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7738) },
                    { 172L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0ef8eaa7-fa20-478a-96a9-4fb0ad9616a7", "mock172", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7748) },
                    { 173L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3b2f1329-7c6e-43f1-a5fd-e05b46821ec4", "mock173", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7759) },
                    { 174L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c7230548-056a-4b5c-8e01-561f4e21de1b", "mock174", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7769) },
                    { 175L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5320cddd-0d22-40f4-8df7-87604b46aa61", "mock175", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7780) },
                    { 176L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "51e0136f-0759-4d97-a09a-2e1bbac7752b", "mock176", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7831) },
                    { 177L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a3b65894-fa30-4c74-ae0d-e9b6168f72d4", "mock177", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7842) },
                    { 178L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1f53dde9-340f-466d-8161-e48ec428859c", "mock178", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7852) },
                    { 179L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fdf63248-566c-4d39-b304-1ff38e13366e", "mock179", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7863) },
                    { 180L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f2c1ac58-5d43-433b-9b27-9e31b5a6b086", "mock180", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7874) },
                    { 181L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "171e44a1-eaa8-4b3c-943b-066493449def", "mock181", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7884) },
                    { 182L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4013a301-9a8a-4003-8f95-3d17239d54c3", "mock182", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7895) },
                    { 183L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8686426b-f98c-43c7-9fc8-d661e90e15ec", "mock183", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7905) },
                    { 184L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eebc7925-f4d5-4ab6-a7ab-d7188d8baf30", "mock184", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7916) },
                    { 185L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c249f793-6839-463b-838b-2c1b3bfa89e0", "mock185", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7926) },
                    { 186L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1acbaa32-54b4-4248-b661-9bbfea7f8a1d", "mock186", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7936) },
                    { 187L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "470ef8cd-d0e9-4a64-afc9-d53b601041e8", "mock187", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7947) },
                    { 188L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8f4901a4-2694-4dcb-a700-836705f9b551", "mock188", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(7957) },
                    { 189L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f8f500c7-9ef7-4664-9958-d48bca5d54a9", "mock189", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8007) },
                    { 190L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "86faabd4-db00-4ca5-8684-83b736ed26c0", "mock190", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8018) },
                    { 191L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ccbae531-51fd-4b10-bb93-9a4cf2e9832c", "mock191", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8028) },
                    { 192L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "12599ede-1700-4205-8cad-2d1014afe3b8", "mock192", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8038) },
                    { 193L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3816ce34-ab97-45cb-a714-b2afaf7c2b6d", "mock193", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8048) },
                    { 194L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "be4ddbff-f7ec-4438-b198-e4d77c306282", "mock194", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8059) },
                    { 195L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4596e845-c21e-4a97-8d20-656dbb5c7adc", "mock195", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8069) },
                    { 196L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "06349fe7-952e-401b-8811-c5dd83cf8abb", "mock196", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8080) },
                    { 197L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0d5c3b2c-39f4-427f-b349-7316d36c51bc", "mock197", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8090) },
                    { 198L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ac663469-4405-4fee-92db-11af26572ec9", "mock198", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8100) },
                    { 199L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b07c0ea2-631b-4d07-b975-92497a8e14e4", "mock199", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8111) },
                    { 200L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b34609ee-a7d4-44ef-b42c-b69251f8f26b", "mock200", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8121) },
                    { 201L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f57c29b1-6907-4a44-8612-7e537d67edb7", "mock201", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8190) },
                    { 202L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bb9fcfc4-ab28-4ec8-8498-648e753a40ae", "mock202", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8201) },
                    { 203L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b16af845-08f0-4ef8-9a7a-bc24fffb356b", "mock203", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8212) },
                    { 204L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a486c762-266e-4901-a45a-c3d02712ae35", "mock204", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8222) },
                    { 205L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0770ad3b-5c51-4c6d-b914-ca7de643ecf7", "mock205", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8232) },
                    { 206L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9babe164-bba8-4d76-93dc-edbb837726cd", "mock206", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8243) },
                    { 207L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2accf4d7-6405-4304-8c9b-b97881893eec", "mock207", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8253) },
                    { 208L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "948ccc09-1407-4d0c-94ad-8891526e8031", "mock208", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8263) },
                    { 209L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0d80eb15-edc0-4b85-9362-29837b98d4c3", "mock209", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8274) },
                    { 210L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1a0af768-1168-4d59-85f9-d801807a4ce6", "mock210", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8285) },
                    { 211L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "710a55fd-5416-4eb6-878d-3d578fcf44b0", "mock211", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8295) },
                    { 212L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "88d150c4-570c-4e99-83e6-02307c177b3a", "mock212", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8307) },
                    { 213L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "717b7452-90e5-4267-9999-42001480d037", "mock213", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8317) },
                    { 214L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "33492173-5cad-4a8c-b26d-3e37cb3e13e6", "mock214", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8367) },
                    { 215L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "01ef6478-eba4-4253-956d-632a67b60fbf", "mock215", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8377) },
                    { 216L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "67c1503d-2397-4cf8-9d54-0f6becdbce9c", "mock216", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8388) },
                    { 217L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b29704ac-f8b8-49cb-85f6-31b857478922", "mock217", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8398) },
                    { 218L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a071940e-72ca-4bfe-993a-0fe6efbbee7e", "mock218", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8409) },
                    { 219L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "53bf789e-fa07-4efe-a693-fc1f2e06f7fd", "mock219", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8419) },
                    { 220L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b96c617e-eef5-4d90-94d1-9c77223533fd", "mock220", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8429) },
                    { 221L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "33273d56-49e7-41e3-9ff5-22c2e6dd5d4b", "mock221", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8440) },
                    { 222L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b632a7fe-088e-4234-9a9d-ceef60d0eefe", "mock222", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8450) },
                    { 223L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8846b4d0-7a8f-4896-875f-0602555f70ae", "mock223", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8460) },
                    { 224L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "32026a51-2aed-4ec4-9f2f-ec9da16c026e", "mock224", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8470) },
                    { 225L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "91e521d9-10aa-4782-af43-cb3ae8de68da", "mock225", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8480) },
                    { 226L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "68d54679-fd64-47a1-943e-4f20223d3898", "mock226", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8491) },
                    { 227L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6e216d91-0fdd-4165-be19-38ce2a29ce67", "mock227", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8540) },
                    { 228L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1b42a520-2a23-4eb2-854f-d04552b9f921", "mock228", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8551) },
                    { 229L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "02ae8a4e-c931-4c2a-9d3e-5784678339aa", "mock229", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8561) },
                    { 230L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "048b751b-c53c-4471-8c25-18dd2dbe4013", "mock230", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8572) },
                    { 231L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7ac469ef-7ef9-4461-9ea3-8f21fad263ca", "mock231", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8582) },
                    { 232L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e337c780-d505-4bfa-84e6-3bbb93dde6e2", "mock232", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8592) },
                    { 233L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "580968c3-8730-4aaf-8cd5-b247dd9626d7", "mock233", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8603) },
                    { 234L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "77b7aab2-a1e4-4d49-8ee3-02ba1c0329e0", "mock234", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8613) },
                    { 235L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eed69b48-f8ed-4766-95d2-b437be8ccd3f", "mock235", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8623) },
                    { 236L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e62a34e5-c4a3-4285-8896-69a48549275c", "mock236", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8635) },
                    { 237L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9669b34b-4a74-4799-a7d1-8db99bcbf6e9", "mock237", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8645) },
                    { 238L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2ca234d6-432b-40a3-92de-94eadcf762bc", "mock238", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8655) },
                    { 239L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b4648a27-f83b-421e-9fb1-7bc418e608e8", "mock239", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8687) },
                    { 240L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7c3026b-3e6f-4021-a907-d247ecaf2c96", "mock240", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8699) },
                    { 241L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "273c5cd2-4e4f-4ea1-8739-cdb20cf005e1", "mock241", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8710) },
                    { 242L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b1777349-e2f9-4eec-ac03-231cb8541346", "mock242", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8720) },
                    { 243L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9d41c723-4201-4cc5-b85a-307e328c8a2d", "mock243", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8730) },
                    { 244L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "29e91b5c-c23f-4df7-a203-6d60a5ba665e", "mock244", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8742) },
                    { 245L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ed048d25-c7c1-416c-be52-c134924a7759", "mock245", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8753) },
                    { 246L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ae15157f-bd0a-4315-b23c-8385c4ebf4f4", "mock246", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8763) },
                    { 247L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "40ba3a55-b704-4301-84ff-67ee53546d16", "mock247", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8773) },
                    { 248L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "83d1a54a-421a-4e34-861c-c750bc115713", "mock248", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8784) },
                    { 249L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f913cd66-fbb9-4296-82e7-bbf8bcc26b21", "mock249", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8794) },
                    { 250L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6d716c23-0581-40b4-aadc-65f7c51b2bd1", "mock250", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8805) },
                    { 251L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a40b18d5-17cb-4431-bf3c-918fdaf6c983", "mock251", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8902) },
                    { 252L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f96fe846-d077-4e18-b28c-53b6446de249", "mock252", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8914) },
                    { 253L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "29843df0-7987-44e2-b88f-464b87c259b7", "mock253", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8924) },
                    { 254L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "55788afc-8960-4d1c-a9f1-0172283a366a", "mock254", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8935) },
                    { 255L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6b2652fa-5b68-4c9a-9384-310080354fd1", "mock255", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8945) },
                    { 256L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "39ac326e-7e2c-489a-9c2f-d55283d2b59b", "mock256", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8956) },
                    { 257L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1149b909-cb98-43be-ab0f-19b139a8f4a0", "mock257", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(8966) },
                    { 258L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fb59d595-1652-425c-aea2-2c8933e8e6c4", "mock258", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9033) },
                    { 259L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0f63e4ad-6ca2-4234-8abe-adedc108ddb4", "mock259", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9044) },
                    { 260L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a1c9da29-91ca-4706-bd35-7cbc6a766b4e", "mock260", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9054) },
                    { 261L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d436bfe5-2f5d-4c89-80d6-89e9da24384c", "mock261", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9065) },
                    { 262L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4644f605-36aa-41f4-bb42-c16a9c7c032c", "mock262", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9076) },
                    { 263L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "24339f0b-e69a-48ee-b50a-7d95888b3c07", "mock263", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9087) },
                    { 264L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9490c041-4e20-49b5-abd5-feafc81ba081", "mock264", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9097) },
                    { 265L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b22be15b-1399-4fe9-8df9-97188c8f37a3", "mock265", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9108) },
                    { 266L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dc34fd52-d2e3-42ca-b185-966c604f0d99", "mock266", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9118) },
                    { 267L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "681c4d5a-9b87-4ae2-8afc-2ca2a952b55d", "mock267", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9129) },
                    { 268L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9cf54de4-3cb3-4300-b896-400d3746fde6", "mock268", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9140) },
                    { 269L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ad7121c1-1a0c-478d-af55-a42f8d849fdf", "mock269", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9151) },
                    { 270L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dcfa635a-1e5e-4b03-a423-965e8c33cf77", "mock270", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9200) },
                    { 271L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "773c84ee-3449-4326-aaa0-49ed7b620142", "mock271", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9212) },
                    { 272L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c0a83caf-b6dc-4f29-9873-7220e76fd606", "mock272", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9222) },
                    { 273L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2f13d3a0-bb06-4deb-812a-b7fa40e19312", "mock273", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9232) },
                    { 274L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6292a162-866b-401a-8408-d21e62ee168c", "mock274", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9242) },
                    { 275L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "47cf4695-8936-45df-87df-9b6ddfc1be40", "mock275", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9252) },
                    { 276L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "98542664-1372-4f2f-8b52-f237299c4680", "mock276", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9263) },
                    { 277L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7114e38-7b8c-4e48-9085-f0f7bb38e5ce", "mock277", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9273) },
                    { 278L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1ffc5d21-3576-4f96-a81c-6781319f9733", "mock278", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9283) },
                    { 279L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "64087090-4688-4263-a0c5-bf6307c2191f", "mock279", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9294) },
                    { 280L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1eca56dc-1fa3-44a7-bbed-6a9db1e7036b", "mock280", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9304) },
                    { 281L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3510ffa8-0818-416e-b714-3c4400257134", "mock281", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9315) },
                    { 282L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c192977f-c957-40ec-8177-ff075c4ad137", "mock282", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9326) },
                    { 283L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4dad8607-7771-42bf-b53a-8f85e0bd9d25", "mock283", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9376) },
                    { 284L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cf34b14f-1080-4772-b978-fd16ed28da1f", "mock284", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9386) },
                    { 285L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c74b4d8d-3d19-42a0-a47d-2f54b53c4874", "mock285", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9397) },
                    { 286L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dbb53671-46c7-400e-ae6d-b69a908bb4ad", "mock286", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9407) },
                    { 287L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d54a34cc-79f1-43ca-a5fb-19c4e3600fe9", "mock287", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9417) },
                    { 288L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "81649827-c541-42f0-9865-ae084a5624bc", "mock288", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9428) },
                    { 289L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5ad3a447-970b-429a-8d64-5bacee96551e", "mock289", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9438) },
                    { 290L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "074ee765-d45e-45e9-b0f4-c819c53059f2", "mock290", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9449) },
                    { 291L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bc0773be-f7d0-4c3c-9bd1-67099f5dde85", "mock291", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9461) },
                    { 292L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "68613161-66c5-4ce9-b2bf-b7c2a4d48c57", "mock292", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9473) },
                    { 293L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a273f2b7-220c-4762-a1d8-2ea898c49af9", "mock293", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9484) },
                    { 294L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b32b0a06-c494-4a28-b0a1-04f35205ba93", "mock294", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9495) },
                    { 295L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f95508fd-dbc9-4802-b26d-db632f84eb2a", "mock295", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9505) },
                    { 296L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7c975a3c-ff0a-4aa5-8f83-ef5b3ece465d", "mock296", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9579) },
                    { 297L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4df6510c-b421-4776-a6e2-355aecbe08e3", "mock297", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9593) },
                    { 298L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "438045d9-c80a-4a46-aebf-a100abe1802d", "mock298", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9606) },
                    { 299L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "62b05607-90dd-4058-8038-8ff534461a1f", "mock299", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9619) },
                    { 300L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7503409-9ebe-49af-8c7f-a9f0862843cc", "mock300", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9632) },
                    { 301L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a58e16ce-9b05-41ad-b10e-aaa178a35031", "mock301", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9646) },
                    { 302L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "53525d1c-97a5-48e9-952a-3bf890e2d3d3", "mock302", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9659) },
                    { 303L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7daa118f-356a-4c86-994f-b793cb2f0d5d", "mock303", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9672) },
                    { 304L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "321c10c6-07b4-41f1-aeb9-2b834e16b131", "mock304", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9684) },
                    { 305L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bddb402b-dc4b-470b-bb2f-5b0639d61b58", "mock305", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9694) },
                    { 306L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "878f16ed-926b-41b3-8265-8a1a043e20e1", "mock306", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9705) },
                    { 307L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "34c9a0e4-4718-4c02-80b4-98a7ada8f978", "mock307", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9715) },
                    { 308L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "89f3b4cc-4907-4185-a1e8-765dc6f984f8", "mock308", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9772) },
                    { 309L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "45a80a3b-d5f5-4c84-ae98-7cc68a9c7e65", "mock309", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9785) },
                    { 310L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c3a87688-0e61-4ca0-ad3c-f5ff3deceac1", "mock310", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9798) },
                    { 311L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "880d65c5-d827-48f1-8f3d-8e8574891aae", "mock311", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9811) },
                    { 312L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b8c6b436-3787-492d-94ae-0886c0f4f8a5", "mock312", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9824) },
                    { 313L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eb14fc10-8a72-4bf6-9f93-0be6bacea3ff", "mock313", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9837) },
                    { 314L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d722807c-448f-4d9e-ae56-d2be9fedb958", "mock314", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9849) },
                    { 315L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ddc75216-ed76-47c6-9809-b0acf5da8659", "mock315", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9862) },
                    { 316L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0fd07c17-d817-4d01-8485-7781b11a472e", "mock316", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9874) },
                    { 317L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2c17f9c3-1b5a-4823-9ea0-6ad625c51ee8", "mock317", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9884) },
                    { 318L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d015adcb-f67a-4f31-9a10-4640660affe8", "mock318", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9895) },
                    { 319L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1ff7231e-b6c4-4fc6-86e1-73fbda2ac2fb", "mock319", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9905) },
                    { 320L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "046b35d5-ae05-4650-8d3c-a2c3cff92b3a", "mock320", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9958) },
                    { 321L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3c107a11-ff21-4ad3-b141-37c442e54203", "mock321", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9970) },
                    { 322L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "18efe386-6c39-424d-bf65-335b1cfa4986", "mock322", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9980) },
                    { 323L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0d45608c-caa4-46c7-9664-67594132b8d3", "mock323", new DateTime(2024, 4, 29, 14, 51, 39, 886, DateTimeKind.Utc).AddTicks(9990) },
                    { 324L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "532e16d3-9e00-4833-9de1-95a67548bed9", "mock324", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1) },
                    { 325L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7c536a08-7daa-4af2-92c2-891a7da322eb", "mock325", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(11) },
                    { 326L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7d9b3bf5-14e8-4386-900b-904f69525cea", "mock326", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(21) },
                    { 327L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "38b44496-b0bb-4abc-83f9-2584de3a2c50", "mock327", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(32) },
                    { 328L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "641a2bbf-2230-47df-8948-1e9837c1c1f3", "mock328", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(42) },
                    { 329L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1b3f3af2-2081-40ae-9dae-e73d2123a823", "mock329", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(52) },
                    { 330L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "33845a21-71cf-402e-8ef8-2a856670cad0", "mock330", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(63) },
                    { 331L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bd29c323-fb13-45f6-84bf-16501c922692", "mock331", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(73) },
                    { 332L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ef8d5b8a-6186-474d-988d-e74c133fce09", "mock332", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(104) },
                    { 333L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "97f5a9da-fc70-4ca9-bb77-25a05d14e17c", "mock333", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(115) },
                    { 334L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "490800a8-8691-41a0-a5fe-0ec5c528e39f", "mock334", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(125) },
                    { 335L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d10a8bb9-fc6d-406b-a545-ccb436cae761", "mock335", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(136) },
                    { 336L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7258f60b-0a2a-4e68-b34b-36bf10ad5546", "mock336", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(146) },
                    { 337L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "77dc1573-3f53-4595-b76b-b768cf0b63f0", "mock337", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(156) },
                    { 338L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "480715ff-7a26-4dfd-8f8e-449be7671db8", "mock338", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(166) },
                    { 339L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a2081695-9724-4162-8f20-a1282a96ce7b", "mock339", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(177) },
                    { 340L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c689bb96-48af-45fc-a7c8-b58761deef4d", "mock340", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(187) },
                    { 341L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a59a7c33-db26-420a-8103-a849a90cf1e4", "mock341", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(197) },
                    { 342L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7f4e854-f1b2-4ebd-b152-9b39baa83b3c", "mock342", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(207) },
                    { 343L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6df36904-596f-478e-b90a-3e66d2f2a5d1", "mock343", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(218) },
                    { 344L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b2ddc62e-0142-4783-80c5-038e2284808a", "mock344", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(362) },
                    { 345L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "63e06008-5433-4e08-afec-18df4e163bac", "mock345", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(371) },
                    { 346L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "87d4df6a-2d5d-4312-8560-366c6841e24c", "mock346", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(382) },
                    { 347L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b19790f5-f53d-4bab-bd5a-2a255c9b5e9d", "mock347", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(392) },
                    { 348L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "261e6beb-e1d1-49c3-a168-9173c1c6d233", "mock348", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(402) },
                    { 349L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "be4c8e57-a2d5-4261-9ce8-c06ae738d069", "mock349", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(412) },
                    { 350L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bdf7ac37-e111-4eb2-ae29-f7e49d6799f0", "mock350", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(423) },
                    { 351L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0fb3f40b-76d2-4d21-821a-daff3ccef41b", "mock351", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(433) },
                    { 352L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0fe96bd0-e2f1-43ff-b852-7a0edaaa1734", "mock352", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(443) },
                    { 353L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7e53c4be-db46-4a9e-bf8a-95e022ca9026", "mock353", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(453) },
                    { 354L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9544c1b3-f445-4a08-806a-95fa2831cd0b", "mock354", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(464) },
                    { 355L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7c9f9130-d85b-4327-a86e-c2f61168f3cb", "mock355", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(474) },
                    { 356L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "80eaf7c9-c5b0-44e4-8de9-0bbff1b390a4", "mock356", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(541) },
                    { 357L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1845bebd-16af-4cb6-b930-15a46135b8ae", "mock357", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(551) },
                    { 358L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f27a3b0b-b50e-48c5-82b3-a164dc80815d", "mock358", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(561) },
                    { 359L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6de5a959-b223-4401-9b4f-de2d3dfd92fb", "mock359", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(572) },
                    { 360L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "55610aa1-57ee-404f-8613-f5b1ea3eaf88", "mock360", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(582) },
                    { 361L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3f65b23a-12d4-442b-8542-fad74b9a764d", "mock361", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(592) },
                    { 362L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fa03dc2b-cbf3-4309-a2e3-33c0478742d5", "mock362", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(601) },
                    { 363L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b4ffc18d-b2db-4086-9d7f-4c5d15177dbe", "mock363", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(612) },
                    { 364L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fafb6655-2e0a-4401-964f-a1e5dcab7c9b", "mock364", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(622) },
                    { 365L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "01d68847-c1be-48b5-8eca-b75d6b2ea3a5", "mock365", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(632) },
                    { 366L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6965477a-fef0-4591-8826-6d17051e6f6d", "mock366", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(642) },
                    { 367L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9fc439b3-6369-4ac9-829b-2b5c03fded70", "mock367", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(653) },
                    { 368L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "76ee67ec-d434-4ed9-9d15-51fc993a8dd0", "mock368", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(707) },
                    { 369L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6f287787-fbbe-4f83-8df0-67c54422e62b", "mock369", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(717) },
                    { 370L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9e136fd9-8f27-4f88-bdf3-03c01fecfafa", "mock370", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(727) },
                    { 371L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fca81aca-5809-41b5-a9c9-8ab9e6b48bed", "mock371", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(738) },
                    { 372L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e5544a64-00b9-4019-ae3a-60fec012f2dd", "mock372", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(748) },
                    { 373L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8a66ce6c-0e80-404b-a71e-d45e059f78af", "mock373", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(758) },
                    { 374L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "abbdf5a2-2f1f-4c41-b645-759beab3c824", "mock374", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(768) },
                    { 375L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "facc973e-af5e-458d-88d2-bc5b998206c2", "mock375", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(779) },
                    { 376L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a258a8ec-ed51-4c93-9d77-da44bcc6cb89", "mock376", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(789) },
                    { 377L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f5791343-b6fd-45bf-b48f-d5db3c022355", "mock377", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(799) },
                    { 378L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "91149ae8-2e28-470b-ad54-9fdad509a975", "mock378", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(810) },
                    { 379L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "455a21da-65a8-47c3-9f0d-9d5268870561", "mock379", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(820) },
                    { 380L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9c9ac9cb-1d9a-4609-820d-116fc66f3cc4", "mock380", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(944) },
                    { 381L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "765465b3-cbfc-4cd5-a7e7-7d47b2c2df00", "mock381", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(955) },
                    { 382L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c28c83e1-0318-4947-bf44-0b34c4d53f7e", "mock382", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(965) },
                    { 383L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5020933d-7c1a-40b6-802c-aa9b6f33e769", "mock383", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(976) },
                    { 384L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0b2d4c53-44c4-44a8-8fed-480631282986", "mock384", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(986) },
                    { 385L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "037e1ad8-0a53-41af-aa18-09f382437b7c", "mock385", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(996) },
                    { 386L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4f2d8479-106a-427c-a520-65f05714a1b7", "mock386", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1006) },
                    { 387L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "30920c9d-5436-498a-b18b-5eb5e913d355", "mock387", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1017) },
                    { 388L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c94bfb51-dd80-4d91-a6f5-25caf4daaa9c", "mock388", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1027) },
                    { 389L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bc9911a7-5ce4-41c2-8e65-72c2f2a76d3f", "mock389", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1037) },
                    { 390L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b27cc77b-7c83-4985-87cc-b0d0c441f1a0", "mock390", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1047) },
                    { 391L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6c549155-1778-4c48-9346-44aa45160c5c", "mock391", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1058) },
                    { 392L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f76a5b9f-1c0c-4851-9c44-3ef52e6ca090", "mock392", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1122) },
                    { 393L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1d3e1e91-75a4-48bb-82b3-9264ee5c1572", "mock393", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1133) },
                    { 394L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "58bc0343-0c9d-49e1-a91c-bd6dc3baf195", "mock394", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1143) },
                    { 395L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4f164f0f-a277-47e8-a8c3-07baf4443c00", "mock395", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1153) },
                    { 396L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f858b9ec-33f6-4043-9dcf-4358ede1ccd7", "mock396", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1164) },
                    { 397L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f2ef4925-b522-4c4f-b85a-1f7266ec99b7", "mock397", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1174) },
                    { 398L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "441165d2-245c-4f3d-959c-882576102ba3", "mock398", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1184) },
                    { 399L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dac2d7d3-cc13-48c6-a5f8-c709bcd002e6", "mock399", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1194) },
                    { 400L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "86f81756-0ee4-4ada-b352-b8eb62461ed0", "mock400", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1205) },
                    { 401L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "77eede90-eee0-460d-8a62-d26b71dbabde", "mock401", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1215) },
                    { 402L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "06324065-079a-4470-bc14-408e2d355d60", "mock402", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1225) },
                    { 403L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "736d6f6a-76ba-4112-b539-2c3528611468", "mock403", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1236) },
                    { 404L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6ae9e58d-d4ff-4d6d-b5ea-9766b1213e08", "mock404", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1284) },
                    { 405L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7f953eff-a1dc-48fc-9065-df4ce48d54ab", "mock405", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1294) },
                    { 406L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "05480b48-19d4-4737-b870-460544ba0e06", "mock406", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1305) },
                    { 407L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "61533ffd-8069-44f4-8d1c-d956246e8050", "mock407", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1315) },
                    { 408L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2ffb01d7-6f87-47aa-b7f9-2a01c87b729c", "mock408", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1325) },
                    { 409L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a4d1067b-24d7-448a-89a2-7524959ddf67", "mock409", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1336) },
                    { 410L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6ab82363-1f46-4dac-90a3-563b7e70dfea", "mock410", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1346) },
                    { 411L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2e54daad-05d9-4102-8f4f-d2c1d233d4ca", "mock411", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1356) },
                    { 412L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ec02ace6-3334-42b6-8730-123bcfee7b44", "mock412", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1366) },
                    { 413L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8d96cada-a851-400d-bc4d-7c8458c1fb89", "mock413", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1377) },
                    { 414L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "301ce5e0-caa5-4f9c-b747-1044d10d41fa", "mock414", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1387) },
                    { 415L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ff299464-651b-4470-92a0-0bf5fd833750", "mock415", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1397) },
                    { 416L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c1f89a3c-0a3d-4c97-bdd7-38e083e46dd9", "mock416", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1445) },
                    { 417L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "920a01c9-a5ee-46fa-9aac-548b0b84576b", "mock417", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1456) },
                    { 418L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3e948e38-795c-4ff1-8ffd-0bf2aeb3e45a", "mock418", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1466) },
                    { 419L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3e6fb33a-9918-4cd5-8c7b-8f1dad008729", "mock419", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1477) },
                    { 420L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d03e4d4a-bbe8-4665-94b7-e90be9dfcaa2", "mock420", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1487) },
                    { 421L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f4755f1a-347a-4d7f-a697-1e7e8e99f1d8", "mock421", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1497) },
                    { 422L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8ea72e7f-832e-4b6d-bb9e-c93522f81488", "mock422", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1507) },
                    { 423L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d25dfa55-36ac-4062-833b-1ae63d1f3800", "mock423", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1518) },
                    { 424L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "06458057-bd5d-4e6a-af8c-c0fad1b32cd5", "mock424", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1528) },
                    { 425L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "20f3a892-3b74-42d5-9f90-fc376a461941", "mock425", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1538) },
                    { 426L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fa723809-5ca3-4791-98d3-732f0e72dd1f", "mock426", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1548) },
                    { 427L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ab5fa60c-4967-401b-aa7d-224f3ac37259", "mock427", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1559) },
                    { 428L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1abd4073-51a3-4a2f-b620-6879ea6488a4", "mock428", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1607) },
                    { 429L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "99a0f5ed-6c77-4ced-a7fd-d56591f44288", "mock429", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1617) },
                    { 430L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4d7bf505-3bf1-402f-a827-56c028afab3c", "mock430", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1628) },
                    { 431L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5dd0bdd9-4bd6-4716-b2b6-77ab8f936bf9", "mock431", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1638) },
                    { 432L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0f71515a-d453-4413-a937-a64a4ff39c80", "mock432", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1649) },
                    { 433L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3edc588b-bff0-474e-8199-7696e8f99145", "mock433", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1659) },
                    { 434L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d7bb54b8-c16c-4235-a750-f2b2b11064cc", "mock434", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1669) },
                    { 435L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a93a54d1-a6ca-48d0-86d3-e965bec6abd7", "mock435", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1680) },
                    { 436L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4715661d-f3a8-4b95-8f9a-b95cffd255ef", "mock436", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1690) },
                    { 437L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ada16f35-604b-4076-860e-b29596ed0154", "mock437", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1700) },
                    { 438L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6e4c1198-5fe2-494d-94e0-77b829b12b52", "mock438", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1711) },
                    { 439L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5eb1b38c-bde1-4f25-8a0a-593511992902", "mock439", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1721) },
                    { 440L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f78a786b-b60c-46c8-86aa-ad3d9d324380", "mock440", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1768) },
                    { 441L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9e303783-6646-493a-ba42-4dbec89707e0", "mock441", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1779) },
                    { 442L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "235f0875-6433-40c0-88a7-7114175db245", "mock442", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1789) },
                    { 443L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "881fee72-0408-49d2-b1ba-1bff99b26586", "mock443", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1800) },
                    { 444L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "84be324a-ec9c-4f7b-a9cb-99c221d800db", "mock444", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1810) },
                    { 445L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8fa7131f-37d5-4902-b1b1-66b300603d58", "mock445", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1820) },
                    { 446L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "aec3755b-2ff1-4e74-ab22-643bf6ae9544", "mock446", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1830) },
                    { 447L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "56fa2e1b-3227-4272-8a56-93d3d795bee1", "mock447", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1841) },
                    { 448L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0d87b25d-a967-49f4-85e0-6e61a2847c40", "mock448", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1851) },
                    { 449L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ac0a54f0-15bf-4717-a664-c7163902f42d", "mock449", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1861) },
                    { 450L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6c8bed62-73f8-4244-8bb7-3c8c8959c805", "mock450", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1871) },
                    { 451L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5850082e-5988-4332-98a4-42791501af91", "mock451", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1882) },
                    { 452L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "87cfa5cf-f4df-4462-be77-dee4662044af", "mock452", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1928) },
                    { 453L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6c8a4360-d52c-4d7f-89ff-a4a8328ffb99", "mock453", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1939) },
                    { 454L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7d51cd87-aa90-4d88-847d-1afe3ff55dee", "mock454", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1950) },
                    { 455L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b815c03a-bee2-4561-8dfd-0619074fcc60", "mock455", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1960) },
                    { 456L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "43e4ed4c-166e-41d0-a54c-ce2daa86af86", "mock456", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1970) },
                    { 457L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "57d5db51-e7b0-4fb8-a5af-61f5e92024a4", "mock457", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1980) },
                    { 458L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4a35c079-8aba-4756-a71b-b4a9e75d6224", "mock458", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(1991) },
                    { 459L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5601dca2-fc2a-401c-a37a-497527704044", "mock459", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2001) },
                    { 460L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "87fd794f-f44d-4e63-af58-3da5062eb2ce", "mock460", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2011) },
                    { 461L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e59d8bdb-3b9f-4195-b61d-a432e3674a76", "mock461", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2021) },
                    { 462L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0b5cd5a4-ccef-4361-b87f-b84dad378f6f", "mock462", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2032) },
                    { 463L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b9751e31-c200-4c49-a449-20301767c3ad", "mock463", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2042) },
                    { 464L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c46651c3-d1a7-45d5-a852-911693fe7acd", "mock464", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2073) },
                    { 465L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5950fbde-6e88-4f30-a34d-04369b5cb9d4", "mock465", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2084) },
                    { 466L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6c172c84-36b2-4106-b227-26c58c2ee7f7", "mock466", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2095) },
                    { 467L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fabaea32-9982-4b85-9ce0-eadd62ba89ae", "mock467", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2105) },
                    { 468L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c1a900d0-02dc-4959-a49a-fd0a09f0f93f", "mock468", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2115) },
                    { 469L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "58e86a79-214b-4ff8-bf65-a69d2a53dd17", "mock469", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2125) },
                    { 470L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9e5c3bec-17f6-43b4-9bac-e18839127bdc", "mock470", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2136) },
                    { 471L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "98b5b541-cf06-4c80-bcde-9426286dd0db", "mock471", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2146) },
                    { 472L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "40cd6752-a05d-4e72-96a5-ccaa6c96557a", "mock472", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2156) },
                    { 473L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "474ee59e-1ffd-4f88-997c-8ad64676e755", "mock473", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2166) },
                    { 474L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f66c6ba1-f991-41b7-aeeb-8aa87010c317", "mock474", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2177) },
                    { 475L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c1dd8208-5ccd-4a7e-83be-d7953db109c8", "mock475", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2187) },
                    { 476L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "baa09ffc-8b9a-41ad-b45a-7a0822398c5f", "mock476", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2306) },
                    { 477L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a77e39cd-b4bb-4409-83ab-e2a7e81b8c02", "mock477", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2317) },
                    { 478L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2eaf4e72-582a-4f54-874a-9c135b95fc95", "mock478", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2327) },
                    { 479L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "75e09c72-8542-4b80-bb49-288c5a946f29", "mock479", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2337) },
                    { 480L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e66d5ee2-2d4a-4467-8057-222c7ced42c6", "mock480", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2347) },
                    { 481L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fd1b8d20-043b-46b9-9b2e-2dad24380954", "mock481", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2358) },
                    { 482L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eb5f65f2-863d-4f2a-9798-4ad9ed667d6f", "mock482", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2367) },
                    { 483L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7616d9d2-3de7-485b-babc-53c43dc79fd4", "mock483", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2377) },
                    { 484L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f6c6dfa0-1739-43ff-8465-b85c9f9622e3", "mock484", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2387) },
                    { 485L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "82b72b44-dbb4-49bd-9e6c-45c229105f3f", "mock485", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2397) },
                    { 486L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "15ddefbd-3633-44e0-b592-0874e331803d", "mock486", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2407) },
                    { 487L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7b700fc0-0cc1-4d67-b8a4-877dac9dc017", "mock487", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2418) },
                    { 488L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d116e4fa-8247-4a5c-91c6-5e4d0cd81991", "mock488", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2482) },
                    { 489L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7d66f466-6091-4baa-aacc-8488d10a9935", "mock489", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2493) },
                    { 490L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b5fc51c4-7506-4fd9-82db-2bfae1e65b36", "mock490", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2504) },
                    { 491L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f2b20696-c241-4f12-93eb-3dbd63c7573c", "mock491", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2514) },
                    { 492L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2538f105-f7d5-47f2-abe6-51925268d95c", "mock492", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2525) },
                    { 493L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8d57f227-85a1-40c3-a9b4-d0ef3ff996c8", "mock493", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2535) },
                    { 494L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f64ae66a-0b07-4a1f-b5c3-56419a72426a", "mock494", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2545) },
                    { 495L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5e796c1a-7d28-489c-a0b4-00166fe2d692", "mock495", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2555) },
                    { 496L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c30a36c0-7a1f-4528-9bf4-cd852d6e207a", "mock496", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2566) },
                    { 497L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "35fdc635-f555-464e-be3e-7aaefdcfea5a", "mock497", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2576) },
                    { 498L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b0582972-ff51-47cd-9181-57d39fff2bc3", "mock498", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2586) },
                    { 499L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eb39da49-4f31-41a7-bfa6-6b2e75ae309a", "mock499", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2596) },
                    { 500L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a0756bdc-23c1-4c8a-911d-a8a8e5f01193", "mock500", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2644) },
                    { 501L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fdca2262-f8a4-4556-9b3c-43f67250e885", "mock501", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2655) },
                    { 502L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c09b6ee6-39a6-49d0-a561-2fc61394cb31", "mock502", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2665) },
                    { 503L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fb0c2fab-42ae-44a7-be77-cd73b6d7d73c", "mock503", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2676) },
                    { 504L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3162e401-8243-4a8e-bdfd-c6a525422183", "mock504", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2686) },
                    { 505L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "07976ede-46b3-4e3d-b756-e636eb2ed056", "mock505", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2696) },
                    { 506L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3687237d-93e1-40df-bd29-94f88020b1f5", "mock506", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2706) },
                    { 507L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9d406d14-3485-49f8-a143-191b40e43901", "mock507", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2717) },
                    { 508L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a28b7162-ec8b-4abc-8a25-bdbd1c723e74", "mock508", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2727) },
                    { 509L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e9cd72d6-425d-486b-88b9-b6803b5ec2b9", "mock509", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2737) },
                    { 510L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b1f787bd-c639-4376-b6d9-a38c304e7ab3", "mock510", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2747) },
                    { 511L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "829ade55-7c70-4949-9447-e9c1a63685cd", "mock511", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2758) },
                    { 512L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e546a148-3b4f-4f03-85cc-cc3c20966bf1", "mock512", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2805) },
                    { 513L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e866672a-3dfe-471b-81a3-3519627f6b7f", "mock513", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2816) },
                    { 514L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7e570cb5-6842-4fdb-8bd5-d4a347a46737", "mock514", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2866) },
                    { 515L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "32e20cf4-e11f-48a8-ba3d-0d7156b03f69", "mock515", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2877) },
                    { 516L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd658256-ee27-4c2c-bc50-aa3ba4b23fed", "mock516", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2887) },
                    { 517L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4e36462d-0ae8-45e7-9932-c271ea6f96d7", "mock517", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2898) },
                    { 518L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b2a4d70e-bff2-490a-b74f-f8d08798127c", "mock518", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2908) },
                    { 519L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f51a633a-2b2d-4927-be95-b7268345762e", "mock519", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2918) },
                    { 520L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "253e4aae-2aba-4105-a1c6-d2bb96c5b1eb", "mock520", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2929) },
                    { 521L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2e55bb22-d15d-4248-b83f-e19f67bdb7c8", "mock521", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2939) },
                    { 522L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "57de6cd0-29fd-47cd-8ea3-bbe4fca43dd1", "mock522", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2949) },
                    { 523L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "94f1af4c-cecf-4365-91e5-87fc2fa426f0", "mock523", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(2959) },
                    { 524L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "56bd1710-fd8f-40fd-8a39-551e85dc82c1", "mock524", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3007) },
                    { 525L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e98e21be-ea05-4361-914e-38688e3be8c1", "mock525", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3018) },
                    { 526L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "542f8da6-f5f1-41f5-8de3-8b7881512baf", "mock526", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3028) },
                    { 527L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8ca76c55-619d-4142-84e5-28c0855c85c5", "mock527", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3039) },
                    { 528L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8b7f7074-3ce4-4676-af62-68a5993ac9fc", "mock528", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3049) },
                    { 529L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dc62e203-598f-4b48-bbac-3c1adfd8c1a4", "mock529", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3059) },
                    { 530L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4d73b8d3-605d-4a35-9464-d100a10f7b7d", "mock530", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3069) },
                    { 531L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "402e5025-a305-49b9-bf26-d318799d853c", "mock531", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3079) },
                    { 532L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "855c9a6c-dc50-4d61-9be5-7ef9ea6aba88", "mock532", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3090) },
                    { 533L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7e27c3db-1110-4d9c-af76-85b5be8e874c", "mock533", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3100) },
                    { 534L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5a7070bc-d1f6-4cfa-9327-402a88dcbb14", "mock534", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3110) },
                    { 535L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "725dc92d-060d-4198-ab43-b0e6f6165153", "mock535", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3120) },
                    { 536L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "add5b494-dde2-4a72-ac7e-b94046478990", "mock536", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3168) },
                    { 537L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "66de70dc-46cd-4f3d-929c-e9869b47df36", "mock537", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3179) },
                    { 538L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c5198d6b-3b9c-47ac-8ed1-575d209aa667", "mock538", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3189) },
                    { 539L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d9971761-48c2-42da-a16d-ddce982980d1", "mock539", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3200) },
                    { 540L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b95e0694-e0d7-4a88-90ba-9699a22b0bee", "mock540", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3210) },
                    { 541L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "94d38e73-7c87-44f3-9a9b-261a67ff8079", "mock541", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3220) },
                    { 542L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "44b7d57d-e4eb-402a-92b5-0fd84283f3d1", "mock542", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3230) },
                    { 543L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bfafce90-3ad3-48eb-a1d2-7bafb9e05265", "mock543", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3241) },
                    { 544L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "12fbc339-072d-4086-9901-0da089121e19", "mock544", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3251) },
                    { 545L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1cee30bd-7833-4707-aae3-eff6dbd76ca6", "mock545", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3261) },
                    { 546L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "31c42e0c-8fb8-4a21-b0b7-3774b1d33951", "mock546", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3271) },
                    { 547L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "344dafa3-53a4-4955-8ee8-1fef504b5ef9", "mock547", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3282) },
                    { 548L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8f3fae0f-2eaf-4650-813c-88a0abf57e97", "mock548", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3335) },
                    { 549L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ae136c1a-058f-4701-88ab-491901d3c1a6", "mock549", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3346) },
                    { 550L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "79ec751b-e719-4062-82c8-0c584f3543c8", "mock550", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3356) },
                    { 551L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e9c28823-8400-4051-8af2-643d12259d4a", "mock551", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3366) },
                    { 552L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e65a020b-b31b-40b8-9ded-b2efba39a2e0", "mock552", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3377) },
                    { 553L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0132b202-f371-4c3b-af9c-acee50a151f6", "mock553", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3387) },
                    { 554L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8d1e71cd-8a02-40ea-a177-0ff37d7662b8", "mock554", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3397) },
                    { 555L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "966141d5-67e0-49b7-8b5f-e9a22d59ab40", "mock555", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3407) },
                    { 556L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6836c241-63cd-41f2-82c6-addbae8086b5", "mock556", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3418) },
                    { 557L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bd5aeb9f-fee6-48d7-870e-6d8ab1502522", "mock557", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3428) },
                    { 558L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "65f85d59-56bf-4c69-88ee-fdc87e1227c0", "mock558", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3438) },
                    { 559L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e800dcac-4599-4f63-ae91-e66520255c3c", "mock559", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3448) },
                    { 560L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2f30ceec-74e8-46fa-8c7d-15910c084bbb", "mock560", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3544) },
                    { 561L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "53f30678-9dd6-4a50-ac1e-32903353e660", "mock561", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3554) },
                    { 562L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "202c5656-e76f-4337-a891-6f98d2421e01", "mock562", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3565) },
                    { 563L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5fff1efc-05f7-4305-8ad8-c9bd4cc3af4e", "mock563", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3575) },
                    { 564L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f01d22ad-fac9-4345-85b1-0e3efe9616a1", "mock564", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3585) },
                    { 565L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cec2d2ee-b180-4517-b4bb-59940ad13d20", "mock565", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3595) },
                    { 566L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5c967501-28ce-4284-a589-3dc67f83450c", "mock566", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3606) },
                    { 567L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "46ede36b-9b49-4719-9d80-e498fdc02518", "mock567", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3616) },
                    { 568L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "01381c96-9e70-40fb-ba84-28eb42b714c1", "mock568", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3626) },
                    { 569L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "538ebafb-5121-4111-9637-9f915e81289d", "mock569", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3636) },
                    { 570L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4198aeff-0ab7-480e-8abd-1cbbcad20797", "mock570", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3646) },
                    { 571L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c7d08536-f885-4d7d-9043-55e4672309e4", "mock571", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3657) },
                    { 572L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "da310e04-087d-4023-9550-7c2941df286d", "mock572", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3722) },
                    { 573L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4e47466d-f150-4eab-9672-687df82a2441", "mock573", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3733) },
                    { 574L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e864bebf-0af7-4e19-8206-ac79a86e69cf", "mock574", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3743) },
                    { 575L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "018e6a7a-de2f-4048-a712-872320a2c87e", "mock575", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3754) },
                    { 576L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9759d999-9f8a-4988-b854-edcb5122d324", "mock576", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3764) },
                    { 577L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d345c72f-393f-488c-be1f-66a32822e962", "mock577", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3774) },
                    { 578L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "89273d78-9bc3-49cf-8d83-528ef950d839", "mock578", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3784) },
                    { 579L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3eed9388-5957-48c2-9279-de8c82cab52d", "mock579", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3795) },
                    { 580L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c100c174-c2da-424a-8f3c-0ea477a6b2da", "mock580", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3805) },
                    { 581L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3c0a2ebb-907c-454f-bfe0-472f96f4d547", "mock581", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3815) },
                    { 582L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d86d8d53-ebc4-4c72-8347-5194f658cdde", "mock582", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3825) },
                    { 583L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "93e04d0f-5a0c-43d2-9c21-ca29ec788fba", "mock583", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3836) },
                    { 584L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7dd63137-529d-4ce9-bd10-570d1d7db208", "mock584", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3883) },
                    { 585L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d8da7788-2569-42c9-bf6c-5b30aabd40c9", "mock585", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3894) },
                    { 586L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e3376bc2-daf6-45c5-9f11-af84c13d4ae6", "mock586", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3904) },
                    { 587L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1eb58f82-dd46-4df2-8a6f-70d425d0d66a", "mock587", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3914) },
                    { 588L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e6406668-9c5c-4676-a4f6-1cf01c75462f", "mock588", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3925) },
                    { 589L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ac1e8aa5-a957-4c66-9cb4-69074fae0780", "mock589", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3935) },
                    { 590L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "233f39f1-a382-4ca1-94c6-2b2b76c93054", "mock590", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3945) },
                    { 591L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "04552555-3b85-4ad6-8da6-d9182b327a50", "mock591", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3955) },
                    { 592L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4936b2ea-626b-44e2-89df-7bd0ea32077e", "mock592", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3966) },
                    { 593L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "99a7b75d-2efd-4eb2-ad33-0f3b47354839", "mock593", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3976) },
                    { 594L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1ede9d4c-dfea-4c7b-a9fe-6f13e9f4f4c4", "mock594", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3986) },
                    { 595L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ced0dbac-f995-4ea3-8f68-dbdd96d2e3b7", "mock595", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(3997) },
                    { 596L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "34bb5773-fad2-4805-ada3-24d98f2077db", "mock596", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4045) },
                    { 597L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6cac2ae2-e271-4e10-b582-4768f08904b1", "mock597", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4056) },
                    { 598L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "760ac3e9-e0c6-4224-bbfa-60d972a40a5a", "mock598", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4066) },
                    { 599L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7e873f69-1bc8-4a9b-affd-598c3c99d990", "mock599", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4077) },
                    { 600L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b2d73754-0d13-48fc-afb4-67f42808a815", "mock600", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4087) },
                    { 601L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2f2477da-f36d-401c-b55b-4e35903f9a15", "mock601", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4097) },
                    { 602L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f39e8193-c500-4120-8973-171a4a1be5b3", "mock602", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4108) },
                    { 603L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3f3d5917-a51c-499f-8c2f-04c547a37dd5", "mock603", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4118) },
                    { 604L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fefc2560-2194-4aa7-acb8-8259be41e793", "mock604", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4128) },
                    { 605L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "942932fe-3ec8-48a4-b459-905b07e299dc", "mock605", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4138) },
                    { 606L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "953197b6-7419-42b2-a578-ae6cae235447", "mock606", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4149) },
                    { 607L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "00cf36d5-83f7-4d0f-a525-bcf2e924cb3b", "mock607", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4159) },
                    { 608L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "17f346ee-6107-445d-b922-79621c11e452", "mock608", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4208) },
                    { 609L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "145dbccf-34f3-4332-8901-bc5e086676c9", "mock609", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4219) },
                    { 610L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f1ea39a7-bb96-4ea2-a240-589252ed9eb1", "mock610", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4229) },
                    { 611L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7feb50a0-a86a-4797-9003-a2cd9d8bf034", "mock611", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4240) },
                    { 612L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2d2e63cb-1f7f-4025-a847-423b8c84b69d", "mock612", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4250) },
                    { 613L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a6561036-6591-4880-8a40-6efa8be9bcf1", "mock613", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4260) },
                    { 614L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3576b595-9388-44ba-9e73-75fffe69ca41", "mock614", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4270) },
                    { 615L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e64f58cd-2bde-4551-a93e-89f6c83ec4f0", "mock615", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4281) },
                    { 616L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5be86338-2924-4333-96d5-37b794fbe5ae", "mock616", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4291) },
                    { 617L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7bd3ca55-944b-4006-8899-64c5ca60be6b", "mock617", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4301) },
                    { 618L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "328653b7-b954-4b71-be84-3ffacdf495b5", "mock618", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4311) },
                    { 619L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f5a848d1-4f91-41c3-a8ce-a9f5e75f1ec6", "mock619", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4322) },
                    { 620L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f80bde8f-dfaa-486e-9fac-61c3a1b9c6e9", "mock620", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4371) },
                    { 621L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a6e5ac7b-dfe5-401d-a1be-65037a371196", "mock621", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4382) },
                    { 622L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6a75af39-9fde-4cb7-8456-96b01cd84fde", "mock622", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4392) },
                    { 623L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "12a19f47-42fa-41bc-a836-0fc3595d7bf4", "mock623", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4402) },
                    { 624L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eb1919c7-05fb-4218-b731-c0eb67809999", "mock624", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4413) },
                    { 625L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e19225f6-09a9-46ec-bf7e-901c69ce9e0e", "mock625", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4423) },
                    { 626L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2003904e-3e2a-47b8-880b-8d2986fb5176", "mock626", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4433) },
                    { 627L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "484a4c48-30a4-48e4-bd68-1834fe1dafce", "mock627", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4444) },
                    { 628L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "40e9b98e-8aed-4e9e-bedf-7e7499bb4820", "mock628", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4454) },
                    { 629L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b399438d-bbd8-4f18-bbd8-22226a0ab8bf", "mock629", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4464) },
                    { 630L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5358bb27-9a24-46bc-b55f-c1ffcb0cbbb7", "mock630", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4474) },
                    { 631L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8db691b2-4036-4473-b094-11139ecdc0f0", "mock631", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4485) },
                    { 632L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "99bdf280-83f1-4ee7-b7d6-e632ffd59891", "mock632", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4555) },
                    { 633L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2169e7c6-5348-4f6e-83af-e4a52d9b4a1b", "mock633", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4566) },
                    { 634L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ceead0df-f549-4471-baaa-5d4578699a69", "mock634", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4576) },
                    { 635L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "350c0881-f3c8-4c4e-aca0-c0a9e984a28f", "mock635", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4587) },
                    { 636L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "72aa1b90-7a0c-4d9d-bc15-893f26bc9c67", "mock636", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4597) },
                    { 637L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0e737bf7-7f56-4f95-968c-15750204f911", "mock637", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4607) },
                    { 638L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ce15f7d4-0b05-43aa-aff3-f4d51220ad86", "mock638", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4617) },
                    { 639L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f06f054d-7047-4787-af1f-04de42fc3887", "mock639", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4628) },
                    { 640L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6adcc7fb-4901-4ff9-aec9-206c01c13aa3", "mock640", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4638) },
                    { 641L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0e8275e8-2b49-4031-a3b2-7a0bfdde12b8", "mock641", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4648) },
                    { 642L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2b3d5e93-f18f-4c69-af34-206fc9d4b610", "mock642", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4658) },
                    { 643L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "89e34b37-32a4-4e21-b85c-00f412b50d80", "mock643", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4669) },
                    { 644L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a46c9b6f-9779-4ee1-bdfc-c751beb0ae3c", "mock644", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4699) },
                    { 645L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "806c53ca-c14e-4865-8022-3bd7db2e6f52", "mock645", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4710) },
                    { 646L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "550f0128-8fa2-4d15-82b2-07b8a6d4acf1", "mock646", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4720) },
                    { 647L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d2ee1287-d673-452d-9825-d5e56165f36a", "mock647", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4731) },
                    { 648L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4a9be569-7c0d-4566-9d8e-7140fdf35ae5", "mock648", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4741) },
                    { 649L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7179af5d-3a4b-4349-b63d-a06703d696ca", "mock649", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4751) },
                    { 650L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1f7abf0d-e050-4a9a-a054-798bfad84fef", "mock650", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4761) },
                    { 651L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cef1a464-b888-4536-908d-8c8b6bc7a33a", "mock651", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4772) },
                    { 652L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6a075255-1380-4b66-a306-1023a28f66d0", "mock652", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4782) },
                    { 653L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d0444cca-9619-4af6-a31e-ae31d2d48c59", "mock653", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4792) },
                    { 654L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c88db845-73b7-4a06-85f3-1ee6f679a204", "mock654", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4803) },
                    { 655L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9ee8b900-1e82-40e4-9661-0b82f8e25f8c", "mock655", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4813) },
                    { 656L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8f59f911-d51c-43ef-82ed-1d9489b638ab", "mock656", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4900) },
                    { 657L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "57a85a8f-a5c3-44fa-a627-90500c827039", "mock657", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4911) },
                    { 658L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "02d78555-898b-4b26-8313-3f5cba768e85", "mock658", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4921) },
                    { 659L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "07f9c796-3ffa-4deb-b0a9-4b14e5134f40", "mock659", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4931) },
                    { 660L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0431d2c7-8dee-453e-a127-06bf51e0d329", "mock660", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4941) },
                    { 661L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6859df9a-8399-453f-aa9c-8f1b1acb45f7", "mock661", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4951) },
                    { 662L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b7ecfafc-a995-40ae-a9a7-591841c8e0a3", "mock662", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4962) },
                    { 663L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b447aa77-abf8-4d7b-9a32-1b208a867169", "mock663", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4972) },
                    { 664L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7d0f49b1-d92a-4b9a-aff5-e5eaab90d476", "mock664", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4981) },
                    { 665L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7e8eb859-80e2-488e-bb1b-27a6ce076c3b", "mock665", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(4992) },
                    { 666L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fd1738eb-0366-4174-96ac-29c3a7bb57cd", "mock666", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5002) },
                    { 667L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "79f421d2-0156-4418-b0f6-596823c73b35", "mock667", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5012) },
                    { 668L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "29af2f9b-0a06-48ae-bb94-3a2ea2ab217a", "mock668", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5078) },
                    { 669L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1af8465a-7e5b-4acb-bb5c-68e164713538", "mock669", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5089) },
                    { 670L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "008bdea7-d961-41d0-a2c1-b2b1f85fa77c", "mock670", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5099) },
                    { 671L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "75686d3a-9473-44c8-80a7-e9e81a87acd5", "mock671", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5110) },
                    { 672L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "64cb9f2f-7df3-4769-a535-b51f7a2af626", "mock672", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5120) },
                    { 673L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0a736f64-9ae3-482f-8cee-bbbc2957241c", "mock673", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5130) },
                    { 674L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c6a1102e-af92-4ed8-83ec-bbbd40538707", "mock674", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5140) },
                    { 675L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e948e955-bc14-4e86-b358-c38316eecf66", "mock675", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5151) },
                    { 676L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2f289156-306c-4c9f-a05e-4748f53f0f23", "mock676", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5161) },
                    { 677L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2249efeb-7005-45ce-818c-2869aa58699f", "mock677", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5171) },
                    { 678L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2e459c9d-d8c1-4a0c-9d63-6c7c58afac3a", "mock678", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5181) },
                    { 679L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9210e718-ac28-41dc-b3bc-6f1d7612f7a8", "mock679", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5191) },
                    { 680L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "23320538-d44f-4309-9a17-8d381dca9c5e", "mock680", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5239) },
                    { 681L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "39c10a74-98a2-45fa-98bf-c1762efbeea3", "mock681", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5250) },
                    { 682L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4ad65672-f435-4e5b-afd0-a18a3d95a97e", "mock682", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5260) },
                    { 683L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "473726da-598b-4a23-98ac-040916423742", "mock683", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5271) },
                    { 684L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7d2554c6-3c24-4ae5-bf39-8c5715242a33", "mock684", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5281) },
                    { 685L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5a59ec36-250e-48bc-a968-ad5cc3eeb162", "mock685", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5291) },
                    { 686L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f1f038c5-653d-4d14-a136-c422771f95a0", "mock686", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5301) },
                    { 687L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "47eb0517-8d02-41f3-a914-46fd37d56f38", "mock687", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5311) },
                    { 688L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "70f0a6e0-2970-4897-8bf7-0ed6c83c9991", "mock688", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5321) },
                    { 689L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "56f5600d-06f2-4868-af0b-01cf0d5cbb47", "mock689", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5332) },
                    { 690L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5c04447a-6975-4a74-868b-6ca9790587b7", "mock690", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5342) },
                    { 691L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b34a6678-a9e2-4914-9ae3-02831a0211f4", "mock691", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5352) },
                    { 692L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eb3c9200-2250-432c-853c-62b223de9180", "mock692", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5399) },
                    { 693L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "751e68e3-0283-4998-9361-5d583d49fed3", "mock693", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5410) },
                    { 694L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "13441da2-50e5-40b1-9b41-242e4852da52", "mock694", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5420) },
                    { 695L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "52a5c4ae-886e-4154-aa31-38b621c4a896", "mock695", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5430) },
                    { 696L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "de559ae0-7cc7-412f-b26f-e7fe3f3de0a8", "mock696", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5441) },
                    { 697L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "407bd00f-8cb5-4017-af77-6c9f1d7f042d", "mock697", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5451) },
                    { 698L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1c4c7d36-60a3-4e05-89ab-12ca9382fdab", "mock698", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5461) },
                    { 699L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f5b60863-bcca-4682-b002-16994c9fb937", "mock699", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5471) },
                    { 700L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "347ed863-0ad0-4007-8164-c9109f8ed991", "mock700", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5482) },
                    { 701L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "07b324eb-ee5a-487a-bee0-9e3454cb2220", "mock701", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5492) },
                    { 702L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4ea67021-8e4c-486d-b505-3ee03ed17fa7", "mock702", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5502) },
                    { 703L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "17b04183-1ee2-4187-8c1a-c6b28b82ae9a", "mock703", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5512) },
                    { 704L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e75600e0-f6f3-432f-b640-ba5c8f28594b", "mock704", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5561) },
                    { 705L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b2a02bdf-a6a2-47b8-8430-550cf94a802c", "mock705", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5572) },
                    { 706L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8f22ab81-b5c1-4c3c-8b9f-5ffd31560b51", "mock706", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5583) },
                    { 707L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e88d3d01-a732-488f-941f-1592ebf81a99", "mock707", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5593) },
                    { 708L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d3d6d6cb-ffaa-4fbd-919d-67719b15c0bb", "mock708", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5603) },
                    { 709L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1ca355af-9cc7-4532-8223-77ce3f7addf1", "mock709", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5613) },
                    { 710L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1d1de2cb-f883-451e-97fa-810102ed43d7", "mock710", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5624) },
                    { 711L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1cdf2264-a93e-4b88-a356-d5b5abf7c08e", "mock711", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5634) },
                    { 712L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ce12b4a1-dc04-4cc0-ae5b-4ae16f4859c3", "mock712", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5644) },
                    { 713L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "26846c39-51bf-4880-8fe7-891197a50eb8", "mock713", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5655) },
                    { 714L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c0f6e082-ef0d-4e9f-b906-b274008924ea", "mock714", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5665) },
                    { 715L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "55e2f0df-9844-4348-9aec-9a45f767cf4c", "mock715", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5675) },
                    { 716L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "eb84bed8-754b-4ffc-865a-e861575a1896", "mock716", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5721) },
                    { 717L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ad8952a6-209d-4f08-8979-767b56c79ca5", "mock717", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5732) },
                    { 718L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "80ed1493-30d8-4f8c-9e3c-f1eff43bfa5e", "mock718", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5743) },
                    { 719L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "721852a2-f1ca-4f2c-b9a9-52a55834b0f5", "mock719", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5753) },
                    { 720L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fc2c49ee-9922-400f-b550-512e68df553e", "mock720", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5763) },
                    { 721L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9ae3ecc4-d47b-49fb-a001-470f30d6bee6", "mock721", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5774) },
                    { 722L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "03d5c93f-6344-43ea-afbe-28970834ed41", "mock722", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5784) },
                    { 723L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1166ba1d-cf1a-40bc-aaf0-c35b5b9698d8", "mock723", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5794) },
                    { 724L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d6ede436-5d84-4e02-8449-f01b053e67bd", "mock724", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5804) },
                    { 725L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "698799c5-cd83-4849-8216-e6358a786d11", "mock725", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5815) },
                    { 726L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1659819b-6dbd-4251-bca3-e5d8a6dfafd1", "mock726", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5825) },
                    { 727L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "367c16c5-fe17-4327-b5ad-e07d071d8ae6", "mock727", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5835) },
                    { 728L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2c3c71de-c4be-4da8-bec9-121f6efce3a3", "mock728", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5907) },
                    { 729L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d1ae62cd-9e71-4ee8-988f-455d1d51f610", "mock729", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5918) },
                    { 730L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e9642258-2a64-4a4f-90a1-1611d87380c9", "mock730", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5928) },
                    { 731L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dc515814-dd3b-4395-ad99-6d9df80df523", "mock731", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5938) },
                    { 732L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "20f4a557-e3b4-401b-9128-b8533c731e85", "mock732", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5949) },
                    { 733L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6e9fac81-5162-48f4-95af-8d60fd019207", "mock733", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5959) },
                    { 734L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5a58015f-32db-4deb-a883-7a54f79998cb", "mock734", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5969) },
                    { 735L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bfe76576-c898-4620-942a-a4cc4673f039", "mock735", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5979) },
                    { 736L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "56fed7cb-c9c3-461e-9f22-790f7928b1eb", "mock736", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(5990) },
                    { 737L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8641345a-10a4-472d-a9d3-24501f19cc1e", "mock737", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6000) },
                    { 738L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e7b25b86-13fe-4239-a6fb-2cc691ce8214", "mock738", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6010) },
                    { 739L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "85e7c373-842a-45e7-a29b-207299a40539", "mock739", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6020) },
                    { 740L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "87857d89-db51-4dac-9d90-865606d39e83", "mock740", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6052) },
                    { 741L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3d427721-489c-474a-9205-2eaa242a141e", "mock741", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6063) },
                    { 742L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0bd51b03-7878-4c61-8e06-516336e561bf", "mock742", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6074) },
                    { 743L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5c71062d-10db-46b3-b9de-23f6c70f098f", "mock743", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6084) },
                    { 744L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d888f38d-d457-472e-abdd-00b4d83ad1fe", "mock744", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6094) },
                    { 745L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "edef60e4-9d8b-4977-9256-b5262d565c48", "mock745", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6104) },
                    { 746L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "05893a89-a5a8-4ac0-a1f8-7c7a6990485b", "mock746", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6115) },
                    { 747L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "15d899b3-08ef-4c2b-a3aa-7d597c0796f4", "mock747", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6125) },
                    { 748L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c15c4776-daee-4cd3-969d-139207cbeb95", "mock748", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6135) },
                    { 749L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7a9bb9b0-9e0f-42a0-b05e-c6ed35fdbc6c", "mock749", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6145) },
                    { 750L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3aced5b1-bb6d-437b-9510-e1d14dad2850", "mock750", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6156) },
                    { 751L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3c54191b-49d7-4cc2-8a10-ea2af962b9d6", "mock751", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6165) },
                    { 752L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4c39ea93-9319-42e7-a7c7-ef410a9c1e09", "mock752", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6231) },
                    { 753L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5529527e-30da-428c-b9d7-42e848e73fd2", "mock753", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6241) },
                    { 754L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b0b15039-e55c-4a19-a254-da3cca4bc6a9", "mock754", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6251) },
                    { 755L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0f63852b-ba37-45f7-8581-79ca96d97c0c", "mock755", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6261) },
                    { 756L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f11ddf4d-14b3-4d0b-b7d0-c8a62349403e", "mock756", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6272) },
                    { 757L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c9870ef8-ca27-4b79-abb3-403c461b8ccf", "mock757", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6282) },
                    { 758L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ccc3eaec-aa1a-470c-b52d-0e9bd87f510f", "mock758", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6292) },
                    { 759L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "433cd855-d693-4b7e-9181-87ba2f4d4104", "mock759", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6302) },
                    { 760L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "867f1fd5-eff7-4cc5-9a60-08a136928bb4", "mock760", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6313) },
                    { 761L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b05c358a-636f-497b-b591-2fa21803a1a3", "mock761", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6323) },
                    { 762L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "767edca5-3d13-4a20-96af-ae070e02c5c6", "mock762", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6333) },
                    { 763L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1c39ede2-2fa5-458a-9552-c1900aa367b5", "mock763", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6343) },
                    { 764L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "11a0e3fe-6266-445f-a630-1da8c0ca24d8", "mock764", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6392) },
                    { 765L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fcddd717-9f84-4ae9-97f4-ba14167e0ed8", "mock765", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6403) },
                    { 766L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f946af1f-f162-4928-b659-a4f36df271ab", "mock766", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6413) },
                    { 767L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b7ad8321-20a6-4677-8511-ecb8fdcf8040", "mock767", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6423) },
                    { 768L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "52ccad50-0111-4ef4-8207-24b70e945d13", "mock768", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6434) },
                    { 769L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b99709b2-b984-4064-a695-ff9d9774f2d8", "mock769", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6444) },
                    { 770L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2bbb034c-32c1-4ce2-af3e-a80575559cfa", "mock770", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6454) },
                    { 771L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bc09b384-ae80-4d6c-b8a7-540e2f0efea3", "mock771", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6464) },
                    { 772L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0b9f9d8b-b794-4efe-a7d5-56a70b45a7a8", "mock772", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6474) },
                    { 773L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "87fa18d8-e7b8-4091-aab4-4e0eb638aed1", "mock773", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6485) },
                    { 774L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5b3ed225-bf65-4005-a223-366dbfe79c4f", "mock774", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6495) },
                    { 775L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b553bb1d-d6fc-43a0-a383-681728e2b7c3", "mock775", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6505) },
                    { 776L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "03435c3a-c0b3-4550-bab5-e26443cdaed2", "mock776", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6554) },
                    { 777L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d3c60d2b-1402-4ffe-b0f4-ab8d83e2871e", "mock777", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6565) },
                    { 778L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a769a524-ac06-4b16-9eab-c10fad4c894e", "mock778", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6575) },
                    { 779L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e02e7aeb-dbb2-4f33-ade3-fb3682aa7b35", "mock779", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6586) },
                    { 780L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f91f10cc-5f4e-4b0d-ad04-be2048f90db9", "mock780", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6596) },
                    { 781L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "60431bc4-f60d-4957-9f6f-b84cd125b1bb", "mock781", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6606) },
                    { 782L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "25a1b08f-10c3-42bc-9da6-6a744712da61", "mock782", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6616) },
                    { 783L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4dbc02fc-bc6d-4120-b3c2-e54416f8ba06", "mock783", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6627) },
                    { 784L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ca50d9f4-f736-48b2-bb22-627802f9f975", "mock784", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6637) },
                    { 785L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4e63a046-a6ed-44e5-804b-f09b4d40fe0a", "mock785", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6647) },
                    { 786L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "158f6971-9428-4217-a8ce-f540ffd51861", "mock786", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6658) },
                    { 787L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b063f86b-3dbc-45b4-a2ed-40b24f178dc6", "mock787", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6668) },
                    { 788L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0ed1db13-30ea-4fab-aae1-d8cd34216dd0", "mock788", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6716) },
                    { 789L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "12cdecc7-9d9a-4256-8b71-de817f41e4c6", "mock789", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6727) },
                    { 790L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a549967c-66b7-4d8c-a39b-7d0a16e2b61a", "mock790", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6737) },
                    { 791L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8a123c34-c9a3-40e3-813c-1b9e51e89eae", "mock791", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6747) },
                    { 792L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e314c6a9-3dd3-49aa-98e8-d9983430bd27", "mock792", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6757) },
                    { 793L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "56b55f1d-72fd-406c-bf82-9815abf81d79", "mock793", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6768) },
                    { 794L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0e2d948f-d9dd-4971-8d6d-ad5ef3b8ef7b", "mock794", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6778) },
                    { 795L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6b6944d1-cfb8-46d1-bc36-624513f73ffc", "mock795", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6788) },
                    { 796L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a171c3bb-981e-4bcf-8089-cd9f9476c0ed", "mock796", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6798) },
                    { 797L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "999fedac-9547-4d56-85ae-90797142a90c", "mock797", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6809) },
                    { 798L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "aa44aec2-e708-4ab4-a461-b89cfe993363", "mock798", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6819) },
                    { 799L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "77fdff23-84cb-4a85-9bd5-0ebc49f10b03", "mock799", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6829) },
                    { 800L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0033ab9c-f94a-49af-b6db-b836f53f2dd6", "mock800", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6881) },
                    { 801L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "96d7efe2-bb10-446e-b8a1-83d99def8672", "mock801", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6892) },
                    { 802L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "176a6b2e-29fb-49f0-a862-4f727ccaa2da", "mock802", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6902) },
                    { 803L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f9867d80-0a90-4f44-a14e-a26960405023", "mock803", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6912) },
                    { 804L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7901e5e6-4490-43a3-8c42-0c169d6cddc4", "mock804", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6922) },
                    { 805L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "62ba3f70-e4c6-4078-8db0-d4cac6ca6639", "mock805", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6933) },
                    { 806L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "93207f01-4dc2-485f-8a88-b30c4255bfa7", "mock806", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6943) },
                    { 807L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8349a78b-2a15-4105-ae50-2b6d64d4abe7", "mock807", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6953) },
                    { 808L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c040f15a-6eb6-487f-a725-213c9396e586", "mock808", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6963) },
                    { 809L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "31d5470b-04d8-417c-92ed-4f999af842ee", "mock809", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6973) },
                    { 810L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f8fff676-f0b6-4ea6-aa70-9550465a201f", "mock810", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6984) },
                    { 811L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dca7a170-7755-4fd4-b2cb-8eacb29ebac2", "mock811", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(6994) },
                    { 812L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "67750ba7-49da-4c6e-8dbd-2cdb1c66951c", "mock812", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7065) },
                    { 813L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "39c5be02-2235-4799-84c7-d848d145b76a", "mock813", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7076) },
                    { 814L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a8f6e517-ab7b-485c-9b18-e640351bce4a", "mock814", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7087) },
                    { 815L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b4bddf9e-47ac-44ac-8400-3d0376640540", "mock815", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7097) },
                    { 816L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "110c5964-9396-47b1-9376-96a7c9dfbbbb", "mock816", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7107) },
                    { 817L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "db29606e-0810-496e-b5f3-1a215f4a4a07", "mock817", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7117) },
                    { 818L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c1fc936a-f01a-4b8c-8da4-3e035a5423fa", "mock818", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7127) },
                    { 819L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd82deec-1dff-4f4f-a4e4-fb9aa8183ef1", "mock819", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7138) },
                    { 820L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5ac7afdb-7542-4d5b-9f47-171672c4358b", "mock820", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7148) },
                    { 821L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d8532c36-cf6d-4be3-a766-1fe85a946081", "mock821", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7158) },
                    { 822L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a16d33f8-8ac8-4831-b02d-0569e93744eb", "mock822", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7168) },
                    { 823L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "519e7ceb-2e06-4bfe-b1c7-1d17d343f36f", "mock823", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7178) },
                    { 824L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cea4a412-1251-4d14-88c6-0b50b5494e33", "mock824", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7189) },
                    { 825L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e041e480-1f87-4df8-9010-97b04e36ed30", "mock825", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7221) },
                    { 826L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "defdf269-e999-4b23-b97f-27e34c04fd50", "mock826", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7232) },
                    { 827L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d2844936-a709-414b-a3fa-40bba2355724", "mock827", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7242) },
                    { 828L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "51a11135-e5fe-46bb-87af-1bd500cb13d0", "mock828", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7252) },
                    { 829L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c5737c9d-7b4f-4028-8b05-8aba1bac24ba", "mock829", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7262) },
                    { 830L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dde9e46d-e981-410e-8aaa-f1d0c09f3d8d", "mock830", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7273) },
                    { 831L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4b07b7b7-d845-49e6-ace0-19c091c7bb21", "mock831", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7283) },
                    { 832L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cb70d756-ad58-4bc5-ba8e-4f40e6da8d8b", "mock832", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7293) },
                    { 833L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "db94100e-dee5-43ae-9a20-82dcc62c310a", "mock833", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7303) },
                    { 834L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "aaf3973c-3e75-486e-83b7-5f740eb7948d", "mock834", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7314) },
                    { 835L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "09d70944-aae1-4331-be24-1a860e27b62f", "mock835", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7324) },
                    { 836L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d8f21aad-cb2f-4f15-9f86-c01c4040d462", "mock836", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7416) },
                    { 837L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7da95261-6571-4e9d-803a-a515a2e122ab", "mock837", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7427) },
                    { 838L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "10912321-cb4d-471b-b1e5-f17db95872bc", "mock838", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7438) },
                    { 839L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3fc7693f-01e0-44b9-b457-c597fc177ad9", "mock839", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7448) },
                    { 840L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5e8f47f3-6499-43cb-827f-08227dec040f", "mock840", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7458) },
                    { 841L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "168e3299-e9eb-43af-a0f4-925969adb6d5", "mock841", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7468) },
                    { 842L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e3f2e36d-a37b-4f87-b68b-901c2b7398a1", "mock842", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7479) },
                    { 843L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a6e37007-f7bd-48ca-860a-c7736e3bad80", "mock843", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7489) },
                    { 844L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d45338d8-fe2d-47fe-be23-43625813c3f4", "mock844", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7499) },
                    { 845L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e859693f-86d0-4aff-9acc-9381153b1f7e", "mock845", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7509) },
                    { 846L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4cf4ee2d-1993-429c-842b-2d627fc4439e", "mock846", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7520) },
                    { 847L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1b018250-dfa4-4711-88cd-10f358c0d3a1", "mock847", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7530) },
                    { 848L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fde4f0f3-80e9-4248-a762-25f786d67583", "mock848", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7594) },
                    { 849L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "90a4206e-f774-4873-aac6-185159694881", "mock849", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7605) },
                    { 850L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d105b5fc-1196-430e-b2b7-d67de6825ec9", "mock850", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7615) },
                    { 851L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "23eca98e-9054-428d-ab82-991e4bc2094e", "mock851", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7626) },
                    { 852L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ff624571-0285-4aba-aa16-0a1cc5bd02e8", "mock852", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7636) },
                    { 853L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b670eee0-b5b9-43c9-9b80-98f552d70c8a", "mock853", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7646) },
                    { 854L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ab904726-1171-46a7-8724-bc3aa43e650c", "mock854", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7656) },
                    { 855L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ea6e5c76-cceb-41ee-b269-7a932ecb870f", "mock855", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7667) },
                    { 856L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "37a6cdae-cf48-46b3-98e9-c8c537108126", "mock856", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7677) },
                    { 857L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a01aff6b-2dd6-4076-9cb4-40d41eaf218d", "mock857", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7687) },
                    { 858L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "de6081ea-c8b2-4148-adbf-1956e81a34f4", "mock858", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7697) },
                    { 859L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e2a20735-788b-4868-a679-3633a09114b2", "mock859", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7708) },
                    { 860L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c931cf18-93b9-4472-83e0-6010dbebc7e9", "mock860", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7757) },
                    { 861L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1cfb09dc-66c5-4a24-9a26-0e48307a8500", "mock861", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7768) },
                    { 862L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd1b3e97-73da-4bda-aaef-d9f2af5c1366", "mock862", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7778) },
                    { 863L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "63adc288-34fe-4e6f-849e-6671084ad846", "mock863", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7788) },
                    { 864L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6db78c37-e96e-482b-8516-8c0fba35fd9d", "mock864", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7799) },
                    { 865L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f7545ed6-3010-4418-b20f-c7cd10c551b6", "mock865", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7809) },
                    { 866L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a2a63908-ce20-4595-97e8-974917f3cc2f", "mock866", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7819) },
                    { 867L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6b175cae-c259-4879-a47d-7bf97ae1fdf3", "mock867", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7829) },
                    { 868L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "518a15d6-dd33-49da-88ef-436f1f11f9b0", "mock868", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7840) },
                    { 869L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8242d51b-f420-4049-98df-fd84bc1a7cef", "mock869", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7850) },
                    { 870L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "27ce6680-cbf4-4ebf-8c63-30c1bf0847eb", "mock870", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7860) },
                    { 871L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd1e6875-0bc1-4d37-8e0e-59ee8a9f4018", "mock871", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7870) },
                    { 872L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0b1c747f-93ac-46a4-ae86-b753115bcc61", "mock872", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7918) },
                    { 873L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "42c8b17c-cbb9-4816-a5f6-b57d3c7eaf29", "mock873", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7929) },
                    { 874L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "efbe7568-c253-4240-bccd-6e746bae3dc1", "mock874", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7939) },
                    { 875L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "56991c7c-9b5a-4e17-901b-356d587f8c02", "mock875", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7949) },
                    { 876L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "98b374da-66e2-4e68-8315-53a7bc7e4157", "mock876", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7960) },
                    { 877L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4cc67008-db8e-46f7-8aa4-532fe0bebd1a", "mock877", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7970) },
                    { 878L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "36302430-e965-4a2c-b4a2-c686fda9f5c3", "mock878", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7980) },
                    { 879L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e97c9015-d3dc-4b2c-9992-1106927770c1", "mock879", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(7990) },
                    { 880L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bfddb1b6-42c4-4a8a-88f3-bac3c77affcc", "mock880", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8001) },
                    { 881L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cc3c97de-23ed-4191-a5f1-3578f45a4a20", "mock881", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8011) },
                    { 882L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c8211ca6-a9a7-4591-b5fd-7277239d7df0", "mock882", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8021) },
                    { 883L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "571fbdf0-f388-40a9-96d4-f5ae342aa8f9", "mock883", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8032) },
                    { 884L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9885d22b-e0eb-4bb9-9013-c02a96bdbf84", "mock884", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8080) },
                    { 885L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e3dfbeba-5592-4ddf-9330-10fa06f0a7b9", "mock885", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8091) },
                    { 886L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cde5e180-0554-44cd-9235-c84fb32de63b", "mock886", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8102) },
                    { 887L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "589410a5-b0d1-44f0-b641-fd99468ebd78", "mock887", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8112) },
                    { 888L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f9e49cbf-70e5-4307-b685-4af04b38ff48", "mock888", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8122) },
                    { 889L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "90114d3e-3dfb-4fea-933e-bb86f747dcc2", "mock889", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8132) },
                    { 890L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "c18dabea-86cf-4033-9ecf-6a31fe747c9e", "mock890", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8143) },
                    { 891L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "df4b884c-0412-4867-bf6a-68fb4efde322", "mock891", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8153) },
                    { 892L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3c333ad9-8a0b-499b-87a8-243f617188e4", "mock892", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8163) },
                    { 893L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0eff6e50-40ba-433d-abbb-277733181272", "mock893", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8173) },
                    { 894L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "440bdc62-a644-4c07-a2d8-5b00de1d45a5", "mock894", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8184) },
                    { 895L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7dd89190-68f1-41c0-b488-e2735229d1ee", "mock895", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8194) },
                    { 896L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "afb11d86-185f-4197-adb9-2b9ddc53c41f", "mock896", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8242) },
                    { 897L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "16a580b5-317b-4a37-bf3a-1308b3ca6df9", "mock897", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8253) },
                    { 898L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "382add41-12d0-4831-82f8-89ed8f86449b", "mock898", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8263) },
                    { 899L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "68326fbc-ff0e-4fd0-88b6-e7777e8ed360", "mock899", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8274) },
                    { 900L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "503153b3-fcd1-420f-a263-f67b632bb88f", "mock900", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8284) },
                    { 901L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "64bdd1b9-359c-4318-a071-e4c2188205eb", "mock901", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8294) },
                    { 902L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f15842b9-e2d3-46fa-b5fa-e8392d80d683", "mock902", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8304) },
                    { 903L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "449cabf8-dc8b-46b9-a901-5d0f194ab7b9", "mock903", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8315) },
                    { 904L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9f87d19e-ed94-4bf0-bf4d-81942544d66d", "mock904", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8325) },
                    { 905L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "52cfe2be-479b-424a-b478-232071af9a35", "mock905", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8335) },
                    { 906L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "144bc5d7-be8e-45eb-be83-abf4111dd2c0", "mock906", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8345) },
                    { 907L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "14d937e0-60e5-4feb-92f7-32c976f61ba8", "mock907", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8356) },
                    { 908L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8903ff59-68f4-40e0-b647-31e48865a90e", "mock908", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8366) },
                    { 909L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "df31733e-6514-4cf0-9514-e0d5ed4747cb", "mock909", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8437) },
                    { 910L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7426e464-7964-46be-83ff-718a337de355", "mock910", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8447) },
                    { 911L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4dc9c394-98a5-4e08-994b-cda8fdfdb6ea", "mock911", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8457) },
                    { 912L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6d032cbb-3497-49f6-90d0-15f4b56211eb", "mock912", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8467) },
                    { 913L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6410f5ca-e048-4ea2-8d69-f8e167252127", "mock913", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8478) },
                    { 914L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fdbaa3b8-aa38-48b3-9798-daa0828d716a", "mock914", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8488) },
                    { 915L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "44fec292-0f72-481e-9468-8b142d1a19ce", "mock915", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8498) },
                    { 916L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7401c275-3825-4d39-b2c3-7aabaa5c01a8", "mock916", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8508) },
                    { 917L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9314236d-fae9-4c80-aab4-d54b9a975d2a", "mock917", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8519) },
                    { 918L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "483e29ea-566e-47d3-8288-5c0cd26d17bc", "mock918", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8529) },
                    { 919L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f1a39df0-63ee-4163-85d1-ae4453cf9268", "mock919", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8539) },
                    { 920L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "969c3647-caa8-4b7c-aa63-521648266033", "mock920", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8549) },
                    { 921L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f6a62768-9843-4d98-86c8-aa3d691642f7", "mock921", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8582) },
                    { 922L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "28029f17-9511-4f4d-8830-0be5b79b882f", "mock922", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8592) },
                    { 923L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7dda4e52-50de-45ee-acaa-e42c6a698714", "mock923", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8602) },
                    { 924L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ae7fd303-bc35-4cd6-88b0-875cc3dc66f8", "mock924", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8613) },
                    { 925L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "35c4d677-ae39-4236-b753-32211ec58514", "mock925", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8623) },
                    { 926L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8f7736e3-5c33-461e-a215-ac745d2d3567", "mock926", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8633) },
                    { 927L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6105abf2-16b3-46b5-8638-9aea865503c4", "mock927", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8643) },
                    { 928L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d486040e-9390-4080-9704-5afc16461ee3", "mock928", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8654) },
                    { 929L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "bb8ea499-dc48-4e05-8d30-a671c838f658", "mock929", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8664) },
                    { 930L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "328ba309-aedd-4b6b-be08-e8a35b8b3ca1", "mock930", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8674) },
                    { 931L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6d66a10a-66aa-4e08-ba56-8cc23bf7f71c", "mock931", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8684) },
                    { 932L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "36d7aee1-f78a-49b2-aee9-dee430c34d45", "mock932", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8773) },
                    { 933L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9dcdf318-8798-4a98-9d4b-bbf281f33b81", "mock933", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8785) },
                    { 934L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "70981aa4-0bdf-4704-a80d-7b2946f57473", "mock934", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8795) },
                    { 935L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "935ffd07-0812-458b-9639-35b6a9675298", "mock935", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8806) },
                    { 936L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "da81293a-4f0c-490b-89e3-6a821774da51", "mock936", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8816) },
                    { 937L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "74777db2-d1c2-4255-809a-220e78aacd21", "mock937", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8826) },
                    { 938L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "88c207db-6a1a-4f17-9123-1e1b486fb80d", "mock938", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8836) },
                    { 939L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7c86a7f4-0255-4a93-bcf5-1559fdb11a07", "mock939", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8847) },
                    { 940L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "03a69b59-8dcd-4133-a82e-35abbb1a5cfe", "mock940", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8857) },
                    { 941L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3291442d-fe7e-49d5-9f48-b12265a06452", "mock941", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8867) },
                    { 942L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "def099de-2651-4ccc-aab4-e1328296747d", "mock942", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8877) },
                    { 943L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "63723891-69f2-4ffc-8a8e-4522647dff62", "mock943", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8888) },
                    { 944L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e5f4ec1a-3b20-41a6-87c3-9fac70fb5e42", "mock944", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8957) },
                    { 945L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "de021cb4-d936-4671-8eea-2a394ed1358d", "mock945", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8969) },
                    { 946L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0d2e0485-4b19-4c38-9e4c-d300c2dc4d55", "mock946", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8979) },
                    { 947L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "6e1f976f-eda1-456b-8ed2-26dc645480b4", "mock947", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8989) },
                    { 948L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "da062fca-4bea-4135-9e74-54efa37a8760", "mock948", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(8999) },
                    { 949L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "488e9a5d-6b61-4993-88a8-94f5c7fd5079", "mock949", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9010) },
                    { 950L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "95ffca7d-e725-40cc-b776-1a3cbd968fd4", "mock950", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9020) },
                    { 951L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "3166039f-2876-4704-a696-963a8d6c5c99", "mock951", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9030) },
                    { 952L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a88dd994-f091-466f-a50e-87b8bd461961", "mock952", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9040) },
                    { 953L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "cc7ef8ea-f48c-4dd1-a4c9-7864fb4040e8", "mock953", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9051) },
                    { 954L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1fde42a5-897a-4ec6-a5bd-fcc22892bf85", "mock954", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9061) },
                    { 955L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0df12810-2dc9-405a-a9b9-575241449467", "mock955", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9071) },
                    { 956L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "27b7a3b4-34d2-48a0-80e4-3bbecb9cf529", "mock956", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9118) },
                    { 957L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1d01871d-f667-4680-b28a-cd46a4633e8e", "mock957", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9129) },
                    { 958L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "dd0fd66c-ee65-4b61-b1f1-1d9792efb3ea", "mock958", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9139) },
                    { 959L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1d40b14e-22bc-42b6-842c-965c25404b78", "mock959", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9149) },
                    { 960L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "53679bbb-d38d-45c5-ae0f-f8e08f2b95f8", "mock960", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9160) },
                    { 961L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "205d130a-399e-4915-8a7e-5c62da2dd942", "mock961", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9170) },
                    { 962L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0a81c266-45fa-4e3a-aa38-d58dee48daa7", "mock962", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9180) },
                    { 963L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2ac5f740-208d-431c-adfd-11b80bed85ce", "mock963", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9190) },
                    { 964L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a498fa5a-a8ec-41dd-bcf9-6af4015776c3", "mock964", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9201) },
                    { 965L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "fbe5bf49-0fcd-46fe-8d8a-e453fe9c4dcb", "mock965", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9211) },
                    { 966L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "31f35e4f-df58-4883-b4d5-c9154ec28a97", "mock966", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9221) },
                    { 967L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "ced30886-41de-46f3-a288-29f48f0dca19", "mock967", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9231) },
                    { 968L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "886a256a-35d4-4d56-8b6c-d3e3fc541125", "mock968", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9279) },
                    { 969L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "e4511009-6b6f-4354-b84d-046392b8d6b3", "mock969", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9290) },
                    { 970L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "13690880-604f-4468-931c-070ce8d4aeb2", "mock970", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9300) },
                    { 971L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7dd6409-d442-4c77-a000-39642b715130", "mock971", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9311) },
                    { 972L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "14aa090b-2c99-48fc-94fd-3a314c57555e", "mock972", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9321) },
                    { 973L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "9239cbef-f1e1-4ab0-9f04-4c31466c49e3", "mock973", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9331) },
                    { 974L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f49980a6-e9dd-4331-8fcc-e41ca9486117", "mock974", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9341) },
                    { 975L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "0b8be190-0056-4e2c-9d16-dd29dd4dd222", "mock975", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9352) },
                    { 976L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f6a662b8-077a-4106-9062-ff547dff6526", "mock976", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9362) },
                    { 977L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "05b6019b-9c12-4ff7-a19b-0ec01eb9b8ae", "mock977", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9372) },
                    { 978L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "01435821-fe25-47e5-9c4c-cbcf5b7ca622", "mock978", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9382) },
                    { 979L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a7500c92-8b9f-42cc-922a-766bfc81bddb", "mock979", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9393) },
                    { 980L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "42344906-7f40-45d0-9858-fddc46a954b1", "mock980", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9441) },
                    { 981L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "be8f4083-30a5-4144-8203-b2069db734bc", "mock981", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9452) },
                    { 982L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b3ff9c50-5789-4c5d-9756-0b5b9d4ad2ea", "mock982", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9462) },
                    { 983L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "f753e69e-e562-4d81-b15a-d584ee6c77d5", "mock983", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9472) },
                    { 984L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4464d3d4-54af-492e-8680-aef5d2fe971f", "mock984", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9483) },
                    { 985L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "1af8ea6f-0728-4ef7-a621-208836c0bcb0", "mock985", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9493) },
                    { 986L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d3282008-0804-487d-b997-6c72e4e26026", "mock986", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9503) },
                    { 987L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "d2c1f43c-a59e-4480-911f-800c00fbba96", "mock987", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9513) },
                    { 988L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "11736bec-3d30-4bd7-bd06-28dfca5cf73a", "mock988", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9524) },
                    { 989L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "527d3309-aa3a-44bc-a26d-c50191fa3d6b", "mock989", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9534) },
                    { 990L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8985c1ed-a5b4-40a3-b906-4ca52ca88f21", "mock990", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9544) },
                    { 991L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "33946be5-21b9-4770-b498-f30f5da42ca1", "mock991", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9555) },
                    { 992L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "b5dd3f1d-1b59-4d16-9237-44a8aed5ad4b", "mock992", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9565) },
                    { 993L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "5606d420-2330-478d-8307-4fb761092706", "mock993", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9635) },
                    { 994L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "43a62b3d-c093-40b1-97d8-7e49bc798a75", "mock994", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9646) },
                    { 995L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "7f550460-7194-4f1d-a6ce-6c2b89d002b3", "mock995", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9656) },
                    { 996L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "a552da10-220c-4923-be48-baa2d79adac3", "mock996", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9666) },
                    { 997L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "2e0e5f90-9d9b-48d3-9c68-bf0b1d66fa98", "mock997", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9677) },
                    { 998L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "869ffae3-af9c-419a-9142-0371b2d150dc", "mock998", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9687) },
                    { 999L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "4700392a-2d8f-4428-a53c-73fc76e2bb9c", "mock999", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9697) },
                    { 1000L, 10, null, "MOCK DESCRIPTION", 10000m, "MOCK PRODUCT NAME", "8961f99b-fda4-445a-b0f9-91edebe5ed7c", "mock1000", new DateTime(2024, 4, 29, 14, 51, 39, 887, DateTimeKind.Utc).AddTicks(9707) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductsProductId",
                table: "CartProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsProductId",
                table: "CategoryProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PromoCode",
                table: "Orders",
                column: "PromoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagsTagId",
                table: "ProductTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DealId",
                table: "Products",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Promos");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
