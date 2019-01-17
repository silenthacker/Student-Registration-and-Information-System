using System;
using System.Data;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Application
{
    public partial class AccountPermissionsForm : Form
    {
        public AccountPermissionsForm()
        {
            InitializeComponent();
        }

        Variables variables;
        OpacityForm opacityform;
        Cryptography cryptography;
        SQLConnectionConfig sqlconnectionconfig;

        DarkerOpacityForm darkeropacityform;
        NotificationWindow notificationwindow;

        SqlCommand sqlcommand;
        SqlConnection sqlconnection;
        SqlDataAdapter sqldataadapter;
        
        private void AccountPermissionsForm_Load(object sender, EventArgs e)
        {
            //EXCEPTION 1
            try
            {
                variables = new Variables();
                opacityform = new OpacityForm();
                cryptography = new Cryptography();
                sqlconnectionconfig = new SQLConnectionConfig();

                RegistryKey registrykey = Registry.CurrentUser.OpenSubKey(@variables.pathname);
                string tempdata = registrykey.GetValue("SQLServerConnectionString").ToString();

                //USER SQLSERVER CONNECTION SETTINGS
                sqlconnectionconfig.SqlConnectionString = cryptography.Decrypt(tempdata);
                sqlconnection = new SqlConnection(sqlconnectionconfig.SqlConnectionString);
                sqlconnection.Open();

                //INNER EXCEPTION 1
                try
                {
                    //TODO:
                    string Query1 = "SELECT * FROM [Tbl.Permissions]";
                    sqldataadapter = new SqlDataAdapter(Query1, sqlconnection);
                    DataTable datatable = new DataTable();

                    sqldataadapter.Fill(datatable);
                    ListofPermissionsGridview.AutoGenerateColumns = false;
                    ListofPermissionsGridview.DataSource = datatable;
                }

                catch (Exception exception)
                {
                    opacityform.Show();
                    MessageBox.Show(exception.ToString(), "@Account Permission Form Inner Exception 1",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                    opacityform.Hide();
                }
            }

            catch (Exception exception)
            {
                opacityform.Show();
                MessageBox.Show(exception.ToString(), "@Account Permission Form Exception 1",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                opacityform.Hide();
            }
        }

        private void ListofPermissionsGridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow VirtualGridRow = ListofPermissionsGridview.CurrentRow;
                DataGridViewCell VirtualGridCell = ListofPermissionsGridview.CurrentCell;

                try
                {
                    if (ListofPermissionsGridview.CurrentRow != null)
                    {
                        if (isNumber(VirtualGridCell.Value.ToString().Trim()) == true)
                        {
                            darkeropacityform = new DarkerOpacityForm();
                            notificationwindow = new NotificationWindow();

                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.error;
                            notificationwindow.MessageText = "NUMERIC CHARACTERS ARE NOT ALLOWED !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();

                            //RESTORE SECURITY STATE
                            AccountPermissionsForm_Load(sender, e);
                        }

                        else if (!VirtualGridCell.Value.ToString().Trim().ToUpper().Equals("ALLOW") &&
                            !VirtualGridCell.Value.ToString().Trim().ToUpper().Equals("DENY"))
                        {
                            darkeropacityform = new DarkerOpacityForm();
                            notificationwindow = new NotificationWindow();

                            notificationwindow.CaptionText = "MESSAGE CONTENT";
                            notificationwindow.MsgImage.Image = Properties.Resources.warning;
                            notificationwindow.MessageText = "YOU CAN ONLY ENTER THESE VALUES\n\n1. DENY\n2. ALLOW";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();

                            //RESTORE SECURITY STATE
                            AccountPermissionsForm_Load(sender, e);
                        }
                        
                        else
                        {
                            string UpdateQuery = "UPDATE [Tbl.Permissions] SET [PERMISSION ID] = @pmsid, [USER ID] = @uid," + 
                                "[TEACHER ID] = @tid, [PMS-01] = @pms01, [PMS-02] = @pms02, [PMS-03] = @pms03 WHERE [USER ID] = '" + VirtualGridRow.Cells["ColumnUserID"].Value.ToString() + "'";
                            sqlcommand = new SqlCommand(UpdateQuery, sqlconnection);
                            sqlcommand.Parameters.AddWithValue("@pmsid", VirtualGridRow.Cells["ColumnPermissionID"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnPermissionID"].Value.ToString().ToUpper().Trim());
                            sqlcommand.Parameters.AddWithValue("@uid", VirtualGridRow.Cells["ColumnUserID"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnUserID"].Value.ToString().ToUpper().Trim());
                            sqlcommand.Parameters.AddWithValue("@tid", VirtualGridRow.Cells["ColumnTeacherID"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnTeacherID"].Value.ToString().ToUpper().Trim());

                            sqlcommand.Parameters.AddWithValue("@pms01", VirtualGridRow.Cells["ColumnPMS01"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnPMS01"].Value.ToString().ToUpper().Trim());
                            sqlcommand.Parameters.AddWithValue("@pms02", VirtualGridRow.Cells["ColumnPMS03"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnPMS02"].Value.ToString().ToUpper().Trim());
                            sqlcommand.Parameters.AddWithValue("@pms03", VirtualGridRow.Cells["ColumnPMS03"].Value == DBNull.Value ? "" : VirtualGridRow.Cells["ColumnPMS03"].Value.ToString().ToUpper().Trim());
                            sqlcommand.ExecuteNonQuery();

                            //SYNC NEW RECORDS
                            AccountPermissionsForm_Load(sender, e);

                            darkeropacityform = new DarkerOpacityForm();
                            notificationwindow = new NotificationWindow();

                            notificationwindow.CaptionText = "SUCCESSFULLY UPDATED";
                            notificationwindow.MsgImage.Image = Properties.Resources.check;
                            notificationwindow.MessageText = "ONE ACCOUNT PERMISSION CHANGED !";

                            darkeropacityform.Show();
                            notificationwindow.ShowDialog();
                            darkeropacityform.Hide();

                        }
                    }
                }

                catch (Exception)
                {
                    //DO NOTHING BITCH !
                }
            }

            catch (Exception)
            {
                //DO NOTHING BITCH !
            }
        }

        private bool isNumber(string data)
        {
            try
            {
                int.Parse(data);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }

        private void AccountPermissionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
