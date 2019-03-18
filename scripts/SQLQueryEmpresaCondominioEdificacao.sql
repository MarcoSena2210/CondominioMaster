--USE [db_condominiomaster]
--GO

--INSERT INTO [dbo].[Empresa]
--           ([DataIncluiRegistro]
--           ,[StatusRegistro]
--           ,[Nome]
--           ,[Apelido]
--           ,[CpfCnpj]
--           ,[Email]
--           ,[Endereco]
--           ,[Bairro]
--           ,[Cidade]
--           ,[UF]
--           ,[CEP])
--     VALUES
--           ('16-03-2019 10:00:00'
--		   ,'A'
--           ,'Empresa A Praia Grande'
--           ,'PGrande'
--           ,35786336000106
--           ,'pgenderh@gmail.com'
--           ,'Rua A '
--		   ,'Bairro central'
--		   ,'Salvador'
--           ,'BA'
--           ,'40457880')
--GO

--SELECT * FROM EMPRESA

--INSERT INTO [dbo].Condominio
--           ([DataIncluiRegistro]
--           ,[StatusRegistro]
--           ,[Nome]
--           ,[Apelido]
--           ,[CpfCnpj]
--           ,[Email]
--           ,[Endereco]
--           ,[Bairro]
--           ,[Cidade]
--           ,[UF]
--           ,[CEP]
--		   ,IdEmpresa)
--     VALUES
--           ('16-03-2019 10:00:00'
--		   ,'A'
--           ,'Condominio Inglaterra '
--           ,'CI'
--           ,66338984000123
--           ,'pgenderh@gmail.com'
--           ,'Rua A '
--		   ,'Bairro central'
--		   ,'Salvador'
--           ,'BA'
--           ,'40457880',1)
--GO
--SELECT * FROM CONDOMINIO


INSERT INTO [dbo].EDIFICACAO
           ([DataIncluiRegistro]
           ,[StatusRegistro]
           ,[Nome]
           ,[Apelido]
           ,[CpfCnpj]
           ,[Email]
           ,[Endereco]
           ,[Bairro]
           ,[Cidade]
           ,[UF]
           ,[CEP]
			,IdCondominio)
     VALUES
           ('16-03-2019 10:00:00'
		   ,'A'
           ,'Edificio Petalas Brilhantes'
           ,'PTB'
           ,92677158000119
           ,'pgenderh@gmail.com'
           ,'Rua A '
		   ,'Bairro central'
		   ,'Salvador'
           ,'BA'
           ,'40457880',1)
GO
SELECT * FROM EDIFICACAO
go
