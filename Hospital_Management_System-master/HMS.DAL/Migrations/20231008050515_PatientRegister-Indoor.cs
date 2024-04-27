using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class PatientRegisterIndoor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
			string GetAllPatientSP = @"CREATE PROCEDURE GetAllPatients
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        SELECT * FROM PatientRegisters;
                                    END";
			string GetPAtientByIDSP = @"CREATE PROCEDURE GetPatientByID
                                        @PatientID INT
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        SELECT * FROM PatientRegisters
                                        WHERE PatientID = @PatientID;
                                    END";
			string SearchPatientByNameOrGender = @"CREATE PROCEDURE SearchPatients
                                                                    @SearchName NVARCHAR(100) = NULL,
                                                                    @SearchGender INT = NULL
                                                                    AS
                                                                    BEGIN
                                                                        SET NOCOUNT ON;

                                                                        SELECT * FROM PatientRegisters
                                                                        WHERE
                                                                            (@SearchName IS NULL OR PatientName LIKE '%' + @SearchName + '%')
                                                                            AND (@SearchGender IS NULL OR Gender = @SearchGender);
                                                                    END";
			string InsertPatientSP = @"CREATE PROCEDURE InsertPatient
                                @PatientName NVARCHAR(100),
                                @Gender INT,
                                @Address NVARCHAR(500) = NULL,
                                @PhoneNumber NVARCHAR(11),
                                @Email NVARCHAR(255) = NULL
                            AS
                            BEGIN
                                SET NOCOUNT ON;

                                INSERT INTO PatientRegisters (PatientName, Gender, Address, PhoneNumber, Email)
                                VALUES (@PatientName, @Gender, @Address, @PhoneNumber, @Email);

                                DECLARE @PatientID INT;
                                SET @PatientID = SCOPE_IDENTITY();

                                -- You can include additional logic here if needed, such as handling prescriptions or indoor patients.

                                SELECT @PatientID AS PatientID;
                            END";

			string UpdatePatientSP = @"CREATE PROCEDURE UpdatePatient
                                    @PatientID INT,
                                    @PatientName NVARCHAR(100),
                                    @Gender INT,
                                    @Address NVARCHAR(500) = NULL,
                                    @PhoneNumber NVARCHAR(11),
                                    @Email NVARCHAR(255) = NULL
                                AS
                                BEGIN
                                    SET NOCOUNT ON;

                                    UPDATE PatientRegisters
                                    SET PatientName = @PatientName,
                                        Gender = @Gender,
                                        Address = @Address,
                                        PhoneNumber = @PhoneNumber,
                                        Email = @Email
                                    WHERE PatientID = @PatientID;

                                    -- You can include additional logic here if needed, such as handling prescriptions or indoor patients.

                                    SELECT @@ROWCOUNT AS RowsAffected;
                                END";

			migrationBuilder.Sql(GetAllPatientSP);
			migrationBuilder.Sql(GetPAtientByIDSP);
			migrationBuilder.Sql(SearchPatientByNameOrGender);
			migrationBuilder.Sql(InsertPatientSP);
			migrationBuilder.Sql(UpdatePatientSP);


			string GetAllIndoorPatientsSP = @"CREATE PROCEDURE  GetAllIndoorPatients
                                            AS
                                            BEGIN
                                                SET NOCOUNT ON;

                                                SELECT * FROM IndoorPatients;
                                            END";
			string getIndoorPatientByID = @"CREATE PROCEDURE GetIndoorPatientByID
                                            @IndoorPatientID INT
                                        AS
                                        BEGIN
                                            SET NOCOUNT ON;

                                            SELECT * FROM IndoorPatients
                                            WHERE IndoorPatientID = @IndoorPatientID;
                                        END";
			string InsertIndoorPatientSP = @"CREATE PROCEDURE InsertIndoorPatient
                            @ReferredBy NVARCHAR(200),
                            @BedID INT,
                            @InsuranceInfo NVARCHAR(500) = NULL,
                            @AdmissionNotes NVARCHAR(500) = NULL,
                            @IsDead BIT,
                            @PatientID INT,
                            @MedicalRecordsID INT,
                            @NIDnumber NVARCHAR(11),
                            @AdmissionDate DATE,
                            @DateOfBirth DATE,
                            @EmergencyContact NVARCHAR(11),
                            @BloodType INT,
                            @IsTransferred BIT
                        AS
                        BEGIN
                            SET NOCOUNT ON;

                            INSERT INTO IndoorPatients (
                                ReferredBy, BedID, InsuranceInfo, AdmissionNotes, IsDead, PatientID, MedicalRecordsID,
                                NIDnumber, AdmissionDate, DateOfBirth, EmergencyContact, BloodType, IsTransferred
                            )
                            VALUES (
                                @ReferredBy, @BedID, @InsuranceInfo, @AdmissionNotes, @IsDead, @PatientID, @MedicalRecordsID,
                                @NIDnumber, @AdmissionDate, @DateOfBirth, @EmergencyContact, @BloodType, @IsTransferred
                            );

                            -- You can include additional logic here if needed.

                            DECLARE @IndoorPatientID INT;
                            SET @IndoorPatientID = SCOPE_IDENTITY();

                            SELECT @IndoorPatientID AS IndoorPatientID;
                        END";




			string UpdateIndoorPatientSP = @"CREATE PROCEDURE UpdateIndoorPatient
                                        @IndoorPatientID INT,
                                        @ReferredBy NVARCHAR(200),
                                        @BedID INT,
                                        @InsuranceInfo NVARCHAR(500) = NULL,
                                        @AdmissionNotes NVARCHAR(500) = NULL,
                                        @IsDead BIT,
                                        @PatientID INT,
                                        @MedicalRecordsID INT,
                                        @NIDnumber NVARCHAR(11),
                                        @AdmissionDate DATE,
                                        @DateOfBirth DATE,
                                        @EmergencyContact NVARCHAR(11),
                                        @BloodType INT,
                                        @IsTransferred BIT
                                    AS
                                    BEGIN
                                        SET NOCOUNT ON;

                                        UPDATE IndoorPatients
                                        SET
                                            ReferredBy = @ReferredBy,
                                            BedID = @BedID,
                                            InsuranceInfo = @InsuranceInfo,
                                            AdmissionNotes = @AdmissionNotes,
                                            IsDead = @IsDead,
                                            PatientID = @PatientID,
                                            MedicalRecordsID = @MedicalRecordsID,
                                            NIDnumber = @NIDnumber,
                                            AdmissionDate = @AdmissionDate,
                                            DateOfBirth = @DateOfBirth,
                                            EmergencyContact = @EmergencyContact,
                                            BloodType = @BloodType,
                                            IsTransferred = @IsTransferred
                                        WHERE IndoorPatientID = @IndoorPatientID;

                                        -- You can include additional logic here if needed.

                                        SELECT @@ROWCOUNT AS RowsAffected;
                                    END";


			string DeleteIndoorPatientSP = @"CREATE PROCEDURE DeleteIndoorPatient
                                    @IndoorPatientID INT
                                AS
                                BEGIN
                                    SET NOCOUNT ON;

                                    DELETE FROM IndoorPatients
                                    WHERE IndoorPatientID = @IndoorPatientID;

                                    -- You can include additional logic here if needed.

                                    SELECT @@ROWCOUNT AS RowsAffected;
                                END";
			migrationBuilder.Sql(GetAllIndoorPatientsSP);
			migrationBuilder.Sql(getIndoorPatientByID);
			migrationBuilder.Sql(InsertIndoorPatientSP);
			migrationBuilder.Sql(UpdateIndoorPatientSP);
			migrationBuilder.Sql(DeleteIndoorPatientSP);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string GetAllPatientSP = @"drop proc GetAllPatients";

			string GetPAtientByIDSP = @"drop proc GetPatientByID";

			string SearchPatientByNameOrGender = @"drop proc SearchPatients";

			string InsertPatientSP = @"drop proc InsertPatient";

			string UpdatePatientSP = @"drop proc UpdatePatient";


			migrationBuilder.Sql(GetAllPatientSP);
			migrationBuilder.Sql(GetPAtientByIDSP);
			migrationBuilder.Sql(SearchPatientByNameOrGender);
			migrationBuilder.Sql(InsertPatientSP);
			migrationBuilder.Sql(UpdatePatientSP);


			string GetAllIndoorPatientsSP = @"drop proc GetAllIndoorPatients";

			string getIndoorPatientByID = @"drop proc GetIndoorPatientByID";

			string InsertIndoorPatientSP = @"drop proc InsertIndoorPatient";

			string UpdateIndoorPatientSP = @"drop proc UpdateIndoorPatient";

			string DeleteIndoorPatientSP = @"drop proc DeleteIndoorPatient";


			migrationBuilder.Sql(GetAllIndoorPatientsSP);
			migrationBuilder.Sql(getIndoorPatientByID);
			migrationBuilder.Sql(InsertIndoorPatientSP);
			migrationBuilder.Sql(UpdateIndoorPatientSP);
			migrationBuilder.Sql(DeleteIndoorPatientSP);
		}
    }
}
