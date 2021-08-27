using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CurrencyConverter_StaticData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter ada = new SqlDataAdapter();


        private int currencyId = 0;
        private double fromAmount = 0;
        private double toAmount = 0;
        public MainWindow()
        {
            InitializeComponent();
            clearControls();
            bindCurrency();
            getData();
        }

        public void myCon()
        {
            String conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(conn);
            con.Open();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            clearControls();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            double convertedValue;

            if(txtCurrency.Text == null || txtCurrency.Text.Trim()== "")
            {
                MessageBox.Show("Please enter a currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCurrency.Focus();
                return;
            }
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
               
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbFromCurrency.Focus();
                return;
            }
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbToCurrency.Focus();
                return;
            }

            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                convertedValue = double.Parse(txtCurrency.Text);
                lblCurrency.Content = cmbToCurrency.Text + " " + convertedValue.ToString("N3");
            }
            else
            {
                convertedValue = (double.Parse(cmbFromCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbToCurrency.SelectedValue.ToString());
                lblCurrency.Content = cmbToCurrency.Text + " " + convertedValue.ToString("N3");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
           
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    private void bindCurrency()
        {
            myCon();
            DataTable dtCurrency = new DataTable();
            cmd = new SqlCommand("SELECT Id,CurrencyName FROM Currency_Master", con);
            cmd.CommandType = CommandType.Text;

            ada = new SqlDataAdapter(cmd);
            ada.Fill(dtCurrency);

            DataRow newRow = dtCurrency.NewRow();
            newRow["Id"] = 0;
            newRow["CurrencyName"] = "--SELECT--";

            dtCurrency.Rows.InsertAt(newRow, 0);

            if(dtCurrency!= null && dtCurrency.Rows.Count > 0)
            {
                cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
                cmbFromCurrency.DisplayMemberPath = "CurrencyName";
                cmbFromCurrency.SelectedValuePath = "Amount";
                cmbFromCurrency.SelectedIndex = 0;

                cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
                cmbToCurrency.DisplayMemberPath = "CurrencyName";
                cmbToCurrency.SelectedValuePath = "Amount";
                cmbToCurrency.SelectedIndex = 0;

            }
            con.Close();   
        }

        private void clearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = "";
            txtCurrency.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check the validation
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter amount", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtAmount.Focus();
                    return;
                }
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter currency name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCurrencyName.Focus();
                    return;
                }
                else
                {
                    if(currencyId > 0)
                    {
                        //Show the confirmation message
                        if (MessageBox.Show("Are you sure you want to update ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            myCon();
                            DataTable dt = new DataTable();

                            //Update Query Record update using Id
                            cmd = new SqlCommand("UPDATE Currency_Master SET Amount = @Amount, CurrencyName = @CurrencyName WHERE Id = @Id", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Id", currencyId);
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    // Code to Save
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to save ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            myCon();
                            //Insert query to Save data in the table
                            cmd = new SqlCommand("INSERT INTO Currency_Master(Amount, CurrencyName) VALUES(@Amount, @CurrencyName)", con);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Data saved successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    clearMaster();
                }
       
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void clearMaster()
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                btnSave.Content = "Save";
                getData();
                currencyId = 0;
                bindCurrency();
                txtAmount.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void getData()
        {
            myCon();
            DataTable dtCurrency = new DataTable();
            cmd = new SqlCommand("SELECT * FROM Currency_Master", con);
            cmd.CommandType = CommandType.Text;
            ada = new SqlDataAdapter(cmd);
            ada.Fill(dtCurrency);

            if (dtCurrency != null && dtCurrency.Rows.Count > 0)
                dgvCurrency.ItemsSource = dtCurrency.DefaultView;
            else
                dgvCurrency.ItemsSource = null;
            con.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clearMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                //Create object for DataGrid
                DataGrid grd = (DataGrid)sender;

                //Create an object for DataRowView
                DataRowView row_selected = grd.CurrentItem as DataRowView;

                //If row_selected is not null
                if (row_selected != null)
                {
                    //dgvCurrency items count greater than zero
                    if (dgvCurrency.Items.Count > 0)
                    {
                        if (grd.SelectedCells.Count > 0)
                        {
                            //Get selected row id column value and set it to the CurrencyId variable
                            currencyId = Int32.Parse(row_selected["Id"].ToString());

                            //DisplayIndex is equal to zero in the Edited cell
                            if (grd.SelectedCells[0].Column.DisplayIndex == 0)
                            {
                                //Get selected row amount column value and set to amount textbox
                                txtAmount.Text = row_selected["Amount"].ToString();

                                //Get selected row CurrencyName column value and set it to CurrencyName textbox
                                txtCurrencyName.Text = row_selected["CurrencyName"].ToString();
                                btnSave.Content = "Update";     //Change save button text Save to Update
                            }

                            //DisplayIndex is equal to one in the deleted cell
                            if (grd.SelectedCells[0].Column.DisplayIndex == 1)
                            {
                                //Show confirmation dialog box
                                if (MessageBox.Show("Are you sure you want to delete ?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                                {
                                    myCon();
                                    DataTable dt = new DataTable();

                                    //Execute delete query to delete record from table using Id
                                    cmd = new SqlCommand("DELETE FROM Currency_Master WHERE Id = @Id", con);
                                    cmd.CommandType = CommandType.Text;

                                    //CurrencyId set in @Id parameter and send it in delete statement
                                    cmd.Parameters.AddWithValue("@Id", currencyId);
                                    cmd.ExecuteNonQuery();
                                    con.Close();

                                    MessageBox.Show("Data deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    clearMaster();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        //From currency Combobox selection changed event to get the amount of currency on selection change of currency name
        private void cmbFromCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //If cmbFromCurrency selected value is not equal to null and not equal to zero
                if (cmbFromCurrency.SelectedValue != null && int.Parse(cmbFromCurrency.SelectedValue.ToString()) != 0 && cmbFromCurrency.SelectedIndex != 0)
                {
                    //cmbFromCurrency selectedvalue set in CurrencyFromId variable
                    int CurrencyFromId = int.Parse(cmbFromCurrency.SelectedValue.ToString());

                    myCon();
                    DataTable dt = new DataTable();

                    //Select query to get amount from database using id
                    cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyFromId", con);
                    cmd.CommandType = CommandType.Text;

                    if (CurrencyFromId != 0)
                        //CurrencyFromId set in @CurrencyFromId parameter and send parameter in our query
                        cmd.Parameters.AddWithValue("@CurrencyFromId", CurrencyFromId);

                    ada = new SqlDataAdapter(cmd);

                    //Set the data that the query returns in the data table
                    ada.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                        //Get amount column value from datatable and set amount value in From amount variable which is declared globally
                        fromAmount = double.Parse(dt.Rows[0]["Amount"].ToString());

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        //To currency Combobox selection changed event to get the amount of currency on selection change of currency name
        private void cmbToCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //If cmbToCurrency selectedvalue is not equal to null and not equal to zero
                if (cmbToCurrency.SelectedValue != null && int.Parse(cmbToCurrency.SelectedValue.ToString()) != 0 && cmbToCurrency.SelectedIndex != 0)
                {
                    //cmbToCurrency selectedvalue is set to CurrencyToId variable
                    int CurrencyToId = int.Parse(cmbToCurrency.SelectedValue.ToString());

                    myCon();

                    DataTable dt = new DataTable();
                    //Select query for get Amount from database using id
                    cmd = new SqlCommand("SELECT Amount FROM Currency_Master WHERE Id = @CurrencyToId", con);
                    cmd.CommandType = CommandType.Text;

                    if (CurrencyToId != 0)
                        //CurrencyToId set in @CurrencyToId parameter and send parameter in our query
                        cmd.Parameters.AddWithValue("@CurrencyToId", CurrencyToId);

                    ada = new SqlDataAdapter(cmd);

                    //Set the data that the query returns in the data table
                    ada.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                        //Get amount column value from datatable and set amount value in ToAmount variable which is declared globally
                        toAmount = double.Parse(dt.Rows[0]["Amount"].ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbFromCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //If the user press Tab or Enter key then cmbFromCurrency_SelectionChanged event fire
            if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
            {
                cmbFromCurrency_SelectionChanged(sender, null);
            }
        }

        private void cmbToCurrency_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //If the user press Tab or Enter key then cmbToCurrency_SelectionChanged event fire
            if (e.Key == Key.Tab || e.SystemKey == Key.Enter)
            {
                cmbToCurrency_SelectionChanged(sender, null);
            }
        }
    }
}
