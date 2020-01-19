CREATE TABLE [dbo].[Privilliges] (
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [CreateUserID] UNIQUEIDENTIFIER NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [ModifyUserID] UNIQUEIDENTIFIER NULL,
    [ModifyDate]   DATETIME2 (7)    NOT NULL,
    [IsDeleted]    BIT              NOT NULL,
    [NameAr]       NVARCHAR (MAX)   NULL,
    [NameEn]       NVARCHAR (MAX)   NULL,
    [Key]          NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Privilliges] PRIMARY KEY CLUSTERED ([ID] ASC)
);

