CREATE TABLE [dbo].[Colors] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

