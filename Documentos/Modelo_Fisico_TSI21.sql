CREATE TABLE Investimento (
    Id INT IDENTITY PRIMARY KEY,
    TipoConta VARCHAR(20) NOT NULL,
    TempoResgate INT,
    Rendimento FLOAT
)
GO
    CREATE TABLE UsuarioCliente (
        Id INT IDENTITY PRIMARY KEY,
        Nome VARCHAR(50) NOT NULL,
        Cpf VARCHAR(11) NOT NULL,
        Usuario VARCHAR(50) NOT NULL,
        Senha VARCHAR(255) NOT NULL,
        Email VARCHAR(50) NOT NULL
    )
GO
    CREATE TABLE Conta (
        Id INT IDENTITY PRIMARY KEY,
        Numero VARCHAR(10) NOT NULL UNIQUE,
        Saldo FLOAT,
        ClienteId INT REFERENCES UsuarioCliente,
        InvestimentoId INT REFERENCES Investimento,
        Ativa BIT
    )
GO
    CREATE TABLE Movimentacao (
        Id INT IDENTITY PRIMARY KEY,
        Data DATETIME NOT NULL,
        Valor FLOAT NOT NULL,
        ContaId INT REFERENCES Conta,
        TipoMovimentacao VARCHAR(10)
    )
GO