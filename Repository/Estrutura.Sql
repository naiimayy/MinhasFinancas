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

	CREATE TABLE clientes_pessoa_fisica(
		id INT PRIMARY KEy IDENTITY(1,1),
		nome VARCHAR(100),
		cpf VARCHAR(16),
		data_nascimento DATETIME2,
		rg VARCHAR(9),
		sexo VARCHAR(100),
		);

	INSERT INTO clientes_pf (nome, cpf, data_nascimento, rg, sexo)
	VALUES ('Naiara May', '084.915.929.62', '1992-10-18','5226.0747','Feminino');

	SELECT * FROM clientes_pf;
	
