﻿using ControlesPerzonalizados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using System.Net.Sockets;
using System.Globalization;
using System.Net;
using ClosedXML.Excel;
using System.IO;

namespace CapaPresentaciones
{
    public partial class P_PrincipalDocente : Form
    {
        public bool HoraServidor;
        public string CodAsignatura;
        readonly string CodSemestre;

        public P_PrincipalDocente()
        {
            DataTable Semestre = N_Semestre.SemestreActual();
            CodSemestre = Semestre.Rows[0][0].ToString();
            InitializeComponent();
        }

        // Metodo para obtener la fecha y hora de un servidor
        public static DateTime ObtenerFechaHora()
        {
            // Definir un servidor para obtener la fecha y hora
            const string ntpServer = "time.windows.com";
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;
            var addresses = Dns.GetHostEntry(ntpServer).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                // Detener si NTP esta bloqueado
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }
            const byte serverReplyTime = 40;

            // Obtener la parte de segundos
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            // Obtener la fraccion de segundos
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            // Convertir de big-endian a little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);
            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            // Cambiar el tiempo de acuerdo al UTC
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            // Retornar la fecha y hora del servidor
            return networkDateTime.ToLocalTime();
        }

        // Metodo para convertir de big-endian a little-endian
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        private void P_PrincipalDocente_Load(object sender, EventArgs e)
        {
            string[] Dias = { "LU", "MA", "MI", "JU", "VI", "SA" };

            for (int J = 1; J <= 6; J++)
            {
                C_Encabezado EncabezadoDia = new C_Encabezado();
                EncabezadoDia.txtTexto.Name = "Dia0" + J;
                EncabezadoDia.txtTexto.Text = Dias[J - 1];
                pnDias.Controls.Add(EncabezadoDia);
            }

            for (int I = 1; I <= 14; I++)
            {
                C_Encabezado EncabezadoHora = new C_Encabezado();
                EncabezadoHora.txtTexto.Name = "Hora" + I.ToString("D2");
                EncabezadoHora.txtTexto.Text = (I + 6).ToString("D2") + ":00 - " + (I + 7).ToString("D2") + ":00";
                pnHoras.Controls.Add(EncabezadoHora);

                for (int J = 1; J <= 6; J++)
                {
                    C_Evento EventoPersonalizado = new C_Evento();
                    EventoPersonalizado.btnEvento.Name = "Evento" + I.ToString("D2") + "_" + J.ToString("D2");
                    EventoPersonalizado.btnEvento.Text = "";
                    pnHorario.Controls.Add(EventoPersonalizado);
                }
            }

            DataTable HorarioDocente = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, E_InicioSesion.Usuario);

            foreach (DataRow FilaHorario in HorarioDocente.Rows)
            {
                string Asignatura = FilaHorario["CodAsignatura"].ToString();
                string Nombre = FilaHorario["NombreAsignatura"].ToString();
                string Tipo = FilaHorario["Tipo"].ToString();
                string TipoCompleto = "";
                string Aula = FilaHorario["Aula"].ToString();
                string Modalidad = FilaHorario["Modalidad"].ToString();
                string Dia = FilaHorario["Dia"].ToString(); 
                int Inicio = Convert.ToInt32(FilaHorario["HoraInicio"].ToString());
                int Fin = Convert.ToInt32(FilaHorario["HoraFin"].ToString());
                string DiaAsignatura = "0" + (1 + Array.IndexOf(Dias, Dia));
                List<string> HorasAsignatura = new List<string>();

                for (int I = Inicio; I < Fin; I++)
                {
                    HorasAsignatura.Add((I - 6).ToString("D2"));
                }

                foreach (C_Evento EventoPersonalizado in pnHorario.Controls)
                {
                    if (EventoPersonalizado.btnEvento.Name.Substring(9, 2) == DiaAsignatura)
                    {
                        if (HorasAsignatura.Count != 0)
                        {
                            if (EventoPersonalizado.btnEvento.Name.Substring(6, 2) == HorasAsignatura[0])
                            {
                                EventoPersonalizado.btnEvento.OnIdleState.BorderColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.OnIdleState.FillColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.onHoverState.BorderColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.onHoverState.FillColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.OnPressedState.BorderColor = Color.FromArgb(232, 158, 31);
                                EventoPersonalizado.btnEvento.OnPressedState.FillColor = Color.FromArgb(232, 158, 31);

                                EventoPersonalizado.btnEvento.Text = Asignatura;
                                if (Tipo.Equals("T"))
                                    TipoCompleto = "TEORÍA";
                                else
                                    TipoCompleto = "PRÁCTICA";
                                EventoPersonalizado.ttEvento.SetToolTip(EventoPersonalizado.btnEvento, "<b>ASIGNATURA:</b> " + Nombre + "<br/><b>TIPO:</b> " + TipoCompleto + "<br/><b>AULA:</b> " + Aula + "<br/><b>MODALIDAD:</b> " + Modalidad);
                                HorasAsignatura.RemoveAt(0);
                            }
                        }
                    }
                }
            }

            HoraFecha.Start();
        }

        private void HoraFecha_Tick(object sender, EventArgs e)
        {
            DataTable HorarioDocente = N_HorarioAsignatura.HorarioSemanalDocente(CodSemestre, E_InicioSesion.Usuario);

            DateTime Prueba;
            if (HoraServidor)
                Prueba = ObtenerFechaHora();
            else
                Prueba = DateTime.Now;

            string Dia = Prueba.ToString("dddd", new CultureInfo("es-ES")).ToUpper().Substring(0, 2);
            string Hora = Prueba.ToString("HH:mm:ss");

            //lblAsignatura.Text = Hora;

            foreach (DataRow FilaHorario in HorarioDocente.Rows)
            {
                if (FilaHorario["Dia"].Equals(Dia))
                {
                    TimeSpan HoraIntervalo = TimeSpan.Parse(Hora);
                    TimeSpan HoraInicio = TimeSpan.Parse(FilaHorario["HoraInicio"].ToString() + ":00:00", CultureInfo.InvariantCulture);
                    TimeSpan HoraFin = TimeSpan.Parse(FilaHorario["HoraFin"].ToString() + ":00:00", CultureInfo.InvariantCulture);

                    if (HoraIntervalo >= HoraInicio && HoraIntervalo <= HoraFin)
                    {
                        CodAsignatura = FilaHorario["CodAsignatura"].ToString();
                        txtAsignatura.Text = FilaHorario["NombreAsignatura"].ToString();
                        lnAsignatura.Width = txtAsignatura.Width;
                        break;
                    }
                    else
                    {
                        txtAsignatura.Text = "NINGUNA";
                        lnAsignatura.Width = txtAsignatura.Width;
                    }
                }
                else
                {
                    txtAsignatura.Text = "NINGUNA";
                    lnAsignatura.Width = txtAsignatura.Width;
                }
            }
        }

        private void btnMostrarPlanSesiones_Click(object sender, EventArgs e)
        {
            if (txtAsignatura.Text != "NINGUNA")
            {
                DataTable PlanSesiones = N_Catalogo.RecuperarPlanDeSesionAsignatura(CodSemestre, CodAsignatura, E_InicioSesion.Usuario);

                if (PlanSesiones.Rows.Count >= 1)
                {
                    DataTable Resultados = N_AsistenciaDocentePorAsignatura.AvanceAsignatura(CodSemestre, E_InicioSesion.Usuario, CodAsignatura);

                    string Carpeta = AppDomain.CurrentDomain.BaseDirectory + "/temp/";
                    string Ruta = Carpeta + "temp.xlsx";
                    if (!Directory.Exists(Carpeta))
                    {
                        Directory.CreateDirectory(Carpeta);
                    }

                    if (File.Exists(Ruta))
                    {
                        File.Delete(Ruta);
                    }

                    DataRow Fila = PlanSesiones.Rows[0];
                    byte[] Archivo = Fila["PlanSesiones"] as byte[];
                    int NroCreditos = int.Parse(Fila["Creditos"].ToString());
                    File.WriteAllBytes(Ruta, Archivo);
                    XLWorkbook Libro = new XLWorkbook(Ruta);

                    P_TablaSesiones Sesiones = new P_TablaSesiones(Resultados, Libro, CodAsignatura, NroCreditos);
                    Sesiones.Show();
                }
                else
                {
                    Ayudas.A_Dialogo.DialogoError("No hay Plan de Sesiones de dicha asignatura");
                }
            }
            else
            {
                Ayudas.A_Dialogo.DialogoError("No tiene una asignatura en curso");
            }
        }
    }
}
