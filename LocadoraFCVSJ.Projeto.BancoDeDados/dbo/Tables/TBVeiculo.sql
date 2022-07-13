CREATE TABLE [dbo].[TBVeiculo]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [GrupoVeiculo] INT NOT NULL, 
    [Modelo] VARCHAR(50) NOT NULL, 
    [Marca] VARCHAR(50) NOT NULL, 
    [Placa] VARCHAR(50) NOT NULL, 
    [Cor] VARCHAR(50) NOT NULL, 
    [TipoCombustivel] INT NOT NULL, 
    [CapacidadeTanque] INT NOT NULL, 
    [Ano] INT NOT NULL, 
    [KmPercorrido] INT NOT NULL, 
    [Foto] VARBINARY(MAX) NOT NULL
)
