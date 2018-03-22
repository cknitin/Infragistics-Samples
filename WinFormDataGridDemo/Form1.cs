using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDataGridDemo
{
    public partial class UltraGridDemoForm : Form
    {
        public UltraGridDemoForm()
        {
            InitializeComponent();
        }

        private void UltraGridDemoForm_Load(object sender, EventArgs e)
        {
            ultraGridControl.DataSource = SqlHelper.PopulateDataGridOrder().Tables[0].DefaultView;
        }
    }
}
