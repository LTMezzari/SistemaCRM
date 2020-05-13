USE [master]
GO
CREATE DATABASE BDCrm
GO
USE BDCrm
GO
CREATE TABLE Contato(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(60) NOT NULL,
	Email VARCHAR(100) NOT NULL,
)
GO
INSERT INTO Contato VALUES ('Rodrigo Silveira', 'rsilveira@email.com'), ('Marcos Almeida Dias', 'mdias@email.com')
GO
CREATE TABLE Agenda(
	ID INT PRIMARY KEY IDENTITY(1,1),
	data_agenda DATE NOT NULL,
	contato_id INT NOT NULL,
	titulo NVARCHAR(50) NOT NULL,
	descricao NVARCHAR(100) NULL,
	horario_inicio TIME NULL,
	horario_fim TIME NULL
)
GO
SELECT a.*, b.ID AS Codigo, b.Nome, b.Email FROM Agenda AS a INNER JOIN Contato AS b ON a.contato_id = b.ID