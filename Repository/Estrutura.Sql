	DROP TABLE contas_receber;

	CREATE TABLE contas_receber(
		id INT PRIMARY KEY IDENTITY(1,1),
		nome VARCHAR(100),
		valor DECIMAL (8,2),
		tipo VARCHAR(100),
		descricao TEXT,
		status  VARCHAR(100)
	);

	INSERT INTO contas_receber (nome, valor, tipo, descricao, status)
	VALUES ('Editora Abril', 249.99,'Publicidade', 'Promoção do mês de Julho', 'Pago'),
	('Elon Musk', 300.00,'Carro Elétrico', 'Reserva', 'Pago');

	SELECT * FROM contas_receber;
