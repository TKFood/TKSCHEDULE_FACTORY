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

        public void ADD_SFT_OP_REALRUN(string SDATES)
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
INSERT INTO [SFT_TK_SFTTEST].[dbo].[SFT_OP_REALRUN]
(
[ID]
,[SEQUENCE]
,[OPID]
,[EQID]
,[ROUTESEQUENCE]
,[STEPSEQUENCE]
,[ALTSTEPSEQUENCE]
,[OPSEQUENCE]
,[ARRIVEQTY]
,[STARTQTY]
,[ENDQTY]
,[OUTQTY]
,[ARRIVETIME]
,[STARTTIME]
,[ENDTIME]
,[OUTTIME]
,[REWORKQTY]
,[ALERADYDEFECTQTY]
,[DEFECTQTY]
,[UNKNOWQTY]
,[SURPLUSQTY]
,[REPORTQTY]
,[FINISHRATE]
,[OPERID]
,[CHECKMAINTAINNO]
,[LASTMAINTAINUSER]
,[LASTMAINTAINDATETIME]
,[OPDESCRIPTION]
,[UNIT]
,[QTYPER]
,[ALTOPLIMITQTY]
,[OUTUNIT]
,[OUTQTYPER]
,[ERP_OPSEQ]
,[MANWORKTIME]
,[EQWORKTIME]
,[PERLOTWORKTIME]
,[ERP_TRANSQTY]
,[ERP_FIXEDLEADTIME]
,[ERP_VARIABLELEADTIME]
,[COINSTYPE]
,[STANDARDEQWORKTIME]
,[STANDARDMANWORKTIME]
,[COMPLEXION]
,[TA007]
,[PROCESSST]
,[PROCESSET]
,[TA013]
,[TA014]
,[TA015]
,[TA017]
,[TA019]
,[TA020]
,[PROCESSCOST]
,[TA029]
,[TA032]
,[TA033]
,[TA034]
,[TA037]
,[TA038]
,[TA039]
,[TA040]
,[TA041]
,[TA042]
,[TA043]
,[TA044]
,[TA045]
,[TA046]
,[TA047]
,[TA048]
,[TA049]
,[TA050]
,[TA051]
,[TOID]
,[TOSN]
,[PRODUCTION_REPORTID]
,[PRODUCTION_REPORTSN]
,[REPORTSTOCKIN]
,[TB052]
,[TB053]
,[TB054]
,[TB055]
,[TB056]
,[TB057]
,[TB058]
,[TB059]
,[TB060]
,[TB061]
,[TB062]
,[TB063]
,[TB064]
,[TB065]
,[TB066]
,[TB067]
,[TB068]
,[TB069]
,[TB070]
,[TB071]
,[TB072]
,[TB073]
,[TB074]
,[TB075]
,[TB076]
,[TB077]
,[TB078]
,[TB079]
,[TB080]
,[TB081]
,[TB082]
,[TB083]
,[TB084]
,[TB085]
,[TB086]
,[TB087]
,[TB088]
,[ERP_OPID]
,[ERP_WSID]
,[OR001]
,[OR002]
,[OR003]
,[OR004]
,[OR005]
,[OR006]
,[OR007]
,[OR008]
,[OR009]
,[OR010]
,[OR011]
,[PKQTY]
,[PKQTYPER]
,[PKUNIT]
,[OR012]
,[OR013]
,[OR014]
,[OR015]
,[OR016]
,[OR017]
,[OR018]
,[OR019]
,[OR020]
,[OR021]
,[OR022]
,[OR023]
,[OR024]
,[OR025]
,[OR026]
,[OR027]
,[OR028]
,[OR029]
,[OR030]
,[OR031]
,[OR032]
,[OR033]
,[OR034]
,[OR035]
,[OR036]
,[OR037]
,[OR038]
,[OR039]
,[OR040]
,[OR041]
,[OR042]
,[OR043]
,[OR045]
,[OR046]
,[OR047]
,[OR044]
,[OR048]
,[OR049]
,[OR050]
,[OR051]
,[OR056]
,[OR057]
,[OR052]
,[OR055]
,[OR053]
,[OR054]
,[OR058]
,[OR059]
,[OR060]
,[OR061]
,[ERP_LAGTIME]
,[OR062]
)

SELECT
TA001+'-'+TA002[ID]
,'0' [SEQUENCE]
,MF004+'---'+TA021 [OPID]
,NULL [EQID]
,NULL [ROUTESEQUENCE]
,NULL [STEPSEQUENCE]
,NULL [ALTSTEPSEQUENCE]
,NULL [OPSEQUENCE]
,'0' [ARRIVEQTY]
,NULL [STARTQTY]
,NULL [ENDQTY]
,'0' [OUTQTY]
,NULL [ARRIVETIME]
,NULL [STARTTIME]
,NULL [ENDTIME]
,NULL [OUTTIME]
,'0' [REWORKQTY]
,'0' [ALERADYDEFECTQTY]
,'0' [DEFECTQTY]
,'0' [UNKNOWQTY]
,'0' [SURPLUSQTY]
,NULL [REPORTQTY]
,'0' [FINISHRATE]
,NULL [OPERID]
,NULL [CHECKMAINTAINNO]
,NULL [LASTMAINTAINUSER]
,NULL [LASTMAINTAINDATETIME]
,MF008 [OPDESCRIPTION]
,MB004 [UNIT]
,'1' [QTYPER]
,'0' [ALTOPLIMITQTY]
,'PC' [OUTUNIT]
,'1' [OUTQTYPER]
,MF003 [ERP_OPSEQ]
,'0' [MANWORKTIME]
,'0' [EQWORKTIME]
,'1' [PERLOTWORKTIME]
,'1' [ERP_TRANSQTY]
,'0' [ERP_FIXEDLEADTIME]
,'0' [ERP_VARIABLELEADTIME]
,'NTD' [COINSTYPE]
,'0' [STANDARDEQWORKTIME]
,'0' [STANDARDMANWORKTIME]
,'1' [COMPLEXION]
,NULL [TA007]
,CONVERT(NVARCHAR,GETDATE(),111) [PROCESSST]
,CONVERT(NVARCHAR,GETDATE(),111) [PROCESSET]
,'0' [TA013]
,'0' [TA014]
,'0' [TA015]
,'0' [TA017]
,'1' [TA019]
,NULL [TA020]
,'0' [PROCESSCOST]
,'0' [TA029]
,'N' [TA032]
,'0' [TA033]
,NULL [TA034]
,'0' [TA037]
,'0' [TA038]
,'0' [TA039]
,'0' [TA040]
,'0' [TA041]
,'0' [TA042]
,'0' [TA043]
,'0' [TA044]
,'0' [TA045]
,'1' [TA046]
,NULL [TA047]
,NULL [TA048]
,NULL [TA049]
,NULL [TA050]
,NULL [TA051]
,NULL [TOID]
,NULL [TOSN]
,NULL [PRODUCTION_REPORTID]
,NULL [PRODUCTION_REPORTSN]
,'0' [REPORTSTOCKIN]
,NULL [TB052]
,'1' [TB053]
,'0' [TB054]
,'0' [TB055]
,NULL [TB056]
,NULL [TB057]
,NULL [TB058]
,'0' [TB059]
,'999999.000'[TB060]
,'N' [TB061]
,'N' [TB062]
,'1' [TB063]
,NULL [TB064]
,NULL [TB065]
,'0' [TB066]
,'N' [TB067]
,'1' [TB068]
,'2' [TB069]
,'1' [TB070]
,NULL [TB071]
,NULL [TB072]
,NULL [TB073]
,NULL [TB074]
,NULL [TB075]
,NULL [TB076]
,NULL [TB077]
,NULL [TB078]
,NULL [TB079]
,NULL [TB080]
,NULL [TB081]
,NULL [TB082]
,NULL [TB083]
,NULL [TB084]
,NULL [TB085]
,'0' [TB086]
,'0' [TB087]
,'0' [TB088]
,MF004 [ERP_OPID]
,TA021 [ERP_WSID]
,'-1' [OR001]
,'' [OR002]
,'' [OR003]
,'' [OR004]
,'0' [OR005]
,'0' [OR006]
,'0' [OR007]
,'0' [OR008]
,NULL [OR009]
,'0' [OR010]
,NULL [OR011]
,'0' [PKQTY]
,'0' [PKQTYPER]
,NULL [PKUNIT]
,TA015 [OR012]
,'-1' [OR013]
,NULL [OR014]
,'1' [OR015]
,'1' [OR016]
,TA015 [OR017]
,'0' [OR018]
,'0' [OR019]
,'0' [OR020]
,'0' [OR021]
,'0' [OR022]
,'0' [OR023]
,'1' [OR024]
,'N' [OR025]
,'N' [OR026]
,'N' [OR027]
,'N' [OR028]
,'0' [OR029]
,'0' [OR030]
,NULL [OR031]
,'1' [OR032]
,'1' [OR033]
,'0' [OR034]
,'0' [OR035]
,NULL [OR036]
,NULL [OR037]
,'0' [OR038]
,'0' [OR039]
,'0' [OR040]
,'0' [OR041]
,'0' [OR042]
,'0' [OR043]
,NULL [OR045]
,NULL [OR046]
,'N' [OR047]
,NULL [OR044]
,NULL [OR048]
,NULL [OR049]
,NULL [OR050]
,NULL [OR051]
,'0' [OR056]
,'0' [OR057]
,'0' [OR052]
,'N' [OR055]
,'0' [OR053]
,NULL [OR054]
,NULL [OR058]
,NULL [OR059]
,NULL [OR060]
,NULL [OR061]
,'0'  [ERP_LAGTIME]
,NULL [OR062]
FROM [TK_SFTTEST].[dbo].[MOCTA]
INNER JOIN [TK].dbo.INVMB ON MB001=TA006
LEFT JOIN [TK_SFTTEST].dbo.BOMMF ON MF001='04020' AND MF002='4020'
WHERE TA021 IN ('09')
AND MB001 LIKE '4%'
AND MB004 IN ('包')
AND NOT EXISTS (
      SELECT 1 
      FROM [SFT_TK_SFTTEST].[dbo].[SFT_OP_REALRUN] AS R WITH(NOLOCK)
      -- 假設 SFT_OP_REALRUN 的 ID 格式就是 'TA001-TA002'
      WHERE R.[ID] = TA001 + '-' + TA002 
  )
AND TA002 LIkE '%' + @SDATES + '%'
                            


                            ");


                        using (var command = new SqlCommand(sqlBuilder.ToString(), connection, transaction))
                        {
                            command.Parameters.AddWithValue("@SDATES", "20260512007");
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFT_OP_REALRUN: {ex.Message}");
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
        private void button2_Click(object sender, EventArgs e)
        {
            //轉入外包製程
            string SDATES = dateTimePicker1.Value.ToString("yyyyMMdd");
            ADD_SFT_OP_REALRUN(SDATES);
            MessageBox.Show("已完成");
        }

        #endregion


    }
}
