CREATE TABLE [dbo].[tbl_Privilligetbl_User] (
    [tbl_Privillige_ID] UNIQUEIDENTIFIER NOT NULL,
    [tbl_User_ID]       UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_tbl_Privilligetbl_User] PRIMARY KEY CLUSTERED ([tbl_Privillige_ID] ASC, [tbl_User_ID] ASC),
    CONSTRAINT [FK_tbl_Privilligetbl_User_Privilliges_tbl_Privillige_ID] FOREIGN KEY ([tbl_Privillige_ID]) REFERENCES [dbo].[Privilliges] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_Privilligetbl_User_Users_tbl_User_ID] FOREIGN KEY ([tbl_User_ID]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_tbl_Privilligetbl_User_tbl_User_ID]
    ON [dbo].[tbl_Privilligetbl_User]([tbl_User_ID] ASC);

