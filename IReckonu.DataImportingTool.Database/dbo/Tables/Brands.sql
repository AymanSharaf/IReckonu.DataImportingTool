﻿CREATE TABLE [dbo].[Brands] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([Id] ASC)
);

