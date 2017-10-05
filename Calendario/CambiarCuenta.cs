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
    public partial class CambiarCuenta : Form
    {
        string[] scope = new string[] { CalendarService.Scope.Calendar };
        public static CalendarService service;
        public string cuenta;

        public CambiarCuenta()
        {
            InitializeComponent();
        }

        private void btnGmail_Click(object sender, EventArgs e)
        {
            cuenta = "G";

            UserCredential credential;
            
            using (var stream =
                    new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
            {
                DirectoryInfo di = new DirectoryInfo(Application.StartupPath);
                foreach (var fi in di.GetFiles())
                {
                    if (fi.FullName.Contains("user"))
                    {
                        fi.Delete();
                        break;
                    }
                }

                GoogleWebAuthorizationBroker.Folder = Application.StartupPath;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scope,
                    "user",
                    CancellationToken.None).Result;
            }

            // Create Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });

            Calendario calen = new Calendario(cuenta);
            this.Hide();
            calen.ShowDialog();
        }

        private void btnOutlook_Click(object sender, EventArgs e)
        {
            cuenta = "O";

            Calendario calen = new Calendario(cuenta);
            this.Hide();
            calen.ShowDialog();
        }
    }
}
