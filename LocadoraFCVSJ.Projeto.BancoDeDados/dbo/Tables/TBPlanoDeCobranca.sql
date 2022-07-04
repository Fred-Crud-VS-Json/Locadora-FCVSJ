CREATE TABLE [dbo].[TBPlanoDeCobranca] (
    [Id]                          INT             IDENTITY (1, 1) NOT NULL,
    [PlanoDiario_ValorDiario]     DECIMAL (18, 2) NOT NULL,
    [PlanoDiario_ValorKm]         DECIMAL (18, 2) NOT NULL,
    [PlanoLivre_ValorDiario]      DECIMAL (18, 2) NOT NULL,
    [PlanoControlado_ValorDiario] DECIMAL (18, 2) NOT NULL,
    [PlanoControlado_ValorKm]     DECIMAL (18, 2) NOT NULL,
    [PlanoControlado_LimiteKm]    DECIMAL (18, 2) NOT NULL,
    [Grupo_Id]                    INT             NOT NULL,
    CONSTRAINT [PK_TBPlanoDeCobranca] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBPlanoDeCobranca_TBGrupo] FOREIGN KEY ([Grupo_Id]) REFERENCES [dbo].[TBGrupo] ([Id])
);

