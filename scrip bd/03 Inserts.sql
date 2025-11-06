CALL altaTipo('Arquero', @idTipo1);
CALL altaTipo('Defensor', @idTipo2);
CALL altaTipo('Mediocampista', @idTipo3);
CALL altaTipo('Delantero', @idTipo4);

CALL altaEquipo('Boca Juniors', @idEquipos1);
CALL altaEquipo('River Plate', @idEquipos2);
CALL altaEquipo('Racing Club', @idEquipos3);
CALL altaEquipo('Independiente', @idEquipos4);
CALL altaEquipo('San Lorenzo', @idEquipos5);

CALL altaFutbolista('Sergio', 'Romero', 'Chiquito', '1987-02-22', 8500000.00, @idTipo1, @idEquipos1, @idFut1);
CALL altaFutbolista('Luis', 'Advíncula', NULL, '1990-03-02', 7800000.00, @idTipo2, @idEquipos1, @idFut2);
CALL altaFutbolista('Marcos', 'Rojo', NULL, '1990-03-20', 9200000.00, @idTipo2, @idEquipos1, @idFut3);
CALL altaFutbolista('Nicolás', 'Figal', NULL, '1994-02-15', 8700000.00, @idTipo2, @idEquipos1, @idFut4);
CALL altaFutbolista('Frank', 'Fabra', NULL, '1991-02-22', 8000000.00, @idTipo2, @idEquipos1, @idFut5);
CALL altaFutbolista('Pol', 'Fernández', NULL, '1991-10-11', 9500000.00, @idTipo3, @idEquipos1, @idFut6);
CALL altaFutbolista('Cristian', 'Medina', NULL, '2002-06-23', 7300000.00, @idTipo3, @idEquipos1, @idFut7);
CALL altaFutbolista('Equi', 'Fernández', NULL, '2002-05-04', 7800000.00, @idTipo3, @idEquipos1, @idFut8);
CALL altaFutbolista('Edinson', 'Cavani', NULL, '1987-02-14', 9800000.00, @idTipo4, @idEquipos1, @idFut9);
CALL altaFutbolista('Miguel', 'Merentiel', NULL, '1996-02-24', 8700000.00, @idTipo4, @idEquipos1, @idFut10);
CALL altaFutbolista('NAZI', 'PRUEBA', NULL, '1996-02-24', 8700000.00, @idTipo4, @idEquipos1, @idFut11);

CALL altaPuntuacion(1, 7.5, @idFut1, @idPunt1);  -- Sergio Romero
CALL altaPuntuacion(1, 6.8, @idFut2, @idPunt2);  -- Luis Advíncula
CALL altaPuntuacion(1, 7.2, @idFut3, @idPunt3);  -- Marcos Rojo
CALL altaPuntuacion(1, 6.9, @idFut4, @idPunt4);  -- Nicolás Figal
CALL altaPuntuacion(1, 7.0, @idFut5, @idPunt5);  -- Frank Fabra
CALL altaPuntuacion(1, 7.6, @idFut6, @idPunt6);  -- Pol Fernández
CALL altaPuntuacion(1, 7.4, @idFut7, @idPunt7);  -- Cristian Medina
CALL altaPuntuacion(1, 7.1, @idFut8, @idPunt8);  -- Equi Fernández
CALL altaPuntuacion(1, 8.5, @idFut9, @idPunt9);  -- Edinson Cavani
CALL altaPuntuacion(1, 8.2, @idFut10, @idPunt10); -- Miguel Merentiel

CALL altaPuntuacion(2, 7.8, @idFut1, @idPunt11);
CALL altaPuntuacion(2, 6.5, @idFut2, @idPunt12);
CALL altaPuntuacion(2, 7.4, @idFut3, @idPunt13);
CALL altaPuntuacion(2, 6.7, @idFut4, @idPunt14);
CALL altaPuntuacion(2, 7.0, @idFut5, @idPunt15);
CALL altaPuntuacion(2, 7.9, @idFut6, @idPunt16);
CALL altaPuntuacion(2, 7.2, @idFut7, @idPunt17);
CALL altaPuntuacion(2, 7.3, @idFut8, @idPunt18);
CALL altaPuntuacion(2, 8.6, @idFut9, @idPunt19);
CALL altaPuntuacion(2, 8.0, @idFut10, @idPunt20);


CALL altaUsuario('Luis','Armoa','armoa34@outlook.com','2007-01-12','Meamo123jaja',1,@idUsuario);
CALL altaUsuario('Juan', 'Perez', 'juanperez@example.com', '1990-05-10', 'HHHolacomo1234', 0, @idUsuario1);

CALL altaUsuario('BELEN', 'DOMINGUEZ', '23dominguezbelen@attttt.com', '1999-05-10', '23dominguezbelen', 0, @idUsuario1);
CALL altaUsuario('BELEN', 'DOMINGUEZ', 'asd@attttt.com', '1999-05-10', '23dominguezbelen', 0, @idUsuario1);

CALL altaPlantilla(95000000.00, 'Super Boca', @idUsuario1, @idEquipos1, 0, @idPlantilla1);
-- Titulares
CALL altaPlantillaTitular(1, @idPlantilla1, 1);  -- Romero (Arquero)
CALL altaPlantillaTitular(2, @idPlantilla1, 1);  -- Advíncula (Defensor)
CALL altaPlantillaTitular(3, @idPlantilla1, 1);  -- Rojo (Defensor)
CALL altaPlantillaTitular(4, @idPlantilla1, 1);  -- Figal (Defensor)
CALL altaPlantillaTitular(5, @idPlantilla1, 1);  -- Fabra (Defensor)
CALL altaPlantillaTitular(6, @idPlantilla1, 1);  -- Pol Fernández (Mediocampista)
CALL altaPlantillaTitular(7, @idPlantilla1, 1);  -- Medina (Mediocampista)
CALL altaPlantillaTitular(8, @idPlantilla1, 1);  -- Equi Fernández (Mediocampista)

-- SUPLENTES -----------------------------------------------------
CALL altaPlantillaTitular(9,  @idPlantilla1, 0); -- Suplente 1
CALL altaPlantillaTitular(10, @idPlantilla1, 0); -- Suplente 2