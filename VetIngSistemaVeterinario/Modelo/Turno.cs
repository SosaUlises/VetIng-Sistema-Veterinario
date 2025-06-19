﻿namespace VetIngSistemaVeterinario.Modelo
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public string Estado { get; set; } // Pendiente, Cancelado, Rechazado, Finalizado
        public string? Motivo { get; set; }
        public bool PrimeraCita { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Veterinario Veterinario { get; set; }
        public int VeterinarioId { get; set; }
        public Mascota? Mascota { get; set; } // Puede ser null si es Primera Cita
        public int MascotaId { get; set; }
    }
}
