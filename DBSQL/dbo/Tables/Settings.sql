CREATE TABLE [dbo].[Settings] (
    [CreateUserID] UNIQUEIDENTIFIER NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [ModifyUserID] UNIQUEIDENTIFIER NULL,
    [ModifyDate]   DATETIME2 (7)    NOT NULL,
    [IsDeleted]    BIT              NOT NULL,
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [Conf_Key]     NVARCHAR (MAX)   NULL,
    [Conf_Value]   NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([ID] ASC)
);

