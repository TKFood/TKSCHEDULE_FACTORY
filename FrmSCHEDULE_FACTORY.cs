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
                        var sqlBuilder = new StringBuilder();
                        sqlBuilder.AppendFormat(@"
                            DELETE [TK_SFTTEST].[dbo].[MOCTA] WHERE TA002 LIKE '%' + @SDATES + '%';
                            DELETE [TK_SFTTEST].[dbo].[MOCTB] WHERE TB002 LIKE '%' + @SDATES + '%';
INSERT INTO [TK_SFTTEST].[dbo].[MOCTA]
(
[COMPANY],[CREATOR],[USR_GROUP],[CREATE_DATE],[MODIFIER],[MODI_DATE],[FLAG],[CREATE_TIME],[MODI_TIME],[TRANS_TYPE],[TRANS_NAME],[sync_date],[sync_time],[sync_mark],[sync_count],[DataUser],[DataGroup]
,[TA001],[TA002],[TA003],[TA004],[TA005],[TA006],[TA007],[TA008],[TA009],[TA010]
,[TA011],[TA012],[TA013],[TA014],[TA015],[TA016],[TA017],[TA018],[TA019],[TA020]
,[TA021],[TA022],[TA023],[TA024],[TA025],[TA026],[TA027],[TA028],[TA029],[TA030]
,[TA031],[TA032],[TA033],[TA034],[TA035],[TA036],[TA037],[TA038],[TA039],[TA040]
,[TA041],[TA042],[TA043],[TA044],[TA045],[TA046],[TA047],[TA048],[TA049],[TA050]
,[TA051],[TA052],[TA053],[TA054],[TA055],[TA056],[TA057],[TA058],[TA059],[TA060]
,[TA061],[TA062],[TA063],[TA064],[TA065],[TA066],[TA067],[TA068],[TA069],[TA070]
,[TA071],[TA072],[TA073],[TA074],[TA075],[TA076],[TA077],[TA078],[TA079],[TA080]
,[TA081],[TA082],[TA083],[TA084],[TA085],[TA086],[TA087],[TA088],[TA089],[TA090]
,[TA091],[TA092],[TA093],[TA094],[TA095],[TA096]
,[TA500],[TA501],[TA502],[TA503],[TA504],[TA505],[TA506],[TA507],[TA508],[TA509]
,[TA510],[TA511],[TA512],[TA513],[TA514],[TA515],[TA516],[TA520],[TA521],[TA522]
,[TA523],[TA524],[TA525],[TA526],[TA527],[TA528],[TA530],[TA531],[TA532],[TA533]
,[TA534],[TA535],[TA550],[TA551],[TA552],[TA553]
,[TA200],[TA201],[TA202]
,[UDF01],[UDF02],[UDF03],[UDF04],[UDF05],[UDF06],[UDF07],[UDF08],[UDF09],[UDF10]
)
SELECT 
[COMPANY],[CREATOR],[USR_GROUP],[CREATE_DATE],[MODIFIER],[MODI_DATE],[FLAG],[CREATE_TIME],[MODI_TIME],[TRANS_TYPE],[TRANS_NAME],[sync_date],[sync_time],[sync_mark],[sync_count],[DataUser],[DataGroup]
,[TA001],[TA002],[TA003],[TA004],[TA005],[TA006],[TA007],[TA008],[TA009],[TA010]
,[TA011],[TA012],[TA013],[TA014],[TA015],[TA016],[TA017],[TA018],[TA019],[TA020]
,[TA021],[TA022],[TA023],[TA024],[TA025],[TA026],[TA027],[TA028],[TA029],[TA030]
,[TA031],[TA032],[TA033],[TA034],[TA035],[TA036],[TA037],[TA038],[TA039],[TA040]
,[TA041],[TA042],[TA043],[TA044],[TA045],[TA046],[TA047],[TA048],[TA049],[TA050]
,[TA051],[TA052],[TA053],[TA054],[TA055],[TA056],[TA057],[TA058],[TA059],[TA060]
,[TA061],[TA062],[TA063],[TA064],[TA065],[TA066],[TA067],[TA068],[TA069],[TA070]
,[TA071],[TA072],[TA073],[TA074],[TA075],[TA076],[TA077],[TA078],[TA079],[TA080]
,[TA081],[TA082],[TA083],[TA084],[TA085],[TA086],[TA087],[TA088],[TA089],[TA090]
,[TA091],[TA092],[TA093],[TA094],[TA095],[TA096]
,[TA500],[TA501],[TA502],[TA503],[TA504],[TA505],[TA506],[TA507],[TA508],[TA509]
,[TA510],[TA511],[TA512],[TA513],[TA514],[TA515],[TA516],[TA520],[TA521],[TA522]
,[TA523],[TA524],[TA525],[TA526],[TA527],[TA528],[TA530],[TA531],[TA532],[TA533]
,[TA534],[TA535],[TA550],[TA551],[TA552],[TA553]
,[TA200],[TA201],[TA202]
,[UDF01],[UDF02],[UDF03],[UDF04],[UDF05],[UDF06],[UDF07],[UDF08],[UDF09],[UDF10]
FROM [TK].[dbo].[MOCTA]
WHERE TA002 LIKE '%' + @SDATES + '%';


INSERT INTO [TK_SFTTEST].[dbo].[MOCTB]
(
[COMPANY],[CREATOR],[USR_GROUP],[CREATE_DATE],[MODIFIER],[MODI_DATE],[FLAG],[CREATE_TIME],[MODI_TIME],[TRANS_TYPE],[TRANS_NAME],[sync_date],[sync_time],[sync_mark],[sync_count],[DataUser],[DataGroup]
,[TB001],[TB002],[TB003],[TB004],[TB005],[TB006],[TB007],[TB008],[TB009],[TB010]
,[TB011],[TB012],[TB013],[TB014],[TB015],[TB016],[TB017],[TB018],[TB019],[TB020]
,[TB021],[TB022],[TB023],[TB024],[TB025],[TB026],[TB027],[TB028],[TB029],[TB030]
,[TB031],[TB032],[TB033],[TB034],[TB035],[TB036],[TB037]
,[TB500],[TB501],[TB502],[TB503],[TB504],[TB505],[TB550],[TB551],[TB552],[TB553]
,[TB554],[TB555],[TB556],[TB557],[TB558],[TB559],[TB560]
,[UDF01],[UDF02],[UDF03],[UDF04],[UDF05],[UDF06],[UDF07],[UDF08],[UDF09],[UDF10]
)
SELECT 
[COMPANY],[CREATOR],[USR_GROUP],[CREATE_DATE],[MODIFIER],[MODI_DATE],[FLAG],[CREATE_TIME],[MODI_TIME],[TRANS_TYPE],[TRANS_NAME],[sync_date],[sync_time],[sync_mark],[sync_count],[DataUser],[DataGroup]
,[TB001],[TB002],[TB003],[TB004],[TB005],[TB006],[TB007],[TB008],[TB009],[TB010]
,[TB011],[TB012],[TB013],[TB014],[TB015],[TB016],[TB017],[TB018],[TB019],[TB020]
,[TB021],[TB022],[TB023],[TB024],[TB025],[TB026],[TB027],[TB028],[TB029],[TB030]
,[TB031],[TB032],[TB033],[TB034],[TB035],[TB036],[TB037]
,[TB500],[TB501],[TB502],[TB503],[TB504],[TB505],[TB550],[TB551],[TB552],[TB553]
,[TB554],[TB555],[TB556],[TB557],[TB558],[TB559],[TB560]
,[UDF01],[UDF02],[UDF03],[UDF04],[UDF05],[UDF06],[UDF07],[UDF08],[UDF09],[UDF10]
FROM [TK].[dbo].[MOCTB]
WHERE TB002 LIKE '%' + @SDATES + '%';


                            ");
                     

                        using (var command = new SqlCommand(sqlBuilder.ToString(), connection, transaction))
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

            MessageBox.Show("已完成");
        }
        #endregion
    }
}
