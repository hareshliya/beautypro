using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautyPro.CRM.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "Tbl_Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(unicode: false, maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Config",
                columns: table => new
                {
                    ConfigId = table.Column<int>(nullable: false),
                    AbsentDeductionRatio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PresentAllawancesRatio = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Config", x => x.ConfigId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeAttendance",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(nullable: false),
                    EMPNo = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Shift = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    WorkedHrs = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LateMins = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OT1 = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    MonthId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeAttendance", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeSalarySupport",
                columns: table => new
                {
                    ESSid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPNo = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 25, nullable: false),
                    NoOfPresentDays = table.Column<int>(nullable: false),
                    ChequNo = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    MonthId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeSalarySupport", x => x.ESSid);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Allowances",
                columns: table => new
                {
                    AllowanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Currency = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_SalaryDetail", x => x.AllowanceId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Bank",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Commission",
                columns: table => new
                {
                    CommissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Currency = table.Column<string>(maxLength: 20, nullable: false),
                    Ratio = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_CommissionDetail", x => x.CommissionId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Deduction",
                columns: table => new
                {
                    DeductionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Currency = table.Column<string>(maxLength: 20, nullable: false),
                    Ratio = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_DeductionDetail", x => x.DeductionId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_LeaveType",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 150, nullable: false),
                    AllowDate = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_LeaveType", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Nationality",
                columns: table => new
                {
                    NationalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 10, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_Nationality", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_OriginCountry",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_OriginCountry", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_PaymentType",
                columns: table => new
                {
                    PTId = table.Column<int>(nullable: false),
                    PTName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_PaymentType", x => x.PTId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_ProductCategory",
                columns: table => new
                {
                    CatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CatID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_ProductUnits",
                columns: table => new
                {
                    UnitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnitName = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierName = table.Column<string>(maxLength: 100, nullable: true),
                    ContactNo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    ContactPersonName = table.Column<string>(maxLength: 100, nullable: true),
                    ContactPersonTelNo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Month",
                columns: table => new
                {
                    MonthId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FinMonth = table.Column<string>(maxLength: 25, nullable: false),
                    FinYear = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    EnteredBy = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Month", x => x.MonthId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Product",
                columns: table => new
                {
                    ItemID = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    ItemName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    CatID = table.Column<int>(nullable: true),
                    MaxQty = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MinQty = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    LeadTime = table.Column<decimal>(type: "decimal(5, 2)", nullable: true),
                    ReOrderLevel = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    ReOrderQty = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    UnitID = table.Column<int>(nullable: true),
                    LastPurchasePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Barcode = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductGINDetails",
                columns: table => new
                {
                    GINNO = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ItemNo = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Remarks = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GINDetails", x => new { x.GINNO, x.ItemNo });
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductGINHeader",
                columns: table => new
                {
                    GINNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    GINDate = table.Column<DateTime>(type: "date", nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsDeletedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GINHeader", x => x.GINNo);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductGRNDetails",
                columns: table => new
                {
                    GRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ItemID = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    UnitID = table.Column<int>(nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    PriceVarianceValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNDetails", x => new { x.GRNNo, x.ItemID });
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductGRNHeader",
                columns: table => new
                {
                    GRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    SupplierInvoiceNo = table.Column<string>(maxLength: 50, nullable: true),
                    GRNDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SupplierIvoiceDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsCach = table.Column<bool>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsDeletedBy = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    PONo = table.Column<string>(unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNHeader", x => x.GRNNo);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductPONDetails",
                columns: table => new
                {
                    PONo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ItemID = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    UnitID = table.Column<int>(nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedOrder_Details", x => new { x.PONo, x.ItemID });
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductPONHeader",
                columns: table => new
                {
                    PONo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    PODate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsCach = table.Column<bool>(nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsDeletedBy = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    IsPurchased = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedOrder_Header", x => x.PONo);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductReceptionGRNDetail",
                columns: table => new
                {
                    ReceptionGRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ItemID = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    UnitID = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionGRNDetail", x => new { x.ReceptionGRNNo, x.ItemID });
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductReceptionGRNHeader",
                columns: table => new
                {
                    ReceptionGRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    GRNDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    IsDeletedBy = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionGRNHeader", x => x.ReceptionGRNNo);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductSellingPrice",
                columns: table => new
                {
                    ItemID = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSellingPrice", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductSRNDetails",
                columns: table => new
                {
                    SRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ItemID = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    UnitID = table.Column<int>(nullable: true),
                    Qry = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRNDetails", x => new { x.SRNNo, x.ItemID });
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ProductSRNHeader",
                columns: table => new
                {
                    SRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    GRNNo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    SupplierID = table.Column<int>(nullable: true),
                    SupplierInvoiceNo = table.Column<string>(maxLength: 50, nullable: true),
                    SupplierInvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SRNDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsCash = table.Column<bool>(nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsDeletedBy = table.Column<int>(nullable: true),
                    BranchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRNHeader", x => x.SRNNo);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Rpt_Temp_ProductSaleIncomeMonthBase",
                columns: table => new
                {
                    AutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemID = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    ItemName = table.Column<string>(unicode: false, maxLength: 350, nullable: true),
                    January_Count = table.Column<int>(nullable: true),
                    January_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    February_Count = table.Column<int>(nullable: true),
                    February_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    March_Count = table.Column<int>(nullable: true),
                    March_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    April_Count = table.Column<int>(nullable: true),
                    April_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    May_Count = table.Column<int>(nullable: true),
                    May_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    June_Count = table.Column<int>(nullable: true),
                    June_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    July_Count = table.Column<int>(nullable: true),
                    July_Income = table.Column<decimal>(type: "decimal(18, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tbl_Rpt___6B2329055935D4F4", x => x.AutoId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SystemAutoNo",
                columns: table => new
                {
                    FormType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AutoNum = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "date", nullable: true),
                    LastModifiedTime = table.Column<TimeSpan>(nullable: true),
                    IsDateUpdated = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsMorningUpdated = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsEveningUpdated = table.Column<bool>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAutoNo", x => x.FormType);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_User",
                columns: table => new
                {
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Designation = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    MobNo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    UserType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsPasswordChanged = table.Column<bool>(nullable: false),
                    PasswordChangedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Address = table.Column<string>(maxLength: 10, nullable: false),
                    TP1 = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    TP2 = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Fax = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Branch", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Tbl_Branch_Tbl_Company",
                        column: x => x.CompanyId,
                        principalTable: "Tbl_Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Customer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    FullName = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    MobileNo = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 350, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Profession = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LoyaltyCardNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Tbl_Customer_Tbl_Branch",
                        column: x => x.BranchId,
                        principalTable: "Tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMain = table.Column<bool>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Tbl_Mast_Department_Tbl_Branch",
                        column: x => x.BranchId,
                        principalTable: "Tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_Designation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Mast_Designation", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_Tbl_Mast_Designation_Tbl_Branch",
                        column: x => x.BranchId,
                        principalTable: "Tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CustomerSchedule",
                columns: table => new
                {
                    CSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    BookedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CustomerSchedule", x => x.CSId);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerSchedule_Tbl_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Tbl_Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerSchedule_Tbl_Mast_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Mast_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Mast_TreatmentType",
                columns: table => new
                {
                    TTId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TTName = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Master_TreatmentType", x => x.TTId);
                    table.ForeignKey(
                        name: "FK_Tbl_Mast_TreatmentType_Tbl_Branch",
                        column: x => x.BranchId,
                        principalTable: "Tbl_Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_Mast_TreatmentType_Tbl_Mast_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Mast_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeDetail",
                columns: table => new
                {
                    EMPNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    DesignationId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(maxLength: 200, nullable: true),
                    Gender = table.Column<string>(maxLength: 20, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    PassportNo = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateOfJoin = table.Column<DateTime>(type: "date", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ContactNo = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 350, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EmergencyContactPerson = table.Column<string>(maxLength: 100, nullable: true),
                    EmergencyContactNo = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    BankAccountNo = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeDetail", x => x.EMPNo);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDetail_Tbl_Mast_Bank",
                        column: x => x.BankId,
                        principalTable: "Tbl_Mast_Bank",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDetail_Tbl_Mast_OriginCountry",
                        column: x => x.CountryId,
                        principalTable: "Tbl_Mast_OriginCountry",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDetail_Tbl_Mast_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Mast_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDetail_Tbl_Mast_Designation",
                        column: x => x.DesignationId,
                        principalTable: "Tbl_Mast_Designation",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDetail_Tbl_Mast_Nationality",
                        column: x => x.NationalityId,
                        principalTable: "Tbl_Mast_Nationality",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CustomerGiftVoucher",
                columns: table => new
                {
                    GVInvoiceNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    VoucherNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CustomerId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    InvDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    TransType = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TTId = table.Column<int>(nullable: false),
                    SubTotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DueAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    PTId = table.Column<int>(nullable: false),
                    IsRedeem = table.Column<bool>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false),
                    CancelReason = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    CanceledBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CanceledDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CustomerGiftVoucher", x => x.GVInvoiceNo);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerGiftVoucher_Tbl_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Tbl_Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerGiftVoucher_Tbl_Mast_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Mast_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerGiftVoucher_Tbl_Mast_PaymentType",
                        column: x => x.PTId,
                        principalTable: "Tbl_Mast_PaymentType",
                        principalColumn: "PTId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerGiftVoucher_Tbl_Mast_TreatmentType",
                        column: x => x.TTId,
                        principalTable: "Tbl_Mast_TreatmentType",
                        principalColumn: "TTId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CustomerScheduleTreatment",
                columns: table => new
                {
                    CSTId = table.Column<int>(nullable: false),
                    CSId = table.Column<int>(nullable: false),
                    TTId = table.Column<int>(nullable: false),
                    EMPNo = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CustomerScheduleTreatment", x => x.CSTId);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerScheduleTreatment_Tbl_CustomerSchedule",
                        column: x => x.CSId,
                        principalTable: "Tbl_CustomerSchedule",
                        principalColumn: "CSId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerScheduleTreatment_Tbl_EmployeeDetail",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerScheduleTreatment_Tbl_Mast_TreatmentType",
                        column: x => x.TTId,
                        principalTable: "Tbl_Mast_TreatmentType",
                        principalColumn: "TTId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeAllowances",
                columns: table => new
                {
                    EAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPNo = table.Column<int>(nullable: false),
                    AllowanceId = table.Column<int>(nullable: false),
                    AllowanceValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    MonthId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeAllowances_1", x => x.EAId);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeAllowances_Tbl_Mast_Allowances1",
                        column: x => x.AllowanceId,
                        principalTable: "Tbl_Mast_Allowances",
                        principalColumn: "AllowanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeAllowances_Tbl_EmployeeDetail1",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeBasicSalary",
                columns: table => new
                {
                    EBSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPNo = table.Column<int>(nullable: false),
                    BasicSalaryValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MonthId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeBasicSalary", x => x.EBSId);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeBasicSalary_Tbl_EmployeeDetail",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeCommision",
                columns: table => new
                {
                    ECId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPNo = table.Column<int>(nullable: false),
                    CommissionId = table.Column<int>(nullable: false),
                    CommisionValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    MonthId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeCommision_1", x => x.ECId);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeCommision_Tbl_Mast_Commission1",
                        column: x => x.CommissionId,
                        principalTable: "Tbl_Mast_Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeCommision_Tbl_EmployeeDetail1",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeDeduction",
                columns: table => new
                {
                    EDId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPNo = table.Column<int>(nullable: false),
                    DeductionId = table.Column<int>(nullable: false),
                    DeductionValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MonthId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeDeduction_1", x => x.EDId);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDeduction_Tbl_Mast_Deduction1",
                        column: x => x.DeductionId,
                        principalTable: "Tbl_Mast_Deduction",
                        principalColumn: "DeductionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeDeduction_Tbl_EmployeeDetail1",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeLeave",
                columns: table => new
                {
                    EmployeeLeaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPNo = table.Column<int>(nullable: false),
                    LeaveTypeId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remark = table.Column<string>(maxLength: 150, nullable: true),
                    IsNope = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_EmployeeLeave", x => x.EmployeeLeaveId);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeLeave_Tbl_EmployeeDetail",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_EmployeeLeave_Tbl_Mast_LeaveType",
                        column: x => x.LeaveTypeId,
                        principalTable: "Tbl_Mast_LeaveType",
                        principalColumn: "LeaveTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_EmployeeRoster",
                columns: table => new
                {
                    RosterId = table.Column<int>(nullable: false),
                    EMPNo = table.Column<int>(nullable: false),
                    WorkingDate = table.Column<DateTime>(type: "date", nullable: false),
                    InTime = table.Column<TimeSpan>(nullable: false),
                    OutTime = table.Column<TimeSpan>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_RosterDetail", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_Tbl_RosterDetail_Tbl_EmployeeDetail",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CustomerInvoiceHeader",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    CustomerId = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    InvDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    CSTId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    TransType = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    PTId = table.Column<int>(nullable: false),
                    SubTotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DueAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    GVInvoiceNo = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    IsCanceled = table.Column<bool>(nullable: false),
                    CancelReason = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EnteredBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: true),
                    CanceledBy = table.Column<int>(nullable: true),
                    EnteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CanceledDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CustomerInvoiceHeader", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceHeader_Tbl_CustomerScheduleTreatment",
                        column: x => x.CSTId,
                        principalTable: "Tbl_CustomerScheduleTreatment",
                        principalColumn: "CSTId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceHeader_Tbl_Mast_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Tbl_Mast_Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceHeader_Tbl_Mast_PaymentType",
                        column: x => x.PTId,
                        principalTable: "Tbl_Mast_PaymentType",
                        principalColumn: "PTId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CustomerInvoiceProducts",
                columns: table => new
                {
                    CIPId = table.Column<int>(nullable: false),
                    InvoiceNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    ProductId = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CustomerInvoiceProducts", x => x.CIPId);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceProducts_Tbl_CustomerInvoiceHeader",
                        column: x => x.InvoiceNo,
                        principalTable: "Tbl_CustomerInvoiceHeader",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CustomerInvoiceTreatment",
                columns: table => new
                {
                    CITId = table.Column<int>(nullable: false),
                    InvoiceNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    TTId = table.Column<int>(nullable: false),
                    EMPNo = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CustomerInvoiceTreatment", x => x.CITId);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceTreatment_Tbl_EmployeeDetail",
                        column: x => x.EMPNo,
                        principalTable: "Tbl_EmployeeDetail",
                        principalColumn: "EMPNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceTreatment_Tbl_CustomerInvoiceHeader",
                        column: x => x.InvoiceNo,
                        principalTable: "Tbl_CustomerInvoiceHeader",
                        principalColumn: "InvoiceNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tbl_CustomerInvoiceTreatment_Tbl_Mast_TreatmentType",
                        column: x => x.TTId,
                        principalTable: "Tbl_Mast_TreatmentType",
                        principalColumn: "TTId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Branch_CompanyId",
                table: "Tbl_Branch",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Customer_BranchId",
                table: "Tbl_Customer",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerGiftVoucher_CustomerId",
                table: "Tbl_CustomerGiftVoucher",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerGiftVoucher_DepartmentId",
                table: "Tbl_CustomerGiftVoucher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerGiftVoucher_PTId",
                table: "Tbl_CustomerGiftVoucher",
                column: "PTId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerGiftVoucher_TTId",
                table: "Tbl_CustomerGiftVoucher",
                column: "TTId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceHeader_CSTId",
                table: "Tbl_CustomerInvoiceHeader",
                column: "CSTId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceHeader_DepartmentId",
                table: "Tbl_CustomerInvoiceHeader",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceHeader_PTId",
                table: "Tbl_CustomerInvoiceHeader",
                column: "PTId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceProducts_InvoiceNo",
                table: "Tbl_CustomerInvoiceProducts",
                column: "InvoiceNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceTreatment_EMPNo",
                table: "Tbl_CustomerInvoiceTreatment",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceTreatment_InvoiceNo",
                table: "Tbl_CustomerInvoiceTreatment",
                column: "InvoiceNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerInvoiceTreatment_TTId",
                table: "Tbl_CustomerInvoiceTreatment",
                column: "TTId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerSchedule_CustomerId",
                table: "Tbl_CustomerSchedule",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerSchedule_DepartmentId",
                table: "Tbl_CustomerSchedule",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerScheduleTreatment_CSId",
                table: "Tbl_CustomerScheduleTreatment",
                column: "CSId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerScheduleTreatment_EMPNo",
                table: "Tbl_CustomerScheduleTreatment",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CustomerScheduleTreatment_TTId",
                table: "Tbl_CustomerScheduleTreatment",
                column: "TTId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeAllowances_AllowanceId",
                table: "Tbl_EmployeeAllowances",
                column: "AllowanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeAllowances_EMPNo",
                table: "Tbl_EmployeeAllowances",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeBasicSalary_EMPNo",
                table: "Tbl_EmployeeBasicSalary",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeCommision_CommissionId",
                table: "Tbl_EmployeeCommision",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeCommision_EMPNo",
                table: "Tbl_EmployeeCommision",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDeduction_DeductionId",
                table: "Tbl_EmployeeDeduction",
                column: "DeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDeduction_EMPNo",
                table: "Tbl_EmployeeDeduction",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDetail_BankId",
                table: "Tbl_EmployeeDetail",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDetail_CountryId",
                table: "Tbl_EmployeeDetail",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDetail_DepartmentId",
                table: "Tbl_EmployeeDetail",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDetail_DesignationId",
                table: "Tbl_EmployeeDetail",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeDetail_NationalityId",
                table: "Tbl_EmployeeDetail",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeLeave_EMPNo",
                table: "Tbl_EmployeeLeave",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeLeave_LeaveTypeId",
                table: "Tbl_EmployeeLeave",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_EmployeeRoster_EMPNo",
                table: "Tbl_EmployeeRoster",
                column: "EMPNo");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Mast_Department_BranchId",
                table: "Tbl_Mast_Department",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Mast_Designation_BranchId",
                table: "Tbl_Mast_Designation",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Mast_TreatmentType_BranchId",
                table: "Tbl_Mast_TreatmentType",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Mast_TreatmentType_DepartmentId",
                table: "Tbl_Mast_TreatmentType",
                column: "DepartmentId");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Config");

            migrationBuilder.DropTable(
                name: "Tbl_CustomerGiftVoucher");

            migrationBuilder.DropTable(
                name: "Tbl_CustomerInvoiceProducts");

            migrationBuilder.DropTable(
                name: "Tbl_CustomerInvoiceTreatment");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeAllowances");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeAttendance");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeBasicSalary");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeCommision");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeDeduction");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeLeave");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeRoster");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeSalarySupport");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_ProductCategory");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_ProductUnits");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Suppliers");

            migrationBuilder.DropTable(
                name: "Tbl_Month");

            migrationBuilder.DropTable(
                name: "Tbl_Product");

            migrationBuilder.DropTable(
                name: "Tbl_ProductGINDetails");

            migrationBuilder.DropTable(
                name: "Tbl_ProductGINHeader");

            migrationBuilder.DropTable(
                name: "Tbl_ProductGRNDetails");

            migrationBuilder.DropTable(
                name: "Tbl_ProductGRNHeader");

            migrationBuilder.DropTable(
                name: "Tbl_ProductPONDetails");

            migrationBuilder.DropTable(
                name: "Tbl_ProductPONHeader");

            migrationBuilder.DropTable(
                name: "Tbl_ProductReceptionGRNDetail");

            migrationBuilder.DropTable(
                name: "Tbl_ProductReceptionGRNHeader");

            migrationBuilder.DropTable(
                name: "Tbl_ProductSellingPrice");

            migrationBuilder.DropTable(
                name: "Tbl_ProductSRNDetails");

            migrationBuilder.DropTable(
                name: "Tbl_ProductSRNHeader");

            migrationBuilder.DropTable(
                name: "Tbl_Rpt_Temp_ProductSaleIncomeMonthBase");

            migrationBuilder.DropTable(
                name: "Tbl_SystemAutoNo");

            migrationBuilder.DropTable(
                name: "Tbl_User");

            migrationBuilder.DropTable(
                name: "Tbl_CustomerInvoiceHeader");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Allowances");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Commission");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Deduction");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_LeaveType");

            migrationBuilder.DropTable(
                name: "Tbl_CustomerScheduleTreatment");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_PaymentType");

            migrationBuilder.DropTable(
                name: "Tbl_CustomerSchedule");

            migrationBuilder.DropTable(
                name: "Tbl_EmployeeDetail");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_TreatmentType");

            migrationBuilder.DropTable(
                name: "Tbl_Customer");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Bank");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_OriginCountry");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Designation");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Nationality");

            migrationBuilder.DropTable(
                name: "Tbl_Mast_Department");

            migrationBuilder.DropTable(
                name: "Tbl_Branch");

            migrationBuilder.DropTable(
                name: "Tbl_Company");
        }
    }
}
