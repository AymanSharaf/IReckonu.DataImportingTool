CREATE TABLE [dbo].[Articles] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Code]          NVARCHAR (MAX) NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [BrandId]       INT            NOT NULL,
    [TargetGroupId] INT            NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Articles_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Articles_TargetGroups_TargetGroupId] FOREIGN KEY ([TargetGroupId]) REFERENCES [dbo].[TargetGroups] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Articles_TargetGroupId]
    ON [dbo].[Articles]([TargetGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Articles_BrandId]
    ON [dbo].[Articles]([BrandId] ASC);

