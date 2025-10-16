using System;

namespace GranDT.Core
{
    public interface IAdo
    {
        // Alta
        int AltaPlantilla(decimal? presupuesto, string nombrePlantilla, int idUsuario, byte? cantidadJugadores);
        void AltaPlantillaTitular(int idFutbolista, int idPlantilla, bool esTitular);
        void AltaPlantillaSuplente(int idFutbolista, int idPlantilla, bool esSuplente);
        

        // Actualizar
        void ActualizarPlantilla(int idPlantilla, int idUsuario, decimal? presupuesto, string nombrePlantilla, byte? cantidadJugadores);
        void ActualizarPlantillaTitular(int idFutbolista, int idPlantilla, bool esTitular);


        // Eliminar
        void EliminarPlantilla(int idPlantilla, int idUsuario);
        void EliminarPlantillaTitular(int idFutbolista, int idPlantilla);
    }
}
