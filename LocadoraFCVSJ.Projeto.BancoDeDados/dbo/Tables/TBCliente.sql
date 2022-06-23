CREATE TABLE [dbo].[TBCliente] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (300) NOT NULL,
    [Dado]     VARCHAR (300) NOT NULL,
    [Endereco] VARCHAR (300) NOT NULL,
    [Tipo]     VARCHAR (300) NOT NULL,
    [Cnh]      VARCHAR (300) NOT NULL,
    [Telefone] VARCHAR (300) NOT NULL,
    [Email]    VARCHAR (300) NOT NULL,
    CONSTRAINT [PK__TBClient__3214EC077C074026] PRIMARY KEY CLUSTERED ([Id] ASC)
);

