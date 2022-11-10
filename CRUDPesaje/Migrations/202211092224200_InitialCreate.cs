namespace CRUDPesaje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Codigo = c.Int(nullable: false),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Cuidad = c.String(),
                        Departamento = c.String(),
                        Pais = c.String(),
                        FechaAdd = c.DateTime(),
                        FechaEdit = c.DateTime(),
                    })
                .PrimaryKey(t => t.EmpresaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Empresas");
        }
    }
}
