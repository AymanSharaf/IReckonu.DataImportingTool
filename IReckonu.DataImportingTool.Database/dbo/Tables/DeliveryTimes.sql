CREATE TABLE [dbo].[DeliveryTimes] (
    [Id]   INT      IDENTITY (1, 1) NOT NULL,
    [From] TIME (7) NOT NULL,
    [To]   TIME (7) NOT NULL,
    CONSTRAINT [PK_DeliveryTimes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

