USE Pessoas;

SELECT * FROM Email;
SELECT * FROM Telefone;
SELECT * FROM Pessoas;

SELECT Pessoas.IdPessoa , Telefone.Numero , Email.Email , Pessoas.CNH FROM Pessoas
INNER JOIN Telefone
ON Pessoas.Telefone = Telefone.Telefone
INNER JOIN Email
ON Pessoas.Email = Email.IdEmail;