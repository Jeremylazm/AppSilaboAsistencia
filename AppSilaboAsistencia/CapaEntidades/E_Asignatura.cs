namespace CapaEntidades
{
    public class E_Asignatura
    {
        // Definir los atributos o campos que tiene una asignatura
        public string CodAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public int Creditos { get; set; }
        public string Categoria { get; set; }
        public int HorasTeoria { get; set; }
        public int HorasPractica { get; set; }
        public string Prerrequisito { get; set; }
    }
}
