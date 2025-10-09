DELIMITER //

CREATE PROCEDURE altaTipo(IN Nombre VARCHAR(50), OUT idTipo_generado INT)
BEGIN
    INSERT INTO Tipo (Nombre) VALUES (Nombre);
    SET idTipo_generado = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaEquipo(IN Nombre VARCHAR(45), OUT idEquipo_generado INT)
BEGIN
    INSERT INTO Equipos (Nombre) VALUES (Nombre);
    SET idEquipo_generado = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaFutbolista(
    IN Nombre VARCHAR(45),
    IN Apellido VARCHAR(45),
    IN Apodo VARCHAR(45),
    IN FechadeNacimiento DATE,
    IN Cotizacion DECIMAL(11,2),
    IN idTipo INT,
    IN idEquipos INT,
    OUT idFutbolista_generado INT
)
BEGIN
    INSERT INTO Futbolista (Nombre, Apellido, Apodo, FechadeNacimiento, Cotizacion, idTipo, idEquipos)
    VALUES (Nombre, Apellido, Apodo, FechadeNacimiento, Cotizacion, idTipo, idEquipos);
    SET idFutbolista_generado = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaUsuario(
    IN Nombre VARCHAR(45),
    IN Apellido VARCHAR(45),
    IN Email VARCHAR(90),
    IN FechadeNacimiento DATE,
    IN Contrasena CHAR(64),
    IN esAdmin TINYINT,
    OUT idUsuario_generado INT
)
BEGIN
    INSERT INTO Usuario (Nombre, Apellido, Email, FechadeNacimiento, Contrasena, esAdmin)
    VALUES (Nombre, Apellido, Email, FechadeNacimiento, Contrana, esAdmin);
    SET idUsuario_generado = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaPlantilla(
    IN Presupuesto DECIMAL(11,2),
    IN NombrePlantilla VARCHAR(50),
    IN idUsuario INT,
    IN CantidadJugadores TINYINT,
    OUT idPlantilla_generado INT
)
BEGIN
    INSERT INTO Plantillas (Presupuesto, NombrePlantilla, idUsuario, CantidadJugadores)
    VALUES (Presupuesto, NombrePlantilla, idUsuario, CantidadJugadores);
    SET idPlantilla_generado = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaPlantillaTitular(
    IN idFutbolista INT,
    IN idPlantillas INT,
    IN esTitular TINYINT
)
BEGIN
    INSERT INTO PlantillaTitular (idFutbolista, idPlantillas, esTitular)
    VALUES (idFutbolista, idPlantillas, esTitular);
END;
//


   ------------------------- */
CREATE PROCEDURE altaPlantillaSuplente(
    IN idFutbolista INT,
    IN idPlantillas INT,
    IN esSuplente TINYINT
)
BEGIN
    INSERT INTO PlantillaSuplente (idFutbolista, idPlantillas, esSuplente)
    VALUES (idFutbolista, idPlantillas, esSuplente);
END;
//


CREATE PROCEDURE altaPuntuacion(
    IN fechaNro TINYINT,
    IN Puntuacion DECIMAL(3,1),
    IN idFutbolista INT,
    OUT idPuntuacion_generado INT
)
BEGIN
    INSERT INTO Puntuacion (fechaNro, Puntuacion, idFutbolista)
    VALUES (fechaNro, Puntuacion, idFutbolista);
    SET idPuntuacion_generado = LAST_INSERT_ID();
END;
//




CREATE PROCEDURE actualizarPlantilla(
    IN idPlantillas INT,
    IN idUsuario INT,
    IN Presupuesto DECIMAL(11,2),
    IN NombrePlantilla VARCHAR(50),
    IN CantidadJugadores TINYINT
)
BEGIN
    UPDATE Plantillas
    SET Presupuesto = Presupuesto,
        NombrePlantilla = NombrePlantilla,
        CantidadJugadores = CantidadJugadores
    WHERE idPlantillas = idPlantillas AND idUsuario = idUsuario;
END;
//


CREATE PROCEDURE eliminarPlantilla(
    IN idPlantillas INT,
    IN idUsuario INT
)
BEGIN
    DELETE FROM Plantillas WHERE idPlantillas = idPlantillas AND idUsuario = idUsuario;
END;
//

CREATE PROCEDURE actualizarPlantillaTitular(
    IN idFutbolista INT,
    IN idPlantillas INT,
    IN esTitular TINYINT
)
BEGIN
    UPDATE PlantillaTitular
    SET esTitular = esTitular
    WHERE idFutbolista = idFutbolista AND idPlantillas = idPlantillas;
END;
//

CREATE PROCEDURE eliminarPlantillaTitular(
    IN idFutbolista INT,
    IN idPlantillas INT
)
BEGIN
    DELETE FROM PlantillaTitular WHERE idFutbolista = idFutbolista AND idPlantillas = idPlantillas;
END;
//


CREATE PROCEDURE actualizarPlantillaSuplente(
    IN idFutbolista INT,
    IN idPlantillas INT,
    IN esSuplente TINYINT
)
BEGIN
    UPDATE PlantillaSuplente
    SET esSuplente = esSuplente
    WHERE idFutbolista = idFutbolista AND idPlantillas = idPlantillas;
END;
//


CREATE PROCEDURE eliminarPlantillaSuplente(
    IN idFutbolista INT,
    IN idPlantillas INT
)
BEGIN
    DELETE FROM PlantillaSuplente WHERE idFutbolista = idFutbolista AND idPlantillas = idPlantillas;
END;
//

DELIMITER ;
