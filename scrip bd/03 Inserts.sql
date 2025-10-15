CALL altaTipo('Arquero', @idTipo1);
CALL altaTipo('Defensor', @idTipo2);
CALL altaTipo('Mediocampista', @idTipo3);
CALL altaTipo('Delantero', @idTipo4);

CALL altaEquipo('Boca Juniors', @idEquipo1);
CALL altaEquipo('River Plate', @idEquipo2);
CALL altaEquipo('Racing Club', @idEquipo3);
CALL altaEquipo('Independiente', @idEquipo4);
CALL altaEquipo('San Lorenzo', @idEquipo5);

CALL altaFutbolista('Sergio', 'Romero', 'Chiquito', '1987-02-22', 8500000.00, @idEquipo1, @idTipo1, @idFut1);
CALL altaFutbolista('Luis', 'Advíncula', NULL, '1990-03-02', 7800000.00, @idEquipo1, @idTipo2, @idFut2);
CALL altaFutbolista('Marcos', 'Rojo', NULL, '1990-03-20', 9200000.00, @idEquipo1, @idTipo2, @idFut3);
CALL altaFutbolista('Nicolás', 'Figal', NULL, '1994-02-15', 8700000.00, @idEquipo1, @idTipo2, @idFut4);
CALL altaFutbolista('Frank', 'Fabra', NULL, '1991-02-22', 8000000.00, @idEquipo1, @idTipo2, @idFut5);
CALL altaFutbolista('Pol', 'Fernández', NULL, '1991-10-11', 9500000.00, @idEquipo1, @idTipo3, @idFut6);
CALL altaFutbolista('Cristian', 'Medina', NULL, '2002-06-23', 7300000.00, @idEquipo1, @idTipo3, @idFut7);
CALL altaFutbolista('Equi', 'Fernández', NULL, '2002-05-04', 7800000.00, @idEquipo1, @idTipo3, @idFut8);
CALL altaFutbolista('Edinson', 'Cavani', NULL, '1987-02-14', 9800000.00, @idEquipo1, @idTipo4, @idFut9);
CALL altaFutbolista('Miguel', 'Merentiel', NULL, '1996-02-24', 8700000.00, @idEquipo1, @idTipo4, @idFut10);
