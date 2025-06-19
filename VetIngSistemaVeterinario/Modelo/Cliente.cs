﻿using VetIngSistemaVeterinario.Modelo.Identity;

namespace VetIngSistemaVeterinario.Modelo
{
    public class Cliente : Persona
    {
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public string Direccion { get; set; }
        public List<Mascota> Mascotas { get; set; }
        public List<Turno> Turnos { get; set; }
    }
}
