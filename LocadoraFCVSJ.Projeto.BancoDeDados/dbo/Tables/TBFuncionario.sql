CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Nome]         VARCHAR (100)    NOT NULL,
    [Login]        VARCHAR (100)    NOT NULL,
    [Senha]        VARCHAR (100)    NOT NULL,
    [Salario]      DECIMAL (18, 2)  NOT NULL,
    [DataAdmissao] DATETIME         NOT NULL,
    [NivelAcesso]  INT              NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

