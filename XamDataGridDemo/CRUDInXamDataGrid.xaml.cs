using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XamDataGridDemo
{
    /// <summary>
    /// Interaction logic for CRUDInXamDataGrid.xaml
    /// </summary>
    public partial class CRUDInXamDataGrid : Window
    {
        DataRecord record = null;
        public CRUDInXamDataGrid()
        {
            InitializeComponent();

            xamDataGridCategories.RecordAdding += XamDataGridCategories_RecordAdding;
            xamDataGridCategories.RecordAdded += XamDataGridCategories_RecordAdded;
            xamDataGridCategories.RecordUpdating += XamDataGridCategories_RecordUpdating;
            xamDataGridCategories.RecordUpdated += XamDataGridCategories_RecordUpdated;
            xamDataGridCategories.RecordsDeleting += XamDataGridCategories_RecordsDeleting;
            xamDataGridCategories.RecordsDeleted += XamDataGridCategories_RecordsDeleted;
        }

        private void XamDataGridCategories_RecordAdded(object sender, Infragistics.Windows.DataPresenter.Events.RecordAddedEventArgs e)
        {
            
        }

        private void XamDataGridCategories_RecordAdding(object sender, Infragistics.Windows.DataPresenter.Events.RecordAddingEventArgs e)
        {
            
        }

        private void XamDataGridCategories_RecordUpdating(object sender, Infragistics.Windows.DataPresenter.Events.RecordUpdatingEventArgs e)
        {
            int index = ((Infragistics.Windows.DataPresenter.DataPresenterBase)e.Source).ActiveRecord.Index;
            record = (DataRecord)xamDataGridCategories.Records[index];
        }
        private void XamDataGridCategories_RecordUpdated(object sender, Infragistics.Windows.DataPresenter.Events.RecordUpdatedEventArgs e)
        {
            string categoryID = record.Cells["CategoryID"].Value.ToString();
            string categoryName = record.Cells["CategoryName"].Value.ToString();
            string description = record.Cells["Description"].Value.ToString();

            if (!string.IsNullOrEmpty(categoryID))
            {
                // Update the record
                SqlHelper.UpdateRecord(categoryID, categoryName, description);
            }
            else
            {
                // Add New Record
                SqlHelper.AddRecord(categoryName, description);
                xamDataGridCategories.DataSource = SqlHelper.PopulateDataGridCategories().Tables[0].DefaultView;
            }

        }
        private void XamDataGridCategories_RecordsDeleting(object sender, Infragistics.Windows.DataPresenter.Events.RecordsDeletingEventArgs e)
        {
            int index = ((Infragistics.Windows.DataPresenter.DataPresenterBase)e.Source).ActiveRecord.Index;
            record = (DataRecord)xamDataGridCategories.Records[index];
        }

        private void XamDataGridCategories_RecordsDeleted(object sender, Infragistics.Windows.DataPresenter.Events.RecordsDeletedEventArgs e)
        {
            string value = record.Cells["CategoryID"].Value.ToString();
            SqlHelper.DeleteRecord(value);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            xamDataGridCategories.DataSource = SqlHelper.PopulateDataGridCategories().Tables[0].DefaultView;
        }


    }
}
