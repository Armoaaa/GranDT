DELIMITER //

CREATE PROCEDURE altaTipo(IN UnNombre VARCHAR(50), OUT AIidTipo INT)
BEGIN
    INSERT INTO Tipo (Nombre) VALUES (UnNombre);
    SET AIidTipo = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaEquipo(IN Nombre VARCHAR(45), OUT AIidEquipo INT)
BEGIN
    INSERT INTO Equipos (Nombre) VALUES (Nombre);
    SET AIidEquipo = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaFutbolista(
    IN UnNombre VARCHAR(45),
    IN UnApellido VARCHAR(45),
    IN UnApodo VARCHAR(45),
    IN UnFechadeNacimiento DATE,
    IN UnCotizacion DECIMAL(11,2),
    IN UnidTipo INT,
    IN UnidEquipos INT,
    OUT AIidFutbolista INT
)
BEGIN
    INSERT INTO Futbolista (Nombre, Apellido, Apodo, FechadeNacimiento, Cotizacion, idTipo, idEquipos)
    VALUES (UnNombre, UnApellido, UnApodo, UnFechadeNacimiento, UnCotizacion, UnidTipo, UnidEquipos);
    SET AIidFutbolista = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaUsuario(
    IN UnNombre VARCHAR(45),
    IN UnApellido VARCHAR(45),
    IN UnEmail VARCHAR(90),
    IN UnFechadeNacimiento DATE,
    IN UnContrasena CHAR(64),
    IN UnesAdmin TINYINT,
    OUT AIidUsuario INT
)
BEGIN
    INSERT INTO Usuario (Nombre, Apellido, Email, FechadeNacimiento, Contrasena, esAdmin)
    VALUES (UnNombre, UnApellido, UnEmail, UnFechadeNacimiento, UnContrasena, UnesAdmin);
    SET AIidUsuario = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaPlantilla(
    IN UnPresupuesto DECIMAL(11,2),
    IN UnNombrePlantilla VARCHAR(50),
    IN UnidUsuario INT,
    IN UnCantidadJugadores TINYINT,
    OUT AIidPlantilla INT
)
BEGIN
    INSERT INTO Plantillas (Presupuesto, NombrePlantilla, idUsuario, CantidadJugadores)
    VALUES (UnPresupuesto, UnNombrePlantilla, UnidUsuario, UnCantidadJugadores);
    SET AIidPlantilla = LAST_INSERT_ID();
END;
//

CREATE PROCEDURE altaPlantillaTitular(
    IN UnidFutbolista INT,
    IN UnidPlantillas INT,
    IN UnesTitular TINYINT
)
BEGIN
    INSERT INTO PlantillaTitular (idFutbolista, idPlantillas, esTitular)
    VALUES (UnidFutbolista, UnidPlantillas, UnesTitular);
END;
//





CREATE PROCEDURE altaPuntuacion(
    IN UnfechaNro TINYINT,
    IN UnPuntuacion DECIMAL(3,1),
    IN UnidFutbolista INT,
    OUT AIidpuntuacion INT
)
BEGIN
    INSERT INTO Puntuacion (fechaNro, Puntuacion, idFutbolista)
    VALUES (UnfechaNro, UnPuntuacion, UnidFutbolista);
    SET AIidpuntuacion = LAST_INSERT_ID();
END;
//




CREATE PROCEDURE actualizarPlantilla(
    IN UnidPlantillas INT,
    IN UnidUsuario INT,
    IN UnPresupuesto DECIMAL(11,2),
    IN UnNombrePlantilla VARCHAR(50),
    IN UnCantidadJugadores TINYINT
)
BEGIN
    UPDATE Plantillas
    SET Presupuesto = UnPresupuesto,
        NombrePlantilla = UnNombrePlantilla,
        CantidadJugadores = UnCantidadJugadores
    WHERE idPlantillas = UnidPlantillas AND idUsuario = UnidUsuario;
END;
//


CREATE PROCEDURE eliminarPlantilla(
    IN UnidPlantillas INT,
    IN UnidUsuario INT
)
BEGIN
    DELETE FROM Plantillas WHERE idPlantillas = UnidPlantillas AND idUsuario = UnidUsuario;
END;
//

CREATE PROCEDURE actualizarPlantillaTitular(
    IN UnidFutbolista INT,
    IN UnidPlantillas INT,
    IN UnesTitular TINYINT
)
BEGIN
    UPDATE PlantillaTitular
    SET esTitular = UnesTitular
    WHERE idFutbolista = UnidFutbolista AND idPlantillas = UnidPlantillas;
END;
//

CREATE PROCEDURE eliminarPlantillaTitular(
    IN UnidFutbolista INT,
    IN UnidPlantillas INT
)
BEGIN
    DELETE FROM PlantillaTitular WHERE idFutbolista = UnidFutbolista AND idPlantillas = UnidPlantillas;
END;
//


CREATE PROCEDURE loginUsuario(
    IN UnEmail VARCHAR(90),
    IN UnContrasena VARCHAR(64)
)
BEGIN
    -- Verificamos si el email existe y la contraseña coincide
    SELECT 
        idUsuario,
        Nombre,
        Apellido,
        Email,
        esAdmin
    FROM Usuario
    WHERE Email = UnEmail
      AND Contrasena = SHA2(UnContrasena, 256);
END;
//
-- clickclack

CREATE PROCEDURE agregarFutbolistaAPlantilla(
    IN UnidUsuario INT,
    IN UnNombrePlantilla VARCHAR(50),
    IN UnPresupuesto DECIMAL(11,2),
    IN UnidFutbolista INT,
    IN UnesTitular TINYINT
)
BEGIN
    DECLARE idPlantillaExistente INT;


    SELECT idPlantillas INTO idPlantillaExistente
    FROM Plantillas
    WHERE NombrePlantilla = UnNombrePlantilla AND idUsuario = UnidUsuario
    LIMIT 1;

    IF idPlantillaExistente IS NULL THEN
        INSERT INTO Plantillas (Presupuesto, NombrePlantilla, idUsuario, CantidadJugadores)
        VALUES (UnPresupuesto, UnNombrePlantilla, UnidUsuario, 0);
        SET idPlantillaExistente = LAST_INSERT_ID();
    END IF;

    IF EXISTS (
        SELECT 1 FROM PlantillaTitular
        WHERE idFutbolista = UnidFutbolista AND idPlantillas = idPlantillaExistente
    ) THEN
        UPDATE PlantillaTitular
        SET esTitular = UnesTitular
        WHERE idFutbolista = UnidFutbolista AND idPlantillas = idPlantillaExistente;
    ELSE
        INSERT INTO PlantillaTitular (idFutbolista, idPlantillas, esTitular)
        VALUES (UnidFutbolista, idPlantillaExistente, UnesTitular);
    END IF;

    UPDATE Plantillas p
    SET p.CantidadJugadores = (
        SELECT COUNT(*) FROM PlantillaTitular WHERE idPlantillas = idPlantillaExistente
    )
    WHERE p.idPlantillas = idPlantillaExistente;
END;
//


CREATE PROCEDURE promedioFutbolista(
    IN UnidFutbolista INT
)
BEGIN
    SELECT 
        f.Nombre,
        f.Apellido,
        ROUND(AVG(p.Puntuacion), 2) AS PromedioPuntuacion,
        COUNT(p.fechaNro) AS CantidadFechas
    FROM Puntuacion p
    JOIN Futbolista f ON f.idFutbolista = p.idFutbolista
    WHERE p.idFutbolista = UnidFutbolista
    GROUP BY f.idFutbolista, f.Nombre, f.Apellido;
END;
//

DELIMITER ;

