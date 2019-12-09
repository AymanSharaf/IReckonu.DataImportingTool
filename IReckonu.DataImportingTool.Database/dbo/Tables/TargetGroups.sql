CREATE TABLE [dbo].[TargetGroups] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TargetGroups] PRIMARY KEY CLUSTERED ([Id] ASC)
);

