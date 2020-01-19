﻿CREATE TABLE [dbo].[UserTypes] (
    [ID]           UNIQUEIDENTIFIER NOT NULL,
    [CreateUserID] UNIQUEIDENTIFIER NULL,
    [CreateDate]   DATETIME2 (7)    NOT NULL,
    [ModifyUserID] UNIQUEIDENTIFIER NULL,
    [ModifyDate]   DATETIME2 (7)    NOT NULL,
    [IsDeleted]    BIT              NOT NULL,
    [NameAr]       NVARCHAR (MAX)   NULL,
    [NameEn]       NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);
