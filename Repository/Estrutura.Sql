	CREATE TABLE contas_receber(
		id INT PRIMARY KEY IDENTITY(1,1),
		nome VARCHAR(100),
		valor DECIMAL (8,2),
		tipo VARCHAR(100),
		descricao TEXT,
		status  BIT,
	);

	INSERT INTO contas_receber 
