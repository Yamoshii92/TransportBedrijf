USE transportbedrijf;

CREATE TABLE IF NOT EXISTS Klant (
    klant_id INT AUTO_INCREMENT PRIMARY KEY,
    naam VARCHAR(100) NOT NULL,
    contact VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS Voertuig (
    voertuig_id INT AUTO_INCREMENT PRIMARY KEY,
    kenteken VARCHAR(20) NOT NULL,
    type ENUM('PERSONEN', 'VRACHT') NOT NULL,
    kilometerstand DECIMAL(10,2) DEFAULT 0,
    afschrijving DECIMAL(5,2) DEFAULT 0,
    max_personen INT,
    max_capaciteit DECIMAL(10,2)
);

CREATE TABLE IF NOT EXISTS Verzoek (
    verzoek_id INT AUTO_INCREMENT PRIMARY KEY,
    klant_id INT NOT NULL,
    type ENUM('PERSONEN', 'VRACHT') NOT NULL,
    aantal_personen INT,
    gewicht DECIMAL(10,2),
    omvang DECIMAL(10,2),
    FOREIGN KEY (klant_id) REFERENCES Klant(klant_id)
);

CREATE TABLE IF NOT EXISTS Rit (
    rit_id INT AUTO_INCREMENT PRIMARY KEY,
    verzoek_id INT NOT NULL,
    voertuig_id INT NOT NULL,
    datum DATETIME NOT NULL,
    afstand DECIMAL(10,2),
    prijs DECIMAL(10,2),
    FOREIGN KEY (verzoek_id) REFERENCES Verzoek(verzoek_id),
    FOREIGN KEY (voertuig_id) REFERENCES Voertuig(voertuig_id)
);
