CREATE TABLE Partecipanti(
idPartecipanti INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(250) NOT NULL,
cognome VARCHAR(250) NOT NULL,
codFis CHAR(16) NOT NULL,
contatto CHAR(11) NOT NULL UNIQUE
);


CREATE TABLE Eventi (
idEventi INT PRIMARY KEY IDENTITY(1,1),
nomeEvento VARCHAR(250) NOT NULL,
descrizione VARCHAR(250) NOT NULL,
dataevento DATETIME NOT NULL,
luogo VARCHAR(250) NOT NULL,
capienzaMax INT NOT NULL
);

CREATE TABLE Risorse (
idRisorse INT PRIMARY KEY IDENTITY(1,1),
tipo VARCHAR(250) NOT NULL,
costo DECIMAL(5,2) NOT NULL,
quantità INT NOT NULL,
fornitore VARCHAR(250) NOT NULL
);

CREATE TABLE Partecipante_Eventi(
partecipantiRIF INT NOT NULL,
eventiRIF INT NOT NULL,
FOREIGN KEY (partecipantiRIF) REFERENCES Partecipanti(idPartecipanti),
FOREIGN KEY (eventiRIF) REFERENCES Eventi(idEventi),
PRIMARY KEY (eventiRIF,partecipantiRIF)
);

