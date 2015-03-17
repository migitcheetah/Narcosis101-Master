namespace Narcosis101.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Class = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        ShutterSpeed = c.String(),
                        PowerReq = c.String(),
                        Dimensions = c.String(),
                        Weight = c.String(),
                        Finish = c.String(),
                        Lens = c.String(),
                        ExposureMeter = c.String(),
                        ExposureControl = c.String(),
                        Brightness = c.String(),
                        Lens1 = c.String(),
                        ExposureMeter1 = c.String(),
                        ExposureControl1 = c.String(),
                        Millimeters = c.String(),
                        Fnum = c.String(),
                        FilterSize = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Flash_ID = c.Int(),
                        Lense_ID = c.Int(),
                        Camera_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.Flash_ID)
                .ForeignKey("dbo.Items", t => t.Lense_ID)
                .ForeignKey("dbo.Items", t => t.Camera_ID)
                .Index(t => t.Flash_ID)
                .Index(t => t.Lense_ID)
                .Index(t => t.Camera_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Camera_ID", "dbo.Items");
            DropForeignKey("dbo.Items", "Lense_ID", "dbo.Items");
            DropForeignKey("dbo.Items", "Flash_ID", "dbo.Items");
            DropIndex("dbo.Items", new[] { "Camera_ID" });
            DropIndex("dbo.Items", new[] { "Lense_ID" });
            DropIndex("dbo.Items", new[] { "Flash_ID" });
            DropTable("dbo.Items");
        }
    }
}
