using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Infragistics.Documents.Excel;
using Infragistics.Windows;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.ExcelExporter;

namespace XamDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xamDataGridControl.DataSource = SqlHelper.PopulateDataGridOrder().Tables[0].DefaultView;
        }
      
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = System.IO.Path.GetTempPath() + "TempFile.xlsx";
                DataPresenterExcelExporter excelExporter = new DataPresenterExcelExporter();
                excelExporter.ExportAsync(this.xamDataGridControl, fileName, WorkbookFormat.Excel2007);
                System.Windows.MessageBox.Show("File save successfully. \n"+fileName);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnCRUD_Click(object sender, RoutedEventArgs e)
        {
            CRUDInXamDataGrid objCRUDWindow = new CRUDInXamDataGrid();
            objCRUDWindow.Show();
        }
    }
}
