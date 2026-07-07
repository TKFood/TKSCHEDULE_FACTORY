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
                            WHERE 1=1
                            AND TA021 IN (
                                SELECT [TA021]     
                                FROM [TKSCHEDULE_FACTORY].[dbo].[LIMITS_TA021]
                                WHERE [ISUSED] IN ('Y')
                             )
                            AND TA002 LIKE '%' + @SDATES + '%';


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
                            [MOCTB].[COMPANY],[MOCTB].[CREATOR],[MOCTB].[USR_GROUP],[MOCTB].[CREATE_DATE],[MOCTB].[MODIFIER],[MOCTB].[MODI_DATE],[MOCTB].[FLAG],[MOCTB].[CREATE_TIME],[MOCTB].[MODI_TIME],[MOCTB].[TRANS_TYPE],[MOCTB].[TRANS_NAME],[MOCTB].[sync_date],[MOCTB].[sync_time],[MOCTB].[sync_mark],[MOCTB].[sync_count],[MOCTB].[DataUser],[MOCTB].[DataGroup]
                            ,[TB001],[TB002],[TB003],[TB004],[TB005],[TB006],[TB007],[TB008],[TB009],[TB010]
                            ,[TB011],[TB012],[TB013],[TB014],[TB015],[TB016],[TB017],[TB018],[TB019],[TB020]
                            ,[TB021],[TB022],[TB023],[TB024],[TB025],[TB026],[TB027],[TB028],[TB029],[TB030]
                            ,[TB031],[TB032],[TB033],[TB034],[TB035],[TB036],[TB037]
                            ,[TB500],[TB501],[TB502],[TB503],[TB504],[TB505],[TB550],[TB551],[TB552],[TB553]
                            ,[TB554],[TB555],[TB556],[TB557],[TB558],[TB559],[TB560]
                            ,[MOCTB].[UDF01],[MOCTB].[UDF02],[MOCTB].[UDF03],[MOCTB].[UDF04],[MOCTB].[UDF05],[MOCTB].[UDF06],[MOCTB].[UDF07],[MOCTB].[UDF08],[MOCTB].[UDF09],[MOCTB].[UDF10]
                            FROM [TK].[dbo].[MOCTB],[TK].[dbo].[MOCTA]
                            WHERE TA001=TB001 AND TA002=TB002
                            AND TA021 IN (
                                SELECT [TA021]     
                                FROM [TKSCHEDULE_FACTORY].[dbo].[LIMITS_TA021]
                                WHERE [ISUSED] IN ('Y')
                             )
                            AND TB002 LIKE '%' + @SDATES + '%';


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
                                                TA001 + '-' + TA002 AS [ID]
                                                ,'0' AS [SEQUENCE]
                                                ,MF.MF004 + '---' + TA021 AS [OPID]
                                                ,NULL AS [EQID]
                                                ,NULL AS [ROUTESEQUENCE]
                                                ,NULL AS [STEPSEQUENCE]
                                                ,NULL AS [ALTSTEPSEQUENCE]
                                                ,NULL AS [OPSEQUENCE]
                                                ,'0' AS [ARRIVEQTY]
                                                ,NULL AS [STARTQTY]
                                                ,NULL AS [ENDQTY]
                                                ,'0' AS [OUTQTY]
                                                ,NULL AS [ARRIVETIME]
                                                ,NULL AS [STARTTIME]
                                                ,NULL AS [ENDTIME]
                                                ,NULL AS [OUTTIME]
                                                ,'0' AS [REWORKQTY]
                                                ,'0' AS [ALERADYDEFECTQTY]
                                                ,'0' AS [DEFECTQTY]
                                                ,'0' AS [UNKNOWQTY]
                                                ,'0' AS [SURPLUSQTY]
                                                ,NULL AS [REPORTQTY]
                                                ,'0' AS [FINISHRATE]
                                                ,NULL AS [OPERID]
                                                ,NULL AS [CHECKMAINTAINNO]
                                                ,NULL AS [LASTMAINTAINUSER]
                                                ,GETDATE() AS [LASTMAINTAINDATETIME]
                                                ,MF.MF008 AS [OPDESCRIPTION]
                                                ,MB.MB004 AS [UNIT]
                                                ,'1' AS [QTYPER]
                                                ,'0' AS [ALTOPLIMITQTY]
                                                ,'PC' AS [OUTUNIT]
                                                ,'1' AS [OUTQTYPER]
                                                ,MF.MF003 AS [ERP_OPSEQ]
                                                ,'0' AS [MANWORKTIME]
                                                ,'0' AS [EQWORKTIME]
                                                ,'1' AS [PERLOTWORKTIME]
                                                ,'1' AS [ERP_TRANSQTY]
                                                ,'0' AS [ERP_FIXEDLEADTIME]
                                                ,'0' AS [ERP_VARIABLELEADTIME]
                                                ,'NTD' AS [COINSTYPE]
                                                ,'0' AS [STANDARDEQWORKTIME]
                                                ,'0' AS [STANDARDMANWORKTIME]
                                                ,'1' AS [COMPLEXION]
                                                ,NULL AS [TA007]
                                                ,TA009 AS [PROCESSST]
                                                ,TA010 AS [PROCESSET]
                                                ,'0' AS [TA013]
                                                ,'0' AS [TA014]
                                                ,'0' AS [TA015]
                                                ,'0' AS [TA017]
                                                ,'1' AS [TA019]
                                                ,NULL AS [TA020]
                                                ,'0' AS [PROCESSCOST]
                                                ,'0' AS [TA029]
                                                ,'N' AS [TA032]
                                                ,'0' AS [TA033]
                                                ,NULL AS [TA034]
                                                ,'0' AS [TA037]
                                                ,'0' AS [TA038]
                                                ,'0' AS [TA039]
                                                ,'0' AS [TA040]
                                                ,'0' AS [TA041]
                                                ,'0' AS [TA042]
                                                ,'0' AS [TA043]
                                                ,'0' AS [TA044]
                                                ,'0' AS [TA045]
                                                ,'1' AS [TA046]
                                                ,NULL AS [TA047]
                                                ,NULL AS [TA048]
                                                ,NULL AS [TA049]
                                                ,NULL AS [TA050]
                                                ,NULL AS [TA051]
                                                ,NULL AS [TOID]
                                                ,NULL AS [TOSN]
                                                ,NULL AS [PRODUCTION_REPORTID]
                                                ,NULL AS [PRODUCTION_REPORTSN]
                                                ,'0' AS [REPORTSTOCKIN]
                                                ,NULL AS [TB052]
                                                ,'1' AS [TB053]
                                                ,'0' AS [TB054]
                                                ,'0' AS [TB055]
                                                ,NULL AS [TB056]
                                                ,NULL AS [TB057]
                                                ,NULL AS [TB058]
                                                ,'0' AS [TB059]
                                                ,'999999.000' AS [TB060]
                                                ,'N' AS [TB061]
                                                ,'N' AS [TB062]
                                                ,'1' AS [TB063]
                                                ,NULL AS [TB064]
                                                ,NULL AS [TB065]
                                                ,'0' AS [TB066]
                                                ,'N' AS [TB067]
                                                ,'1' AS [TB068]
                                                ,'2' AS [TB069]
                                                ,'1' AS [TB070]
                                                ,NULL AS [TB071]
                                                ,NULL AS [TB072]
                                                ,NULL AS [TB073]
                                                ,NULL AS [TB074]
                                                ,NULL AS [TB075]
                                                ,NULL AS [TB076]
                                                ,NULL AS [TB077]
                                                ,NULL AS [TB078]
                                                ,NULL AS [TB079]
                                                ,NULL AS [TB080]
                                                ,NULL AS [TB081]
                                                ,NULL AS [TB082]
                                                ,NULL AS [TB083]
                                                ,NULL AS [TB084]
                                                ,NULL AS [TB085]
                                                ,'0' AS [TB086]
                                                ,'0' AS [TB087]
                                                ,'0' AS [TB088]
                                                ,MF.MF004 AS [ERP_OPID]
                                                ,TA021 AS [ERP_WSID]
                                                ,'-1' AS [OR001]
                                                ,'' AS [OR002]
                                                ,'' AS [OR003]
                                                ,'' AS [OR004]
                                                ,'0' AS [OR005]
                                                ,'0' AS [OR006]
                                                ,'0' AS [OR007]
                                                ,'0' AS [OR008]
                                                ,NULL AS [OR009]
                                                ,'0' AS [OR010]
                                                ,NULL AS [OR011]
                                                ,'0' AS [PKQTY]
                                                ,'0' AS [PKQTYPER]
                                                ,NULL AS [PKUNIT]
                                                ,TA015 AS [OR012]
                                                ,'-1' AS [OR013]
                                                ,NULL AS [OR014]
                                                ,'1' AS [OR015]
                                                ,'1' AS [OR016]
                                                ,TA015 AS [OR017]
                                                ,'0' AS [OR018]
                                                ,'0' AS [OR019]
                                                ,TA015 AS [OR020]
                                                ,'0' AS [OR021]
                                                ,'0' AS [OR022]
                                                ,'0' AS [OR023]
                                                ,'1' AS [OR024]
                                                ,'N' AS [OR025]
                                                ,'N' AS [OR026]
                                                ,'N' AS [OR027]
                                                ,'N' AS [OR028]
                                                ,'0' AS [OR029]
                                                ,'0' AS [OR030]
                                                ,NULL AS [OR031]
                                                ,'1' AS [OR032]
                                                ,'1' AS [OR033]
                                                ,'0' AS [OR034]
                                                ,'0' AS [OR035]
                                                ,NULL AS [OR036]
                                                ,NULL AS [OR037]
                                                ,'0' AS [OR038]
                                                ,'0' AS [OR039]
                                                ,'0' AS [OR040]
                                                ,'0' AS [OR041]
                                                ,'0' AS [OR042]
                                                ,'0' AS [OR043]
                                                ,NULL AS [OR045]
                                                ,NULL AS [OR046]
                                                ,'N' AS [OR047]
                                                ,NULL AS [OR044]
                                                ,NULL AS [OR048]
                                                ,NULL AS [OR049]
                                                ,NULL AS [OR050]
                                                ,NULL AS [OR051]
                                                ,'0' AS [OR056]
                                                ,'0' AS [OR057]
                                                ,'0' AS [OR052]
                                                ,'N' AS [OR055]
                                                ,'0' AS [OR053]
                                                ,NULL AS [OR054]
                                                ,NULL AS [OR058]
                                                ,NULL AS [OR059]
                                                ,NULL AS [OR060]
                                                ,NULL AS [OR061]
                                                ,'0' AS [ERP_LAGTIME]
                                                ,NULL AS [OR062]
                                                FROM [TK_SFTTEST].[dbo].[MOCTA] AS TA
                                            INNER JOIN [TK].dbo.INVMB AS MB ON MB.MB001 = TA.TA006
                                            -- 關鍵優化：利用 LEFT JOIN 的 ON 條件直接對應 包(04020/4020) 與 盒(04010/04010)
                                            LEFT JOIN [TK_SFTTEST].dbo.BOMMF AS MF ON 
                                                (MB.MB004 = '盒' AND MF.MF001 = '04010' AND MF.MF002 = '4010') OR
                                                (MB.MB004 = '包' AND MF.MF001 = '04020' AND MF.MF002 = '4020') OR
                                                (MB.MB004 = '片' AND MF.MF001 = '04040' AND MF.MF002 = '4040') OR
                                                (MB.MB004 = '罐' AND MF.MF001 = '04050' AND MF.MF002 = '4050') 
                                            WHERE TA.TA021 IN ('09')
                                              AND MB.MB001 LIKE '4%'
                                              AND MB.MB004 IN ( '盒','包','片','罐') -- 同時篩選包與盒
                                              AND TA002 LIkE '%' + @SDATES + '%'
                                              AND NOT EXISTS (
                                                    SELECT 1 
                                                    FROM [SFT_TK_SFTTEST].[dbo].[SFT_OP_REALRUN] AS R WITH(NOLOCK)
                                                    WHERE R.[ID] = TA.TA001 + '-' + TA.TA002 
                                              )
                                            ORDER BY [ID];
                            


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
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFT_OP_REALRUN: {ex.Message}");
            }
        }

        public void ADD_SFT_MODETAIL(string SDATES)
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
                                                INSERT INTO SFT_TK_SFTTEST.dbo.MODETAIL
                                                (
                                                CMOID
                                                ,DOID
                                                ,SEQUENCE
                                                ,ITEMID
                                                ,QTY
                                                ,DUEDATETIME
                                                ,PLANRELEASEQTY
                                                ,FACTORYID
                                                ,WAREHOUSEID
                                                ,PLANPROCESSST
                                                ,UNIT
                                                ,COINSTYPE
                                                ,MOVEOUTWHID
                                                ,TOTALEXCEPTQTY
                                                ,PLANBATCHNUMBER
                                                ,DEFBATCHNUMBER
                                                ,STATUS
                                                ,MO004
                                                ,MO005
                                                ,MO013
                                                ,MO014
                                                ,MO008
                                                ,DESCRIPTION
                                                ,MO021
                                                ,MO022
                                                ,MO032
                                                ,MO033
                                                ,MO034
                                                ,MO035
                                                ,MO016
                                                ,MO025
                                                ,MO009	
                                                ,MO010
                                                ,MO017	
                                                ,MO018	
                                                ,MO019	
                                                ,MO020
                                                ,FLAG
                                                ,MO024
                                                ,MO027	
                                                ,MO028	
                                                ,MO029	
                                                ,MO030	
                                                ,MO031
                                                ,LASTMAINTAINDATETIME
                                                ) 

                                                SELECT 
                                                TA001+'-'+TA002 AS CMOID
                                                ,TA026+'-'+TA027 DOID
                                                ,TA028 SEQUENCE
                                                ,TA006 ITEMID
                                                ,TA015 QTY
                                                ,TA003 DUEDATETIME
                                                ,TA015 PLANRELEASEQTY
                                                ,TA019 FACTORYID
                                                ,TA020 WAREHOUSEID
                                                ,TA009 PLANPROCESSST
                                                ,TA007 UNIT
                                                ,'' COINSTYPE
                                                ,TA020 MOVEOUTWHID
                                                ,0 TOTALEXCEPTQTY
                                                ,'' PLANBATCHNUMBER
                                                ,'' DEFBATCHNUMBER
                                                ,TA011 STATUS
                                                ,TA001 MO004
                                                ,TA002 MO005
                                                ,TA026 MO013
                                                ,TA027 MO014
                                                ,1 MO008
                                                ,TA029 DESCRIPTION
                                                ,TA034 MO021
                                                ,'' MO022
                                                ,'N' MO032
                                                ,'' MO033
                                                ,TA011 MO034
                                                ,TA003 MO035
                                                ,0 MO016
                                                ,TA009 MO025
                                                ,0 MO009	
                                                ,0 MO010
                                                ,0 MO017	
                                                ,0 MO018	
                                                ,0 MO019	
                                                ,'N' MO020
                                                ,MOCTA.FLAG	 FLAG
                                                ,0 MO024
                                                ,0 MO027	
                                                ,0 MO028	
                                                ,0 MO029	
                                                ,0 MO030	
                                                ,0 MO031
                                                ,GETDATE() LASTMAINTAINDATETIME
                                                FROM [TK_SFTTEST].dbo.MOCTA
                                                WHERE 1=1
                                                AND TA021 IN (
                                                    SELECT [TA021]     
                                                    FROM [TKSCHEDULE_FACTORY].[dbo].[LIMITS_TA021]
                                                    WHERE [ISUSED] IN ('Y')
                                                )
                                                AND NOT EXISTS
                                                (
                                                    SELECT 1 
                                                    FROM [SFT_TK_SFTTEST].dbo.MODETAIL
                                                    WHERE RTRIM(MO004) = RTRIM(TA001)
                                                    AND RTRIM(MO005) = RTRIM(TA002)
                                                )
                                                AND TA002 LIkE '%' + @SDATES + '%'
                                           
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
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFT_MODETAIL: {ex.Message}");
            }
        }
        public void ADD_SFT_LOT(string SDATES)
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
                                                INSERT INTO  [SFT_TK_SFTTEST].[dbo].[LOT]
                                                (
                                                [ID]
                                                ,[TYPE]
                                                ,[MOID]
                                                ,[RELEASEDATETIME]
                                                ,[ITEMID]
                                                ,[LOTSIZE]
                                                ,[DUEDATETIME]
                                                ,[PRIORITY]
                                                ,[STATUS]
                                                ,[ROUTESEQ]
                                                ,[STEPSEQ]
                                                ,[ALTID]
                                                ,[OPERATIONSEQ]
                                                ,[EQUIPMENTID]
                                                ,[OPERATEDTIME]
                                                ,[REMAINTIME]
                                                ,[MFGFLAG]
                                                ,[QTIME1]
                                                ,[QTIME2]
                                                ,[QTIME3]
                                                ,[QTIME4]
                                                ,[QTIME5]
                                                ,[QTIME6]
                                                ,[QTIME7]
                                                ,[QTIME8]
                                                ,[ISBANKORDER]
                                                ,[RECIPEID]
                                                ,[ISSUPPLY]
                                                ,[ISPLANNED]
                                                ,[OUTPUTQTY]
                                                ,[REMAININGTIME]
                                                ,[LOTGROUP]
                                                ,[PARTSISSUEDSTATUS]
                                                ,[KEYVALUE]
                                                ,[LOCKVALUE]
                                                ,[PASSVALUE]
                                                ,[CHECKMAINTAINNO]
                                                ,[LASTMAINTAINUSER]
                                                ,[LASTMAINTAINDATETIME]
                                                ,[UNIT]
                                                ,[QTYPER]
                                                ,[LOCATION]
                                                ,[DESCRIPTION]
                                                ,[SPLIT_ITEMID]
                                                ,[ORIGINAL_MOID]
                                                ,[ORIGINAL_LOTID]
                                                ,[REWORK_OPID]
                                                ,[MO_SEQUENCE]
                                                ,[SPLIT_OPID]
                                                ,[HEAD_OP_SEQ]
                                                ,[SUBMITFLAG]
                                                ,[ERP_OPSEQ]
                                                ,[ERP_OPID]
                                                ,[ERP_WSID]
                                                ,[LOT001]
                                                ,[LOT002]
                                                ,[LOT003]
                                                ,[LOT004]
                                                ,[LOT005]
                                                ,[LOT006]
                                                ,[PKQTY]
                                                ,[PKQTYPER]
                                                ,[PKUNIT]
                                                ,[LOT007]
                                                ,[LOT008]
                                                ,[LOT009]
                                                ,[LOT010]
                                                ,[LOT011]
                                                ,[LOT012]
                                                ,[LOT013]
                                                ,[LOT014]
                                                ,[LOT015]
                                                ,[LOT016]
                                                )

                                                SELECT 
                                                TA001+'-'+TA002 [ID]
                                                ,1 [TYPE]
                                                ,TA001+'-'+TA002 [MOID]
                                                ,NULL [RELEASEDATETIME]
                                                ,TA006 [ITEMID]
                                                ,TA015 [LOTSIZE]
                                                ,NULL [DUEDATETIME]
                                                ,NULL [PRIORITY]
                                                ,0 [STATUS]
                                                ,NULL [ROUTESEQ]
                                                ,NULL [STEPSEQ]
                                                ,NULL [ALTID]
                                                ,NULL [OPERATIONSEQ]
                                                ,NULL[EQUIPMENTID]
                                                ,NULL [OPERATEDTIME]
                                                ,NULL [REMAINTIME]
                                                ,NULL [MFGFLAG]
                                                ,NULL [QTIME1]
                                                ,NULL [QTIME2]
                                                ,NULL [QTIME3]
                                                ,NULL [QTIME4]
                                                ,NULL [QTIME5]
                                                ,NULL [QTIME6]
                                                ,NULL [QTIME7]
                                                ,NULL [QTIME8]
                                                ,NULL [ISBANKORDER]
                                                ,NULL [RECIPEID]
                                                ,1 [ISSUPPLY]
                                                ,1 [ISPLANNED]
                                                ,NULL [OUTPUTQTY]
                                                ,NULL [REMAININGTIME]
                                                ,NULL [LOTGROUP]
                                                ,NULL [PARTSISSUEDSTATUS]
                                                ,NULL [KEYVALUE]
                                                ,NULL [LOCKVALUE]
                                                ,NULL [PASSVALUE]
                                                ,NULL [CHECKMAINTAINNO]
                                                ,NULL [LASTMAINTAINUSER]
                                                ,GETDATE() [LASTMAINTAINDATETIME]
                                                ,TA007 [UNIT]
                                                ,1 [QTYPER]
                                                ,'release' [LOCATION]
                                                ,NULL [DESCRIPTION]
                                                ,NULL [SPLIT_ITEMID]
                                                ,NULL [ORIGINAL_MOID]
                                                ,NULL [ORIGINAL_LOTID]
                                                ,NULL [REWORK_OPID]
                                                ,0 [MO_SEQUENCE]
                                                ,NULL [SPLIT_OPID]
                                                ,0 [HEAD_OP_SEQ]
                                                ,0 [SUBMITFLAG]
                                                ,'' [ERP_OPSEQ]
                                                ,'' [ERP_OPID]
                                                ,'' [ERP_WSID]
                                                ,NULL [LOT001]
                                                ,NULL [LOT002]
                                                ,NULL [LOT003]
                                                ,NULL [LOT004]
                                                ,NULL [LOT005]
                                                ,NULL [LOT006]
                                                ,0 [PKQTY]
                                                ,0 [PKQTYPER]
                                                ,'' [PKUNIT]
                                                ,0 [LOT007]
                                                ,'' [LOT008]
                                                ,'' [LOT009]
                                                ,'' [LOT010]
                                                ,'N' [LOT011]
                                                ,NULL [LOT012]
                                                ,NULL [LOT013]
                                                ,NULL [LOT014]
                                                ,NULL [LOT015]
                                                ,NULL [LOT016]
                                                FROM [TK_SFTTEST].dbo.MOCTA
                                                WHERE 1=1
                                                AND TA021 IN (
                                                    SELECT [TA021]     
                                                    FROM [TKSCHEDULE_FACTORY].[dbo].[LIMITS_TA021]
                                                    WHERE [ISUSED] IN ('Y')
                                                )
                                                AND NOT EXISTS
                                                (
                                                    SELECT 1 
                                                    FROM [SFT_TK_SFTTEST].[dbo].[LOT]
                                                    WHERE RTRIM(ID) = RTRIM(TA001)+'-'+RTRIM(TA002)
                                                )
                                                AND TA002 LIkE '%' + @SDATES + '%'
                                           
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
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFT_LOT: {ex.Message}");
            }
        }

        public void ADD_SFT_ITEM()
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
                                                INSERT INTO [SFT_TK_SFTTEST].[dbo].[ITEM]
                                                (
                                                [ID]
                                                ,[NAME]
                                                ,[DESCRIPTION]
                                                ,[ITEMGROUPID]
                                                ,[SAFETYSTOCKQTY]
                                                ,[EXISTSTOCKQTY]
                                                ,[ISBANKORDERITEM]
                                                ,[MAXBANKQTY]
                                                ,[FIXEDLEADTIME]
                                                ,[VARIABLELEADTIME]
                                                ,[LEADTIMERATIO]
                                                ,[MAXBATCH]
                                                ,[MINBATCH]
                                                ,[INCREASEQTY]
                                                ,[EARLYCONSUMEDAY]
                                                ,[LATECONSUMEDAY]
                                                ,[ISLOTCONNECT]
                                                ,[LAYERNAME]
                                                ,[CHECKMAINTAINNO]
                                                ,[LASTMAINTAINUSER]
                                                ,[LASTMAINTAINDATETIME]
                                                ,[LOTSPLIT]
                                                ,[TRACK_TYPE]
                                                ,[RELEASEQTYPER]
                                                ,[BUILDQTY]
                                                ,[BASEQTY]
                                                ,[RELEASEUNIT]
                                                ,[ISSUBSTITUTE]
                                                ,[STDROUTEITEMID]
                                                ,[STDROUTEID]
                                                ,[ITEMTYPE]
                                                ,[CHECKBY]
                                                ,[SERIALMANAGEMENT]
                                                ,[UNIT]
                                                ,[FILENAME]
                                                ,[FLAG]
                                                ,[ITEM001]
                                                ,[ITEM002]
                                                ,[ITEM003]
                                                ,[ITEM004]
                                                ,[ITEM005]
                                                ,[ITEM006]
                                                ,[ITEM007]
                                                ,[ITEM008]
                                                ,[ITEM009]
                                                )
                                                SELECT 
                                                MB001 [ID]
                                                ,MB002 [NAME]
                                                ,MB003 [DESCRIPTION]
                                                ,'' [ITEMGROUPID]
                                                ,0 [SAFETYSTOCKQTY]
                                                ,0 [EXISTSTOCKQTY]
                                                ,0 [ISBANKORDERITEM]
                                                ,999999 [MAXBANKQTY]
                                                ,0 [FIXEDLEADTIME]
                                                ,0 [VARIABLELEADTIME]
                                                ,0 [LEADTIMERATIO]
                                                ,999999 [MAXBATCH]
                                                ,1 [MINBATCH]
                                                ,1 [INCREASEQTY]
                                                ,999999 [EARLYCONSUMEDAY]
                                                ,999999 [LATECONSUMEDAY]
                                                ,0 [ISLOTCONNECT]
                                                ,'' [LAYERNAME]
                                                ,NULL [CHECKMAINTAINNO]
                                                ,NULL [LASTMAINTAINUSER]
                                                ,NULL [LASTMAINTAINDATETIME]
                                                ,0 [LOTSPLIT]
                                                ,0 [TRACK_TYPE]
                                                ,1 [RELEASEQTYPER]
                                                ,1 [BUILDQTY]
                                                ,1 [BASEQTY]
                                                ,MB004 [RELEASEUNIT]
                                                ,1 [ISSUBSTITUTE]
                                                ,NULL [STDROUTEITEMID]
                                                ,NULL [STDROUTEID]
                                                ,2 [ITEMTYPE]
                                                ,2 [CHECKBY]
                                                ,'N' [SERIALMANAGEMENT]
                                                ,MB004 [UNIT]
                                                ,FLAG [FILENAME]
                                                ,MB004 [FLAG]
                                                ,NULL [ITEM001]
                                                ,'N' [ITEM002]
                                                ,'N' [ITEM003]
                                                ,0 [ITEM004]
                                                ,1 [ITEM005]
                                                ,1 [ITEM006]
                                                ,'N' [ITEM007]
                                                ,NULL [ITEM008]
                                                ,NULL [ITEM009]
                                                FROM [TK].dbo.INVMB
                                                WHERE (MB001 LIKE '4%')
                                                AND  NOT EXISTS
                                                (
                                                    SELECT 1 
                                                    FROM [SFT_TK_SFTTEST].[dbo].[ITEM]
                                                    WHERE [ID]=MB001
                                                )                    
                                           
                            ");


                        using (var command = new SqlCommand(sqlBuilder.ToString(), connection, transaction))
                        {
                            //ommand.Parameters.AddWithValue("@SDATES", SDATES);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFT_ITEM: {ex.Message}");
            }
        }

        public void ADD_TK_SFTTEST_INVMB()
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
                                                
                                                INSERT INTO [TK_SFTTEST].[dbo].[INVMB]
                                                (
                                                [COMPANY]
                                                ,[CREATOR]
                                                ,[USR_GROUP]
                                                ,[CREATE_DATE]
                                                ,[MODIFIER]
                                                ,[MODI_DATE]
                                                ,[FLAG]
                                                ,[CREATE_TIME]
                                                ,[MODI_TIME]
                                                ,[TRANS_TYPE]
                                                ,[TRANS_NAME]
                                                ,[sync_date]
                                                ,[sync_time]
                                                ,[sync_mark]
                                                ,[sync_count]
                                                ,[DataUser]
                                                ,[DataGroup]
                                                ,[MB001]
                                                ,[MB002]
                                                ,[MB003]
                                                ,[MB004]
                                                ,[MB005]
                                                ,[MB006]
                                                ,[MB007]
                                                ,[MB008]
                                                ,[MB009]
                                                ,[MB010]
                                                ,[MB011]
                                                ,[MB012]
                                                ,[MB013]
                                                ,[MB014]
                                                ,[MB015]
                                                ,[MB016]
                                                ,[MB017]
                                                ,[MB018]
                                                ,[MB019]
                                                ,[MB020]
                                                ,[MB021]
                                                ,[MB022]
                                                ,[MB023]
                                                ,[MB024]
                                                ,[MB025]
                                                ,[MB026]
                                                ,[MB027]
                                                ,[MB028]
                                                ,[MB029]
                                                ,[MB030]
                                                ,[MB031]
                                                ,[MB032]
                                                ,[MB033]
                                                ,[MB034]
                                                ,[MB035]
                                                ,[MB036]
                                                ,[MB037]
                                                ,[MB038]
                                                ,[MB039]
                                                ,[MB040]
                                                ,[MB041]
                                                ,[MB042]
                                                ,[MB043]
                                                ,[MB044]
                                                ,[MB045]
                                                ,[MB046]
                                                ,[MB047]
                                                ,[MB048]
                                                ,[MB049]
                                                ,[MB050]
                                                ,[MB051]
                                                ,[MB052]
                                                ,[MB053]
                                                ,[MB054]
                                                ,[MB055]
                                                ,[MB056]
                                                ,[MB057]
                                                ,[MB058]
                                                ,[MB059]
                                                ,[MB060]
                                                ,[MB061]
                                                ,[MB062]
                                                ,[MB063]
                                                ,[MB064]
                                                ,[MB065]
                                                ,[MB066]
                                                ,[MB067]
                                                ,[MB068]
                                                ,[MB069]
                                                ,[MB070]
                                                ,[MB071]
                                                ,[MB072]
                                                ,[MB073]
                                                ,[MB074]
                                                ,[MB075]
                                                ,[MB076]
                                                ,[MB077]
                                                ,[MB078]
                                                ,[MB079]
                                                ,[MB080]
                                                ,[MB081]
                                                ,[MB082]
                                                ,[MB083]
                                                ,[MB084]
                                                ,[MB085]
                                                ,[MB086]
                                                ,[MB087]
                                                ,[MB088]
                                                ,[MB089]
                                                ,[MB090]
                                                ,[MB091]
                                                ,[MB092]
                                                ,[MB093]
                                                ,[MB094]
                                                ,[MB095]
                                                ,[MB096]
                                                ,[MB097]
                                                ,[MB098]
                                                ,[MB099]
                                                ,[MB100]
                                                ,[MB101]
                                                ,[MB102]
                                                ,[MB103]
                                                ,[MB104]
                                                ,[MB105]
                                                ,[MB106]
                                                ,[MB107]
                                                ,[MB108]
                                                ,[MB109]
                                                ,[MB110]
                                                ,[MB111]
                                                ,[MB112]
                                                ,[MB113]
                                                ,[MB114]
                                                ,[MB115]
                                                ,[MB116]
                                                ,[MB117]
                                                ,[MB118]
                                                ,[MB119]
                                                ,[MB120]
                                                ,[MB121]
                                                ,[MB122]
                                                ,[MB123]
                                                ,[MB124]
                                                ,[MB125]
                                                ,[MB126]
                                                ,[MB127]
                                                ,[MB128]
                                                ,[MB129]
                                                ,[MB130]
                                                ,[MB131]
                                                ,[MB132]
                                                ,[MB133]
                                                ,[MB134]
                                                ,[MB135]
                                                ,[MB136]
                                                ,[MB137]
                                                ,[MB138]
                                                ,[MB139]
                                                ,[MB140]
                                                ,[MB141]
                                                ,[MB142]
                                                ,[MB143]
                                                ,[MB144]
                                                ,[MB145]
                                                ,[MB146]
                                                ,[MB147]
                                                ,[MB148]
                                                ,[MB149]
                                                ,[MB150]
                                                ,[MB151]
                                                ,[MB152]
                                                ,[MB153]
                                                ,[MB154]
                                                ,[MB155]
                                                ,[MB156]
                                                ,[MB157]
                                                ,[MB158]
                                                ,[MB159]
                                                ,[MB160]
                                                ,[MB161]
                                                ,[MB162]
                                                ,[MB163]
                                                ,[MB164]
                                                ,[MB165]
                                                ,[MB166]
                                                ,[MB167]
                                                ,[MB168]
                                                ,[MB169]
                                                ,[MB170]
                                                ,[MB171]
                                                ,[MB172]
                                                ,[MB173]
                                                ,[MB174]
                                                ,[MB175]
                                                ,[MB176]
                                                ,[MB177]
                                                ,[MB178]
                                                ,[MB179]
                                                ,[MB180]
                                                ,[MB181]
                                                ,[MB182]
                                                ,[MB183]
                                                ,[MB184]
                                                ,[MB185]
                                                ,[MB186]
                                                ,[MB187]
                                                ,[MB188]
                                                ,[MB189]
                                                ,[MB190]
                                                ,[MB191]
                                                ,[MB192]
                                                ,[MB193]
                                                ,[MB194]
                                                ,[MB195]
                                                ,[MB196]
                                                ,[MB197]
                                                ,[MB198]
                                                ,[MB199]
                                                ,[UDF01]
                                                ,[UDF02]
                                                ,[UDF03]
                                                ,[UDF04]
                                                ,[UDF05]
                                                ,[UDF06]
                                                ,[UDF07]
                                                ,[UDF08]
                                                ,[UDF09]
                                                ,[UDF10]
                                                )
                                                SELECT 
                                                [COMPANY]
                                                ,[CREATOR]
                                                ,[USR_GROUP]
                                                ,[CREATE_DATE]
                                                ,[MODIFIER]
                                                ,[MODI_DATE]
                                                ,[FLAG]
                                                ,[CREATE_TIME]
                                                ,[MODI_TIME]
                                                ,[TRANS_TYPE]
                                                ,[TRANS_NAME]
                                                ,[sync_date]
                                                ,[sync_time]
                                                ,[sync_mark]
                                                ,[sync_count]
                                                ,[DataUser]
                                                ,[DataGroup]
                                                ,[MB001]
                                                ,[MB002]
                                                ,[MB003]
                                                ,[MB004]
                                                ,[MB005]
                                                ,[MB006]
                                                ,[MB007]
                                                ,[MB008]
                                                ,[MB009]
                                                ,[MB010]
                                                ,[MB011]
                                                ,[MB012]
                                                ,[MB013]
                                                ,[MB014]
                                                ,[MB015]
                                                ,[MB016]
                                                ,[MB017]
                                                ,[MB018]
                                                ,[MB019]
                                                ,[MB020]
                                                ,[MB021]
                                                ,[MB022]
                                                ,[MB023]
                                                ,[MB024]
                                                ,[MB025]
                                                ,[MB026]
                                                ,[MB027]
                                                ,[MB028]
                                                ,[MB029]
                                                ,[MB030]
                                                ,[MB031]
                                                ,[MB032]
                                                ,[MB033]
                                                ,[MB034]
                                                ,[MB035]
                                                ,[MB036]
                                                ,[MB037]
                                                ,[MB038]
                                                ,[MB039]
                                                ,[MB040]
                                                ,[MB041]
                                                ,[MB042]
                                                ,[MB043]
                                                ,[MB044]
                                                ,[MB045]
                                                ,[MB046]
                                                ,[MB047]
                                                ,[MB048]
                                                ,[MB049]
                                                ,[MB050]
                                                ,[MB051]
                                                ,[MB052]
                                                ,[MB053]
                                                ,[MB054]
                                                ,[MB055]
                                                ,[MB056]
                                                ,[MB057]
                                                ,[MB058]
                                                ,[MB059]
                                                ,[MB060]
                                                ,[MB061]
                                                ,[MB062]
                                                ,[MB063]
                                                ,[MB064]
                                                ,[MB065]
                                                ,[MB066]
                                                ,[MB067]
                                                ,[MB068]
                                                ,[MB069]
                                                ,[MB070]
                                                ,[MB071]
                                                ,[MB072]
                                                ,[MB073]
                                                ,[MB074]
                                                ,[MB075]
                                                ,[MB076]
                                                ,[MB077]
                                                ,[MB078]
                                                ,[MB079]
                                                ,[MB080]
                                                ,[MB081]
                                                ,[MB082]
                                                ,[MB083]
                                                ,[MB084]
                                                ,[MB085]
                                                ,[MB086]
                                                ,[MB087]
                                                ,[MB088]
                                                ,[MB089]
                                                ,[MB090]
                                                ,[MB091]
                                                ,[MB092]
                                                ,[MB093]
                                                ,[MB094]
                                                ,[MB095]
                                                ,[MB096]
                                                ,[MB097]
                                                ,[MB098]
                                                ,[MB099]
                                                ,[MB100]
                                                ,[MB101]
                                                ,[MB102]
                                                ,[MB103]
                                                ,[MB104]
                                                ,[MB105]
                                                ,[MB106]
                                                ,[MB107]
                                                ,[MB108]
                                                ,[MB109]
                                                ,[MB110]
                                                ,[MB111]
                                                ,[MB112]
                                                ,[MB113]
                                                ,[MB114]
                                                ,[MB115]
                                                ,[MB116]
                                                ,[MB117]
                                                ,[MB118]
                                                ,[MB119]
                                                ,[MB120]
                                                ,[MB121]
                                                ,[MB122]
                                                ,[MB123]
                                                ,[MB124]
                                                ,[MB125]
                                                ,[MB126]
                                                ,[MB127]
                                                ,[MB128]
                                                ,[MB129]
                                                ,[MB130]
                                                ,[MB131]
                                                ,[MB132]
                                                ,[MB133]
                                                ,[MB134]
                                                ,[MB135]
                                                ,[MB136]
                                                ,[MB137]
                                                ,[MB138]
                                                ,[MB139]
                                                ,[MB140]
                                                ,[MB141]
                                                ,[MB142]
                                                ,[MB143]
                                                ,[MB144]
                                                ,[MB145]
                                                ,[MB146]
                                                ,[MB147]
                                                ,[MB148]
                                                ,[MB149]
                                                ,[MB150]
                                                ,[MB151]
                                                ,[MB152]
                                                ,[MB153]
                                                ,[MB154]
                                                ,[MB155]
                                                ,[MB156]
                                                ,[MB157]
                                                ,[MB158]
                                                ,[MB159]
                                                ,[MB160]
                                                ,[MB161]
                                                ,[MB162]
                                                ,[MB163]
                                                ,[MB164]
                                                ,[MB165]
                                                ,[MB166]
                                                ,[MB167]
                                                ,[MB168]
                                                ,[MB169]
                                                ,[MB170]
                                                ,[MB171]
                                                ,[MB172]
                                                ,[MB173]
                                                ,[MB174]
                                                ,[MB175]
                                                ,[MB176]
                                                ,[MB177]
                                                ,[MB178]
                                                ,[MB179]
                                                ,[MB180]
                                                ,[MB181]
                                                ,[MB182]
                                                ,[MB183]
                                                ,[MB184]
                                                ,[MB185]
                                                ,[MB186]
                                                ,[MB187]
                                                ,[MB188]
                                                ,[MB189]
                                                ,[MB190]
                                                ,[MB191]
                                                ,[MB192]
                                                ,[MB193]
                                                ,[MB194]
                                                ,[MB195]
                                                ,[MB196]
                                                ,[MB197]
                                                ,[MB198]
                                                ,[MB199]
                                                ,[UDF01]
                                                ,[UDF02]
                                                ,[UDF03]
                                                ,[UDF04]
                                                ,[UDF05]
                                                ,[UDF06]
                                                ,[UDF07]
                                                ,[UDF08]
                                                ,[UDF09]
                                                ,[UDF10]
                                                FROM [TK].dbo.INVMB
                                                WHERE (MB001 LIKE '4%')
                                                AND MB001 NOT IN (
                                                SELECT MB001 FROM [TK_SFTTEST].[dbo].[INVMB]
                                                )                  
                                           
                            ");


                        using (var command = new SqlCommand(sqlBuilder.ToString(), connection, transaction))
                        {
                            //ommand.Parameters.AddWithValue("@SDATES", SDATES);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ADD_TK_SFTTEST_INVMB: {ex.Message}");
            }
        }

        public void ADD_SFCTB_SFCTC(string SDATES)
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
                                                INSERT INTO  [TK_SFTTEST].dbo.SFCTB
                                                (
                                                COMPANY
                                                ,CREATOR
                                                ,USR_GROUP
                                                ,CREATE_DATE
                                                ,MODIFIER
                                                ,MODI_DATE
                                                ,FLAG
                                                ,CREATE_TIME
                                                ,MODI_TIME
                                                ,TRANS_TYPE
                                                ,TRANS_NAME
                                                ,sync_date
                                                ,sync_time
                                                ,sync_mark
                                                ,sync_count
                                                ,DataUser
                                                ,DataGroup
                                                ,TB001
                                                ,TB002
                                                ,TB003
                                                ,TB004
                                                ,TB005
                                                ,TB006
                                                ,TB007
                                                ,TB008
                                                ,TB009
                                                ,TB010
                                                ,TB011
                                                ,TB012
                                                ,TB013
                                                ,TB014
                                                ,TB015
                                                ,TB016
                                                ,TB017
                                                ,TB018
                                                ,TB019
                                                ,TB020
                                                ,TB021
                                                ,TB022
                                                ,TB023
                                                ,TB024
                                                ,TB025
                                                ,TB026
                                                ,TB027
                                                ,TB028
                                                ,TB029
                                                ,TB030
                                                ,TB031
                                                ,TB032
                                                ,TB033
                                                ,TB034
                                                ,TB035
                                                ,TB036
                                                ,TB037
                                                ,TB038
                                                ,TB039
                                                ,TB040
                                                ,TB041
                                                ,TB042
                                                ,TB043
                                                ,TB044
                                                ,TB045
                                                )
                                                SELECT 
                                                'TK_SFTTEST' COMPANY
                                                ,'160115' CREATOR
                                                ,'117000' USR_GROUP
                                                ,CONVERT(NVARCHAR,GETDATE(),112) CREATE_DATE
                                                ,'160115' MODIFIER
                                                ,CONVERT(NVARCHAR,GETDATE(),112) MODI_DATE
                                                ,0 FLAG
                                                ,CONVERT(NVARCHAR, GETDATE(), 108) CREATE_TIME
                                                ,CONVERT(NVARCHAR, GETDATE(), 108)  MODI_TIME
                                                ,'P003' TRANS_TYPE
                                                ,'Sftb03' TRANS_NAME
                                                ,'' sync_date
                                                ,'' sync_time
                                                ,'' sync_mark
                                                ,0 sync_count
                                                ,'' DataUser
                                                ,'' DataGroup
                                                ,(CASE WHEN TA001='A510' THEN 'D101' WHEN TA001='A513' THEN 'D103' END)  TB001
                                                ,TA002 TB002
                                                ,CONVERT(NVARCHAR,GETDATE(),112) TB003
                                                ,'3' TB004
                                                ,TA020 TB005
                                                ,(SELECT TOP 1 MC002 FROM [TK].dbo.CMSMC WHERE MC001=TA020) TB006
                                                ,'1' TB007
                                                ,TA021 TB008
                                                ,(SELECT TOP 1 MD002 FROM [TK].dbo.CMSMD WHERE MD001=TA021) TB009
                                                ,TA019 TB010
                                                ,0 TB011
                                                ,'N' TB012
                                                ,'Y' TB013
                                                ,'' TB014
                                                ,CONVERT(NVARCHAR,GETDATE(),112) TB015
                                                ,'160115' TB016
                                                ,'N' TB017
                                                ,'' TB018
                                                ,1 TB019
                                                ,'' TB020
                                                ,'' TB021
                                                ,1 TB022
                                                ,1 TB023
                                                ,'' TB024
                                                ,SUBSTRING(CONVERT(NVARCHAR,GETDATE(),112),1,6) TB025
                                                ,0.0500 TB026
                                                ,0 TB027
                                                ,'' TB028
                                                ,0 TB029
                                                ,0 TB030
                                                ,0 TB031
                                                ,'' TB032
                                                ,'' TB033
                                                ,'' TB034
                                                ,'' TB035
                                                ,'NTD' TB036
                                                ,0 TB037
                                                ,(CASE WHEN TA001='A510' THEN 'D101' WHEN TA001='A513' THEN 'D103' END) TB038
                                                ,TA002 TB039
                                                ,'' TB040
                                                ,0 TB041
                                                ,'' TB042
                                                ,'' TB043
                                                ,'' TB044
                                                ,0 TB045
                                                FROM [TK_SFTTEST].dbo.MOCTA
                                                WHERE 1=1
                                                AND NOT EXISTS
                                                (
                                                    SELECT 1 
                                                    FROM [TK_SFTTEST].dbo.SFCTB
                                                    WHERE TB001=(CASE WHEN TA001='A510' THEN 'D101' WHEN TA001='A513' THEN 'D103' END)
                                                    AND TB002=TA002
                                                )
                                                AND TA002 LIkE '%' + @SDATES + '%'

                                                INSERT INTO [TK_SFTTEST].dbo.SFCTC
                                                (
                                                COMPANY
                                                ,CREATOR
                                                ,USR_GROUP
                                                ,CREATE_DATE
                                                ,MODIFIER
                                                ,MODI_DATE
                                                ,FLAG
                                                ,CREATE_TIME
                                                ,MODI_TIME
                                                ,TRANS_TYPE
                                                ,TRANS_NAME
                                                ,sync_date
                                                ,sync_time
                                                ,sync_mark
                                                ,sync_count
                                                ,DataUser
                                                ,DataGroup
                                                ,TC001
                                                ,TC002
                                                ,TC003
                                                ,TC004
                                                ,TC005
                                                ,TC006
                                                ,TC007
                                                ,TC008
                                                ,TC009
                                                ,TC010
                                                ,TC011
                                                ,TC012
                                                ,TC013
                                                ,TC014
                                                ,TC015
                                                ,TC016
                                                ,TC017
                                                ,TC018
                                                ,TC019
                                                ,TC020
                                                ,TC021
                                                ,TC022
                                                ,TC023
                                                ,TC024
                                                ,TC025
                                                ,TC026
                                                ,TC027
                                                ,TC028
                                                ,TC029
                                                ,TC030
                                                ,TC031
                                                ,TC032
                                                ,TC033
                                                ,TC034
                                                ,TC035
                                                ,TC036
                                                ,TC037
                                                ,TC038
                                                ,TC039
                                                ,TC040
                                                ,TC041
                                                ,TC042
                                                ,TC043
                                                ,TC044
                                                ,TC045
                                                ,TC046
                                                ,TC047
                                                ,TC048
                                                ,TC049
                                                ,TC050
                                                ,TC051
                                                ,TC052
                                                ,TC053
                                                ,TC054
                                                ,TC055
                                                ,TC056
                                                ,TC057
                                                ,TC058
                                                ,TC059
                                                ,TC060
                                                ,TC061
                                                ,TC062
                                                ,TC063
                                                ,TC064
                                                )

                                                SELECT 
                                                'TK_SFTTEST' COMPANY
                                                ,'160115' CREATOR
                                                ,'117000' USR_GROUP
                                                ,CONVERT(NVARCHAR,GETDATE(),112) CREATE_DATE
                                                ,'160115' MODIFIER
                                                ,CONVERT(NVARCHAR,GETDATE(),112) MODI_DATE
                                                ,0 FLAG
                                                ,CONVERT(NVARCHAR, GETDATE(), 108) CREATE_TIME
                                                ,CONVERT(NVARCHAR, GETDATE(), 108)  MODI_TIME
                                                ,'P003' TRANS_TYPE
                                                ,'Sftb03' TRANS_NAME
                                                ,'' sync_date
                                                ,'' sync_time
                                                ,'' sync_mark
                                                ,0 sync_count
                                                ,'' DataUser
                                                ,'' DataGroup
                                                ,(CASE WHEN TA001='A510' THEN 'D101' WHEN TA001='A513' THEN 'D103' END) TC001
                                                ,TA002 TC002
                                                ,RIGHT('0000' + CAST(ROW_NUMBER() OVER (ORDER BY TA001, TA002,ERP_OPID) AS VARCHAR(4)), 4) TC003
                                                ,TA001 TC004
                                                ,TA002 TC005
                                                ,'' TC006
                                                ,'' TC007
                                                ,ERP_OPSEQ TC008
                                                ,ERP_OPID TC009
                                                ,MOCTA.TA007 TC010
                                                ,'' TC011
                                                ,'' TC012
                                                ,'6' TC013
                                                ,MOCTA.TA015 TC014
                                                ,0 TC015
                                                ,0 TC016
                                                ,0 TC017
                                                ,0 TC018
                                                ,0 TC019
                                                ,0 TC020
                                                ,0 TC021
                                                ,'N' TC022
                                                ,MOCTA.TA020 TC023
                                                ,'' TC024
                                                ,0 TC025
                                                ,'N' TC026
                                                ,'Y' TC027
                                                ,'' TC028
                                                ,'' TC029
                                                ,'' TC030
                                                ,'' TC031
                                                ,'' TC032
                                                ,CONVERT(NVARCHAR(8), DATEADD(MONTH, 10, GETDATE()), 112) TC033
                                                ,CONVERT(NVARCHAR,GETDATE(),112) TC034
                                                ,'N' TC035
                                                ,MOCTA.TA015  TC036
                                                ,0 TC037
                                                ,CONVERT(NVARCHAR,GETDATE(),112) TC038
                                                ,0 TC039
                                                ,'' TC040
                                                ,TA021 TC041
                                                ,0 TC042
                                                ,0 TC043
                                                ,0 TC044
                                                ,0 TC045
                                                ,0 TC046
                                                ,MOCTA.TA006 TC047
                                                ,MOCTA.TA034 TC048
                                                ,MOCTA.TA035 TC049
                                                ,'' TC050
                                                ,0 TC051
                                                ,'' TC052
                                                ,0 TC053
                                                ,0 TC054
                                                ,'' TC055
                                                ,'' TC056
                                                ,'' TC057
                                                ,'' TC058
                                                ,'' TC059
                                                ,0 TC060
                                                ,'' TC061
                                                ,'' TC062
                                                ,'' TC063
                                                ,0 TC064
                                                FROM [SFT_TK_SFTTEST].dbo.SFT_OP_REALRUN,[TK_SFTTEST].dbo.MOCTA
                                                WHERE ID=TA001+'-'+TA002
                                                AND NOT EXISTS
                                                (
                                                    SELECT 1 
                                                    FROM [TK_SFTTEST].dbo.SFCTC
                                                    WHERE TC001=(CASE WHEN TA001='A510' THEN 'D101' WHEN TA001='A513' THEN 'D103' END)
                                                    AND TC002=TA002
                                                )
                                                AND ID LIkE '%' + @SDATES + '%'
                                                               
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
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFCTB_SFCTC: {ex.Message}");
            }
        }
        public void ADD_SFT_MOCTA_MOCTB(string SDATES)
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
                                                INSERT INTO [SFT_TK_SFTTEST].[dbo].[ERP_MOCTA]
                                                (
                                                [TA001]
                                                ,[TA002]
                                                ,[TA006]
                                                ,[TA007]
                                                ,[TA009]
                                                ,[TA010]
                                                ,[TA011]
                                                ,[TA015]
                                                ,[TA019]
                                                ,[TA020]
                                                ,[TA024]
                                                ,[TA025]
                                                ,[TA026]
                                                ,[TA027]
                                                ,[TA028]
                                                ,[TA037]
                                                ,[TA042]
                                                ,[TA033]
                                                ,[TA063]
                                                ,[FLAG]
                                                )
                                                SELECT 
                                                [TA001]
                                                ,[TA002]
                                                ,[TA006]
                                                ,[TA007]
                                                ,[TA009]
                                                ,[TA010]
                                                ,[TA011]
                                                ,[TA015]
                                                ,[TA019]
                                                ,[TA020]
                                                ,[TA024]
                                                ,[TA025]
                                                ,[TA026]
                                                ,[TA027]
                                                ,[TA028]
                                                ,[TA037]
                                                ,[TA042]
                                                ,[TA033]
                                                ,[TA063]
                                                ,[FLAG]
                                                FROM [TK_SFTTEST].dbo.MOCTA
                                                WHERE 1=1
                                                AND NOT EXISTS
                                                (
	                                                SELECT 1 
	                                                FROM [SFT_TK_SFTTEST].[dbo].[ERP_MOCTA]
	                                                WHERE [ERP_MOCTA].TA001=MOCTA.TA001
	                                                AND [ERP_MOCTA].TA002=MOCTA.TA002
	
                                                )
                                                AND TA002 LIKE '%' + @SDATES + '%'

                                                INSERT INTO [SFT_TK_SFTTEST].[dbo].[ERP_MOCTB]
                                                (
                                                [TB001]
                                                ,[TB002]
                                                ,[TB003]
                                                ,[TB004]
                                                ,[TB006]
                                                ,[TB014]
                                                ,[TB015]
                                                ,[FLAG]
                                                )
                                                SELECT  
                                                [TB001]
                                                ,[TB002]
                                                ,[TB003]
                                                ,[TB004]
                                                ,[TB006]
                                                ,[TB014]
                                                ,[TB015]
                                                ,[FLAG]
                                                FROM [TK_SFTTEST].dbo.MOCTB
                                                WHERE 1=1
                                                AND NOT EXISTS
                                                (
	                                                SELECT 1 
	                                                FROM [SFT_TK_SFTTEST].[dbo].[ERP_MOCTB]
	                                                WHERE [ERP_MOCTB].TB001=MOCTB.TB001
	                                                AND [ERP_MOCTB].TB002=MOCTB.TB002
	                                                AND [ERP_MOCTB].TB003=MOCTB.TB003
                                                )
                                                AND TB002 LIKE '%' + @SDATES + '%'
                                               
                                                               
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
                System.Diagnostics.Debug.WriteLine($"Error in ADD_SFT_MOCTA_MOCTB: {ex.Message}");
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

        private void button3_Click(object sender, EventArgs e)
        {
            //轉入製令-TKSFT>SFT
            string SDATES = dateTimePicker1.Value.ToString("yyyyMMdd");
            ADD_SFT_MODETAIL(SDATES);
            ADD_SFT_LOT(SDATES);
            ADD_SFT_MOCTA_MOCTB(SDATES);
            MessageBox.Show("已完成");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //不能用，因為kmi不直接讀資料庫
            //製令的製程發放
            //string SDATES = dateTimePicker1.Value.ToString("yyyyMMdd");
            //ADD_SFCTB_SFCTC(SDATES);
            //MessageBox.Show("已完成");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //更新資料
            ADD_SFT_ITEM();
            ADD_TK_SFTTEST_INVMB();

            MessageBox.Show("已完成");
        }
        #endregion


    }
}
