namespace Almacen.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeloinicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Referencia = c.String(nullable: false, maxLength: 50),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 200),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Int(nullable: false),
                        Imagen = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        Usuario = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Usuario);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Request");
            DropTable("dbo.Producto");
        }
    }
}
