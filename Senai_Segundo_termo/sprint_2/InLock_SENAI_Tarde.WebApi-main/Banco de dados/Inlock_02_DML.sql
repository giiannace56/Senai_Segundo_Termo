USE inlock_games_tarde;

INSERT INTO Estudios
VALUES						('Blizzard'),
							('Rockstar Studios'),
							('Square Enix');


INSERT INTO Jogos			(IdEstudio,NomeJogo,Descricao,DataLancamento,Valor)
VALUES						(1,'Diablo 3','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã','2012-5-15',99.00),
							(2,'Red Dead Redemption II','jogo eletrônico de ação-aventura western','2018-10-26',120.00);

INSERT INTO TipoUsuarios	
VALUES						('Administrador'),
							('Cliente');

INSERT INTO Usuarios		(IdTipoUsuario,Email,Senha)
VALUES						(1,'admin@admin.com','admin'),
							(2,'cliente@cliente.com','cliente');