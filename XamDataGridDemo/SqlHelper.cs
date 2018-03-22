using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamDataGridDemo
{
    public static class SqlHelper
    {
        public static DataSet PopulateDataGridOrder()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString()))
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from Orders", con);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                else
                    return null;
            }
        }

        public static DataSet PopulateDataGridCategories()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString()))
            {
                SqlDataAdapter adap = new SqlDataAdapter("select * from Categories", con);
                DataSet ds = new DataSet();
                adap.Fill(ds);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                   
                    return ds;
                }
                else
                    return null;
            }
        }

        public static void AddRecord(string CategoryName, string Description)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName,Description) VALUES('" + CategoryName + "','" + Description + "')", con);
                    int count = cmd.ExecuteNonQuery();

                    if(count>0)
                        System.Windows.MessageBox.Show("Record Added Successfully.");
                    else
                        System.Windows.MessageBox.Show("Can not add the record.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Can not add the record. " + ex.Message);
            }
        }

        public static void UpdateRecord(string categoryID, string CategoryName, string Description)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Categories SET  CategoryName ='" + CategoryName + "', Description='" + Description + "' WHERE categoryID=" + categoryID, con);
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                        System.Windows.MessageBox.Show("Record Updated Successfully.");
                    else
                        System.Windows.MessageBox.Show("Can not update the record.");

                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Can not delete the record, " + ex.Message);
            }
        }

        public static void DeleteRecord(string categoryID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE categoryID=" + categoryID, con);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                        System.Windows.MessageBox.Show("Record Deleted Successfully.");
                    else
                        System.Windows.MessageBox.Show("Can not delete the record.");
                  
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Can not delete record " + ex.Message);
            }
        }

    }
}
