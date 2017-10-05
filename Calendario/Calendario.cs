using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;

namespace Calendario
{
    public partial class Calendario : Form
    {
        DataTable TablaConsulta = new DataTable();
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/calendar-dotnet-quickstart.json 
        string[] scope = new string[] { CalendarService.Scope.Calendar };
        CambiarCuenta CC;
        string cuenta;

        public Calendario()
        {
            InitializeComponent();
            ValorInicial();
        }

        public Calendario(string cta)
        {
            InitializeComponent();
            ValorInicial();
            cuenta = cta;
            if (cuenta == "G")
            {
                this.Text = "EVENTOS CALENDARIO GMAIL";

                // Define parameters of request.
                EventsResource.ListRequest request; request = CambiarCuenta.service.Events.List("primary");
                request.TimeMin = DateTime.Now.AddYears(-2);
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 1000;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // List events.
                Events events = request.Execute();
                //Console.WriteLine("Upcoming events:");
                if (events.Items != null && events.Items.Count > 0)
                {
                    int indice = -1;
                    TablaConsulta.Rows.Clear();
                    foreach (var eventItem in events.Items)
                    {
                        DataRow FilaNueva = TablaConsulta.NewRow();
                        //EVENTO DIARIO
                        if (!string.IsNullOrEmpty(eventItem.Start.Date))
                            FilaNueva["fechahoraInicio"] = Convert.ToDateTime(eventItem.Start.Date).ToShortDateString();
                        //EVENTO CON DURACION
                        else
                            FilaNueva["fechahoraInicio"] = Convert.ToDateTime(eventItem.Start.DateTime).ToLocalTime();
                        //EVENTO DIARIO
                        if (!string.IsNullOrEmpty(eventItem.End.Date))
                            FilaNueva["fechahoraFin"] = Convert.ToDateTime(eventItem.End.Date).ToShortDateString();
                        //EVENTO CON DURACION
                        else
                            FilaNueva["fechahoraFin"] = Convert.ToDateTime(eventItem.End.DateTime).ToLocalTime();
                        FilaNueva["titulo"] = eventItem.Summary.ToString();
                        if(eventItem.Description!=null)
                            FilaNueva["descripcion"] = eventItem.Description.ToString();
                        TablaConsulta.Rows.Add(FilaNueva);

                        if (Convert.ToDateTime(eventItem.Start.Date).Year == DateTime.Now.Year && Convert.ToDateTime(eventItem.Start.Date).Month == DateTime.Now.Month && indice < 0)
                            indice = TablaConsulta.Rows.IndexOf(FilaNueva);
                    }
                    dgvEventos.DataSource = TablaConsulta;
                    dgvEventos.CurrentCell = dgvEventos.Rows[indice].Cells[0];
                }
                else
                {
                    MessageBox.Show("No hay eventos");
                }
            }
            else if(cuenta=="O")
            {
                this.Text = "EVENTOS CALENDARIO OUTLOOK";
                                
                try
                {
                    Microsoft.Office.Interop.Outlook.Application oApp = null;
                    Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;
                    Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
                    Microsoft.Office.Interop.Outlook.Items outlookCalendarItems = null;
                    oApp = new Microsoft.Office.Interop.Outlook.Application();
                    mapiNamespace = oApp.GetNamespace("MAPI");
                    CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
                    outlookCalendarItems = CalendarFolder.Items;
                    outlookCalendarItems.IncludeRecurrences = true;
                    outlookCalendarItems.Sort("Start");

                    if (outlookCalendarItems != null && outlookCalendarItems.Count > 0)
                    {
                        int indice = -1;
                        TablaConsulta.Rows.Clear();
                        foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
                        {
                            DataRow FilaNueva = TablaConsulta.NewRow();
                            //EVENTO DIARIO
                            if (item.AllDayEvent)
                            {
                                FilaNueva["fechahoraInicio"] = item.Start.Date.ToShortDateString();
                                FilaNueva["fechahoraFin"] = item.End.Date.ToShortDateString();
                            }
                            else
                            {
                                FilaNueva["fechahoraInicio"] = item.Start;
                                FilaNueva["fechahoraFin"] = item.End;
                            }                                
                            FilaNueva["titulo"] = item.Subject;
                            FilaNueva["descripcion"] = item.Body;
                            TablaConsulta.Rows.Add(FilaNueva);

                            if (item.Start.Date.Year == DateTime.Now.Year && item.Start.Date.Month == DateTime.Now.Month && indice < 0)
                                indice = TablaConsulta.Rows.IndexOf(FilaNueva);
                        }
                        dgvEventos.DataSource = TablaConsulta;
                        dgvEventos.CurrentCell = dgvEventos.Rows[indice].Cells[0];
                    }
                    else
                    {
                        MessageBox.Show("No hay eventos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: "+ex.Message);
                }
            }
        }

        public void ValorInicial()
        {
            //genero la tabla que muestro en la grilla
            if (!TablaConsulta.Columns.Contains("fechahoraInicio"))
                TablaConsulta.Columns.Add("fechahoraInicio", Type.GetType("System.String"));
            if (!TablaConsulta.Columns.Contains("fechahoraFin"))
                TablaConsulta.Columns.Add("fechahoraFin", Type.GetType("System.String"));
            if (!TablaConsulta.Columns.Contains("titulo"))
                TablaConsulta.Columns.Add("titulo", Type.GetType("System.String"));
            if (!TablaConsulta.Columns.Contains("descripcion"))
                TablaConsulta.Columns.Add("descripcion", Type.GetType("System.String"));

            TablaConsulta.Rows.Clear();
            //DataRow FilaNom = TablaConsulta.NewRow();
            //TablaConsulta.Rows.Add(FilaNom);
            dgvEventos.DataSource = TablaConsulta.DefaultView;
            dgvEventos.Columns["fechahoraInicio"].HeaderText = "Inicio";
            dgvEventos.Columns["fechahoraInicio"].ReadOnly = true;
            dgvEventos.Columns["fechahoraInicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEventos.Columns["fechahoraFin"].HeaderText = "Fin";
            dgvEventos.Columns["fechahoraFin"].ReadOnly = true;
            dgvEventos.Columns["fechahoraFin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEventos.Columns["titulo"].HeaderText = "Evento";
            dgvEventos.Columns["titulo"].ReadOnly = true;
            dgvEventos.Columns["titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEventos.Columns["descripcion"].HeaderText = "Descripcion";
            dgvEventos.Columns["descripcion"].ReadOnly = true;
            dgvEventos.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewColumn column in dgvEventos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(cuenta=="G")
            {
                // Define parameters of request.
                EventsResource.ListRequest request; request = CambiarCuenta.service.Events.List("primary");
                request.TimeMin = DateTime.Now.AddYears(-2);
                request.ShowDeleted = false;
                request.SingleEvents = true;
                request.MaxResults = 1000;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                // List events.
                Events events = request.Execute();
                //Console.WriteLine("Upcoming events:");
                if (events.Items != null && events.Items.Count > 0)
                {
                    int indice = -1;
                    TablaConsulta.Rows.Clear();
                    foreach (var eventItem in events.Items)
                    {
                        DataRow FilaNueva = TablaConsulta.NewRow();
                        //EVENTO DIARIO
                        if (!string.IsNullOrEmpty(eventItem.Start.Date))                        
                            FilaNueva["fechahoraInicio"] = Convert.ToDateTime(eventItem.Start.Date).ToShortDateString();   
                        //EVENTO CON DURACION
                        else
                            FilaNueva["fechahoraInicio"] = Convert.ToDateTime(eventItem.Start.DateTime).ToLocalTime(); 
                        //EVENTO DIARIO
                        if (!string.IsNullOrEmpty(eventItem.End.Date))
                            FilaNueva["fechahoraFin"] = Convert.ToDateTime(eventItem.End.Date).ToShortDateString();
                        //EVENTO CON DURACION
                        else
                            FilaNueva["fechahoraFin"] = Convert.ToDateTime(eventItem.End.DateTime).ToLocalTime();
                        FilaNueva["titulo"] = eventItem.Summary.ToString();
                        if(eventItem.Description!=null)
                            FilaNueva["descripcion"] = eventItem.Description.ToString();
                        TablaConsulta.Rows.Add(FilaNueva);

                        if (Convert.ToDateTime(eventItem.Start.Date).Year == DateTime.Now.Year && Convert.ToDateTime(eventItem.Start.Date).Month == DateTime.Now.Month && indice<0)
                            indice = TablaConsulta.Rows.IndexOf(FilaNueva);
                    }
                    dgvEventos.DataSource = TablaConsulta;
                    dgvEventos.CurrentCell = dgvEventos.Rows[indice].Cells[0];
                }
                else
                {
                    MessageBox.Show("No hay eventos");
                }
            }
            else if(cuenta=="O")
            {
                Microsoft.Office.Interop.Outlook.Application oApp = null;
                Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;
                Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
                Microsoft.Office.Interop.Outlook.Items outlookCalendarItems = null;
                try
                {
                    oApp = new Microsoft.Office.Interop.Outlook.Application();
                    mapiNamespace = oApp.GetNamespace("MAPI");
                    CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
                    outlookCalendarItems = CalendarFolder.Items;
                    outlookCalendarItems.IncludeRecurrences = true;
                    outlookCalendarItems.Sort("Start");

                    if (outlookCalendarItems != null && outlookCalendarItems.Count > 0)
                    {
                        int indice=-1;
                        TablaConsulta.Rows.Clear();
                        foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
                        {
                            DataRow FilaNueva = TablaConsulta.NewRow();
                            //EVENTO DIARIO
                            if (item.AllDayEvent)
                            {
                                FilaNueva["fechahoraInicio"] = item.Start.Date.ToShortDateString();
                                FilaNueva["fechahoraFin"] = item.End.Date.ToShortDateString();
                            }
                            else
                            {
                                FilaNueva["fechahoraInicio"] = item.Start;
                                FilaNueva["fechahoraFin"] = item.End;
                            }
                            FilaNueva["titulo"] = item.Subject;
                            FilaNueva["descripcion"] = item.Body;
                            TablaConsulta.Rows.Add(FilaNueva);

                            if (item.Start.Date.Year == DateTime.Now.Year && item.Start.Date.Month == DateTime.Now.Month && indice < 0)
                                indice = TablaConsulta.Rows.IndexOf(FilaNueva);
                        }
                        dgvEventos.DataSource = TablaConsulta;
                        dgvEventos.CurrentCell = dgvEventos.Rows[indice].Cells[0];
                    }
                    else
                    {
                        MessageBox.Show("No hay eventos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ABMEvento nuevo = new ABMEvento(cuenta);
            nuevo.ShowDialog();
            btnConsultar_Click(null, null);
        }

        private void btnCambiarCuenta_Click(object sender, EventArgs e)
        {
            this.Hide();
            CC = new CambiarCuenta();
            CC.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }

        private void Calendario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
