CREATE TABLE [dbo].[TBCliente] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Nome]        VARCHAR (300)    NOT NULL,
    [CPF]         VARCHAR (300)    NOT NULL,
    [CNPJ]        VARCHAR (300)    NULL,
    [Cnh]         VARCHAR (300)    NOT NULL,
    [Telefone]    VARCHAR (300)    NOT NULL,
    [Email]       VARCHAR (300)    NOT NULL,
    [Cidade]      VARCHAR (300)    NOT NULL,
    [CEP]         VARCHAR (300)    NOT NULL,
    [Numero]      VARCHAR (300)    NOT NULL,
    [Bairro]      VARCHAR (300)    NOT NULL,
    [UF]          INT              NOT NULL,
    [Complemento] VARCHAR (300)    NOT NULL,
    [Rua]         VARCHAR (300)    NOT NULL,
    CONSTRAINT [PK__TBClient__3214EC077C074026] PRIMARY KEY CLUSTERED ([Id] ASC)
);

