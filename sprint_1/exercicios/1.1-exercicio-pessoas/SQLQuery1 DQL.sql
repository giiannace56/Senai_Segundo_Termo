USE Filmes;

SELECT * FROM Filmes;
SELECT * FROM Genero;

SELECT Filmes.IdFilmes, Filmes.Titulo , Genero.Nome FROM Filmes
INNER JOIN Genero
ON Filmes.Genero = Genero.IdGenero;
