CREATE TABLE [dbo].[GridSettings] (
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [CreateUserID] UNIQUEIDENTIFIER NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [ModifyUserID] UNIQUEIDENTIFIER NULL,
    [ModifyDate]   DATETIME2 (7)    NOT NULL,
    [IsDeleted]    BIT              NOT NULL,
    [UserID]       UNIQUEIDENTIFIER NOT NULL,
    [Key]          NVARCHAR (MAX)   NULL,
    [Value]        NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_GridSettings] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_GridSettings_Users_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GridSettings_UserID]
    ON [dbo].[GridSettings]([UserID] ASC);

