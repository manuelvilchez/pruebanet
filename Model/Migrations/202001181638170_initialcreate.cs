namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        idcliente = c.Int(nullable: false, identity: true),
                        nmcliente = c.String(nullable: false, maxLength: 60),
                        ruccliente = c.String(nullable: false, maxLength: 11),
                        dircliente = c.String(nullable: false, maxLength: 100),
                        correocliente = c.String(nullable: false, maxLength: 30),
                        telefonocliente = c.String(nullable: false, maxLength: 15),
                        logocliente = c.String(maxLength: 32),
                        obscliente = c.String(maxLength: 100),
                        estadocliente = c.Int(nullable: false),
                        empresa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idcliente)
                .ForeignKey("dbo.Empresa", t => t.empresa_id)
                .Index(t => t.empresa_id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        idempresa = c.Int(nullable: false, identity: true),
                        nmempresa = c.String(nullable: false, maxLength: 60),
                        rucempresa = c.String(nullable: false, maxLength: 11),
                        dirempresa = c.String(nullable: false, maxLength: 100),
                        correoempresa = c.String(nullable: false, maxLength: 30),
                        telefonoempresa = c.String(nullable: false, maxLength: 15),
                        logoempresa = c.String(maxLength: 32),
                        obsempresa = c.String(maxLength: 100),
                        estadoempresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idempresa);
            
            CreateTable(
                "dbo.Sucursal",
                c => new
                    {
                        idsucursal = c.Int(nullable: false, identity: true),
                        nmsucursal = c.String(maxLength: 100),
                        codigosuc = c.String(maxLength: 20),
                        direccionsuc = c.String(maxLength: 100),
                        telefonosuc = c.String(maxLength: 20),
                        otroscu = c.String(maxLength: 100),
                        observacionsuc = c.String(maxLength: 100),
                        estadosuc = c.Int(nullable: false),
                        empresa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idsucursal)
                .ForeignKey("dbo.Empresa", t => t.empresa_id)
                .Index(t => t.empresa_id);
            
            CreateTable(
                "dbo.DetalleOrden",
                c => new
                    {
                        iddetalleorden = c.Int(nullable: false, identity: true),
                        Orden_Id = c.Int(nullable: false),
                        Hardware_Id = c.Int(nullable: false),
                        seriedt = c.String(),
                        usuariof = c.String(),
                        telefonof = c.String(),
                        ubicacion = c.String(),
                        cableseg = c.String(),
                        mouse = c.String(),
                        maleta = c.String(),
                        accesorio = c.String(),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IGV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        obscambio = c.String(),
                        estadodetalleorden = c.Int(nullable: false),
                        fregistro = c.String(),
                        gremision = c.String(),
                        grecepcion = c.String(),
                        codigontb = c.String(),
                        typedevice = c.String(),
                        seriehw = c.String(),
                        nmbrand = c.String(),
                        nmmodel = c.String(),
                        partnumberhw = c.String(),
                        snbatery = c.String(),
                        sncharger = c.String(),
                        nmprocessor = c.String(),
                        ghzprocessor = c.String(),
                        mcapacity = c.String(),
                        capacitystorage = c.String(),
                        lic = c.String(),
                        nmequipo = c.String(),
                        obshw = c.String(),
                    })
                .PrimaryKey(t => t.iddetalleorden)
                .ForeignKey("dbo.Hardware", t => t.Hardware_Id)
                .ForeignKey("dbo.Orden", t => t.Orden_Id)
                .Index(t => t.Orden_Id)
                .Index(t => t.Hardware_Id);
            
            CreateTable(
                "dbo.Hardware",
                c => new
                    {
                        idhw = c.Int(nullable: false, identity: true),
                        codigontb = c.String(maxLength: 10),
                        seriehw = c.String(maxLength: 60),
                        partnumberhw = c.String(maxLength: 30),
                        fgarantiahw = c.DateTime(nullable: false),
                        fregistrohw = c.DateTime(nullable: false),
                        typedevice = c.String(maxLength: 10),
                        nmequipo = c.String(maxLength: 30),
                        iddevice = c.Int(nullable: false),
                        idbrand = c.Int(nullable: false),
                        idmodel = c.Int(nullable: false),
                        iddetailhw = c.Int(nullable: false),
                        idstatusdevice = c.Int(nullable: false),
                        obshw = c.String(maxLength: 100),
                        sthw = c.Int(nullable: false),
                        docref = c.String(),
                    })
                .PrimaryKey(t => t.idhw);
            
            CreateTable(
                "dbo.Orden",
                c => new
                    {
                        idorden = c.Int(nullable: false, identity: true),
                        numeroorden = c.String(maxLength: 50),
                        codigoorden = c.String(maxLength: 10),
                        empresaorden = c.String(),
                        sucursalorden = c.String(),
                        clienteorden = c.String(),
                        contratointernoorden = c.String(maxLength: 50),
                        refacturableorden = c.String(maxLength: 50),
                        generateuserorden = c.String(maxLength: 50),
                        generateempresaorden = c.String(maxLength: 50),
                        fsolicitudorden = c.String(),
                        fentregaorden = c.String(),
                        responsableorden = c.String(maxLength: 50),
                        telefonoresponsableorden = c.String(maxLength: 50),
                        tipousuarioorden = c.String(maxLength: 50),
                        equipousuarioorden = c.String(maxLength: 50),
                        telefonousuarioorden = c.String(maxLength: 50),
                        redequipoorden = c.String(maxLength: 50),
                        ubicacionequipoorden = c.String(maxLength: 50),
                        Observacionesorden = c.String(maxLength: 50),
                        ordenservicio = c.String(maxLength: 50),
                        rqservicio = c.String(maxLength: 50),
                        adjuntoorden = c.String(maxLength: 50),
                        aprobadorrq = c.String(maxLength: 50),
                        correoaprobador = c.String(maxLength: 50),
                        motivorenting = c.String(maxLength: 50),
                        contratomarco = c.String(maxLength: 50),
                        tipocliente = c.String(maxLength: 50),
                        grupoeconomico = c.String(maxLength: 50),
                        rentinginicio = c.String(),
                        rentingfin = c.String(),
                        hardwaredevice = c.String(maxLength: 50),
                        cantidadhardware = c.String(maxLength: 50),
                        tipohardware = c.String(maxLength: 50),
                        sofwareorden = c.String(maxLength: 50),
                        estadoorden = c.String(maxLength: 50),
                        tipoatencionorden = c.String(maxLength: 50),
                        factura = c.String(),
                        ftemision = c.String(),
                        produccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idorden);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 300),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(),
                        ThemeColor = c.String(maxLength: 10),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        idusuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        correo = c.String(nullable: false, maxLength: 50),
                        clave = c.String(maxLength: 50),
                        telefono = c.String(nullable: false, maxLength: 15),
                        razonsocial = c.String(nullable: false, maxLength: 200),
                        foto = c.String(maxLength: 100),
                        activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idusuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleOrden", "Orden_Id", "dbo.Orden");
            DropForeignKey("dbo.DetalleOrden", "Hardware_Id", "dbo.Hardware");
            DropForeignKey("dbo.Sucursal", "empresa_id", "dbo.Empresa");
            DropForeignKey("dbo.Cliente", "empresa_id", "dbo.Empresa");
            DropIndex("dbo.DetalleOrden", new[] { "Hardware_Id" });
            DropIndex("dbo.DetalleOrden", new[] { "Orden_Id" });
            DropIndex("dbo.Sucursal", new[] { "empresa_id" });
            DropIndex("dbo.Cliente", new[] { "empresa_id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Events");
            DropTable("dbo.Orden");
            DropTable("dbo.Hardware");
            DropTable("dbo.DetalleOrden");
            DropTable("dbo.Sucursal");
            DropTable("dbo.Empresa");
            DropTable("dbo.Cliente");
        }
    }
}
