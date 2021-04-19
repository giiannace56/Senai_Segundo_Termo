USE inlock_games_tarde;

SELECT * FROM Usuarios;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT Jogos.NomeJogo , Estudios.NomeEstudio FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio;

SELECT Estudios.NomeEstudio , Jogos.NomeJogo FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdJogo;

SELECT * FROM Usuarios
WHERE Email = 'admin@admin.com' AND Senha = 'admin';

SELECT * FROM Jogos
WHERE IdJogo = 2;

SELECT * FROM Estudios
WHERE IdEstudio = 3;