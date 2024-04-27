using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Test_Doseges_Symtomp_other : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterDosageEntry_Dosage_DosageID",
                table: "MasterDosageEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dosage",
                table: "Dosage");

            migrationBuilder.RenameTable(
                name: "Dosage",
                newName: "Dosages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dosages",
                table: "Dosages",
                column: "DosageID");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterDosageEntry_Dosages_DosageID",
                table: "MasterDosageEntry",
                column: "DosageID",
                principalTable: "Dosages",
                principalColumn: "DosageID",
                onDelete: ReferentialAction.Cascade);


			string getAllTEST = @"CREATE PROCEDURE GetTestsList
                                AS
                                BEGIN
                                    SELECT * FROM Tests
                                END";
			string getTESTById = @"CREATE PROCEDURE GetTestsById
                                @testid int 
                                AS 
                                BEGIN
                                SELECT * FROM Tests WHERE  TestID=@testid
                                END";
			string insertTEST = @"CREATE PROCEDURE InsertTest
                                    @Testname VARCHAR(MAX),
                                    @Testype VARCHAR(MAX),
									@price money
                                AS
                                BEGIN
                                    INSERT INTO Tests (TestName,TestType,Price)
                                    VALUES (@Testname,@Testype,@price)
                                END";
			string updateTEST = @"CREATE PROCEDURE UpdateTest
                                    @testid INT,
                                    @NewTestname VARCHAR(MAX),
									 @Testype VARCHAR(MAX),
									 @price money
                                AS
                                BEGIN
                                    UPDATE Tests
                                    SET TestName = @NewTestname ,
										TestType = @Testype,
										Price= @price 
                                    WHERE TestID = @testid
                                END";
			string deleteTEST = @"CREATE PROCEDURE DeleteTest
                                @testid INT
                            AS
                            BEGIN
                                DELETE FROM Tests
                                WHERE TestID = @testid
                            END";
			string getAllSymptoms = @"CREATE PROCEDURE GetSymptoms
                                AS
                                BEGIN
                                    SELECT * FROM Symptoms
                                END";
			//symptoms
			string getSymptomById = @"CREATE PROCEDURE GetSymptomById
                                @symptomsid int 
                                AS 
                                BEGIN
                                SELECT * FROM Symptoms WHERE  SymptomId=@symptomsid
                                END";
			string insertSymptom = @"CREATE PROCEDURE InsertSymptoms
                                    @symptomname VARCHAR(MAX)
                                AS
                                BEGIN
                                    INSERT INTO Symptoms(SymptomName)
                                    VALUES (@symptomname)
                                END";
			string updateSymptom = @"CREATE PROCEDURE UpdateSymptoms
                                    @symptomsid INT,
                                    @Newsymptomname VARCHAR(MAX)
                                AS
                                BEGIN
                                    UPDATE Symptoms
                                    SET SymptomName =  @Newsymptomname
                                    WHERE SymptomId = @symptomsid
                                END";
			string deleteSymptom = @"CREATE PROCEDURE DeleteSymptoms
                                @symptomsid INT
                            AS
                            BEGIN
                                DELETE FROM Symptoms
                                WHERE SymptomId =  @symptomsid
                            END";
			//Create
			string getAllDOSAGE = @"CREATE PROCEDURE GetDosage
                                AS
                                BEGIN
                                    SELECT * FROM Dosage
                                END";
			string getDOSAGEById = @"CREATE PROCEDURE GetDosageById
                                @Dosageid int 
                                AS 
                                BEGIN
                                SELECT * FROM Dosage WHERE  DosageID=@Dosageid
                                END";
			string insertDOSAGE = @"CREATE PROCEDURE InsertDosage
                                    @Newdosagename VARCHAR(MAX)
                                AS
                                BEGIN
                                    INSERT INTO Dosage(DosageName)
                                    VALUES ( @Newdosagename)
                                END";
			string updateDOSAGE = @"CREATE PROCEDURE UpdateDosage
                                    @Dosageid INT,
                                    @Newdosagename VARCHAR(MAX)
                                AS
                                BEGIN
                                    UPDATE Dosage
                                    SET DosageName =  @Newdosagename
                                    WHERE DosageID = @Dosageid
                                END";
			string deleteDOSAGE = @"CREATE PROCEDURE DeleteDosage
                                @Dosageid INT
                            AS
                            BEGIN
                                DELETE FROM Dosage
                                WHERE DosageID =  @Dosageid
                            END";
			//test
			migrationBuilder.Sql(getAllTEST);
			migrationBuilder.Sql(getTESTById);
			migrationBuilder.Sql(insertTEST);
			migrationBuilder.Sql(updateTEST);
			migrationBuilder.Sql(deleteTEST);
			//symptoms
			migrationBuilder.Sql(getAllSymptoms);
			migrationBuilder.Sql(getSymptomById);
			migrationBuilder.Sql(insertSymptom);
			migrationBuilder.Sql(updateSymptom);
			migrationBuilder.Sql(deleteSymptom);
			//Dosage
			migrationBuilder.Sql(getAllDOSAGE);
			migrationBuilder.Sql(getDOSAGEById);
			migrationBuilder.Sql(insertDOSAGE);
			migrationBuilder.Sql(updateDOSAGE);
			migrationBuilder.Sql(deleteDOSAGE);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterDosageEntry_Dosages_DosageID",
                table: "MasterDosageEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dosages",
                table: "Dosages");

            migrationBuilder.RenameTable(
                name: "Dosages",
                newName: "Dosage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dosage",
                table: "Dosage",
                column: "DosageID");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterDosageEntry_Dosage_DosageID",
                table: "MasterDosageEntry",
                column: "DosageID",
                principalTable: "Dosage",
                principalColumn: "DosageID",
                onDelete: ReferentialAction.Cascade);


			//test
			string getAllTEST = @"Drop proc GetTestsList";
			string getTESTById = @"Drop proc GetTestsById";
			string insertTEST = @"Drop proc InsertTest";
			string updateTEST = @"Drop proc UpdateTest";
			string deleteTEST = @"Drop proc DeleteTest";
			//symptoms
			string getAllSymptoms = @"Drop proc GetSymptoms";
			string getSymptomById = @"Drop proc GetSymptomById";
			string insertSymptom = @"Drop proc InsertSymptoms";
			string updateSymptom = @"Drop proc UpdateSymptoms";
			string deleteSymptom = @"Drop proc DeleteSymptoms";
			//Drop
			string getAllDOSAGE = @"Drop proc GetDosage";
			string getDOSAGEById = @"Drop proc GetDosageById";
			string insertDOSAGE = @"Drop proc insertDOSAGE";
			string updateDOSAGE = @"Drop proc UpdateDosage";
			string deleteDOSAGE = @"Drop proc DeleteDosage";

			//test
			migrationBuilder.Sql(getAllTEST);
			migrationBuilder.Sql(getTESTById);
			migrationBuilder.Sql(insertTEST);
			migrationBuilder.Sql(updateTEST);
			migrationBuilder.Sql(deleteTEST);
			//symptoms
			migrationBuilder.Sql(getAllSymptoms);
			migrationBuilder.Sql(getSymptomById);
			migrationBuilder.Sql(insertSymptom);
			migrationBuilder.Sql(updateSymptom);
			migrationBuilder.Sql(deleteSymptom);
			//Dosage
			migrationBuilder.Sql(getAllDOSAGE);
			migrationBuilder.Sql(getDOSAGEById);
			migrationBuilder.Sql(insertDOSAGE);
			migrationBuilder.Sql(updateDOSAGE);
			migrationBuilder.Sql(deleteDOSAGE);
		}
    }
}
