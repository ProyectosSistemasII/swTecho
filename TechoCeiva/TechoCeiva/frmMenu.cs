using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Capa_Logica_Negocio;

namespace TechoCeiva
{
    public partial class frmMenu : Form
    {
        public frmLogin _nLog = new frmLogin();
        public UsuarioLN currentUser { get; set; }

        public frmMenu()
        {
            InitializeComponent();
            UC_Menu menuControl = new UC_Menu();
            menuControl.setUser(this.currentUser);
            elementHost1.Dock = DockStyle.Fill;
            elementHost1.Controls.Clear();
            elementHost1.Child = menuControl;
        }

        public frmMenu(UsuarioLN user)
        {
            InitializeComponent();
            this.currentUser = user;
            elementHost1.Dock = DockStyle.Fill;
            elementHost1.Controls.Clear();
            elementHost1.Child = new UC_Menu(user);
        }

        public void setUser(UsuarioLN user)
        {
            this.currentUser = user;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _nLog.Close();
        }
    }
}
