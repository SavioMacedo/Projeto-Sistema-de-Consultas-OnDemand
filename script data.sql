-- Script Date: 30/04/2018 22:59  - ErikEJ.SqlCeScripting version 3.5.2.75
-- Database information:
-- Database: C:\Users\savio\Desktop\Projeto\MVC\database.db
-- ServerVersion: 3.22.0
-- DatabaseSize: 96 KB
-- Created: 20/04/2018 13:28

-- User Table information:
-- Number of tables: 10
-- __EFMigrationsHistory: -1 row(s)
-- Assoc_usua_consus: -1 row(s)
-- Atualizas: -1 row(s)
-- Consultas: -1 row(s)
-- PARAMETRO_CONSULTAs: -1 row(s)
-- SQL_LINHAs: -1 row(s)
-- Tipo_Associacaos: -1 row(s)
-- Tipo_Parametros: -1 row(s)
-- Usuarios: -1 row(s)
-- Versaos: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
INSERT INTO [Usuarios] ([ID],[EMAIL],[NOME],[SENHA]) VALUES (
1,'cristhiansamuelp@hotmail.com','Cristhian','senha1');
INSERT INTO [Usuarios] ([ID],[EMAIL],[NOME],[SENHA]) VALUES (
2,'saviom.cedo@hotmail.com','Savio','senha2');
INSERT INTO [Tipo_Parametros] ([ID],[NM_LABEL],[NOME]) VALUES (
1,'number','Numerico');
INSERT INTO [Tipo_Parametros] ([ID],[NM_LABEL],[NOME]) VALUES (
2,'date','Data');
INSERT INTO [Tipo_Parametros] ([ID],[NM_LABEL],[NOME]) VALUES (
3,'datetime','Data com Hora');
INSERT INTO [Tipo_Parametros] ([ID],[NM_LABEL],[NOME]) VALUES (
4,'text','Texto');
INSERT INTO [Tipo_Associacaos] ([ID],[TP_ASSOC]) VALUES (
1,'Usuario Criador');
INSERT INTO [Tipo_Associacaos] ([ID],[TP_ASSOC]) VALUES (
2,'Usuario Chave');
INSERT INTO [Consultas] ([ID],[DESCRICAO],[DT_CRIACAO],[IC_ATIVO],[NOME],[TipoBancoDadosID]) VALUES (
6,'Relatório de todos os 100 primeiros produtos da tabela.','2018-04-17 13:34:24.8964153','Sim','Todos os Produtos',1);
INSERT INTO [Consultas] ([ID],[DESCRICAO],[DT_CRIACAO],[IC_ATIVO],[NOME],[TipoBancoDadosID]) VALUES (
8,'Esta consulta mostra a data atual','2018-04-20 19:34:24.8964153','Sim','Consulta de Data',1);
INSERT INTO [Consultas] ([ID],[DESCRICAO],[DT_CRIACAO],[IC_ATIVO],[NOME],[TipoBancoDadosID]) VALUES (
9,'Todos os emails cadastros na base do sistema ','2018-04-20 21:31:06.209731','Sim','Todos os Emails',1);
INSERT INTO [Versaos] ([ID],[ConsultaID],[DESCRICAO],[DT_CRIACAO],[IC_ATIVO],[NU_VERSAO]) VALUES (
5,6,'Versão Inicial','2017-10-22 21:14:21.1482279','Sim',1);
INSERT INTO [Versaos] ([ID],[ConsultaID],[DESCRICAO],[DT_CRIACAO],[IC_ATIVO],[NU_VERSAO]) VALUES (
7,8,'Versão Inicial','2018-04-20 19:34:25.2113983','Sim',1);
INSERT INTO [Versaos] ([ID],[ConsultaID],[DESCRICAO],[DT_CRIACAO],[IC_ATIVO],[NU_VERSAO]) VALUES (
8,9,'Versão Inicial','2018-04-20 21:31:06.5528986','Sim',1);
INSERT INTO [SQL_LINHAs] ([ID],[NU_LINHA],[SQL],[VersaoID]) VALUES (
6,'1','/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (100) [ProductID]
      ,[Name]
      ,[ProductNumber]
      ,[MakeFlag]
      ,[FinishedGoodsFlag]
      ,[Color]
      ,[SafetyStockLevel]
      ,[ReorderPoint]
      ,[StandardCost]
      ,[ListPrice]
      ,[Size]
      ,[SizeUnitMeasureCode]
      ,[WeightUnitMeasureCode]
      ,[Weight]
      ,[DaysToManufacture]
      ,[ProductLine]
      ,[Class]
      ,[Style]
      ,[ProductSubcategoryID]
      ,[ProductModelID]
      ,[SellStartDate]
      ,[SellEndDate]
      ,[DiscontinuedDate]
      ,[rowguid]
      ,[ModifiedDate]
  FROM [AdventureWorks2014].[Production].[Product]',5);
INSERT INTO [SQL_LINHAs] ([ID],[NU_LINHA],[SQL],[VersaoID]) VALUES (
8,'1','select getdate() as DataAtual',7);
INSERT INTO [SQL_LINHAs] ([ID],[NU_LINHA],[SQL],[VersaoID]) VALUES (
9,'1','select top 100',8);
INSERT INTO [SQL_LINHAs] ([ID],[NU_LINHA],[SQL],[VersaoID]) VALUES (
10,'2','*',8);
INSERT INTO [SQL_LINHAs] ([ID],[NU_LINHA],[SQL],[VersaoID]) VALUES (
11,'3','from',8);
INSERT INTO [SQL_LINHAs] ([ID],[NU_LINHA],[SQL],[VersaoID]) VALUES (
12,'4','AdventureWorks2014.[Person].[EmailAddress]',8);
INSERT INTO [Assoc_usua_consus] ([ID],[ConsultaID],[DT_CRIACAO],[Tipo_AssociacaoID],[UsuarioID]) VALUES (
7,8,'2018-04-20 19:34:25.4384755',2,2);
INSERT INTO [Assoc_usua_consus] ([ID],[ConsultaID],[DT_CRIACAO],[Tipo_AssociacaoID],[UsuarioID]) VALUES (
8,8,'2018-04-20 19:34:25.4391767',1,1);
INSERT INTO [Assoc_usua_consus] ([ID],[ConsultaID],[DT_CRIACAO],[Tipo_AssociacaoID],[UsuarioID]) VALUES (
9,9,'2018-04-20 21:31:07.1748711',2,2);
INSERT INTO [Assoc_usua_consus] ([ID],[ConsultaID],[DT_CRIACAO],[Tipo_AssociacaoID],[UsuarioID]) VALUES (
10,9,'2018-04-20 21:31:07.1752159',1,1);
COMMIT;

