USE HRoads;

-- Tabela com as Classes
SELECT Classes.Cargos AS Classes FROM Classes;

-- Tabela com o Nome das Habilidades
SELECT Habilidades.Tecnicas AS Habilidades FROM Habilidades;

-- Tabela com Personagens e Classes
SELECT Personagens.Nomes, Personagens.VidaMaxima, Personagens.ManaMaxima, Personagens.DataAtualizacao, Personagens.DataCriacao, Classes.Cargos AS Classes FROM Personagens
INNER JOIN Classes
ON Personagens.idPersonagem = Classes.idClasses;

-- Tabela com os id's das Habilidades
SELECT Habilidades.idHabilidades FROM Habilidades;

-- Tabela com os tipos de Habilidades
SELECT TiposHabilidades.Tipos AS Tipos_de_Habilidades FROM TiposHabilidades

-- Tabela com todas as Classes e respectivos personagens
SELECT Classes.Cargos AS Classes, Personagens.Nomes FROM Personagens
RIGHT JOIN Classes
ON Personagens.idPersonagem = Classes.idClasses;

-- Realizar a contagem de quantas habilidades estão cadastradas
SELECT COUNT(idHabilidades) AS QtdHabilidades FROM Habilidades;

-- Tabela de Habilidades e suas respectivas Classes
SELECT Classes.Cargos AS Classes, Habilidades.Tecnicas AS Habilidades FROM Classes
INNER JOIN ClassesHabilidades
ON Classes.idClasses = ClassesHabilidades.idClasses
INNER JOIN Habilidades
ON ClassesHabilidades.idHabilidades = Habilidades.idHabilidades;

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência)
SELECT Habilidades.Tecnicas, Classes.Cargos AS Classes FROM Habilidades
INNER JOIN ClassesHabilidades
ON Habilidades.idHabilidades = ClassesHabilidades.idHabilidades
RIGHT JOIN Classes
ON Classes.idClasses = ClassesHabilidades.idClasses;
