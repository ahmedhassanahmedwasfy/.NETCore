CREATE TABLE [dbo].[Menus] (
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [CreateUserID] UNIQUEIDENTIFIER NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [ModifyUserID] UNIQUEIDENTIFIER NULL,
    [ModifyDate]   DATETIME2 (7)    NOT NULL,
    [IsDeleted]    BIT              NOT NULL,
    [NameAr]       NVARCHAR (MAX)   NULL,
    [NameEn]       NVARCHAR (MAX)   NULL,
    [icon]         NVARCHAR (MAX)   NULL,
    [link]         NVARCHAR (MAX)   NULL,
    [isPrivate]    BIT              NOT NULL,
    [ParentID]     UNIQUEIDENTIFIER NULL,
    [PrivilligeID] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Menus_Menus_ParentID] FOREIGN KEY ([ParentID]) REFERENCES [dbo].[Menus] ([ID]),
    CONSTRAINT [FK_Menus_Privilliges_PrivilligeID] FOREIGN KEY ([PrivilligeID]) REFERENCES [dbo].[Privilliges] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Menus_ParentID]
    ON [dbo].[Menus]([ParentID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Menus_PrivilligeID]
    ON [dbo].[Menus]([PrivilligeID] ASC);

