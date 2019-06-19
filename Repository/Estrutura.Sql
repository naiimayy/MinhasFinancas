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

	CREATE TABLE contas_pagar(
		id INT PRIMARY KEY IDENTITY(1,1),
		nome VARCHAR(100),
		valor DECIMAL(8,2),
		tipo VARCHAR(100),
		descricao TEXT,
		status VARCHAR(100)
	);

	INSERT INTO contas_pagar (nome, valor, tipo, descricao, status)
	VALUES ('Água', 250.65, 'suprimento', 'mês de junho', 'a pagar'),
		   ('Luz', 300.00, 'suprimento', 'mês maio', 'pago');

	SELECT * FROM contas_pagar;

	CREATE TABLE cliente_pf(
		id INT PRIMARY KEy IDENTITY(1,1),
		nome VARCHAR(100),
		cpf
