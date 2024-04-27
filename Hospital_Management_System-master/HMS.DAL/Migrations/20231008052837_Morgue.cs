using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.DAL.Migrations
{
    public partial class Morgue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string getall = @"create proc SpGetAllMorgues
              as
              BEGIN
              SELECT * FROM Morgues
              END";
            string getbyid = @"create proc SpMorguesgetById(@id int)
            as
            BEGIN
            SELECT * FROM Morgues where MorgueID=@id 
            END";
            string InsertMorgue = @"
            CREATE PROCEDURE InsertMorgue
                @MorgueName NVARCHAR(100),
                @Capacity INT,
                @IsolationCapability BIT
            AS
            BEGIN
                INSERT INTO Morgues (MorgueName,Capacity, IsolationCapability)
                VALUES (@MorgueName, @Capacity, @IsolationCapability);
            END";
            string UpdateMorgue = @"
            CREATE PROCEDURE UpdateMorgue
                @MorgueID INT,
                @MorgueName NVARCHAR(100),
                @Capacity INT,
                @IsolationCapability BIT
            AS
            BEGIN
                UPDATE Morgues
                SET MorgueName= @MorgueName,
                    Capacity = @Capacity,
                    IsolationCapability = @IsolationCapability
                WHERE MorgueID = @MorgueID;
            END";
            string DeleteMorgue = @"
            CREATE PROCEDURE DeleteMorgue
                @MorgueID INT
            AS
            BEGIN
                DELETE FROM Morgues
                WHERE MorgueID = @MorgueID;
            END";

            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertMorgue);
            migrationBuilder.Sql(UpdateMorgue);
            migrationBuilder.Sql(DeleteMorgue);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string getall = @"Drop proc SpGetAllMorgues";
            string getbyid = @"Drop proc SpMorguesgetById";
            string InsertMorgue = @"Drop proc InsertMorgue";
            string UpdateMorgue = @"Drop proc UpdateMorgue";
            string DeleteMorgue = @"Drop proc DeleteMorgue";


            migrationBuilder.Sql(getall);
            migrationBuilder.Sql(getbyid);
            migrationBuilder.Sql(InsertMorgue);
            migrationBuilder.Sql(UpdateMorgue);
            migrationBuilder.Sql(DeleteMorgue);
        }
    }
}
