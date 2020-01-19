CREATE TABLE [dbo].[tbl_Privilligetbl_Group] (
    [tbl_Privillige_ID] UNIQUEIDENTIFIER NOT NULL,
    [tbl_Group_ID]      UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_tbl_Privilligetbl_Group] PRIMARY KEY CLUSTERED ([tbl_Privillige_ID] ASC, [tbl_Group_ID] ASC),
    CONSTRAINT [FK_tbl_Privilligetbl_Group_Groups_tbl_Group_ID] FOREIGN KEY ([tbl_Group_ID]) REFERENCES [dbo].[Groups] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_tbl_Privilligetbl_Group_Privilliges_tbl_Privillige_ID] FOREIGN KEY ([tbl_Privillige_ID]) REFERENCES [dbo].[Privilliges] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [AK_tbl_Privilligetbl_Group_tbl_Group_ID_tbl_Privillige_ID] UNIQUE NONCLUSTERED ([tbl_Group_ID] ASC, [tbl_Privillige_ID] ASC)
);

