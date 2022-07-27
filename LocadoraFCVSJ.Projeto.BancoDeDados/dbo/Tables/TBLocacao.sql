CREATE TABLE [dbo].[TBLocacao] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [Cliente_ID]         UNIQUEIDENTIFIER NOT NULL,
    [DataLocacao]        DATETIME         NOT NULL,
    [DataDevolucao]      DATETIME         NOT NULL,
    [Veiculo_ID]         UNIQUEIDENTIFIER NOT NULL,
    [Taxa_ID]            UNIQUEIDENTIFIER NOT NULL,
    [precoEstimado]      DECIMAL (18)     NOT NULL,
    [PlanoDeCobranca_ID] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TBLocacao] PRIMARY KEY CLUSTERED ([Id] ASC)
);

