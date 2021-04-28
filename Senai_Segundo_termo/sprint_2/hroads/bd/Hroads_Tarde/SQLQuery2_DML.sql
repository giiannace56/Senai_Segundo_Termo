USE HRoads;

INSERT INTO Personagens(Nomes, VidaMaxima, ManaMaxima, DataAtualizacao, DataCriacao, idClasses)
VALUES	 ('DeuBug', 100, 80, GETDATE(), '18/01/2019', 1)
		,('BitBug', 80, 100, GETDATE(), '20/02/2020', 4)
		,('Fer8', 120, 50, GETDATE(), '25/12/1996', 2);

DELETE FROM Personagens;
TRUNCATE TABLE Personagens;

INSERT INTO Habilidades(Tecnicas)
VALUES		('Lança Mortal')
			,('Escudo Supremo')
			,('Recuperar Vida');

INSERT INTO TiposHabilidades(Tipos)
VALUES		 ('Ataque')
			,('Defesa')
			,('Cura')
			,('Magia');

INSERT INTO ClassesHabilidades(idClasses, idHabilidades)
VALUES       (1,1)
			,(1,2)
			,(2,2)
			,(3,1)
			,(4,3)
			,(4,2)
			,(6,3);

INSERT INTO Classes(Cargos)
VALUES		('Bárbaro')
			,('Cruzado')
			,('Caçadora')
			,('Monge')
			,('Necromante')
			,('Feiticeiro')
			,('Arcanista');

UPDATE Personagens
SET Nomes = 'Fer7'
WHERE idPersonagem = 3;

UPDATE Classes
SET Cargos = 'Necromancer'
WHERE idClasses = 5;
