USE SENAI_HROADS_TARDE;

--Selecionar todas as habilidades;
SELECT * FROM Habilidades;

--Selecionar todos as classes;
SELECT * FROM Classe;

--Selecionar somente o nome das classes;
SELECT Classe.NomeClasse FROM Classe;

--Selecionar todos os personagens;
SELECT * FROM Personagens;

--Contar de quantas habilidades estão cadastradas;
SELECT * FROM Habilidades
SELECT COUNT(*) FROM Habilidades;

-- Selecionar somente os id’s das habilidades classificando-os por ordem crescente;

SELECT  Habilidades.IdHabilidade FROM Habilidades
ORDER BY Habilidades.IdHabilidade;

--Selecionar todos os tipos de habilidades;
SELECT * FROM TipoHabilidade;

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
SELECT  Habilidades.NomeHabilidade AS Habilidade, TipoHabilidade.NomeTipo AS Tipo  FROM Habilidades 
INNER JOIN TipoHabilidade
ON Habilidades.IdTipo= TipoHabilidade.IdTipo;

--Selecionar todos os personagens e suas respectivas classes;
SELECT  Personagens.NomePersonagem AS Personagem, Classe.NomeClasse AS Classe  FROM Classe 
INNER JOIN Personagens
ON Personagens.IdClasse= Classe.IdClasse;


--Selecionar todos os personagens e as classes ;
SELECT  Personagens.NomePersonagem AS Personagem, Classe.NomeClasse AS Classe  FROM Classe 
LEFT JOIN Personagens
ON Personagens.IdClasse= Classe.IdClasse;

--Selecionar todas as classes e suas respectivas habilidades;
SELECT Classe.NomeClasse AS Classe, Habilidades.NomeHabilidade AS Habilidade FROM Classe 
RIGHT JOIN ClasseHabilidade
ON Classe.IdClasse= ClasseHabilidade.IdClasse
LEFT JOIN Habilidades
ON ClasseHabilidade.IdHabilidade= Habilidades.IdHabilidade;

--Selecionar todas as habilidades e suas classes ;
SELECT Classe.NomeClasse AS Classe, Habilidades.NomeHabilidade AS Habilidade FROM Classe 
RIGHT JOIN ClasseHabilidade
ON Classe.IdClasse= ClasseHabilidade.IdClasse
INNER JOIN Habilidades
ON ClasseHabilidade.IdHabilidade= Habilidades.IdHabilidade;


SELECT Habilidades.NomeHabilidade AS Habilidade, Classe.NomeClasse AS Classe FROM Habilidades 
LEFT JOIN ClasseHabilidade
ON Habilidades.IdHabilidade= ClasseHabilidade.IdHabilidade
RIGHT JOIN Classe
ON ClasseHabilidade.IdClasse= Classe.IdClasse;