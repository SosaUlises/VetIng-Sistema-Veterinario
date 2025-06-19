﻿namespace VetIngSistemaVeterinario.Modelo
{
    public class AtencionVeterinaria
    {
        public int Id { get; set; }
        public Tratamiento Tratamiento { get; set; }
        public int TratamientoId { get; set; }
        public List<Vacuna>? Vacunas { get; set; }
        public List<Estudio>? EstudiosComplementarios { get; set; }
        public string Diagnostico { get; set; }
        public decimal CostoTotal { get; set; }
        public Veterinario Veterinario { get; set; }
        public int VeterinarioId { get; set; }
        public float PesoMascota { get; set; }
        public int HistoriaClinicaId { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
    }
}
