CREATE DATABASE Roman_Projects
GO

USE Roman_Projects
GO

CREATE TABLE TiposUsuarios
(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(200) UNIQUE NOT NULL
)
GO

CREATE TABLE Equipes
(
	idEquipe INT PRIMARY KEY IDENTITY,
	tituloEquipe VARCHAR(200) UNIQUE NOT NULL
)
GO

CREATE TABLE Usuarios
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(idTipoUsuario),
	idEquipe INT FOREIGN KEY REFERENCES Equipes(idEquipe),
	nomeUsuario VARCHAR(200) NOT NULL,
	email VARCHAR(200) UNIQUE NOT NULL,
	senha VARCHAR(200) NOT NULL
)
GO

CREATE TABLE Temas
(
	idTema INT PRIMARY KEY IDENTITY,
	descricaoTema VARCHAR(200) UNIQUE NOT NULL,
	situacaoTema BIT DEFAULT(1) -- 1=ativo(padrão) / 0=inativo
)
GO

CREATE TABLE Projetos
(
	idProjeto INT PRIMARY KEY IDENTITY,
	idTema INT FOREIGN KEY REFERENCES Temas(idTema),
	idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario),
	descricaoProjeto TEXT NOT NULL
)