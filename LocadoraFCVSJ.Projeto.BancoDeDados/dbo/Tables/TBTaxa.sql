CREATE TABLE [dbo].[TBTaxa] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Nome]            VARCHAR (200)    NOT NULL,
    [Valor]           DECIMAL (18, 2)  NOT NULL,
    [TipoCalculoTaxa] INT              NOT NULL,
    CONSTRAINT [PK__TBTaxa__3214EC074242E119] PRIMARY KEY CLUSTERED ([Id] ASC)
);

