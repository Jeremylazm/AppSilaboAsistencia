using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControlesPerzonalizados.Ayudas
{
    public class A_Validador
    {
        public bool Validar(string ExpresionRegular, BunifuTextBox TextBox, BunifuLabel Label, string Mensaje)
        {
            Regex Validador = new Regex(ExpresionRegular);

            if (!Validador.IsMatch(TextBox.Text))
            {
                Label.Visible = true;
                Label.Text = Mensaje;
                return false;
            }

            return true;
        }

        public bool ValidarCampoLleno(BunifuTextBox TextBox, BunifuLabel Label)
        {
            return Validar(@"^(?!\s*$).+", TextBox, Label, "El campo no debe estar vacío");
        }

        public bool ValidarUsuario(BunifuTextBox TextBox, BunifuLabel Label)
        {
            bool UsuarioLleno = Validar(@"^(?!\s*$).+", TextBox, Label, "El campo no debe estar vacío");
            bool UsuarioDocente = Validar(@"(^$)|(^(AD)[A-Z]{2}$)|(^\d{5}$)", TextBox, Label, "El usuario debe contener 5 dígitos");
            bool UsuarioAdministrador = Validar(@"(^$)|(^(?!AD).+)|(^(AD)[A-Z]{2}$)", TextBox, Label, "El usuario debe ser AD[Código de Departamento]");

            return UsuarioLleno && UsuarioDocente && UsuarioAdministrador;
        }

        public bool ValidarContraseña(BunifuTextBox TextBox, BunifuLabel Label)
        {
            bool ContraseñaLlena = Validar(@"^(?!\s*$).+", TextBox, Label, "El campo no debe estar vacío");
            bool ContraseñaCorrecta = Validar(@"(^$)|(^(?=.*?\d)(?=.*?[A-Z])(?=.*?[a-z]).{8,20}$)", TextBox, Label, "La contraseña debe tener por lo menos una mayúscula y un número");

            return ContraseñaLlena && ContraseñaCorrecta;
        }

        public bool ValidarConfirmarContraseña(BunifuTextBox TextBox1, BunifuLabel Label, BunifuTextBox TextBox2)
        {
            bool ContraseñaLlena = Validar(@"^(?!\s*$).+", TextBox1, Label, "El campo no debe estar vacío");
            bool CompararContraseñas = (TextBox1.Text == TextBox2.Text) || Validar(@"(^$)", TextBox1, Label, "La contraseña no es igual");

            return ContraseñaLlena && CompararContraseñas;
        }

        public bool ValidarCodigoAsignatura(BunifuTextBox TextBox, BunifuLabel Label, string CodDepartamento)
        {
            bool DigitoLleno = Validar(@"^(?!\s*$).+", TextBox, Label, "El campo no debe estar vacío");
            bool DigitoCorrecto = Validar(@"(^$)|(^(" + CodDepartamento + @")\d{3}$)", TextBox, Label, "El código deber ser " + CodDepartamento + "[Número de 3 dígitos]");

            return DigitoLleno && DigitoCorrecto;
        }

        public bool ValidarNumeroLimitado(BunifuTextBox TextBox, BunifuLabel Label, int NroDigitos)
        {
            bool NumeroLleno = Validar(@"^(?!\s*$).+", TextBox, Label, "El campo no debe estar vacío");
            bool NumeroCorrecto = Validar(@"(^$)|(^\d{" + NroDigitos + @"}$)", TextBox, Label, "El campo debe ser de " + NroDigitos + " dígitos");

            return NumeroLleno && NumeroCorrecto;
        }

        public bool ValidarDigitoIntervalo(BunifuTextBox TextBox, BunifuLabel Label, int Min, int Max)
        {
            bool DigitoLleno = Validar(@"^(?!\s*$).+", TextBox, Label, "El campo no debe estar vacío");
            bool DigitoCorrecto = Validar(@"(^$)|(^[" + Min + @"-" + Max + @"]$)", TextBox, Label, "El campo debe estar en el intervalo [" + Min + "-" + Max + "]");

            return DigitoLleno && DigitoCorrecto;
        }
    }
}
