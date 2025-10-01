using System;
using System.Collections.Generic;

namespace GranDT.Core
{
    public interface IAdo
    {
        // Alta
        int AltaTipo(string nombre);
        int AltaEquipo(string nombre);
        int AltaFutbolista(string nombre, string apellido, string apodo, DateTime? fechaNacimiento, decimal? cotizacion, int idTipo, int idEquipos);
        int AltaUsuario(string nombre, string apellido, string email, DateTime? fechaNacimiento, string contraseña, byte? esAdmin);
        int AltaPlantilla(decimal? presupuesto, string nombrePlantilla, int idUsuario, byte? cantidadJugadores);
        void AltaPlantillaTitular(int idFutbolista, int idPlantillas, byte? esTitular);
        void AltaPlantillaSuplente(int idFutbolista, int idPlantillas, byte? esSuplente);
        int AltaPuntuacion(byte fechaNro, decimal? puntuacion, int idFutbolista);

        // Actualizar
        void ActualizarPlantilla(int idPlantillas, int idUsuario, decimal? presupuesto, string nombrePlantilla, byte? cantidadJugadores);
        void ActualizarPlantillaTitular(int idFutbolista, int idPlantillas, byte? esTitular);
        void ActualizarPlantillaSuplente(int idFutbolista, int idPlantillas, byte? esSuplente);

        // Eliminar
        void EliminarPlantilla(int idPlantillas, int idUsuario);
        void EliminarPlantillaTitular(int idFutbolista, int idPlantillas);
        void EliminarPlantillaSuplente(int idFutbolista, int idPlantillas);
    }
}