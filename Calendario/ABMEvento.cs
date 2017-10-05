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
    public partial class ABMEvento : Form
    {
        string cuenta;

        public ABMEvento()
        {
            InitializeComponent();
        }

        public ABMEvento(string cta)
        {
            InitializeComponent();
            cuenta = cta;

            if (cta == "O")
                chkRepetir.Enabled = false;
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(mTitulo.Text))
            {
                MessageBox.Show("¡Falta título/descripción del evento!");
                return false;
            }

            if (mFechaInicio.Value.Date.CompareTo(mFechaFin.Value.Date) > 0)
            {
                MessageBox.Show("¡La Fecha Inicio no puede ser mayor a la Fecha Fin!");
                return false;
            }

            if (chkRepetir.Checked)
            {
                if (string.IsNullOrEmpty(cmbRepetir.Text))
                {
                    MessageBox.Show("¡Falta seleccionar opción de frecuencia de repitición!");
                    return false;
                }
            }            

            return true;
        }

        private void chkHora_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHora.Checked)
                grHora.Enabled = true;
            else
                grHora.Enabled = false;
        }

        private void chkRepetir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRepetir.Checked)
            {
                cmbRepetir.Enabled = true;
            }                
            else
            {
                cmbRepetir.Enabled = false;
                cmbRepetir.Text = "";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                if (cuenta == "G")
                {
                    try
                    {
                        Event nuevoEvento;

                        string regla = "";
                        if (chkRepetir.Checked)
                        {
                            if (cmbRepetir.Text == "Todos los días")
                                regla = "RRULE:FREQ=DAILY";
                            else if (cmbRepetir.Text == "Todos las semanas")
                                regla = "RRULE:FREQ=WEEKLY";
                            else if (cmbRepetir.Text == "Todos los meses")
                                regla = "RRULE:FREQ=MONTHLY";
                            else if (cmbRepetir.Text == "Todos los años")
                                regla = "RRULE:FREQ=YEARLY";
                        }

                        if (string.IsNullOrEmpty(regla))
                        {
                            if (!chkHora.Checked)
                            {
                                nuevoEvento = new Event
                                {
                                    Summary = mTitulo.Text,
                                    Start = new EventDateTime()
                                    {
                                        Date = mFechaInicio.Value.Date.Year + "-" + mFechaInicio.Value.Date.Month + "-" + mFechaInicio.Value.Date.Day
                                        //DateTime = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, 0, 0, 0),
                                        //TimeZone = "America/Argentina/Buenos_Aires"
                                    },
                                    End = new EventDateTime()
                                    {
                                        Date = mFechaFin.Value.Date.Year + "-" + mFechaFin.Value.Date.Month + "-" + mFechaFin.Value.Date.Day,
                                        //DateTime = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, 0, 0, 0),
                                        //TimeZone = "America/Argentina/Buenos_Aires"
                                    },
                                    Description = mNotas.Text
                                };
                            }
                            else
                            {
                                nuevoEvento = new Event
                                {
                                    Summary = mTitulo.Text,
                                    Start = new EventDateTime()
                                    {
                                        DateTime = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, mHoraInicio.Value.TimeOfDay.Hours, mHoraInicio.Value.TimeOfDay.Minutes, mHoraInicio.Value.TimeOfDay.Seconds)
                                    },
                                    End = new EventDateTime()
                                    {
                                        DateTime = new DateTime(mFechaFin.Value.Date.Year, mFechaFin.Value.Date.Month, mFechaFin.Value.Date.Day, mHoraFin.Value.TimeOfDay.Hours, mHoraFin.Value.TimeOfDay.Minutes, mHoraFin.Value.TimeOfDay.Seconds)
                                    },
                                    Description = mNotas.Text
                                };
                            }
                        }
                        else
                        {
                            if (!chkHora.Checked)
                            {
                                nuevoEvento = new Event
                                {
                                    Summary = mTitulo.Text,
                                    Start = new EventDateTime()
                                    {
                                        Date = mFechaInicio.Value.Date.Year + "-" + mFechaInicio.Value.Date.Month + "-" + mFechaInicio.Value.Date.Day
                                        //DateTime = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, 0, 0, 0),
                                        //TimeZone = "America/Argentina/Buenos_Aires"
                                    },
                                    End = new EventDateTime()
                                    {
                                        Date = mFechaFin.Value.Date.Year + "-" + mFechaFin.Value.Date.Month + "-" + mFechaFin.Value.Date.Day,
                                        //DateTime = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, 0, 0, 0),
                                        //TimeZone = "America/Argentina/Buenos_Aires"
                                    },
                                    Recurrence = new String[] { regla },
                                    Description = mNotas.Text
                                };
                            }
                            else
                            {
                                nuevoEvento = new Event
                                {
                                    Summary = mTitulo.Text,
                                    Start = new EventDateTime()
                                    {
                                        DateTime = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, mHoraInicio.Value.TimeOfDay.Hours, mHoraInicio.Value.TimeOfDay.Minutes, mHoraInicio.Value.TimeOfDay.Seconds)
                                    },
                                    End = new EventDateTime()
                                    {
                                        DateTime = new DateTime(mFechaFin.Value.Date.Year, mFechaFin.Value.Date.Month, mFechaFin.Value.Date.Day, mHoraFin.Value.TimeOfDay.Hours, mHoraFin.Value.TimeOfDay.Minutes, mHoraFin.Value.TimeOfDay.Seconds)
                                    },
                                    Recurrence = new String[] { regla },
                                    Description = mNotas.Text
                                };
                            }
                        }


                        Event recurringEvent = CambiarCuenta.service.Events.Insert(nuevoEvento, "primary").Execute();

                        MessageBox.Show("EVENTO CREADO");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("EVENTO NO CREADO");
                    }
                }
                else if (cuenta == "O")
                {
                    try
                    {
                        Microsoft.Office.Interop.Outlook.Application oApp = null;
                        Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;
                        Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
                        oApp = new Microsoft.Office.Interop.Outlook.Application();
                        mapiNamespace = oApp.GetNamespace("MAPI");
                        CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);

                        Microsoft.Office.Interop.Outlook.AppointmentItem nuevo = oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem)
                            as Microsoft.Office.Interop.Outlook.AppointmentItem;
                        nuevo.Subject = mTitulo.Text;
                        nuevo.Body = mNotas.Text;

                        if (!chkHora.Checked)
                        {
                            nuevo.AllDayEvent = true;
                            nuevo.Start = Convert.ToDateTime(mFechaInicio.Value).Date;
                            nuevo.End = Convert.ToDateTime(mFechaFin.Value).Date;
                        }
                        else if(chkHora.Checked)
                        {
                            nuevo.AllDayEvent = false;
                            nuevo.Start = new DateTime(mFechaInicio.Value.Date.Year, mFechaInicio.Value.Date.Month, mFechaInicio.Value.Date.Day, mHoraInicio.Value.TimeOfDay.Hours, mHoraInicio.Value.TimeOfDay.Minutes, mHoraInicio.Value.TimeOfDay.Seconds);
                            nuevo.End = new DateTime(mFechaFin.Value.Date.Year, mFechaFin.Value.Date.Month, mFechaFin.Value.Date.Day, mHoraFin.Value.TimeOfDay.Hours, mHoraFin.Value.TimeOfDay.Minutes, mHoraFin.Value.TimeOfDay.Seconds);
                        }

                        nuevo.Save();

                        MessageBox.Show("EVENTO CREADO");
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("EVENTO NO CREADO");
                    }
                    
                }
            }
        }
    }
}
