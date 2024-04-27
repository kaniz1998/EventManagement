using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
	public partial class SP_outdoor : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "Morgues",
				columns: new[] { "MorgueID", "Capacity", "IsolationCapability", "MorgueName" },
				values: new object[] { 1, 50, true, "Morgue-1" });

			migrationBuilder.InsertData(
				table: "Morgues",
				columns: new[] { "MorgueID", "Capacity", "IsolationCapability", "MorgueName" },
				values: new object[] { 2, 100, false, "Morgue-2" });

			migrationBuilder.InsertData(
				table: "Drawers",
				columns: new[] { "DrawerID", "DrawerCondition", "DrawerNo", "IsOccupied", "MorgueID" },
				values: new object[] { 1, 1, "Drawer-001", false, 1 });

			migrationBuilder.InsertData(
				table: "Drawers",
				columns: new[] { "DrawerID", "DrawerCondition", "DrawerNo", "IsOccupied", "MorgueID" },
				values: new object[] { 2, 2, "Drawer-002", true, 2 });

			//Store Procedure code
			var procGetOutdoorById = @"
				-- stored procedure ==> Get Any Outdoor record By Id
				CREATE PROCEDURE GetOutdoorById
					@Id INT
				AS
				BEGIN
					BEGIN TRY
						DECLARE @Result INT

						SELECT @Result = COUNT(*) FROM Outdoors WHERE OutdoorID = @Id

						IF @Result = 0
						BEGIN
							THROW 50000, 'Outdoor ID not found', 1
						END
						SELECT * FROM Outdoors WHERE OutdoorID = @Id
					END TRY
					BEGIN CATCH
						PRINT 'An error occurred: ' + ERROR_MESSAGE()
					END CATCH
				END
				GO
				";

			var procGetAllOutdoors = @"
				-- stored procedure ==> Get All Outdoors record
				CREATE PROCEDURE GetAllOutdoors
				AS
				BEGIN
					BEGIN TRY
						-- records in the Outdoors table
						IF NOT EXISTS (SELECT 1 FROM Outdoors)
						BEGIN
							--  no records
							THROW 50001, 'No Outdoor record found', 1
						END

						SELECT * FROM Outdoors
					END TRY
					BEGIN CATCH
						PRINT 'An error occurred: ' + ERROR_MESSAGE()
					END CATCH
				END
				GO
				--test
				EXEC GetAllOutdoors
				";

			var procGetOutdoorsByPatientId = @"
				-- stored procedure ==> Get Outdoor record By searching PatientId
				CREATE PROCEDURE GetOutdoorsByPatientId
					@PatientId INT
				AS
				BEGIN
					BEGIN TRY
						--If PatientRegisters doesn't have PatientID
						IF NOT EXISTS (SELECT 1 FROM PatientRegisters WHERE PatientID = @PatientId)
						BEGIN
							THROW 50002, 'PatientID not Exist!! ', 1
						END
						ELSE
						BEGIN
							-- specific patient hasn't received any treatment (in Outdoor)
							IF NOT EXISTS (SELECT 1 FROM Outdoors WHERE PatientID = @PatientId)
							BEGIN
								-- PatientRegisters has PatientID, but outdoor haven't
								THROW 50003, 'This PatientID exist but It hasn''t received any treatment in Outdoor yet', 2
							END
							SELECT * FROM Outdoors WHERE PatientID = @PatientId
						END
					END TRY
					BEGIN CATCH
						PRINT 'An error occurred: ' + ERROR_MESSAGE()
					END CATCH
				END
				GO
				";

			var procGetOutdoorsByTreatmentType = @"
				-- stored procedure ==> GetOutdoorsByTreatmentType
				CREATE PROCEDURE GetOutdoorsByTreatmentType
					@TreatmentType INT
				AS
				BEGIN
					BEGIN TRY
						--  if the TreatmentType exists
						IF NOT EXISTS (SELECT 1 FROM Outdoors WHERE TreatmentType = @TreatmentType)
						BEGIN
							-- when TreatmentType is not found in Outdoor history // not necessary because of enum
							THROW 50004, 'This type of treatment not exist in Outdoor', 1
						END
						ELSE
						BEGIN
							--TreatmentType exists, but specific treatment records don't exist
							IF EXISTS (SELECT 1 FROM Outdoors WHERE TreatmentType = @TreatmentType AND PatientID IS NULL )
							BEGIN
								THROW 50005, 'No Outdoor record found for this type of Treatment', 2
							END
							SELECT * FROM Outdoors WHERE TreatmentType = @TreatmentType
						END
					END TRY
					BEGIN CATCH
						PRINT 'An error occurred: ' + ERROR_MESSAGE()
					END CATCH
				END
				GO
				";

			var procGetOutdoorsByTreatmentDate = @"
				-- stored procedure ==> GetOutdoorsByTreatmentDate
				CREATE PROCEDURE GetOutdoorsByTreatmentDate
					@TreatmentDate DATE
				AS
				BEGIN
					BEGIN TRY
						-- check records for specific Date
						IF NOT EXISTS (SELECT 1 FROM Outdoors WHERE TreatmentDate = @TreatmentDate)
						BEGIN
							--  no records for specified date
							THROW 50006, 'No outdoor record found for this date', 1
						END
						SELECT * FROM Outdoors WHERE TreatmentDate = @TreatmentDate
					END TRY
					BEGIN CATCH
						PRINT 'An error occurred: ' + ERROR_MESSAGE()
					END CATCH
				END
				GO
				";


			var procAddOutdoor = @"
				-- stored procedure ==> Add new Outdoor record
					create PROCEDURE AddOutdoor
						@PatientID INT,
						@TreatmentType INT,
						@TreatmentDate DATE,
						@Remarks NVARCHAR(MAX),
						@IsAdmissionRequired BIT
					AS
					BEGIN
						BEGIN TRY
							BEGIN TRANSACTION;
							--PatientID null?
							IF @PatientID IS NULL
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50012, 'You can''t insert outdoor record without PatientID', 1;
							END
							-- PatientID exists?
							ELSE IF NOT EXISTS (SELECT 1 FROM PatientRegisters WHERE PatientID = @PatientID)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50013, 'Selected PatientID does not exist in the PatientRegister table', 6;
							END

							-- TreatmentDate is Past Date or not?
							IF @TreatmentDate < CAST(GETDATE() AS DATE)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50014, 'Treatment Date must be today or a future date', 3;
							END

							-- add new Outdoors record
							INSERT INTO Outdoors (PatientID, TreatmentType, TreatmentDate, Remarks, IsAdmissionRequired)
							VALUES (@PatientID, @TreatmentType, @TreatmentDate, @Remarks, @IsAdmissionRequired);

							COMMIT TRANSACTION;
						END TRY
						BEGIN CATCH
							ROLLBACK TRANSACTION;
							PRINT 'An error occurred: ' + ERROR_MESSAGE();
						END CATCH
					END
				GO
				";

			var procUpdateOutdoor = @"
				-- stored procedure ==> UpdateOutdoor
				create PROCEDURE UpdateOutdoor
					@OutdoorID INT,
					@PatientID INT,
					@TreatmentType INT,
					@TreatmentDate DATE,
					@Remarks NVARCHAR(MAX),
					@IsAdmissionRequired BIT
				AS
				BEGIN
					BEGIN TRY
						BEGIN TRANSACTION;
							--PatientID null?
							IF @PatientID IS NULL
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50012, 'You can''t insert outdoor record without PatientID', 1;
							END
							-- PatientID exists?
							ELSE IF NOT EXISTS (SELECT 1 FROM PatientRegisters WHERE PatientID = @PatientID)
							BEGIN
								ROLLBACK TRANSACTION;
								THROW 50013, 'Selected PatientID does not exist in the PatientRegister table', 6;
							END

						-- TreatmentDate past date or not
						IF @TreatmentDate < CAST(GETDATE() AS DATE)
						BEGIN
							ROLLBACK TRANSACTION;
							THROW 50018, 'Treatment Date must be today or a future date', 3;
						END


						-- Update the Outdoor record
						UPDATE Outdoors
						SET PatientID = @PatientID,
							TreatmentType = @TreatmentType,
							TreatmentDate = @TreatmentDate,
							Remarks = @Remarks,
							IsAdmissionRequired = @IsAdmissionRequired
						WHERE OutdoorID = @OutdoorID;

						COMMIT TRANSACTION;
					END TRY
					BEGIN CATCH
						ROLLBACK TRANSACTION;
						PRINT 'An error occurred: ' + ERROR_MESSAGE();
					END CATCH
				END
				GO
				";

			var procDeleteOutdoor = @"
				-- stored procedure ==> DeleteOutdoor
				CREATE PROCEDURE DeleteOutdoor
					@OutdoorID INT
				AS
				BEGIN
					BEGIN TRY
						DECLARE @Result INT

						SELECT @Result = COUNT(*) FROM Outdoors WHERE OutdoorID = @OutdoorID

						IF @Result = 0
						BEGIN
							--OutdoorID is not found
							THROW 50000, 'Outdoor ID not found', 1
						END

						-- Prevent delete outdoor
						IF @OutdoorID is not null
						THROW 50002, 'Outdoor record can''t be deleted', 2
					END TRY
					BEGIN CATCH
						PRINT 'An error occurred: ' + ERROR_MESSAGE()
					END CATCH
				END
				GO
				";


			migrationBuilder.Sql(procGetOutdoorById);
			migrationBuilder.Sql(procGetAllOutdoors);
			migrationBuilder.Sql(procGetOutdoorsByPatientId);
			migrationBuilder.Sql(procGetOutdoorsByTreatmentType);
			migrationBuilder.Sql(procGetOutdoorsByTreatmentDate);
			migrationBuilder.Sql(procAddOutdoor);
			migrationBuilder.Sql(procUpdateOutdoor);
			migrationBuilder.Sql(procDeleteOutdoor);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "Drawers",
				keyColumn: "DrawerID",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Drawers",
				keyColumn: "DrawerID",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "Morgues",
				keyColumn: "MorgueID",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Morgues",
				keyColumn: "MorgueID",
				keyValue: 2);

			migrationBuilder.Sql("DROP PROCEDURE GetOutdoorById;");
			migrationBuilder.Sql("DROP PROCEDURE GetAllOutdoors;");
			migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByPatientId;");
			migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByTreatmentType;");
			migrationBuilder.Sql("DROP PROCEDURE GetOutdoorsByTreatmentDate;");
			migrationBuilder.Sql("DROP PROCEDURE AddOutdoor;");
			migrationBuilder.Sql("DROP PROCEDURE UpdateOutdoor;");
			migrationBuilder.Sql("DROP PROCEDURE DeleteOutdoor;");
		}
	}
}
