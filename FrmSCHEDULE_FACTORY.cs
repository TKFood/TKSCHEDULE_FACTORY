using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKITDLL;

namespace TKSCHEDULE_FACTORY
{
    public partial class FrmSCHEDULE_FACTORY : Form
    {
        int TIMEOUT_LIMITS = 240;
        public FrmSCHEDULE_FACTORY()
        {
            InitializeComponent();
        }

        private void FrmSCHEDULE_FACTORY_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000 * 60; // 1 分鐘
            timer1.Start();
        }


        #region timer_Tick
        /// <summary>
        /// 每分鐘檢查1次，但每天指定時間執行1次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }

        #endregion

        #region FUNCTION
        public void ADD_TK_SFTTEST_MOCTA_MOCTB(string SDATES)
        {
            try
            {
                var tkId = new Class1();
                var sqlsb = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
                sqlsb.Password = tkId.Decryption(sqlsb.Password);
                sqlsb.UserID = tkId.Decryption(sqlsb.UserID);

                using (var connection = new SqlConnection(sqlsb.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = new SqlCommand(
                               "DELETE [TK_SFTTEST].[dbo].[MOCTA] WHERE TA002 LIKE '%'+@SDATES+'%';" +
                               "DELETE [TK_SFTTEST].[dbo].[MOCTB] WHERE TB002 LIKE '%'+@SDATES+'%';",
                               connection,
                               transaction))
                        {
                            command.Parameters.AddWithValue("@SDATES", SDATES);                       
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ADD_TK_SFTTEST_MOCTA_MOCTB: {ex.Message}");
            }
        }


        #endregion

            #region BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
            string SDATES = dateTimePicker1.Value.ToString("yyyyMMdd");
            ADD_TK_SFTTEST_MOCTA_MOCTB(SDATES);
        }
        #endregion
    }
}
