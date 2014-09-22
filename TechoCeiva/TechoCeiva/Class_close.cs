using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechoCeiva
{
    public class Class_close
    {
		frmLogin WinLog;
		
		public void _windowLogin(frmLogin Log)
		{
			WinLog = Log;
		}
		
		public void _closeLogin(Form _log)
		{
            frmMenu _menu = new frmMenu();
            _menu.Show();
            _menu._nLog = (frmLogin)_log;
            _log.Hide();
		}
    }
}
