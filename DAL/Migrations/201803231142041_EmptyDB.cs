namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_batch",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        isReleased = c.Boolean(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_PrintingQueue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SIRAIDCardNumber = c.String(maxLength: 50),
                        CompanyName = c.String(maxLength: 50),
                        LIA = c.String(maxLength: 50),
                        LicenseNumber = c.String(maxLength: 50),
                        RequestNumber = c.String(maxLength: 50),
                        RequestDate = c.String(maxLength: 50),
                        StatusDate = c.String(maxLength: 50),
                        RequestType = c.String(maxLength: 50),
                        RequestStatus = c.String(maxLength: 50),
                        Category = c.String(maxLength: 50),
                        CardType = c.String(maxLength: 50),
                        ExpiryDate = c.String(maxLength: 50),
                        NameOnCard_EN = c.String(maxLength: 50),
                        NameOnCard_AR = c.String(maxLength: 50),
                        EmployeeName_EN = c.String(maxLength: 50),
                        EmployeeName_AR = c.String(maxLength: 50),
                        Nationality = c.String(maxLength: 50),
                        MobileNumber = c.String(maxLength: 50),
                        TelephoneNumber = c.String(maxLength: 50),
                        PassportNumber = c.String(maxLength: 50),
                        DateOfBirth = c.String(maxLength: 50),
                        PassportIssuedBy = c.String(maxLength: 50),
                        EmiratesIDCardNumber = c.String(maxLength: 50),
                        InvoiceNumber = c.String(maxLength: 50),
                        ReceiptNumber = c.String(maxLength: 50),
                        Photo = c.String(),
                        Field01 = c.String(maxLength: 50),
                        Field02 = c.String(maxLength: 50),
                        Field03 = c.String(maxLength: 50),
                        Field04 = c.String(maxLength: 50),
                        Field05 = c.String(maxLength: 50),
                        Field06 = c.String(maxLength: 50),
                        Field07 = c.String(maxLength: 50),
                        Field08 = c.String(maxLength: 50),
                        Field09 = c.String(maxLength: 50),
                        Field10 = c.String(maxLength: 50),
                        RfTagNumber = c.String(maxLength: 50),
                        RFT1 = c.String(maxLength: 50),
                        PrintingStatus = c.Int(nullable: false),
                        PrintTime = c.DateTime(),
                        isLandscape = c.Boolean(nullable: false),
                        isEncoding = c.Boolean(nullable: false),
                        batch_ID = c.Int(),
                        Printer_ID = c.Int(),
                        user_ID = c.Int(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_batch", t => t.batch_ID)
                .ForeignKey("dbo.tbl_Printer", t => t.Printer_ID)
                .ForeignKey("dbo.tbl_Status", t => t.PrintingStatus, cascadeDelete: true)
                .ForeignKey("dbo.tbl_User", t => t.user_ID)
                .Index(t => t.PrintingStatus)
                .Index(t => t.batch_ID)
                .Index(t => t.Printer_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.tbl_Printer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Serial = c.String(maxLength: 50),
                        IsEnabled = c.Boolean(nullable: false),
                        Group_ID = c.Int(),
                        RibbonRemain = c.String(),
                        FilmRemain = c.String(),
                        Status = c.String(),
                        CardPosition = c.String(),
                        TotalPrintCount = c.String(),
                        PrintingStage = c.String(),
                        PrinterError = c.String(),
                        ReaderSerialNumber = c.String(),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_PrintersGroup", t => t.Group_ID)
                .Index(t => t.Group_ID);
            
            CreateTable(
                "dbo.tbl_PrintersGroup",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        location_ID = c.Int(),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_location", t => t.location_ID)
                .Index(t => t.location_ID);
            
            CreateTable(
                "dbo.tbl_location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_QueueImages",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FrontIMG = c.Binary(),
                        BackIMG = c.Binary(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_PrintingQueue", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.tbl_User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        isAD = c.Boolean(nullable: false),
                        isActivated = c.Boolean(nullable: false),
                        ActivatedStartDate = c.DateTime(),
                        PrinterGroup_ID = c.Int(),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_PrintersGroup", t => t.PrinterGroup_ID)
                .Index(t => t.PrinterGroup_ID);
            
            CreateTable(
                "dbo.tbl_Group",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Privillige",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Layout",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Type = c.String(),
                        LayoutFolderPath = c.String(),
                        isLandscape = c.Boolean(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        icon = c.String(),
                        link = c.String(),
                        isPrivate = c.Boolean(nullable: false),
                        NameAr = c.String(),
                        NameEn = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        tbl_Menu_ID = c.Int(),
                        Privillige_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Menu", t => t.tbl_Menu_ID)
                .ForeignKey("dbo.tbl_Privillige", t => t.Privillige_ID)
                .Index(t => t.tbl_Menu_ID)
                .Index(t => t.Privillige_ID);
            
            CreateTable(
                "dbo.tbl_PrintingQueueReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PrintingQueue_CardID = c.Int(nullable: false),
                        SIRAIDCardNumber = c.String(maxLength: 50),
                        CompanyName = c.String(maxLength: 50),
                        LIA = c.String(maxLength: 50),
                        LicenseNumber = c.String(maxLength: 50),
                        RequestNumber = c.String(maxLength: 50),
                        RequestDate = c.String(maxLength: 50),
                        StatusDate = c.String(maxLength: 50),
                        RequestType = c.String(maxLength: 50),
                        RequestStatus = c.String(maxLength: 50),
                        Category = c.String(maxLength: 50),
                        CardType = c.String(maxLength: 50),
                        ExpiryDate = c.String(maxLength: 50),
                        NameOnCard_EN = c.String(maxLength: 50),
                        NameOnCard_AR = c.String(maxLength: 50),
                        EmployeeName_EN = c.String(maxLength: 50),
                        EmployeeName_AR = c.String(maxLength: 50),
                        Nationality = c.String(maxLength: 50),
                        MobileNumber = c.String(maxLength: 50),
                        TelephoneNumber = c.String(maxLength: 50),
                        PassportNumber = c.String(maxLength: 50),
                        DateOfBirth = c.String(maxLength: 50),
                        PassportIssuedBy = c.String(maxLength: 50),
                        EmiratesIDCardNumber = c.String(maxLength: 50),
                        InvoiceNumber = c.String(maxLength: 50),
                        ReceiptNumber = c.String(maxLength: 50),
                        Photo = c.String(),
                        Field01 = c.String(maxLength: 50),
                        Field02 = c.String(maxLength: 50),
                        Field03 = c.String(maxLength: 50),
                        Field04 = c.String(maxLength: 50),
                        Field05 = c.String(maxLength: 50),
                        Field06 = c.String(maxLength: 50),
                        Field07 = c.String(maxLength: 50),
                        Field08 = c.String(maxLength: 50),
                        Field09 = c.String(maxLength: 50),
                        Field10 = c.String(maxLength: 50),
                        RfTagNumber = c.String(maxLength: 50),
                        RFT1 = c.String(maxLength: 50),
                        PrintingStatus = c.Int(nullable: false),
                        PrintTime = c.DateTime(),
                        isLandscape = c.Boolean(nullable: false),
                        isEncoding = c.Boolean(nullable: false),
                        batch_ID = c.Int(nullable: false),
                        Printer = c.String(),
                        user = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Status", t => t.PrintingStatus, cascadeDelete: true)
                .Index(t => t.PrintingStatus);
            
            CreateTable(
                "dbo.tbl_Setting",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Key = c.String(maxLength: 50),
                        Value = c.String(nullable: false),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_vostok_GetCardDetails_CardData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SIRAIDCardNumber = c.String(),
                        CompanyName = c.String(),
                        LIA = c.String(),
                        LicenseNumber = c.String(),
                        RequestNumber = c.String(),
                        RequestDate = c.String(),
                        StatusDate = c.String(),
                        RequestType = c.String(),
                        RequestStatus = c.String(),
                        Category = c.String(),
                        CardType = c.String(),
                        ExpiryDate = c.String(),
                        NameOnCard_EN = c.String(),
                        NameOnCard_AR = c.String(),
                        EmployeeName_EN = c.String(),
                        EmployeeName_AR = c.String(),
                        Nationality = c.String(),
                        MobileNumber = c.String(),
                        TelephoneNumber = c.String(),
                        PassportNumber = c.String(),
                        DateOfBirth = c.DateTime(),
                        PassportIssuedBy = c.String(),
                        EmiratesIDCardNumber = c.String(),
                        InvoiceNumber = c.String(),
                        ReceiptNumber = c.String(),
                        Photo = c.String(),
                        PrintedBy = c.String(),
                        Field01 = c.String(),
                        Field02 = c.String(),
                        Field03 = c.String(),
                        Field04 = c.String(),
                        Field05 = c.String(),
                        Field06 = c.String(),
                        Field07 = c.String(),
                        Field08 = c.String(),
                        Field09 = c.String(),
                        Field10 = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        tbl_vostok_GetCardDetailsResponse_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_vostok_GetCardDetailsResponse", t => t.tbl_vostok_GetCardDetailsResponse_ID)
                .Index(t => t.tbl_vostok_GetCardDetailsResponse_ID);
            
            CreateTable(
                "dbo.tbl_vostok_GetCardDetailsRequest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceRequestType = c.String(),
                        SIRAIDCardNumber = c.String(),
                        CompanyName = c.String(),
                        LIA = c.String(),
                        LicenseNumber = c.String(),
                        RequestNumber = c.String(),
                        RequestDateFrom = c.String(),
                        RequestDateTo = c.String(),
                        RequestType = c.String(),
                        RequestStatus = c.String(),
                        Category = c.String(),
                        CardType = c.String(),
                        ExpiryDate = c.String(),
                        NameOnCard_EN = c.String(),
                        NameOnCard_AR = c.String(),
                        EmployeeName_EN = c.String(),
                        EmployeeName_AR = c.String(),
                        Nationality = c.String(),
                        MobileNumber = c.String(),
                        TelephoneNumber = c.String(),
                        PassportNumber = c.String(),
                        DateOfBirth = c.String(),
                        PassportIssuedBy = c.String(),
                        EmiratesIDCardNumber = c.String(),
                        InvoiceNumber = c.String(),
                        ReceiptNumber = c.String(),
                        StatusDateFrom = c.String(),
                        StatusDateTo = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        ClientIP = c.String(),
                        MACAddress = c.String(),
                        ServiceRequestFrom = c.String(),
                        ServiceRequestNumber = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_vostok_GetCardDetailsResponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OldServiceRequestNumber = c.String(),
                        HavePendingCards = c.String(),
                        TotalCardCount = c.String(),
                        SendCardCount = c.String(),
                        PendingCardCount = c.String(),
                        ServiceRequestNumber = c.String(),
                        Status = c.String(),
                        Message = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_vostok_GetReceiptNumberRequest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FromDate = c.String(),
                        ToDate = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        ClientIP = c.String(),
                        MACAddress = c.String(),
                        ServiceRequestFrom = c.String(),
                        ServiceRequestNumber = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_vostok_GetReceiptNumberResponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServiceRequestNumber = c.String(),
                        Status = c.String(),
                        Message = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_vostok_Receiptnumberlist",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ReceiptNumber = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        tbl_vostok_GetReceiptNumberResponse_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_vostok_GetReceiptNumberResponse", t => t.tbl_vostok_GetReceiptNumberResponse_ID)
                .Index(t => t.tbl_vostok_GetReceiptNumberResponse_ID);
            
            CreateTable(
                "dbo.tbl_vostok_UpdateCardStatus_PrintStatusInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestNumber = c.String(),
                        Location = c.String(),
                        SerialNo = c.String(),
                        RFT1 = c.String(),
                        RfTagNumber = c.String(),
                        Status = c.String(),
                        PrintedDateTime = c.String(),
                        PrintedByName = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        tbl_vostok_UpdateCardStatusRequest_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_vostok_UpdateCardStatusRequest", t => t.tbl_vostok_UpdateCardStatusRequest_ID)
                .Index(t => t.tbl_vostok_UpdateCardStatusRequest_ID);
            
            CreateTable(
                "dbo.tbl_vostok_UpdateCardStatus_CardData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SIRAIDCardNumber = c.String(),
                        CompanyName = c.String(),
                        LIA = c.String(),
                        LicenseNumber = c.String(),
                        RequestNumber = c.String(),
                        RequestDate = c.String(),
                        StatusDate = c.String(),
                        RequestType = c.String(),
                        RequestStatus = c.String(),
                        Category = c.String(),
                        CardType = c.String(),
                        ExpiryDate = c.String(),
                        NameOnCard_EN = c.String(),
                        NameOnCard_AR = c.String(),
                        EmployeeName_EN = c.String(),
                        EmployeeName_AR = c.String(),
                        Nationality = c.String(),
                        MobileNumber = c.String(),
                        TelephoneNumber = c.String(),
                        PassportNumber = c.String(),
                        DateOfBirth = c.DateTime(),
                        PassportIssuedBy = c.String(),
                        EmiratesIDCardNumber = c.String(),
                        InvoiceNumber = c.String(),
                        ReceiptNumber = c.String(),
                        Photo = c.String(),
                        PrintedBy = c.String(),
                        Field01 = c.String(),
                        Field02 = c.String(),
                        Field03 = c.String(),
                        Field04 = c.String(),
                        Field05 = c.String(),
                        Field06 = c.String(),
                        Field07 = c.String(),
                        Field08 = c.String(),
                        Field09 = c.String(),
                        Field10 = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        tbl_vostok_UpdateCardStatusResponse_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_vostok_UpdateCardStatusResponse", t => t.tbl_vostok_UpdateCardStatusResponse_ID)
                .Index(t => t.tbl_vostok_UpdateCardStatusResponse_ID);
            
            CreateTable(
                "dbo.tbl_vostok_UpdateCardStatusRequest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        ClientIP = c.String(),
                        MACAddress = c.String(),
                        ServiceRequestFrom = c.String(),
                        ServiceRequestNumber = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_vostok_UpdateCardStatusResponse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OldServiceRequestNumber = c.String(),
                        HavePendingCards = c.String(),
                        TotalCardCount = c.String(),
                        SendCardCount = c.String(),
                        PendingCardCount = c.String(),
                        ServiceRequestNumber = c.String(),
                        Status = c.String(),
                        Message = c.String(),
                        CreateUserID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyUserID = c.Int(nullable: false),
                        ModifyDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Privilligetbl_Group",
                c => new
                    {
                        tbl_Privillige_ID = c.Int(nullable: false),
                        tbl_Group_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.tbl_Privillige_ID, t.tbl_Group_ID })
                .ForeignKey("dbo.tbl_Privillige", t => t.tbl_Privillige_ID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_Group", t => t.tbl_Group_ID, cascadeDelete: true)
                .Index(t => t.tbl_Privillige_ID)
                .Index(t => t.tbl_Group_ID);
            
            CreateTable(
                "dbo.tbl_Privilligetbl_User",
                c => new
                    {
                        tbl_Privillige_ID = c.Int(nullable: false),
                        tbl_User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.tbl_Privillige_ID, t.tbl_User_ID })
                .ForeignKey("dbo.tbl_Privillige", t => t.tbl_Privillige_ID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_User", t => t.tbl_User_ID, cascadeDelete: true)
                .Index(t => t.tbl_Privillige_ID)
                .Index(t => t.tbl_User_ID);
            
            CreateTable(
                "dbo.tbl_Grouptbl_User",
                c => new
                    {
                        tbl_Group_ID = c.Int(nullable: false),
                        tbl_User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.tbl_Group_ID, t.tbl_User_ID })
                .ForeignKey("dbo.tbl_Group", t => t.tbl_Group_ID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_User", t => t.tbl_User_ID, cascadeDelete: true)
                .Index(t => t.tbl_Group_ID)
                .Index(t => t.tbl_User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_vostok_UpdateCardStatus_CardData", "tbl_vostok_UpdateCardStatusResponse_ID", "dbo.tbl_vostok_UpdateCardStatusResponse");
            DropForeignKey("dbo.tbl_vostok_UpdateCardStatus_PrintStatusInfo", "tbl_vostok_UpdateCardStatusRequest_ID", "dbo.tbl_vostok_UpdateCardStatusRequest");
            DropForeignKey("dbo.tbl_vostok_Receiptnumberlist", "tbl_vostok_GetReceiptNumberResponse_ID", "dbo.tbl_vostok_GetReceiptNumberResponse");
            DropForeignKey("dbo.tbl_vostok_GetCardDetails_CardData", "tbl_vostok_GetCardDetailsResponse_ID", "dbo.tbl_vostok_GetCardDetailsResponse");
            DropForeignKey("dbo.tbl_PrintingQueueReports", "PrintingStatus", "dbo.tbl_Status");
            DropForeignKey("dbo.tbl_Menu", "Privillige_ID", "dbo.tbl_Privillige");
            DropForeignKey("dbo.tbl_Menu", "tbl_Menu_ID", "dbo.tbl_Menu");
            DropForeignKey("dbo.tbl_PrintingQueue", "user_ID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_User", "PrinterGroup_ID", "dbo.tbl_PrintersGroup");
            DropForeignKey("dbo.tbl_Grouptbl_User", "tbl_User_ID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_Grouptbl_User", "tbl_Group_ID", "dbo.tbl_Group");
            DropForeignKey("dbo.tbl_Privilligetbl_User", "tbl_User_ID", "dbo.tbl_User");
            DropForeignKey("dbo.tbl_Privilligetbl_User", "tbl_Privillige_ID", "dbo.tbl_Privillige");
            DropForeignKey("dbo.tbl_Privilligetbl_Group", "tbl_Group_ID", "dbo.tbl_Group");
            DropForeignKey("dbo.tbl_Privilligetbl_Group", "tbl_Privillige_ID", "dbo.tbl_Privillige");
            DropForeignKey("dbo.tbl_QueueImages", "ID", "dbo.tbl_PrintingQueue");
            DropForeignKey("dbo.tbl_PrintingQueue", "PrintingStatus", "dbo.tbl_Status");
            DropForeignKey("dbo.tbl_Printer", "Group_ID", "dbo.tbl_PrintersGroup");
            DropForeignKey("dbo.tbl_PrintersGroup", "location_ID", "dbo.tbl_location");
            DropForeignKey("dbo.tbl_PrintingQueue", "Printer_ID", "dbo.tbl_Printer");
            DropForeignKey("dbo.tbl_PrintingQueue", "batch_ID", "dbo.tbl_batch");
            DropIndex("dbo.tbl_Grouptbl_User", new[] { "tbl_User_ID" });
            DropIndex("dbo.tbl_Grouptbl_User", new[] { "tbl_Group_ID" });
            DropIndex("dbo.tbl_Privilligetbl_User", new[] { "tbl_User_ID" });
            DropIndex("dbo.tbl_Privilligetbl_User", new[] { "tbl_Privillige_ID" });
            DropIndex("dbo.tbl_Privilligetbl_Group", new[] { "tbl_Group_ID" });
            DropIndex("dbo.tbl_Privilligetbl_Group", new[] { "tbl_Privillige_ID" });
            DropIndex("dbo.tbl_vostok_UpdateCardStatus_CardData", new[] { "tbl_vostok_UpdateCardStatusResponse_ID" });
            DropIndex("dbo.tbl_vostok_UpdateCardStatus_PrintStatusInfo", new[] { "tbl_vostok_UpdateCardStatusRequest_ID" });
            DropIndex("dbo.tbl_vostok_Receiptnumberlist", new[] { "tbl_vostok_GetReceiptNumberResponse_ID" });
            DropIndex("dbo.tbl_vostok_GetCardDetails_CardData", new[] { "tbl_vostok_GetCardDetailsResponse_ID" });
            DropIndex("dbo.tbl_PrintingQueueReports", new[] { "PrintingStatus" });
            DropIndex("dbo.tbl_Menu", new[] { "Privillige_ID" });
            DropIndex("dbo.tbl_Menu", new[] { "tbl_Menu_ID" });
            DropIndex("dbo.tbl_User", new[] { "PrinterGroup_ID" });
            DropIndex("dbo.tbl_QueueImages", new[] { "ID" });
            DropIndex("dbo.tbl_PrintersGroup", new[] { "location_ID" });
            DropIndex("dbo.tbl_Printer", new[] { "Group_ID" });
            DropIndex("dbo.tbl_PrintingQueue", new[] { "user_ID" });
            DropIndex("dbo.tbl_PrintingQueue", new[] { "Printer_ID" });
            DropIndex("dbo.tbl_PrintingQueue", new[] { "batch_ID" });
            DropIndex("dbo.tbl_PrintingQueue", new[] { "PrintingStatus" });
            DropTable("dbo.tbl_Grouptbl_User");
            DropTable("dbo.tbl_Privilligetbl_User");
            DropTable("dbo.tbl_Privilligetbl_Group");
            DropTable("dbo.tbl_vostok_UpdateCardStatusResponse");
            DropTable("dbo.tbl_vostok_UpdateCardStatusRequest");
            DropTable("dbo.tbl_vostok_UpdateCardStatus_CardData");
            DropTable("dbo.tbl_vostok_UpdateCardStatus_PrintStatusInfo");
            DropTable("dbo.tbl_vostok_Receiptnumberlist");
            DropTable("dbo.tbl_vostok_GetReceiptNumberResponse");
            DropTable("dbo.tbl_vostok_GetReceiptNumberRequest");
            DropTable("dbo.tbl_vostok_GetCardDetailsResponse");
            DropTable("dbo.tbl_vostok_GetCardDetailsRequest");
            DropTable("dbo.tbl_vostok_GetCardDetails_CardData");
            DropTable("dbo.tbl_Setting");
            DropTable("dbo.tbl_PrintingQueueReports");
            DropTable("dbo.tbl_Menu");
            DropTable("dbo.tbl_Layout");
            DropTable("dbo.tbl_Privillige");
            DropTable("dbo.tbl_Group");
            DropTable("dbo.tbl_User");
            DropTable("dbo.tbl_QueueImages");
            DropTable("dbo.tbl_Status");
            DropTable("dbo.tbl_location");
            DropTable("dbo.tbl_PrintersGroup");
            DropTable("dbo.tbl_Printer");
            DropTable("dbo.tbl_PrintingQueue");
            DropTable("dbo.tbl_batch");
        }
    }
}
