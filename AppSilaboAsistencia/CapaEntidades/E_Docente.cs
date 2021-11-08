namespace CapaEntidades
{
    public class E_Docente
    {
        // Definir los atributos o campos que tiene un docente
        public byte[] Perfil { get; set; }
        public string CodDocente { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string Regimen { get; set; }
        public string CodDepartamentoA { get; set; }
        public string CodEscuelaP { get; set; }
    }
}
