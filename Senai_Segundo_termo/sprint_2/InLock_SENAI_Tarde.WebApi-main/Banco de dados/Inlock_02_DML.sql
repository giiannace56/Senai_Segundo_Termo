USE inlock_games_tarde;

INSERT INTO Estudios
VALUES						('Blizzard'),
							('Rockstar Studios'),
							('Square Enix');


INSERT INTO Jogos			(IdEstudio,NomeJogo,Descricao,DataLancamento,Valor)
VALUES						(1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�','2012-5-15',99.00),
							(2,'Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','2018-10-26',120.00);

INSERT INTO TipoUsuarios	
VALUES						('Administrador'),
							('Cliente');

INSERT INTO Usuarios		(IdTipoUsuario,Email,Senha)
VALUES						(1,'admin@admin.com','admin'),
							(2,'cliente@cliente.com','cliente');