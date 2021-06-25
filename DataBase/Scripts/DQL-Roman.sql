USE Roman_Projects
GO

SELECT * FROM TiposUsuarios

SELECT * FROM Equipes

SELECT * FROM Usuarios

SELECT * FROM Temas

SELECT * FROM Projetos

-- seleciona os dados dos usuários mostrando o tipo de usuário 
-- e a equipe da qual o usuário faz parte
SELECT nomeUsuario AS [Nome de Usuário], tituloTipousuario AS Título, 
tituloEquipe AS Equipe, email AS Email
FROM Usuarios AS U
INNER JOIN TiposUsuarios AS T
ON U.idTipoUsuario = T.idTipoUsuario
INNER JOIN Equipes E
ON U.idEquipe = E.idEquipe


-- seleciona os dados dos projetos, mostrando o título do tema de cada projeto
-- assim como o nome do usuário que cadastrou o projeto no Roman mobile app
SELECT idProjeto [Número do Projeto], descricaoTema Tema, nomeUsuario [Nome de Usuário],
descricaoProjeto [Descrição do Projeto] 
FROM Projetos P
INNER JOIN Temas T
ON P.idTema = T.idTema
INNER JOIN Usuarios U
ON P.idUsuario = U.idUsuario
