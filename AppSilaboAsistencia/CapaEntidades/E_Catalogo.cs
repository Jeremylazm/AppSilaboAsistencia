namespace CapaEntidades
{
    public class E_Catalogo
    {
        // Definir los atributos o campos que tiene un catalogo
        public string CodSemestre { get; set; }
        public string CodEscuelaP { get; set; }
        public string CodAsignatura { get; set; }
        public string Grupo { get; set; }
        public string CodDocente { get; set; }
        public byte[] Silabo { get; set; }
    }
}
