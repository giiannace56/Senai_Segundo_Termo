USE Locadora;

SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Cliente
SELECT * FROM Aluguel
SELECT * FROM Veiculo
SELECT * FROM Empresa;

SELECT Empresa.Nome AS Empresa , Empresa.Veiculo AS IdVeiculo , 
Veiculo.Marca , Veiculo.Modelo , Cliente.Nome , 
Cliente.Cpf , Aluguel.Valor 
FROM Empresa
INNER JOIN Veiculo
ON Empresa.Veiculo = Veiculo.IdVeiculo
INNER JOIN Cliente
ON Empresa.Veiculo = Cliente.IdCliente
INNER JOIN Aluguel
ON Empresa.Veiculo = Aluguel.IdAluguel;

