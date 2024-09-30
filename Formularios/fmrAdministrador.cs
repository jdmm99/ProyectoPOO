using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Formularios
{
    public partial class fmrAdministrador : Form
    {
        public fmrAdministrador()
        {
            InitializeComponent();
        }

        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            lblHoras.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private Form activeForm = null;

        private void AbrirenPanel(Form fmrHijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = fmrHijo;
            fmrHijo.TopLevel = false;
            fmrHijo.FormBorderStyle = FormBorderStyle.None;
            fmrHijo.Dock = DockStyle.Fill;
            pnlCentral.Controls.Add(fmrHijo);
            pnlCentral.Tag = fmrHijo;
            fmrHijo.BringToFront();
            fmrHijo.BringToFront();
            fmrHijo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrInformacion());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrAgendarCita());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            fmrCerrarSesion close = new fmrCerrarSesion();
            close.ShowDialog();
            fmrInicio Ini = new fmrInicio();
            Ini.Show();
        }
    }
}
