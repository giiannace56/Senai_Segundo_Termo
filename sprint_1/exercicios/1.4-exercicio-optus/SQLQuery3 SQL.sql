USE Clinica;

SELECT * FROM Atender;
SELECT * FROM Clinica;
SELECT * FROM Pets;
SELECT * FROM Veterinario;

SELECT Clinica.Endereco AS Endereço , Clinica.Veterinario,
Veterinario.Atender AS IdAtender , Veterinario.Nome AS Veterinário,
Atender.Pet, Atender.Valor,
Pets.RAÇA, Pets.Nome, Pets.DDN
FROM Clinica
INNER JOIN Veterinario
ON Clinica.Veterinario = Veterinario.IdVeterinario
INNER JOIN Atender
ON Clinica.Veterinario = Atender.IdAtender
INNER JOIN Pets
ON Clinica.Veterinario = Pets.IdPets;
