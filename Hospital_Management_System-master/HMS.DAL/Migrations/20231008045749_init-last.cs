using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class initlast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advices",
                columns: table => new
                {
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdviceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advices", x => x.AdviceId);
                });

            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    AmbulanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmbulanceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.AmbulanceID);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    AppointmentType = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientIdentityNumber = table.Column<int>(type: "int", nullable: true),
                    PrescriptionNumber = table.Column<int>(type: "int", nullable: true),
                    BillAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    BillDate = table.Column<DateTime>(type: "date", nullable: false),
                    isInsurance = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillingNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PreparedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MedicineBill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestBill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakenServiceBill = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "BloodBanks",
                columns: table => new
                {
                    BloodBankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBanks", x => x.BloodBankID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DischargeTransfers",
                columns: table => new
                {
                    DT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeSummary = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DischargeTransfers", x => x.DT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Dosage",
                columns: table => new
                {
                    DosageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosage", x => x.DosageID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineBills",
                columns: table => new
                {
                    MedicineBillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: true),
                    MedicineCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[MedicineCount]*[Price]"),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBills", x => x.MedicineBillId);
                });

            migrationBuilder.CreateTable(
                name: "MedicineGenerics",
                columns: table => new
                {
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineGenericNames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineGenerics", x => x.MedicineGenericID);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineType = table.Column<int>(type: "int", nullable: false),
                    DosageForms = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicineGenericID = table.Column<int>(type: "int", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "Morgues",
                columns: table => new
                {
                    MorgueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MorgueName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsolationCapability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morgues", x => x.MorgueID);
                });

            migrationBuilder.CreateTable(
                name: "NumberCounterRecords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberCounterRecords", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PatientRegisters",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientIdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRegisters", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "PreoperativeDiagnoses",
                columns: table => new
                {
                    PreoperativeDiagnosisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreoperativeDiagnosisName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreoperativeDiagnoses", x => x.PreoperativeDiagnosisID);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    SymptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymptomName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.SymptomId);
                });

            migrationBuilder.CreateTable(
                name: "TakenService",
                columns: table => new
                {
                    TakenServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakenServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenService", x => x.TakenServiceId);
                });

            migrationBuilder.CreateTable(
                name: "TestBills",
                columns: table => new
                {
                    TestBillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestBillName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestBills", x => x.TestBillId);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "unidentifiedDeadBodies",
                columns: table => new
                {
                    UnIdenfiedDeadBodyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<int>(type: "int", nullable: false),
                    DeceasedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "date", nullable: true),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unidentifiedDeadBodies", x => x.UnIdenfiedDeadBodyID);
                });

            migrationBuilder.CreateTable(
                name: "WasteManagements",
                columns: table => new
                {
                    WasteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WasteType = table.Column<int>(type: "int", nullable: false),
                    DisposalDate = table.Column<DateTime>(type: "date", nullable: false),
                    DisposalMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NextScheduleDate = table.Column<DateTime>(type: "date", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteManagements", x => x.WasteID);
                });

            migrationBuilder.CreateTable(
                name: "OtherEmployees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherEmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OtherEmployeeType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmbulanceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherEmployees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_OtherEmployees_Ambulances_AmbulanceID",
                        column: x => x.AmbulanceID,
                        principalTable: "Ambulances",
                        principalColumn: "AmbulanceID");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Doctortype = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabTechnicians",
                columns: table => new
                {
                    TechnicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    TechnicianType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTechnicians", x => x.TechnicianID);
                    table.ForeignKey(
                        name: "FK_LabTechnicians_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    NurseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    NurseLevel = table.Column<int>(type: "int", nullable: false),
                    NurseType = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResignDate = table.Column<DateTime>(type: "date", nullable: true),
                    employeeStatus = table.Column<int>(type: "int", nullable: false),
                    Education_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.NurseID);
                    table.ForeignKey(
                        name: "FK_Nurses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WardCabins",
                columns: table => new
                {
                    WardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardCabinName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WardCabinType = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardCabins", x => x.WardID);
                    table.ForeignKey(
                        name: "FK_WardCabins_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drawers",
                columns: table => new
                {
                    DrawerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrawerCondition = table.Column<int>(type: "int", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    MorgueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drawers", x => x.DrawerID);
                    table.ForeignKey(
                        name: "FK_Drawers_Morgues_MorgueID",
                        column: x => x.MorgueID,
                        principalTable: "Morgues",
                        principalColumn: "MorgueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outdoors",
                columns: table => new
                {
                    OutdoorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    TreatmentType = table.Column<int>(type: "int", nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmissionRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outdoors", x => x.OutdoorID);
                    table.ForeignKey(
                        name: "FK_Outdoors_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionBills",
                columns: table => new
                {
                    PrescriptionBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    ServiceID = table.Column<int>(type: "int", nullable: false),
                    PB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientRegistersPatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionBills", x => x.PrescriptionBillID);
                    table.ForeignKey(
                        name: "FK_PrescriptionBills_PatientRegisters_PatientRegistersPatientID",
                        column: x => x.PatientRegistersPatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    ReportDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference_Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetail", x => x.ReportDetailID);
                    table.ForeignKey(
                        name: "FK_ReportDetail_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    WardCabinID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedID);
                    table.ForeignKey(
                        name: "FK_Beds_WardCabins_WardCabinID",
                        column: x => x.WardCabinID,
                        principalTable: "WardCabins",
                        principalColumn: "WardID");
                });

            migrationBuilder.CreateTable(
                name: "DrawersInfo",
                columns: table => new
                {
                    DrawerInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsPatient = table.Column<bool>(type: "bit", nullable: false),
                    DrawerID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    UnidentifiedDeadBodyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawersInfo", x => x.DrawerInfoID);
                    table.ForeignKey(
                        name: "FK_DrawersInfo_Drawers_DrawerID",
                        column: x => x.DrawerID,
                        principalTable: "Drawers",
                        principalColumn: "DrawerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawersInfo_PatientRegisters_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientRegisters",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_DrawersInfo_unidentifiedDeadBodies_UnidentifiedDeadBodyID",
                        column: x => x.UnidentifiedDeadBodyID,
                        principalTable: "unidentifiedDeadBodies",
                        principalColumn: "UnIdenfiedDeadBodyID");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    PrescriptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionDate = table.Column<DateTime>(type: "date", nullable: false),
                    ProgressNotes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NextVisit = table.Column<DateTime>(type: "date", nullable: true),
                    AdmissionSuggested = table.Column<bool>(type: "bit", nullable: false),
                    FollowUpInstructions = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrescriptionBillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescriptions_PrescriptionBills_PrescriptionBillID",
                        column: x => x.PrescriptionBillID,
                        principalTable: "PrescriptionBills",
                        principalColumn: "PrescriptionBillID");
                });

            migrationBuilder.CreateTable(
                name: "IndoorPatients",
                columns: table => new
                {
                    IndoorPatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferredBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BedID = table.Column<int>(type: "int", nullable: false),
                    InsuranceInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AdmissionNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDead = table.Column<bool>(type: "bit", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordsID = table.Column<int>(type: "int", nullable: true),
                    NIDnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    IsTransferred = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndoorPatients", x => x.IndoorPatientID);
                    table.ForeignKey(
                        name: "FK_IndoorPatients_Beds_BedID",
                        column: x => x.BedID,
                        principalTable: "Beds",
                        principalColumn: "BedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterAdviceEntry",
                columns: table => new
                {
                    MasterAdviceEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    AdviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterAdviceEntry", x => x.MasterAdviceEntryID);
                    table.ForeignKey(
                        name: "FK_MasterAdviceEntry_Advices_AdviceId",
                        column: x => x.AdviceId,
                        principalTable: "Advices",
                        principalColumn: "AdviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterAdviceEntry_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterDosageEntry",
                columns: table => new
                {
                    MasterDosageEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    DosageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterDosageEntry", x => x.MasterDosageEntryID);
                    table.ForeignKey(
                        name: "FK_MasterDosageEntry_Dosage_DosageID",
                        column: x => x.DosageID,
                        principalTable: "Dosage",
                        principalColumn: "DosageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterDosageEntry_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterMedicineEntry",
                columns: table => new
                {
                    MasterMedicineEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    MedicineID = table.Column<int>(type: "int", nullable: false),
                    IsPrescribed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterMedicineEntry", x => x.MasterMedicineEntryID);
                    table.ForeignKey(
                        name: "FK_MasterMedicineEntry_Medicines_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "Medicines",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterMedicineEntry_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterSymptomsEntry",
                columns: table => new
                {
                    MasterSymptomsEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    SymptomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSymptomsEntry", x => x.MasterSymptomsEntryID);
                    table.ForeignKey(
                        name: "FK_MasterSymptomsEntry_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterSymptomsEntry_Symptoms_SymptomId",
                        column: x => x.SymptomId,
                        principalTable: "Symptoms",
                        principalColumn: "SymptomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterTestEntry",
                columns: table => new
                {
                    MasterTestEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTestEntry", x => x.MasterTestEntryID);
                    table.ForeignKey(
                        name: "FK_MasterTestEntry_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasterTestEntry_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientType = table.Column<bool>(type: "bit", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true),
                    PrescriptionID = table.Column<int>(type: "int", nullable: true),
                    TestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordsID);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID");
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID");
                });

            migrationBuilder.CreateTable(
                name: "Surgeries",
                columns: table => new
                {
                    SurgeryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurgeryType = table.Column<int>(type: "int", nullable: false),
                    SurgeryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Postoperative_Diagnosis = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    PreoperativeDiagnosisID = table.Column<int>(type: "int", nullable: true),
                    TestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgeries", x => x.SurgeryID);
                    table.ForeignKey(
                        name: "FK_Surgeries_PreoperativeDiagnoses_PreoperativeDiagnosisID",
                        column: x => x.PreoperativeDiagnosisID,
                        principalTable: "PreoperativeDiagnoses",
                        principalColumn: "PreoperativeDiagnosisID");
                    table.ForeignKey(
                        name: "FK_Surgeries_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Surgeries_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID");
                });

            migrationBuilder.CreateTable(
                name: "TestReports",
                columns: table => new
                {
                    TestReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportDetailID = table.Column<int>(type: "int", nullable: false),
                    PrescriptionID = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestReports", x => x.TestReportID);
                    table.ForeignKey(
                        name: "FK_TestReports_Prescriptions_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "Prescriptions",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestReports_ReportDetail_ReportDetailID",
                        column: x => x.ReportDetailID,
                        principalTable: "ReportDetail",
                        principalColumn: "ReportDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionBills",
                columns: table => new
                {
                    AdmissionBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndoorPatientID = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    AB_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionBills", x => x.AdmissionBillID);
                    table.ForeignKey(
                        name: "FK_AdmissionBills_IndoorPatients_IndoorPatientID",
                        column: x => x.IndoorPatientID,
                        principalTable: "IndoorPatients",
                        principalColumn: "IndoorPatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Advices",
                columns: new[] { "AdviceId", "AdviceName" },
                values: new object[,]
                {
                    { 1, "Eat Healthy" },
                    { 2, "Exercise Regularly" },
                    { 3, "Get Enough Sleep" },
                    { 4, "Stay Hydrated" },
                    { 5, "Manage Stress" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentDescription", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "It is concerned with disorders and diseases of the nervous system", "Neurology" },
                    { 2, "The branch of medicine dealing with children and their diseases.", "Paediatrics" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerID", "ManufacturerName" },
                values: new object[,]
                {
                    { 1, "Square Pharmaceuticals Ltd " },
                    { 2, "Incepta Pharmaceutical Ltd" },
                    { 3, "Beximco Pharmaceuticals Ltd" },
                    { 4, "Opsonin Pharma Ltd" },
                    { 5, "Renata Ltd" },
                    { 6, "Healthcare Pharmaceuticals Ltd" },
                    { 7, "Radient Pharmaceuticals Ltd" },
                    { 8, "Eskayef Pharmaceuticals Ltd" },
                    { 9, "ACME Laboratories Ltd" },
                    { 10, "Aristopharma Ltd" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineID", "Discount", "DosageForms", "ExpireDate", "ManufacturerID", "MedicineGenericID", "MedicineName", "MedicineType", "Quantity", "SellPrice", "Weight" },
                values: new object[,]
                {
                    { 1, 50.00m, 2, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Napa", 1, 522, 5612.00m, "500mg" },
                    { 2, 50.00m, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Seclo", 1, 522, 5612.00m, "20mg" },
                    { 3, 50.00m, 2, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Napa Extra", 1, 522, 5612.00m, "20mg" }
                });

            migrationBuilder.InsertData(
                table: "OtherEmployees",
                columns: new[] { "EmployeeID", "AmbulanceID", "Education_Info", "Image", "JoinDate", "OtherEmployeeName", "OtherEmployeeType", "PhoneNumber", "ResignDate", "employeeStatus" },
                values: new object[,]
                {
                    { 1, null, "JSC", "wordboy1.jpg", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "abul mia", 2, "01917123456", null, 1 },
                    { 2, null, "SSC", "driver1.jpg", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ataur", 6, "01517123456", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "PatientRegisters",
                columns: new[] { "PatientID", "Address", "Email", "Gender", "PatientIdentityNumber", "PatientName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "dhaka", "am@gmail.com", 2, null, "Sultana begum", "12345678" },
                    { 2, "Sirajgonj", "az@gmail.com", 1, null, "Azman Mollah", "1233454" }
                });

            migrationBuilder.InsertData(
                table: "PreoperativeDiagnoses",
                columns: new[] { "PreoperativeDiagnosisID", "PreoperativeDiagnosisName" },
                values: new object[,]
                {
                    { 1, "Hypertension" },
                    { 2, "Diabetes" },
                    { 3, "Obesity" },
                    { 4, "Heart Disease" },
                    { 5, "Kidney Disease" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceCharge", "ServiceName" },
                values: new object[,]
                {
                    { 1, 500m, "Bed charge" },
                    { 2, 1500m, "Cabin charge" },
                    { 3, 3000m, "ICU charge" },
                    { 4, 120m, "Oxygen charge (per liter)" },
                    { 5, 200m, "Food (per time)" },
                    { 6, 100m, "Wound Dressing" },
                    { 7, 50m, "Injection Pushing" },
                    { 8, 500m, "Outdoor Doctor Visit" },
                    { 9, 800m, "Indoor Doctor Visit (Assistant Professor)" },
                    { 10, 1200m, "Indoor Doctor Visit (Associate Professor)" },
                    { 11, 1500m, "Indoor Doctor Visit (Professor)" },
                    { 12, 100m, "Room Cleaning" },
                    { 13, 50m, "Patient Cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceID", "ServiceCharge", "ServiceName" },
                values: new object[,]
                {
                    { 14, 300m, "Physical Therapy" },
                    { 15, 1000m, "Ambulance charge" },
                    { 16, 500m, "Morgue charge" },
                    { 17, 100m, "Cloth Fee (Hospital Gown)" },
                    { 18, 250m, "Orthopedic Device charge (crutches, wheelchair)" },
                    { 19, 200m, "Pathological Sample Collection Fee (from Bed/Home)" },
                    { 20, 400m, "Counseling fee" },
                    { 21, 400m, "Rehabilitation fee" },
                    { 22, 500m, "Admission Charge" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "SymptomId", "SymptomName" },
                values: new object[,]
                {
                    { 1, "Fever" },
                    { 2, "Cough" },
                    { 3, "Headache" },
                    { 4, "Sore Throat" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "DepartmentID", "DoctorName", "Doctortype", "Education_Info", "Image", "JoinDate", "PhoneNumber", "ResignDate", "Specialization", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Pipul Rahman", 1, "MD in Cardiology from DMC University", "doctor1.jpg", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01917123456", null, "Cardiologist", 1 },
                    { 2, 2, "Ass Pina", 4, "MD in Orthopedics from ABC University", "doctor2.jpg", new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "01517123456", null, "Orthopedic Surgeon", 1 }
                });

            migrationBuilder.InsertData(
                table: "LabTechnicians",
                columns: new[] { "TechnicianID", "DepartmentID", "Education_Info", "Image", "JoinDate", "PhoneNumber", "ResignDate", "TechnicianName", "TechnicianType", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor of Science in Medical Technology", "labtech1.jpg", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01617123456", null, "valsun choudhury", 1, 1 },
                    { 2, 2, "Certified Laboratory Technician", "labtech2.jpg", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01917123456", null, "Robin mia", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "NurseID", "DepartmentID", "Education_Info", "Image", "JoinDate", "NurseLevel", "NurseName", "NurseType", "PhoneNumber", "ResignDate", "employeeStatus" },
                values: new object[,]
                {
                    { 1, 1, "Bachelor of Science in Nursing", "nurse1.jpg", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Sharmin Jahan", 1, "01317123456", null, 1 },
                    { 2, 2, "Licensed Practical Nurse Certification", "nurse2.jpg", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Hafsa khatun", 2, "01817123456", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "WardCabins",
                columns: new[] { "WardID", "DepartmentID", "WardCabinName", "WardCabinType" },
                values: new object[,]
                {
                    { 1, 1, "Neuro Care", 0 },
                    { 2, 2, "Child Care", 0 }
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "BedID", "BedNumber", "IsOccupied", "WardCabinID" },
                values: new object[,]
                {
                    { 1, "W101", true, 1 },
                    { 2, "W102", true, 1 },
                    { 3, "W103", true, 1 },
                    { 4, "C101", true, 2 },
                    { 5, "C102", true, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionBills_IndoorPatientID",
                table: "AdmissionBills",
                column: "IndoorPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_WardCabinID",
                table: "Beds",
                column: "WardCabinID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentID",
                table: "Doctors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Drawers_MorgueID",
                table: "Drawers",
                column: "MorgueID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_DrawerID",
                table: "DrawersInfo",
                column: "DrawerID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_PatientID",
                table: "DrawersInfo",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_DrawersInfo_UnidentifiedDeadBodyID",
                table: "DrawersInfo",
                column: "UnidentifiedDeadBodyID");

            migrationBuilder.CreateIndex(
                name: "IX_IndoorPatients_BedID",
                table: "IndoorPatients",
                column: "BedID");

            migrationBuilder.CreateIndex(
                name: "IX_LabTechnicians_DepartmentID",
                table: "LabTechnicians",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAdviceEntry_AdviceId",
                table: "MasterAdviceEntry",
                column: "AdviceId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAdviceEntry_PrescriptionID",
                table: "MasterAdviceEntry",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDosageEntry_DosageID",
                table: "MasterDosageEntry",
                column: "DosageID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterDosageEntry_PrescriptionID",
                table: "MasterDosageEntry",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterMedicineEntry_MedicineID",
                table: "MasterMedicineEntry",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterMedicineEntry_PrescriptionID",
                table: "MasterMedicineEntry",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSymptomsEntry_PrescriptionID",
                table: "MasterSymptomsEntry",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterSymptomsEntry_SymptomId",
                table: "MasterSymptomsEntry",
                column: "SymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTestEntry_PrescriptionID",
                table: "MasterTestEntry",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTestEntry_TestID",
                table: "MasterTestEntry",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PrescriptionID",
                table: "MedicalRecords",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_TestID",
                table: "MedicalRecords",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_DepartmentID",
                table: "Nurses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_OtherEmployees_AmbulanceID",
                table: "OtherEmployees",
                column: "AmbulanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Outdoors_PatientID",
                table: "Outdoors",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionBills_PatientRegistersPatientID",
                table: "PrescriptionBills",
                column: "PatientRegistersPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorID",
                table: "Prescriptions",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PrescriptionBillID",
                table: "Prescriptions",
                column: "PrescriptionBillID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_TestID",
                table: "ReportDetail",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PreoperativeDiagnosisID",
                table: "Surgeries",
                column: "PreoperativeDiagnosisID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_PrescriptionID",
                table: "Surgeries",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Surgeries_TestID",
                table: "Surgeries",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_TestReports_PrescriptionID",
                table: "TestReports",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestReports_ReportDetailID",
                table: "TestReports",
                column: "ReportDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_WardCabins_DepartmentID",
                table: "WardCabins",
                column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionBills");

            migrationBuilder.DropTable(
                name: "Appointments");

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
                name: "Bills");

            migrationBuilder.DropTable(
                name: "BloodBanks");

            migrationBuilder.DropTable(
                name: "DischargeTransfers");

            migrationBuilder.DropTable(
                name: "DrawersInfo");

            migrationBuilder.DropTable(
                name: "LabTechnicians");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "MasterAdviceEntry");

            migrationBuilder.DropTable(
                name: "MasterDosageEntry");

            migrationBuilder.DropTable(
                name: "MasterMedicineEntry");

            migrationBuilder.DropTable(
                name: "MasterSymptomsEntry");

            migrationBuilder.DropTable(
                name: "MasterTestEntry");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "MedicineBills");

            migrationBuilder.DropTable(
                name: "MedicineGenerics");

            migrationBuilder.DropTable(
                name: "NumberCounterRecords");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "OtherEmployees");

            migrationBuilder.DropTable(
                name: "Outdoors");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Surgeries");

            migrationBuilder.DropTable(
                name: "TakenService");

            migrationBuilder.DropTable(
                name: "TestBills");

            migrationBuilder.DropTable(
                name: "TestReports");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "WasteManagements");

            migrationBuilder.DropTable(
                name: "IndoorPatients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Drawers");

            migrationBuilder.DropTable(
                name: "unidentifiedDeadBodies");

            migrationBuilder.DropTable(
                name: "Advices");

            migrationBuilder.DropTable(
                name: "Dosage");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "PreoperativeDiagnoses");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "ReportDetail");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "Morgues");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "PrescriptionBills");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "WardCabins");

            migrationBuilder.DropTable(
                name: "PatientRegisters");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
