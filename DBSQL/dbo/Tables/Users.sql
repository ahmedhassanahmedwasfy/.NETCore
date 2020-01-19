CREATE TABLE [dbo].[Users] (
    [ID]                  UNIQUEIDENTIFIER NOT NULL,
    [CreateUserID]        UNIQUEIDENTIFIER NULL,
    [CreateDate]          DATETIME2 (7)    NOT NULL,
    [ModifyUserID]        UNIQUEIDENTIFIER NULL,
    [ModifyDate]          DATETIME2 (7)    NOT NULL,
    [IsDeleted]           BIT              NOT NULL,
    [NameAr]              NVARCHAR (MAX)   NULL,
    [NameEn]              NVARCHAR (MAX)   NULL,
    [Mobile]              NVARCHAR (MAX)   NULL,
    [Password]            NVARCHAR (MAX)   NULL,
    [Email]               NVARCHAR (MAX)   NULL,
    [isAD]                BIT              NOT NULL,
    [IsThirdParty]        BIT              NOT NULL,
    [Image]               NVARCHAR (MAX)   NULL,
    [Name]                NVARCHAR (MAX)   NULL,
    [Secret]              NVARCHAR (MAX)   NULL,
    [UserTypeID]          UNIQUEIDENTIFIER NULL,
    [isActivated]         BIT              NOT NULL,
    [ActivationStartDate] DATETIME2 (7)    NULL,
    [ActivationEndDate]   DATETIME2 (7)    NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Users_UserTypes_UserTypeID] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserTypes] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_UserTypeID]
    ON [dbo].[Users]([UserTypeID] ASC);

