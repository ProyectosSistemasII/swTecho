using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechoCeiva
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            UC_Login Wlog = new UC_Login();
            elementHost1.Child = Wlog;

            Wlog._new = this;            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
