using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class SP_Advice_And_Others : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			//--Create Stored Procedure for Retrieving All Symptoms

			string getAllAdvice = @"CREATE PROCEDURE GetAdviceList
                                AS
                                BEGIN
                                    SELECT * FROM Advices
                                END";

			//--Create Stored Procedure for Retrieving a Specific Symptom by ID

			string getAdviceById = @"CREATE PROCEDURE GetAdviceById
                                @AdviceId int 
                                AS 
                                BEGIN
                                SELECT * FROM Advices WHERE AdviceId=@AdviceId
                                END";

			//--Create Stored Procedure for Inserting a New Symptom
			string insertAdvice = @"CREATE PROCEDURE InsertAdvice
                                    @AdviceName VARCHAR(MAX)
                                AS
                                BEGIN
                                    INSERT INTO Advices (AdviceName)
                                    VALUES (@AdviceName)
                                END";

			//--Create Stored Procedure for Updating an Existing Symptom

			string updateAdvice = @"CREATE PROCEDURE UpdateAdvice
                                    @AdviceId INT,
                                    @NewAdviceName VARCHAR(MAX)
                                AS
                                BEGIN
                                    UPDATE Advices
                                    SET AdviceName = @NewAdviceName
                                    WHERE AdviceId = @AdviceId
                                END";

			//--Create Stored Procedure for Deleting a Symptom by ID

			string deleteAdvice = @"CREATE PROCEDURE DeleteAdvice
                                @AdviceId INT
                            AS
                            BEGIN
                                DELETE FROM Advices
                                WHERE AdviceId = @AdviceId
                            END";

			migrationBuilder.Sql(getAllAdvice);
			migrationBuilder.Sql(getAdviceById);
			migrationBuilder.Sql(insertAdvice);
			migrationBuilder.Sql(updateAdvice);
			migrationBuilder.Sql(deleteAdvice);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			string getAllAdvice = @"Drop proc GetAdviceList";
			string getAdviceById = @"Drop proc GetAdviceById";
			string insertAdvice = @"Drop proc InsertAdvice";
			string updateAdvice = @"Drop proc UpdateAdvice";
			string deleteAdvice = @"Drop proc DeleteAdvice";

			migrationBuilder.Sql(getAllAdvice);
			migrationBuilder.Sql(getAdviceById);
			migrationBuilder.Sql(insertAdvice);
			migrationBuilder.Sql(updateAdvice);
			migrationBuilder.Sql(deleteAdvice);
		}
    }
}
