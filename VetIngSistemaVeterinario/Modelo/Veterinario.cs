﻿using VetIngSistemaVeterinario.Modelo.Identity;

namespace VetIngSistemaVeterinario.Modelo
{
    public class Veterinario : Persona
    {
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public string Matricula { get; set; }
        public List<Turno> Turnos { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; }
    }
}
