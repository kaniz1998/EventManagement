using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Medicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MedicineGenerics",
                columns: new[] { "MedicineGenericID", "MedicineGenericNames" },
                values: new object[,]
                {
                    { 1, "Atorvastatin" },
                    { 2, "Rosuvastatin" },
                    { 3, "Metformin Hydrochloride" },
                    { 4, "linagliptin & Metformin" },
                    { 5, "Olmisertan " }
                });

			string GAllMedicines = @"create proc SpGetAllMedicine 
                        as
                        BEGIN
                        select * FROM Medicines
                        END";
			                string GeMedicineById = @"create proc SphMedicineById(@id int) 
                            as
                            BEGIN
                        select * FROM Medicines where MedicineID= @id
                        END";
			                string PoMedicine = @"create proc SpPtAllMedicine (  
                    @MedicineName NVARCHAR(max),
                    @Weight NVARCHAR(max),             
                    @MedicineType INT,
                    @DosageForms INT,
                    @ExpireDate DATETIME,
                    @Quantity INT,
                    @SellPrice DECIMAL(10,2),
                    @Discount DECIMAL(10,2),
                    @MedicineGenericID INT,
                    @ManufacturerID INT)
	                as 
	                BEGIN
		                INSERT INTO Medicines
                            (
                             MedicineName, Weight, MedicineType,DosageForms, ExpireDate, Quantity, SellPrice, Discount,MedicineGenericID,ManufacturerID)
                                VALUES     ( 
                              @MedicineName, @Weight, @MedicineType, @DosageForms,@ExpireDate, @Quantity, @SellPrice, @Discount,@MedicineGenericID,@ManufacturerID)
                END";
			                string UpMedicine = @"create proc SpUdateMedicine (@id int,
                           @MedicineName NVARCHAR(max),
                            @Weight NVARCHAR(max),                     
                    @MedicineType INT,
                     @DosageForms INT,
                   @ExpireDate DATE,
                   @Quantity INT,
                    @SellPrice DECIMAL(10,2),
                  @Discount DECIMAL(10,2),
                  @MedicineGenericID INT,
                  @ManufacturerID INT)
							                  as 
							                  BEGIN
                    UPDATE Medicines
                    SET    MedicineName=@MedicineName,
                            Weight=@Weight,			                  
                            MedicineType=@MedicineType,
                            DosageForms=@DosageForms,
                            ExpireDate=@ExpireDate,
                            Quantity=@Quantity,
                            SellPrice=@SellPrice,
                            Discount=@Discount,
                           MedicineGenericID=@MedicineGenericID,
                            ManufacturerID=@ManufacturerID
                    WHERE  MedicineID = @id
                    END";
			                string DeMedicine = @"create proc SpDeMedicine (@id int)
                    as
                    BEGIN
                    DELETE FROM Medicines
                    WHERE  MedicineID = @id
                    END";
			migrationBuilder.Sql(GAllMedicines);
			migrationBuilder.Sql(GeMedicineById);
			migrationBuilder.Sql(PoMedicine);
			migrationBuilder.Sql(UpMedicine);
			migrationBuilder.Sql(DeMedicine);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicineGenerics",
                keyColumn: "MedicineGenericID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MedicineGenerics",
                keyColumn: "MedicineGenericID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MedicineGenerics",
                keyColumn: "MedicineGenericID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MedicineGenerics",
                keyColumn: "MedicineGenericID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MedicineGenerics",
                keyColumn: "MedicineGenericID",
                keyValue: 5);

			string GAllMedicines = @"Drop proc SpGetAllMedicine";
			string GeMedicineById = @"Drop proc SphMedicineById";
			string PoMedicine = @"Drop proc SpPtAllMedicine";
			string UpMedicine = @"Drop proc SpUdateMedicine";
			string DeMedicine = @"Drop proc SpDeMedicine";

			migrationBuilder.Sql(GAllMedicines);
			migrationBuilder.Sql(GeMedicineById);
			migrationBuilder.Sql(PoMedicine);
			migrationBuilder.Sql(UpMedicine);
			migrationBuilder.Sql(DeMedicine);
		}
    }
}
