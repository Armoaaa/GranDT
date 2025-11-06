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
    IN UnidEquipos INT,
    IN UnCantidadJugadores TINYINT,
    OUT AIidPlantilla INT
)
BEGIN
    INSERT INTO Plantillas (Presupuesto, NombrePlantilla, idUsuario, idEquipos, CantidadJugadores)
    VALUES (UnPresupuesto, UnNombrePlantilla, UnidUsuario, UnidEquipos, UnCantidadJugadores);
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
    DECLARE RealContrasena CHAR(64);

    -- Convertimos la contraseña ingresada a su hash SHA2 una sola vez
    SET RealContrasena = SHA2(UnContrasena, 256);

    -- Verificamos si el email existe y la contraseña coincide
    SELECT 
        idUsuario,
        Nombre,
        Apellido,
        Email,
        esAdmin
    FROM Usuario
    WHERE Email = UnEmail
      AND Contrasena = RealContrasena;
END;
//



-- clickclack




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


CREATE PROCEDURE PlantillasPorIdUsuario(
    IN UnidUsuario INT
)
BEGIN
    SELECT 
        *
    FROM Plantillas p
    WHERE idUsuario = UnidUsuario;
END;
//

CREATE PROCEDURE PlantillasPorIdPlantilla(
    IN UnidPlantillas INT
)
BEGIN
    SELECT 
        *
    FROM Plantillas p
    WHERE idPlantillas = UnidPlantillas;
END;

//


CREATE PROCEDURE traerEquipos() 
BEGIN
    SELECT  *
    FROM Equipos
    ORDER BY Nombre;
END;
//


CREATE PROCEDURE traerFutbolistasXTipoXEquipo(
    IN UnIdTipo INT,
    IN UnIdEquipos INT
)
BEGIN
    SELECT 
        f.idFutbolista,
        f.Nombre,
        f.Apellido,
        f.Apodo,
        f.Cotizacion,
        f.idEquipos AS IdEquipos,
        f.idTipo AS IdTipo,
        e.idEquipos AS IdEquiposEquipo,
        e.Nombre AS NombreEquipo,
        t.idTipo AS IdTipoTipo,
        t.Nombre AS NombreTipo
    FROM Futbolista f
    INNER JOIN Equipos e ON e.idEquipos = f.idEquipos
    INNER JOIN Tipo t ON t.idTipo = f.idTipo
    WHERE f.idTipo = UnIdTipo
      AND f.idEquipos = UnIdEquipos
    ORDER BY f.Apellido;
END;

//
CREATE PROCEDURE eliminarPuntuacion(
    IN UnidFutbolista INT
)
BEGIN
    DELETE FROM Puntuacion
    WHERE idFutbolista = UnidFutbolista;
END;
//
CREATE PROCEDURE eliminarPlantillaTitularPorPlantilla(
    IN UnidPlantillas INT
)
BEGIN
    DELETE FROM PlantillaTitular
    WHERE idPlantillas = UnidPlantillas;
END;
//
CREATE PROCEDURE eliminarPlantilla(
    IN UnidPlantillas INT
)
BEGIN
    -- Eliminar futbolistas de la plantilla
    CALL eliminarPlantillaTitularPorPlantilla(UnidPlantillas);

    -- Eliminar la plantilla en sí
    DELETE FROM Plantillas
    WHERE idPlantillas = UnidPlantillas;
END;
//
CREATE PROCEDURE eliminarFutbolista(
    IN UnidFutbolista INT
)
BEGIN
    -- Eliminar puntuaciones asociadas
    CALL eliminarPuntuacion(UnidFutbolista);

    -- Eliminar de las plantillas
    DELETE FROM PlantillaTitular
    WHERE idFutbolista = UnidFutbolista;

    -- Eliminar futbolista
    DELETE FROM Futbolista
    WHERE idFutbolista = UnidFutbolista;
END;
//

CREATE PROCEDURE eliminarEquipo(
    IN UnidEquipos INT
)
BEGIN

    DELETE FROM Futbolista WHERE idEquipos = UnidEquipos;
    
    DELETE FROM Equipos WHERE idEquipos = UnidEquipos;
END;
//
CREATE PROCEDURE eliminarTipo(
    IN UnidTipo INT
)
BEGIN

    
    DELETE FROM Futbolista WHERE idTipo = UnidTipo;
    

    DELETE FROM Tipo WHERE idTipo = UnidTipo;
END;
//
CREATE PROCEDURE eliminarUsuario(
    IN UnidUsuario INT
)
BEGIN

    DELETE FROM Plantillas WHERE idUsuario = UnidUsuario;

    DELETE FROM Usuario WHERE idUsuario = UnidUsuario;
END;
//

CREATE PROCEDURE obtenerPlantillaCompleta(
    IN UnidPlantillas INT
)
BEGIN
    -- 1. Traer la información de la Plantilla (Plantilla)
    SELECT 
        p.idPlantillas,
        p.Presupuesto,
        p.NombrePlantilla,
        p.idUsuario,
        p.CantidadJugadores
    FROM Plantillas p
    WHERE p.idPlantillas = UnidPlantillas;

    -- 2. Traer los Futbolistas Titulares (FutbolistasTitulares)
    SELECT 
        f.idFutbolista,
        f.Nombre,
        f.Apellido,
        f.Apodo,
        f.FechadeNacimiento,
        f.Cotizacion,
        f.idTipo,
        f.idEquipos,
        e.Nombre AS NombreEquipo,
        t.Nombre AS NombreTipo
    FROM PlantillaTitular pt
    INNER JOIN Futbolista f ON f.idFutbolista = pt.idFutbolista
    INNER JOIN Equipos e ON e.idEquipos = f.idEquipos
    INNER JOIN Tipo t ON t.idTipo = f.idTipo
    WHERE pt.idPlantillas = UnidPlantillas
      AND pt.esTitular = 1
    ORDER BY f.Apellido;

    -- 3. Traer los Futbolistas Suplentes (FutbolistasSuplentes)
    SELECT 
        f.idFutbolista,
        f.Nombre,
        f.Apellido,
        f.Apodo,
        f.FechadeNacimiento,
        f.Cotizacion,
        f.idTipo,
        f.idEquipos,
        e.Nombre AS NombreEquipo,
        t.Nombre AS NombreTipo
    FROM PlantillaTitular pt
    INNER JOIN Futbolista f ON f.idFutbolista = pt.idFutbolista
    INNER JOIN Equipos e ON e.idEquipos = f.idEquipos
    INNER JOIN Tipo t ON t.idTipo = f.idTipo
    WHERE pt.idPlantillas = UnidPlantillas
      AND pt.esTitular = 0
    ORDER BY f.Apellido;
    
END;
//

CREATE PROCEDURE traerPuntuacionesPorFutbolista(
    IN UnidFutbolista INT
)
BEGIN
    -- Primer conjunto de resultados: Datos del Futbolista (incluyendo Equipo y Tipo)
    -- Dapper mapea estas columnas a las propiedades escalares de Futbolista.
    SELECT 
        f.idFutbolista,
        f.Nombre,
        f.Apellido,
        f.Apodo,
        f.FechadeNacimiento,
        f.Cotizacion,
        f.idEquipos AS IdEquipo,
        e.Nombre AS NombreEquipo, -- Columnas para mapear el objeto Equipos (si usas multi-mapeo)
        f.idTipo AS IdTipo,
        t.Nombre AS NombreTipo     -- Columnas para mapear el objeto Tipo (si usas multi-mapeo)
    FROM Futbolista f
    INNER JOIN Equipos e ON e.idEquipos = f.idEquipos
    INNER JOIN Tipo t ON t.idTipo = f.idTipo
    WHERE f.idFutbolista = UnidFutbolista;

    -- Segundo conjunto de resultados: La Colección de Puntuaciones
    -- Dapper mapea estas columnas a la lista Puntuaciones.
    SELECT 
        p.fechaNro AS FechaNro, -- Asegúrate que el alias coincida con la propiedad en C# (si la tiene)
        p.Puntuacion AS Puntos,  -- Asegúrate que el alias coincida con la propiedad en C# (si la tiene)
        p.idFutbolista
    FROM Puntuacion p
    WHERE p.idFutbolista = UnidFutbolista
    ORDER BY p.fechaNro DESC;
END;
//

DELIMITER ;

