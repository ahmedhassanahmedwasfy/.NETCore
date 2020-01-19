CREATE TABLE [dbo].[tbl_Grouptbl_User] (
    [tbl_Group_ID] UNIQUEIDENTIFIER NOT NULL,
    [tbl_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_tbl_Grouptbl_User] PRIMARY KEY CLUSTERED ([tbl_Group_ID] ASC, [tbl_User_ID] ASC),
    CONSTRAINT [FK_tbl_Grouptbl_User_Groups_tbl_Group_ID] FOREIGN KEY ([tbl_Group_ID]) REFERENCES [dbo].[Groups] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_Grouptbl_User_Users_tbl_User_ID] FOREIGN KEY ([tbl_User_ID]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_tbl_Grouptbl_User_tbl_User_ID]
    ON [dbo].[tbl_Grouptbl_User]([tbl_User_ID] ASC);

