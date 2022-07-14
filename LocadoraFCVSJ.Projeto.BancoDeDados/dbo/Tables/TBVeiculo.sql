CREATE TABLE [dbo].[TBVeiculo] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Modelo]           VARCHAR (100)    NOT NULL,
    [Marca]            VARCHAR (100)    NOT NULL,
    [Placa]            VARCHAR (10)     NOT NULL,
    [Cor]              VARCHAR (100)    NOT NULL,
    [CapacidadeTanque] VARCHAR (100)    NOT NULL,
    [TipoCombustivel]  INT              NOT NULL,
    [Ano]              INT              NOT NULL,
    [KmPercorrido]     INT              NOT NULL,
    [Foto]             VARBINARY (MAX)  NOT NULL,
    [Grupo_Id]         UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TBVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculo_TBGrupo] FOREIGN KEY ([Grupo_Id]) REFERENCES [dbo].[TBGrupo] ([Id])
);

