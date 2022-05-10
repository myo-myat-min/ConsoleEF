namespace ConsoleEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDeviceAndCustomerTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                {
                    SerialNo = c.Int(nullable: false, identity: true),
                    DeviceName = c.String(nullable: false, maxLength: 15)
                })
                .PrimaryKey(t => t.SerialNo)
                .Index(t => t.DeviceName, unique: true, name: "UK_Device");

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20, unicode: false),
                    SerialNo = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.SerialNo, name: "FE_SerialNoTest");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Devices", new[] { "Customer_Id" });
            DropIndex("dbo.Devices", "UK_Device");
            DropTable("dbo.Devices");
            DropTable("dbo.Customers");
        }
    }
}
