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


CALL altaUsuario('Administrador', 'Principal', 'admin.principal@mail.com', '1985-08-20', 'AdminSecure01!', 1, @idUsuario1);
CALL altaUsuario('Usuario', 'Normal', 'usuario.normal@mail.com', '1990-05-10', 'UserPassw123$', 0, @idUsuario2);
CALL altaUsuario('María', 'Gómez', 'maria.gomez@mail.com', '1995-11-25', 'MariaG95_Key', 0, @idUsuario3);
CALL altaUsuario('Administrador', 'Secundario', 'admin.secundario@mail.com', '1988-03-15', 'SecureAdmin19', 1, @idUsuario4);

CALL altaPlantilla(95000000.00, 'Super Boca', @idUsuario1, @idEquipos1, 0, @idPlantilla1);
-- Titulares
CALL altaPlantillaTitular(@idFut1, @idPlantilla1, 1);
CALL altaPlantillaTitular(@idFut2, @idPlantilla1, 1);
CALL altaPlantillaTitular(@idFut3, @idPlantilla1, 1);
CALL altaPlantillaTitular(@idFut4, @idPlantilla1, 1);
CALL altaPlantillaTitular(@idFut5, @idPlantilla1, 1);
CALL altaPlantillaTitular(@idFut6, @idPlantilla1, 1);
CALL altaPlantillaTitular(@idFut7, @idPlantilla1, 1);


-- ARQUEROS (4) - @idTipo1
CALL altaFutbolista('Javier', 'García', 'Javi', '1987-01-29', 1500000.00, @idTipo1, @idEquipos1, @idFut12);
CALL altaFutbolista('Leandro', 'Brey', NULL, '2002-09-21', 4000000.00, @idTipo1, @idEquipos1, @idFut13);
CALL altaFutbolista('Lautaro', 'Gómez', NULL, '1999-05-24', 2200000.00, @idTipo1, @idEquipos1, @idFut14);
CALL altaFutbolista('Sebastián', 'Díaz', NULL, '2001-10-14', 1800000.00, @idTipo1, @idEquipos1, @idFut15);

-- DEFENSORES (12) - @idTipo2
CALL altaFutbolista('Cristian', 'Lema', NULL, '1990-03-24', 6800000.00, @idTipo2, @idEquipos1, @idFut16);
CALL altaFutbolista('Lautaro', 'Di Lollo', NULL, '2004-03-10', 3500000.00, @idTipo2, @idEquipos1, @idFut17);
CALL altaFutbolista('Aaron', 'Anselmino', NULL, '2005-04-29', 2800000.00, @idTipo2, @idEquipos1, @idFut18);
CALL altaFutbolista('Marcelo', 'Saracchi', NULL, '1998-01-13', 4500000.00, @idTipo2, @idEquipos1, @idFut19);
CALL altaFutbolista('Ezequiel', 'Bullaude', NULL, '2000-10-26', 7100000.00, @idTipo2, @idEquipos1, @idFut20);
CALL altaFutbolista('Valentín', 'Barco', NULL, '2004-07-23', 9000000.00, @idTipo2, @idEquipos1, @idFut21);
CALL altaFutbolista('Agustín', 'Sández', NULL, '2001-01-16', 4200000.00, @idTipo2, @idEquipos1, @idFut22);
CALL altaFutbolista('Renzo', 'Giampaoli', NULL, '2002-07-20', 2500000.00, @idTipo2, @idEquipos1, @idFut23);
CALL altaFutbolista('Alexis', 'Alvariño', NULL, '2003-01-15', 2100000.00, @idTipo2, @idEquipos1, @idFut24);
CALL altaFutbolista('Facundo', 'Grispo', NULL, '2004-03-12', 1900000.00, @idTipo2, @idEquipos1, @idFut25);
CALL altaFutbolista('Nahuel', 'Genéz', NULL, '2003-01-20', 3100000.00, @idTipo2, @idEquipos1, @idFut26);
CALL altaFutbolista('Lucas', 'Blondel', NULL, '1996-09-14', 5500000.00, @idTipo2, @idEquipos1, @idFut27);

-- MEDIOCAMPISTAS (15) - @idTipo3
CALL altaFutbolista('Jorman', 'Campuzano', NULL, '1996-04-30', 5000000.00, @idTipo3, @idEquipos1, @idFut28);
CALL altaFutbolista('Guillermo', 'Fernández', NULL, '1992-10-11', 7500000.00, @idTipo3, @idEquipos1, @idFut29);
CALL altaFutbolista('Juan', 'Ramírez', NULL, '1993-05-25', 6200000.00, @idTipo3, @idEquipos1, @idFut30);
CALL altaFutbolista('Vicente', 'Taborda', NULL, '2001-05-18', 4100000.00, @idTipo3, @idEquipos1, @idFut31);
CALL altaFutbolista('Ezequiel', 'Ceballos', NULL, '2002-04-20', 3800000.00, @idTipo3, @idEquipos1, @idFut32);
CALL altaFutbolista('Ezequiel', 'Zeballos', 'Chango', '2002-04-24', 8500000.00, @idTipo3, @idEquipos1, @idFut33);
CALL altaFutbolista('Esteban', 'Rolle', NULL, '2000-09-02', 2900000.00, @idTipo3, @idEquipos1, @idFut34);
CALL altaFutbolista('Jabes', 'Saralegui', NULL, '2003-04-14', 3300000.00, @idTipo3, @idEquipos1, @idFut35);
CALL altaFutbolista('Brandon', 'Cortés', NULL, '2004-04-10', 2000000.00, @idTipo3, @idEquipos1, @idFut36);
CALL altaFutbolista('Mauricio', 'Benítez', NULL, '2002-02-03', 4700000.00, @idTipo3, @idEquipos1, @idFut37);
CALL altaFutbolista('Román', 'Rodríguez', NULL, '2002-04-27', 3100000.00, @idTipo3, @idEquipos1, @idFut38);
CALL altaFutbolista('Santiago', 'Ocampos', NULL, '2002-07-28', 2300000.00, @idTipo3, @idEquipos1, @idFut39);
CALL altaFutbolista('Milton', 'Larrauri', NULL, '2001-04-15', 1900000.00, @idTipo3, @idEquipos1, @idFut40);
CALL altaFutbolista('Elián', 'Giménez', NULL, '2003-03-24', 1500000.00, @idTipo3, @idEquipos1, @idFut41);
CALL altaFutbolista('Mateo', 'Benítez', NULL, '2002-01-05', 2400000.00, @idTipo3, @idEquipos1, @idFut42);

-- DELANTEROS (8) - @idTipo4
CALL altaFutbolista('Darío', 'Benedetto', 'Pipa', '1990-05-17', 7900000.00, @idTipo4, @idEquipos1, @idFut43);
CALL altaFutbolista('Luca', 'Langoni', NULL, '2002-02-09', 6500000.00, @idTipo4, @idEquipos1, @idFut44);
CALL altaFutbolista('Norberto', 'Briasco', NULL, '1996-02-29', 5100000.00, @idTipo4, @idEquipos1, @idFut45);
CALL altaFutbolista('Exequiel', 'Fernández', NULL, '2004-03-20', 3900000.00, @idTipo4, @idEquipos1, @idFut46);
CALL altaFutbolista('Lucas', 'Janson', NULL, '1994-08-16', 6000000.00, @idTipo4, @idEquipos1, @idFut47);
CALL altaFutbolista('Facundo', 'Colidio', NULL, '2000-01-04', 7000000.00, @idTipo4, @idEquipos1, @idFut48);
CALL altaFutbolista('Iker', 'Zuaznabar', NULL, '2005-01-20', 2600000.00, @idTipo4, @idEquipos1, @idFut49);
CALL altaFutbolista('Valentino', 'Simoni', NULL, '2003-01-03', 3000000.00, @idTipo4, @idEquipos1, @idFut50);
-- Los IDs de Futbolista comienzan a partir de @idFut51.

-- ARQUEROS (5) - @idTipo1
CALL altaFutbolista('Franco', 'Armani', 'Pulpo', '1986-10-16', 7500000.00, @idTipo1, @idEquipos2, @idFut51);
CALL altaFutbolista('Ezequiel', 'Centurión', NULL, '1997-05-24', 3000000.00, @idTipo1, @idEquipos2, @idFut52);
CALL altaFutbolista('Lucas', 'Lavagnino', NULL, '2004-08-22', 1800000.00, @idTipo1, @idEquipos2, @idFut53);
CALL altaFutbolista('Santiago', 'Beltrán', NULL, '2004-03-29', 1500000.00, @idTipo1, @idEquipos2, @idFut54);
CALL altaFutbolista('Pedro', 'Alfonso', NULL, '2003-01-10', 1200000.00, @idTipo1, @idEquipos2, @idFut55);

-- DEFENSORES (15) - @idTipo2
CALL altaFutbolista('Milton', 'Casco', NULL, '1988-04-13', 6500000.00, @idTipo2, @idEquipos2, @idFut56);
CALL altaFutbolista('Sebastián', 'Boselli', NULL, '2003-12-04', 5800000.00, @idTipo2, @idEquipos2, @idFut57);
CALL altaFutbolista('Paulo', 'Díaz', NULL, '1994-08-25', 8900000.00, @idTipo2, @idEquipos2, @idFut58);
CALL altaFutbolista('Ramiro', 'Funes Mori', 'Melli', '1991-03-05', 7200000.00, @idTipo2, @idEquipos2, @idFut59);
CALL altaFutbolista('Enzo', 'Díaz', NULL, '1995-12-07', 8100000.00, @idTipo2, @idEquipos2, @idFut60);
CALL altaFutbolista('Leandro', 'González Pirez', NULL, '1992-02-26', 6900000.00, @idTipo2, @idEquipos2, @idFut61);
CALL altaFutbolista('David', 'Martínez', NULL, '1998-01-20', 4500000.00, @idTipo2, @idEquipos2, @idFut62);
CALL altaFutbolista('Emanuel', 'Mammana', NULL, '1996-02-10', 4100000.00, @idTipo2, @idEquipos2, @idFut63);
CALL altaFutbolista('Andrés', 'Herrera', NULL, '1998-11-03', 3500000.00, @idTipo2, @idEquipos2, @idFut64);
CALL altaFutbolista('Elías', 'Gómez', NULL, '1994-06-26', 4900000.00, @idTipo2, @idEquipos2, @idFut65);
CALL altaFutbolista('Santiago', 'Simon', NULL, '2002-06-13', 8500000.00, @idTipo2, @idEquipos2, @idFut66);
CALL altaFutbolista('Alex', 'Vigo', NULL, '1999-05-28', 3100000.00, @idTipo2, @idEquipos2, @idFut67);
CALL altaFutbolista('Lucas', 'Martínez Quarta', NULL, '1996-05-10', 7000000.00, @idTipo2, @idEquipos2, @idFut68);
CALL altaFutbolista('Gonzalo', 'Montiel', NULL, '1997-01-01', 6300000.00, @idTipo2, @idEquipos2, @idFut69);
CALL altaFutbolista('Jonatan', 'Maidana', NULL, '1985-07-29', 2000000.00, @idTipo2, @idEquipos2, @idFut70);

-- MEDIOCAMPISTAS (18) - @idTipo3
CALL altaFutbolista('Enzo', 'Pérez', NULL, '1986-02-22', 9200000.00, @idTipo3, @idEquipos2, @idFut71);
CALL altaFutbolista('Matías', 'Kranevitter', NULL, '1993-05-29', 7800000.00, @idTipo3, @idEquipos2, @idFut72);
CALL altaFutbolista('Nicolás', 'De La Cruz', NULL, '1997-06-01', 9900000.00, @idTipo3, @idEquipos2, @idFut73);
CALL altaFutbolista('Ignacio', 'Fernández', 'Nacho', '1990-01-12', 8800000.00, @idTipo3, @idEquipos2, @idFut74);
CALL altaFutbolista('Manuel', 'Lanzini', NULL, '1993-02-15', 8500000.00, @idTipo3, @idEquipos2, @idFut75);
CALL altaFutbolista('Rodrigo', 'Aliendro', NULL, '1991-02-16', 7000000.00, @idTipo3, @idEquipos2, @idFut76);
CALL altaFutbolista('Agustín', 'Palavecino', NULL, '1996-11-09', 6000000.00, @idTipo3, @idEquipos2, @idFut77);
CALL altaFutbolista('Claudio', 'Echeverri', 'Diablito', '2006-01-02', 4500000.00, @idTipo3, @idEquipos2, @idFut78);
CALL altaFutbolista('Esequiel', 'Barco', NULL, '1999-03-29', 9500000.00, @idTipo3, @idEquipos2, @idFut79);
CALL altaFutbolista('José', 'Paradela', NULL, '1998-12-15', 3800000.00, @idTipo3, @idEquipos2, @idFut80);
CALL altaFutbolista('Tomás', 'Lecanda', NULL, '2002-01-22', 2500000.00, @idTipo3, @idEquipos2, @idFut81);
CALL altaFutbolista('Felipe', 'Peña Biafore', NULL, '2001-04-03', 3000000.00, @idTipo3, @idEquipos2, @idFut82);
CALL altaFutbolista('Jonatan', 'Gómez', NULL, '2003-09-02', 2200000.00, @idTipo3, @idEquipos2, @idFut83);
CALL altaFutbolista('Esteban', 'Fernández', NULL, '2004-06-15', 1800000.00, @idTipo3, @idEquipos2, @idFut84);
CALL altaFutbolista('Franco', 'Alfonso', NULL, '2004-01-09', 1500000.00, @idTipo3, @idEquipos2, @idFut85);
CALL altaFutbolista('Lucas', 'Cameroni', NULL, '2005-02-05', 1300000.00, @idTipo3, @idEquipos2, @idFut86);
CALL altaFutbolista('Martín', 'Solari', NULL, '2005-03-12', 1100000.00, @idTipo3, @idEquipos2, @idFut87);
CALL altaFutbolista('Carlos', 'Auzqui', NULL, '1991-03-17', 3500000.00, @idTipo3, @idEquipos2, @idFut88);

-- DELANTEROS (12) - @idTipo4
CALL altaFutbolista('Miguel', 'Borja', NULL, '1993-01-26', 8000000.00, @idTipo4, @idEquipos2, @idFut89);
CALL altaFutbolista('Facundo', 'Colidio', NULL, '2000-01-04', 7000000.00, @idTipo4, @idEquipos2, @idFut90);
CALL altaFutbolista('Salomón', 'Rondón', NULL, '1989-09-16', 6200000.00, @idTipo4, @idEquipos2, @idFut91);
CALL altaFutbolista('Pablo', 'Solari', NULL, '2001-03-22', 8500000.00, @idTipo4, @idEquipos2, @idFut92);
CALL altaFutbolista('Matías', 'Suárez', NULL, '1988-05-09', 4900000.00, @idTipo4, @idEquipos2, @idFut93);
CALL altaFutbolista('Agustín', 'Ruberto', NULL, '2006-05-26', 3000000.00, @idTipo4, @idEquipos2, @idFut94);
CALL altaFutbolista('Alexis', 'Castro', NULL, '2005-01-04', 2500000.00, @idTipo4, @idEquipos2, @idFut95);
CALL altaFutbolista('Ian', 'Subiabre', NULL, '2007-01-01', 1800000.00, @idTipo4, @idEquipos2, @idFut96);
CALL altaFutbolista('Flabián', 'Londoño', NULL, '2000-07-09', 2800000.00, @idTipo4, @idEquipos2, @idFut97);
CALL altaFutbolista('Lucas', 'Beltrán', NULL, '2001-05-14', 9000000.00, @idTipo4, @idEquipos2, @idFut98);
CALL altaFutbolista('Julian', 'Álvarez', NULL, '2000-01-31', 9900000.00, @idTipo4, @idEquipos2, @idFut99);
CALL altaFutbolista('Rafael', 'Santos Borré', NULL, '1995-09-15', 7500000.00, @idTipo4, @idEquipos2, @idFut100);

-- Los IDs de Futbolista comienzan a partir de @idFut101.

-- ARQUEROS (5) - @idTipo1
CALL altaFutbolista('Gabriel', 'Arias', 'Gaviota', '1987-09-13', 7000000.00, @idTipo1, @idEquipos3, @idFut101);
CALL altaFutbolista('Matías', 'Tagliamonte', NULL, '1998-02-19', 2500000.00, @idTipo1, @idEquipos3, @idFut102);
CALL altaFutbolista('Facundo', 'Cambeses', NULL, '1997-04-09', 3200000.00, @idTipo1, @idEquipos3, @idFut103);
CALL altaFutbolista('Roberto', 'Leiva', NULL, '2004-01-20', 1000000.00, @idTipo1, @idEquipos3, @idFut104);
CALL altaFutbolista('Francisco', 'Gómez', NULL, '2005-02-11', 800000.00, @idTipo1, @idEquipos3, @idFut105);

-- DEFENSORES (15) - @idTipo2
CALL altaFutbolista('Leonardo', 'Sigali', NULL, '1987-05-28', 5500000.00, @idTipo2, @idEquipos3, @idFut106);
CALL altaFutbolista('Gonzalo', 'Piovi', NULL, '1994-09-20', 7800000.00, @idTipo2, @idEquipos3, @idFut107);
CALL altaFutbolista('Gabriel', 'Rojas', NULL, '1994-06-22', 6500000.00, @idTipo2, @idEquipos3, @idFut108);
CALL altaFutbolista('Iván', 'Pillud', NULL, '1986-04-24', 2000000.00, @idTipo2, @idEquipos3, @idFut109);
CALL altaFutbolista('Facundo', 'Mura', NULL, '1999-03-24', 5000000.00, @idTipo2, @idEquipos3, @idFut110);
CALL altaFutbolista('Nazareno', 'Colombo', NULL, '1999-04-20', 4500000.00, @idTipo2, @idEquipos3, @idFut111);
CALL altaFutbolista('Santiago', 'Quiros', NULL, '2002-06-16', 3500000.00, @idTipo2, @idEquipos3, @idFut112);
CALL altaFutbolista('Tobías', 'Rubio', NULL, '2000-07-07', 2800000.00, @idTipo2, @idEquipos3, @idFut113);
CALL altaFutbolista('Ignacio', 'Galván', NULL, '2000-09-01', 3100000.00, @idTipo2, @idEquipos3, @idFut114);
CALL altaFutbolista('Juan', 'Cáceres', NULL, '1999-07-16', 4200000.00, @idTipo2, @idEquipos3, @idFut115);
CALL altaFutbolista('Fernando', 'Prado', NULL, '1999-04-03', 3900000.00, @idTipo2, @idEquipos3, @idFut116);
CALL altaFutbolista('Nicolás', 'Tagliafico', NULL, '1992-08-31', 8900000.00, @idTipo2, @idEquipos3, @idFut117);
CALL altaFutbolista('Germán', 'Conti', NULL, '1994-06-03', 6000000.00, @idTipo2, @idEquipos3, @idFut118);
CALL altaFutbolista('Pablo', 'Adorno', NULL, '2003-01-03', 2200000.00, @idTipo2, @idEquipos3, @idFut119);
CALL altaFutbolista('Damián', 'Calcaterra', NULL, '2004-02-15', 1800000.00, @idTipo2, @idEquipos3, @idFut120);

-- MEDIOCAMPISTAS (18) - @idTipo3
CALL altaFutbolista('Aníbal', 'Moreno', NULL, '1999-05-13', 8500000.00, @idTipo3, @idEquipos3, @idFut121);
CALL altaFutbolista('Juan', 'Nardoni', NULL, '2002-07-14', 7500000.00, @idTipo3, @idEquipos3, @idFut122);
CALL altaFutbolista('Agustín', 'Almendra', NULL, '2000-02-11', 6800000.00, @idTipo3, @idEquipos3, @idFut123);
CALL altaFutbolista('Jonathan', 'Gómez', NULL, '1989-12-21', 4000000.00, @idTipo3, @idEquipos3, @idFut124);
CALL altaFutbolista('Maximiliano', 'Romero', NULL, '1999-01-09', 5200000.00, @idTipo3, @idEquipos3, @idFut125);
CALL altaFutbolista('Nicolás', 'Oroz', NULL, '1994-04-01', 4800000.00, @idTipo3, @idEquipos3, @idFut126);
CALL altaFutbolista('Baltasar', 'Rodríguez', NULL, '2003-07-06', 4100000.00, @idTipo3, @idEquipos3, @idFut127);
CALL altaFutbolista('Gabriel', 'Vera', NULL, '2000-12-05', 3500000.00, @idTipo3, @idEquipos3, @idFut128);
CALL altaFutbolista('Ignacio', 'Cechi', NULL, '2001-03-24', 2800000.00, @idTipo3, @idEquipos3, @idFut129);
CALL altaFutbolista('Fabián', 'Sánchez', NULL, '2002-01-20', 2100000.00, @idTipo3, @idEquipos3, @idFut130);
CALL altaFutbolista('Maico', 'Quiroz', NULL, '2001-08-14', 3000000.00, @idTipo3, @idEquipos3, @idFut131);
CALL altaFutbolista('Tomás', 'Álvarez', NULL, '2001-04-20', 1800000.00, @idTipo3, @idEquipos3, @idFut132);
CALL altaFutbolista('Luca', 'Godoy', NULL, '2003-01-05', 1500000.00, @idTipo3, @idEquipos3, @idFut133);
CALL altaFutbolista('Santiago', 'Coria', NULL, '2005-02-18', 1200000.00, @idTipo3, @idEquipos3, @idFut134);
CALL altaFutbolista('Gastón', 'Martínez', NULL, '1999-07-29', 5500000.00, @idTipo3, @idEquipos3, @idFut135);
CALL altaFutbolista('Leonel', 'Miranda', NULL, '1992-01-07', 4900000.00, @idTipo3, @idEquipos3, @idFut136);
CALL altaFutbolista('Nery', 'Domínguez', NULL, '1990-04-09', 3800000.00, @idTipo3, @idEquipos3, @idFut137);
CALL altaFutbolista('Jonatan', 'Cristaldo', NULL, '1989-03-05', 2900000.00, @idTipo3, @idEquipos3, @idFut138);

-- DELANTEROS (12) - @idTipo4
CALL altaFutbolista('Roger', 'Martínez', NULL, '1994-06-23', 8000000.00, @idTipo4, @idEquipos3, @idFut139);
CALL altaFutbolista('Adrián', 'Martínez', NULL, '1992-07-07', 6500000.00, @idTipo4, @idEquipos3, @idFut140);
CALL altaFutbolista('Johan', 'Carbonero', NULL, '1999-07-20', 7900000.00, @idTipo4, @idEquipos3, @idFut141);
CALL altaFutbolista('Gabriel', 'Hauche', 'Demonio', '1986-11-27', 3500000.00, @idTipo4, @idEquipos3, @idFut142);
CALL altaFutbolista('Maximiliano', 'Salas', NULL, '1997-12-01', 5800000.00, @idTipo4, @idEquipos3, @idFut143);
CALL altaFutbolista('Emiliano', 'Vecchio', NULL, '1988-11-16', 4200000.00, @idTipo4, @idEquipos3, @idFut144);
CALL altaFutbolista('Héctor', 'Fértoli', NULL, '1994-12-03', 3900000.00, @idTipo4, @idEquipos3, @idFut145);
CALL altaFutbolista('Tomás', 'Chancalay', NULL, '1998-01-01', 5000000.00, @idTipo4, @idEquipos3, @idFut146);
CALL altaFutbolista('Nicolás', 'Reniero', NULL, '1995-03-18', 4500000.00, @idTipo4, @idEquipos3, @idFut147);
CALL altaFutbolista('Ramiro', 'Díaz', NULL, '2001-03-24', 2800000.00, @idTipo4, @idEquipos3, @idFut148);
CALL altaFutbolista('Román', 'Vega', NULL, '2003-01-04', 1900000.00, @idTipo4, @idEquipos3, @idFut149);
CALL altaFutbolista('Lautaro', 'Martínez', NULL, '1997-08-22', 9500000.00, @idTipo4, @idEquipos3, @idFut150);

-- Los IDs de Futbolista comienzan a partir de @idFut151.

-- ARQUEROS (5) - @idTipo1
CALL altaFutbolista('Rodrigo', 'Rey', NULL, '1991-03-08', 4500000.00, @idTipo1, @idEquipos4, @idFut151);
CALL altaFutbolista('Diego', 'Segovia', NULL, '2000-09-02', 1500000.00, @idTipo1, @idEquipos4, @idFut152);
CALL altaFutbolista('Manuel', 'Tasso', NULL, '2004-04-05', 900000.00, @idTipo1, @idEquipos4, @idFut153);
CALL altaFutbolista('Mateo', 'Morro', NULL, '2003-01-10', 800000.00, @idTipo1, @idEquipos4, @idFut154);
CALL altaFutbolista('Gianfranco', 'Meza', NULL, '2002-05-18', 750000.00, @idTipo1, @idEquipos4, @idFut155);

-- DEFENSORES (15) - @idTipo2
CALL altaFutbolista('Joaquín', 'Laso', NULL, '1990-07-04', 5000000.00, @idTipo2, @idEquipos4, @idFut156);
CALL altaFutbolista('Felipe', 'Aguilar', NULL, '1993-01-20', 6500000.00, @idTipo2, @idEquipos4, @idFut157);
CALL altaFutbolista('Damián', 'Pérez', NULL, '1993-12-29', 5800000.00, @idTipo2, @idEquipos4, @idFut158);
CALL altaFutbolista('Mauricio', 'Isla', NULL, '1988-06-12', 4000000.00, @idTipo2, @idEquipos4, @idFut159);
CALL altaFutbolista('Edgar', 'Elizalde', NULL, '2000-02-27', 4800000.00, @idTipo2, @idEquipos4, @idFut160);
CALL altaFutbolista('Ayrton', 'Costa', NULL, '1999-07-12', 7200000.00, @idTipo2, @idEquipos4, @idFut161);
CALL altaFutbolista('Cristian', 'Tarragona', NULL, '1998-03-29', 3500000.00, @idTipo2, @idEquipos4, @idFut162);
CALL altaFutbolista('Luciano', 'Gómez', NULL, '1996-02-14', 3000000.00, @idTipo2, @idEquipos4, @idFut163);
CALL altaFutbolista('Julio', 'Buffarini', NULL, '1988-08-15', 2500000.00, @idTipo2, @idEquipos4, @idFut164);
CALL altaFutbolista('Tomás', 'Jara', NULL, '1999-01-08', 2100000.00, @idTipo2, @idEquipos4, @idFut165);
CALL altaFutbolista('Fernando', 'Da Rosa', NULL, '2001-05-12', 1800000.00, @idTipo2, @idEquipos4, @idFut166);
CALL altaFutbolista('Santiago', 'Román', NULL, '2002-04-17', 1500000.00, @idTipo2, @idEquipos4, @idFut167);
CALL altaFutbolista('Ezequiel', 'Muñoz', NULL, '1990-10-20', 1200000.00, @idTipo2, @idEquipos4, @idFut168);
CALL altaFutbolista('Lucas', 'Carabajal', NULL, '2003-03-01', 900000.00, @idTipo2, @idEquipos4, @idFut169);
CALL altaFutbolista('Nicolás', 'Vallejo', NULL, '2004-01-20', 500000.00, @idTipo2, @idEquipos4, @idFut170);

-- MEDIOCAMPISTAS (18) - @idTipo3
CALL altaFutbolista('Iván', 'Marcone', NULL, '1990-06-04', 6200000.00, @idTipo3, @idEquipos4, @idFut171);
CALL altaFutbolista('Lucas', 'González', NULL, '2000-06-03', 7500000.00, @idTipo3, @idEquipos4, @idFut172);
CALL altaFutbolista('Federico', 'Mancuello', NULL, '1989-03-26', 5800000.00, @idTipo3, @idEquipos4, @idFut173);
CALL altaFutbolista('Kevin', 'López', NULL, '2002-12-31', 4900000.00, @idTipo3, @idEquipos4, @idFut174);
CALL altaFutbolista('Santiago', 'Toloza', NULL, '2002-07-28', 5100000.00, @idTipo3, @idEquipos4, @idFut175);
CALL altaFutbolista('Braian', 'Martínez', NULL, '1999-08-20', 7000000.00, @idTipo3, @idEquipos4, @idFut176);
CALL altaFutbolista('Alan', 'Soñora', NULL, '1998-08-03', 6500000.00, @idTipo3, @idEquipos4, @idFut177);
CALL altaFutbolista('Martín', 'Sarrafiore', NULL, '1997-07-20', 3800000.00, @idTipo3, @idEquipos4, @idFut178);
CALL altaFutbolista('Tomás', 'Pozzo', NULL, '2000-09-26', 3100000.00, @idTipo3, @idEquipos4, @idFut179);
CALL altaFutbolista('Sergio', 'Ortiz', NULL, '2001-08-27', 2800000.00, @idTipo3, @idEquipos4, @idFut180);
CALL altaFutbolista('David', 'Sayago', NULL, '2003-04-10', 2100000.00, @idTipo3, @idEquipos4, @idFut181);
CALL altaFutbolista('Rodrigo', 'Atencio', NULL, '2004-10-27', 1500000.00, @idTipo3, @idEquipos4, @idFut182);
CALL altaFutbolista('Mateo', 'Barcia', NULL, '2001-08-16', 4200000.00, @idTipo3, @idEquipos4, @idFut183);
CALL altaFutbolista('Santiago', 'Ramírez', NULL, '2000-04-13', 3500000.00, @idTipo3, @idEquipos4, @idFut184);
CALL altaFutbolista('Lucas', 'Saltita', NULL, '1994-08-16', 5000000.00, @idTipo3, @idEquipos4, @idFut185);
CALL altaFutbolista('Gonzalo', 'Hansen', NULL, '1996-01-20', 2900000.00, @idTipo3, @idEquipos4, @idFut186);
CALL altaFutbolista('Alexis', 'Canelo', NULL, '1992-02-07', 4800000.00, @idTipo3, @idEquipos4, @idFut187);
CALL altaFutbolista('Nicolás', 'Domingo', NULL, '1985-04-04', 1800000.00, @idTipo3, @idEquipos4, @idFut188);

-- DELANTEROS (12) - @idTipo4
CALL altaFutbolista('Matías', 'Giménez', NULL, '1999-12-23', 6800000.00, @idTipo4, @idEquipos4, @idFut189);
CALL altaFutbolista('Gabriel', 'Ávalos', NULL, '1990-10-01', 7500000.00, @idTipo4, @idEquipos4, @idFut190);
CALL altaFutbolista('Alexis', 'Maestros', NULL, '1999-12-19', 4500000.00, @idTipo4, @idEquipos4, @idFut191);
CALL altaFutbolista('Lucas', 'Romero', NULL, '1994-04-18', 6000000.00, @idTipo4, @idEquipos4, @idFut192);
CALL altaFutbolista('Javier', 'Vallejo', NULL, '2004-04-02', 3800000.00, @idTipo4, @idEquipos4, @idFut193);
CALL altaFutbolista('Santiago', 'Hidalgo', NULL, '2001-08-01', 2500000.00, @idTipo4, @idEquipos4, @idFut194);
CALL altaFutbolista('Facundo', 'Velazco', NULL, '2002-05-18', 2100000.00, @idTipo4, @idEquipos4, @idFut195);
CALL altaFutbolista('Nicolás', 'Messiniti', NULL, '1996-04-21', 1900000.00, @idTipo4, @idEquipos4, @idFut196);
CALL altaFutbolista('Gabriel', 'Ríos', NULL, '1999-07-28', 5000000.00, @idTipo4, @idEquipos4, @idFut197);
CALL altaFutbolista('Martín', 'Cauti', NULL, '2003-01-08', 1500000.00, @idTipo4, @idEquipos4, @idFut198);
CALL altaFutbolista('Silvio', 'Romero', NULL, '1988-07-22', 4000000.00, @idTipo4, @idEquipos4, @idFut199);
CALL altaFutbolista('Leandro', 'Fernández', NULL, '1991-03-12', 3500000.00, @idTipo4, @idEquipos4, @idFut200);

-- Los IDs de Futbolista comienzan a partir de @idFut151.

-- ARQUEROS (5) - @idTipo1
CALL altaFutbolista('Augusto', 'Batalla', NULL, '1996-04-30', 5500000.00, @idTipo1, @idEquipos5, @idFut151);
CALL altaFutbolista('Facundo', 'Altamirano', NULL, '1996-03-23', 3000000.00, @idTipo1, @idEquipos5, @idFut152);
CALL altaFutbolista('Lautaro', 'López', NULL, '1999-01-01', 2500000.00, @idTipo1, @idEquipos5, @idFut153);
CALL altaFutbolista('Gastón', 'Gómez', NULL, '1993-02-27', 1500000.00, @idTipo1, @idEquipos5, @idFut154);
CALL altaFutbolista('Santiago', 'Torres', NULL, '2004-01-10', 1200000.00, @idTipo1, @idEquipos5, @idFut155);

-- DEFENSORES (15) - @idTipo2
CALL altaFutbolista('Gastón', 'Hernández', 'Gatito', '1998-01-07', 7500000.00, @idTipo2, @idEquipos5, @idFut156);
CALL altaFutbolista('Rafael', 'Pérez', NULL, '1990-01-09', 5800000.00, @idTipo2, @idEquipos5, @idFut157);
CALL altaFutbolista('Federico', 'Gattoni', NULL, '1999-02-16', 8000000.00, @idTipo2, @idEquipos5, @idFut158);
CALL altaFutbolista('Jalil', 'Elías', NULL, '1996-02-05', 6500000.00, @idTipo2, @idEquipos5, @idFut159);
CALL altaFutbolista('Malcom', 'Braida', NULL, '1997-05-17', 5200000.00, @idTipo2, @idEquipos5, @idFut160);
CALL altaFutbolista('Gonzalo', 'Luján', NULL, '2001-04-27', 4500000.00, @idTipo2, @idEquipos5, @idFut161);
CALL altaFutbolista('Ezequiel', 'Herrera', NULL, '2000-04-26', 4000000.00, @idTipo2, @idEquipos5, @idFut162);
CALL altaFutbolista('Carlos', 'Sánchez', 'Pibe', '1986-02-06', 3000000.00, @idTipo2, @idEquipos5, @idFut163);
CALL altaFutbolista('Facundo', 'Grispo', NULL, '2003-05-18', 2500000.00, @idTipo2, @idEquipos5, @idFut164);
CALL altaFutbolista('Tomás', 'Tapia', NULL, '2004-03-23', 2000000.00, @idTipo2, @idEquipos5, @idFut165);
CALL altaFutbolista('Cristian', 'Tarragona', NULL, '2003-01-15', 1800000.00, @idTipo2, @idEquipos5, @idFut166);
CALL altaFutbolista('Francisco', 'Perruzzi', NULL, '2002-05-19', 3500000.00, @idTipo2, @idEquipos5, @idFut167);
CALL altaFutbolista('Manuel', 'Insaurralde', NULL, '1999-08-16', 4800000.00, @idTipo2, @idEquipos5, @idFut168);
CALL altaFutbolista('Bruno', 'Pittaluga', NULL, '2003-01-08', 2200000.00, @idTipo2, @idEquipos5, @idFut169);
CALL altaFutbolista('Alexandro', 'Segura', NULL, '2004-02-01', 1900000.00, @idTipo2, @idEquipos5, @idFut170);

-- MEDIOCAMPISTAS (18) - @idTipo3
CALL altaFutbolista('Jhohan', 'Romero', NULL, '1995-12-19', 6200000.00, @idTipo3, @idEquipos5, @idFut171);
CALL altaFutbolista('Nahuel', 'Barrios', 'Perrito', '1998-05-07', 7000000.00, @idTipo3, @idEquipos5, @idFut172);
CALL altaFutbolista('Carlos', 'Auzqui', NULL, '1991-03-17', 4500000.00, @idTipo3, @idEquipos5, @idFut173);
CALL altaFutbolista('Gastón', 'Ramírez', NULL, '1990-12-02', 5000000.00, @idTipo3, @idEquipos5, @idFut174);
CALL altaFutbolista('Gonzalo', 'Maroni', NULL, '1999-03-18', 4200000.00, @idTipo3, @idEquipos5, @idFut175);
CALL altaFutbolista('Siro', 'Rosané', NULL, '2000-02-28', 3500000.00, @idTipo3, @idEquipos5, @idFut176);
CALL altaFutbolista('Elián', 'Irala', NULL, '2004-05-24', 3800000.00, @idTipo3, @idEquipos5, @idFut177);
CALL altaFutbolista('Agustín', 'Giay', NULL, '2004-01-16', 5500000.00, @idTipo3, @idEquipos5, @idFut178);
CALL altaFutbolista('Alexis', 'Soto', NULL, '1993-10-20', 4900000.00, @idTipo3, @idEquipos5, @idFut179);
CALL altaFutbolista('Sebastián', 'Palacios', NULL, '1992-01-20', 6000000.00, @idTipo3, @idEquipos5, @idFut180);
CALL altaFutbolista('Cristian', 'Ferreira', NULL, '1999-09-12', 5100000.00, @idTipo3, @idEquipos5, @idFut181);
CALL altaFutbolista('Iván', 'Leguizamón', NULL, '2002-07-03', 4000000.00, @idTipo3, @idEquipos5, @idFut182);
CALL altaFutbolista('Tomás', 'Silva', NULL, '2003-01-08', 2100000.00, @idTipo3, @idEquipos5, @idFut183);
CALL altaFutbolista('Diego', 'Gómez', NULL, '2001-06-25', 1800000.00, @idTipo3, @idEquipos5, @idFut184);
CALL altaFutbolista('Ortigoza', 'Néstor', NULL, '1984-10-07', 1000000.00, @idTipo3, @idEquipos5, @idFut185);
CALL altaFutbolista('Ricardo', 'Centurión', NULL, '1993-01-19', 3000000.00, @idTipo3, @idEquipos5, @idFut186);
CALL altaFutbolista('Ezequiel', 'Cerutti', NULL, '1992-01-17', 2800000.00, @idTipo3, @idEquipos5, @idFut187);
CALL altaFutbolista('Brahian', 'Alemán', NULL, '1989-12-23', 4100000.00, @idTipo3, @idEquipos5, @idFut188);

-- DELANTEROS (12) - @idTipo4
CALL altaFutbolista('Adam', 'Bareiro', NULL, '1996-07-26', 7800000.00, @idTipo4, @idEquipos5, @idFut189);
CALL altaFutbolista('Federico', 'Girotti', NULL, '1999-06-02', 6500000.00, @idTipo4, @idEquipos5, @idFut190);
CALL altaFutbolista('Nicolás', 'Blandi', NULL, '1990-01-13', 4500000.00, @idTipo4, @idEquipos5, @idFut191);
CALL altaFutbolista('Juan', 'Ignacio Méndez', NULL, '1997-04-18', 5000000.00, @idTipo4, @idEquipos5, @idFut192);
CALL altaFutbolista('Cristian', 'Tarragona', NULL, '1991-03-29', 3500000.00, @idTipo4, @idEquipos5, @idFut193);
CALL altaFutbolista('Nahuel', 'Gallerano', NULL, '2003-01-10', 2500000.00, @idTipo4, @idEquipos5, @idFut194);
CALL altaFutbolista('Alexander', 'Díaz', NULL, '2004-03-24', 3000000.00, @idTipo4, @idEquipos5, @idFut195);
CALL altaFutbolista('Matías', 'Córdoba', NULL, '2002-01-05', 2200000.00, @idTipo4, @idEquipos5, @idFut196);
CALL altaFutbolista('Luciano', 'Gondou', NULL, '2001-06-22', 4800000.00, @idTipo4, @idEquipos5, @idFut197);
CALL altaFutbolista('Walter', 'Bou', NULL, '1993-08-25', 6000000.00, @idTipo4, @idEquipos5, @idFut198);
CALL altaFutbolista('Adolfo', 'Gaich', NULL, '1999-02-26', 7000000.00, @idTipo4, @idEquipos5, @idFut199);
CALL altaFutbolista('Gonzalo', 'Ledesma', NULL, '2000-01-01', 3500000.00, @idTipo4, @idEquipos5, @idFut200);