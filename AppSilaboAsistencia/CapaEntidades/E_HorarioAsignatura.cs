﻿namespace CapaEntidades
{
    public class E_HorarioAsignatura
    {
        // Definir los atributos o campos que tiene un catalogo
        public string CodSemestre { get; set; }
        public string CodAsignatura { get; set; }
        public string CodEscuelaP { get; set; }
        public string Grupo { get; set; }
        public string CodDocente { get; set; }
        public string Dia { get; set; }
        public string Tipo { get; set; }
        public int HorasTeoria { get; set; }
        public int HorasPractica { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Aula { get; set; }
        public string Modalidad { get; set; }
    }
}
