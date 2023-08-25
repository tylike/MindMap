using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WpfProject.App;

namespace WinformsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitElementHost();
        }

        private void InitElementHost()
        {
            var wpfView = new AppView();
            var wpfViewModel = new AppViewModel();
            wpfView.DataContext = wpfViewModel;
            var elementHost = new System.Windows.Forms.Integration.ElementHost
            {
                Child = wpfView,
                Dock = DockStyle.Fill
            };
            Controls.Add(elementHost);
        }

    }
}
