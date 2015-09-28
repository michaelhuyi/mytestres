using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.IO;

namespace Corp.Mobile.MoblieTools
{
    public partial class SoaFrom : UserControl
    {
        public static List<string> SOA_ProAddr = new List<string>() { "Corp.BCCOrderProcess", "Corp.CorpAuditProcess", "Corp.CorpBaseInfo", "Corp.CorpBooking", "Corp.CorpLoginCheck", "Corp.CorpOrderDataTransfer", "Corp.CorpOrderProcess", "Corp.HtlRsc", "Corp.ProductProcess", "Corp.User.SmallCorp", "Corp.Booking.FlightWS", "Corp.Booking.HotelWS", "Corp.Booking.IntlFlightBookabilityAPI", "Corp.Booking.IntlFlightRepricingAPI", "Corp.Booking.IntlFlightReservationAPI", "Corp.Booking.IntlFlightSaveOrderAPI", "Corp.Booking.IntlFlightWS", "Corp.Booking.TrainWS", "Corp.Order.CorpFlightOrderService", "Corp.Order.CorpHotelOrderService", "Corp.Order.Statistics", "Corp.Order.TrainJsonWS", "Corp.Order.TrainWS", "Corp.Process.FundAccountDealWS", "Corp.Product.CorpFlightBaseInfoService", "Corp.Product.CorpFlightSearchService", "Corp.Product.CorpHotelActivityService", "Corp.Product.CorpHotelProductService", "Corp.Product.FlightIntlSearchWS", "Corp.Product.HotelSearchService", "Corp.Product.IntlFlightCacheAPI", "Corp.Product.IntlFlightFareRemarkAPI", "Corp.Product.IntlFlightSearchAPI", "Corp.Product.SearchService", "Corp.Product.SearchServiceProtoBuf", "Corp.Report.SearchWS", "Corp.User.AuditWS", "Corp.User.NewAuditWS", "Corp.User.TravelPolicyService" };
        public static Dictionary<string, string> SOA_ADDR = new Dictionary<string, string>() { { "CORP.BCCORDERPROCESS", "http://corps.ws.ctrip.com/CorpService/BCCOrderService.asmx" }, { "CORP.CORPAUDITPROCESS", "http://corpws.sh.ctriptravel.com/CorpHotelService/CorpAuditProcess.asmx" }, { "CORP.CORPBASEINFO", "http://corpws.sh.ctriptravel.com/CorpInfoMaintain/CorpBaseInfo.asmx" }, { "CORP.CORPBOOKING", "http://corpws.sh.ctriptravel.com/CorpBookingWebService/CorpBookingWebService.asmx" }, { "CORP.CORPLOGINCHECK", "http://corpws.sh.ctriptravel.com/CorpService/CorpLoginCheck.asmx" }, { "CORP.CORPORDERDATATRANSFER", "http://corpws.sh.ctriptravel.com/CorpOrderTransfer/Corp.CorpOrderDataTransfer.asmx" }, { "CORP.CORPORDERPROCESS", "http://corpws.sh.ctriptravel.com/CorpOrderProcess/CorpOrderProcess.asmx" }, { "CORP.HTLRSC", "http://corpws.sh.ctriptravel.com/CorpHotelService/HtlRscService.asmx" }, { "CORP.PRODUCTPROCESS", "http://corpws.sh.ctriptravel.com/CorpFlightService/Ctrip.Corp.ProductProcess.asmx" }, { "CORP.USER.SMALLCORP", "http://corpws.sh.ctriptravel.com/Corp-User-SmallCorpWS/SmallCorpWebService.asmx" }, { "CORP.BOOKING.FLIGHTWS", "http://corpws.sh.ctriptravel.com/Corp-Booking-FlightWS/FlightBooking.asmx" }, { "CORP.BOOKING.HOTELWS", "http://corpws.sh.ctriptravel.com/Corp-Booking-HotelWS/HotelBooking.asmx" }, { "CORP.BOOKING.INTLFLIGHTBOOKABILITYAPI", "http://corpws.sh.ctriptravel.com/corp-booking-intlflightapi/intlflightbookabilityasyncws.asmx" }, { "CORP.BOOKING.INTLFLIGHTREPRICINGAPI", "http://corpws.sh.ctriptravel.com/corp-booking-intlflightapi/intlflightrepricingasyncws.asmx" }, { "CORP.BOOKING.INTLFLIGHTRESERVATIONAPI", "http://corpws.sh.ctriptravel.com/corp-booking-intlflightapi/intlflightreservationasyncws.asmx" }, { "CORP.BOOKING.INTLFLIGHTSAVEORDERAPI", "http://corpws.sh.ctriptravel.com/corp-booking-intlflightapi/intlflightsaveorderasyncws.asmx" }, { "CORP.BOOKING.INTLFLIGHTWS", "http://corpws.sh.ctriptravel.com/Corp-Booking-IntlFlightWS/IntlFlightBookingWS.asmx" }, { "CORP.BOOKING.TRAINWS", "http://corpws.sh.ctriptravel.com/Corp-Booking-TrainWS/TrainBooking.asmx" }, { "CORP.ORDER.CORPFLIGHTORDERSERVICE", "http://corpws.sh.ctriptravel.com/Corp-Order-CorpFlightOrderService/CorpFlightOrderService.asmx" }, { "CORP.ORDER.CORPHOTELORDERSERVICE", "http://corpws.sh.ctriptravel.com/Corp-Order-CorpHotelOrderService/HotelOrderService.asmx" }, { "CORP.ORDER.STATISTICS", "http://corpws.sh.ctriptravel.com/CorpStatistics/StatisticsInfo.asmx" }, { "CORP.ORDER.TRAINJSONWS", "http://corpws.sh.ctriptravel.com/Corp-Order-TrainWS/JsonFormatService.asmx" }, { "CORP.ORDER.TRAINWS", "http://corpws.sh.ctriptravel.com/Corp-Order-TrainWS/TraionOrder.asmx" }, { "CORP.PROCESS.FUNDACCOUNTDEALWS", "http://corpws.sh.ctriptravel.com/corp-process-fundaccountdealws/fundaccountdealservice.asmx" }, { "CORP.PRODUCT.CORPFLIGHTBASEINFOSERVICE", "http://corpws.sh.ctriptravel.com/corp-product-corpflightbaseinfoservice/corpflightbaseinfoservice.asmx" }, { "CORP.PRODUCT.CORPFLIGHTSEARCHSERVICE", "http://corpws.sh.ctriptravel.com/Corp-Product-CorpFlightSearchService/FlightProdService.asmx" }, { "CORP.PRODUCT.CORPHOTELACTIVITYSERVICE", "http://corpws.sh.ctriptravel.com/Corp-Product-CorpHotelActivityService/HotelProductService.asmx" }, { "CORP.PRODUCT.CORPHOTELPRODUCTSERVICE", "http://corpws.sh.ctriptravel.com/corp-product-corphotelproductservice/hotelproductservice.asmx" }, { "CORP.PRODUCT.FLIGHTINTLSEARCHWS", "http://corpws.sh.ctriptravel.com/Corp-Product-FlightIntlSearchWS/FlightIntlSearchService.asmx" }, { "CORP.PRODUCT.HOTELSEARCHSERVICE", "http://corpws.sh.ctriptravel.com/Corp-Product-CorpHotelSearchService/HotelProductService.asmx" }, { "CORP.PRODUCT.INTLFLIGHTCACHEAPI", "http://corpws.sh.ctriptravel.com/corp-product-intlflightsearchapi/intlflightcacheremovalasyncws.asmx" }, { "CORP.PRODUCT.INTLFLIGHTFAREREMARKAPI", "http://corpws.sh.ctriptravel.com/corp-product-intlflightsearchapi/intlflightfareremarkasyncws.asmx" }, { "CORP.PRODUCT.INTLFLIGHTSEARCHAPI", "http://corpws.sh.ctriptravel.com/corp-product-intlflightsearchapi/intlflightsearchasyncws.asmx" }, { "CORP.PRODUCT.SEARCHSERVICE", "http://corpws.sh.ctriptravel.com/Corp-Product-AgreementHotelSearchService/HotelSearchService.asmx" }, { "CORP.PRODUCT.SEARCHSERVICEPROTOBUF", "http://corpws.sh.ctriptravel.com/Corp-Product-AgreementHotelSearchService/HotelSearchServiceProtoBuf.asmx" }, { "CORP.REPORT.SEARCHWS", "http://corpws.sh.ctriptravel.com/corp-report-searchws/corpreport.asmx" }, { "CORP.USER.AUDITWS", "http://corpws.sh.ctriptravel.com/Corp-User-AuditWS/CorpAuditService.asmx" }, { "CORP.USER.NEWAUDITWS", "http://corpws.sh.ctriptravel.com/Corp-User-NewAuditWS/CorpAuditService.asmx" }, { "CORP.USER.TRAVELPOLICYSERVICE", "http://corpws.sh.ctriptravel.com/Corp-User-TravelPolicyService/TravelPolicy.asmx" } };

        private string _type;

        /// <summary>
        /// "Ctrip.SOA.ESB.asmx"
        /// </summary>
        private const string _ESBSERVICE = "Ctrip.SOA.ESB.asmx";
        /// <summary>
        /// "coreproxysite.ctripcorp.com"
        /// </summary>
        private const string _WEBPROXY = "coreproxysite.ctripcorp.com";

        /// <summary>
        /// 构造函数
        /// </summary>
        public SoaFrom()
        {
            InitializeComponent();
        }

        public SoaFrom(string type)
        {
            InitializeComponent();
            _type = type;

            //cmbEnv.Items.Clear();

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (_type.Equals("SOA1"))
            {
                SOA1Request();
            }
            else
            {
                SOA2Request();
            }
        }

        private void SOA1Request()
        {
            DelegateControlProxy dp = new DelegateControlProxy();
            btnRequest.Enabled = false;

            Task.Factory.StartNew((taskObj) =>
            {
                Stopwatch sw = new Stopwatch();

                sw.Start();

                try
                {
                    dynamic dyObj = taskObj;
                    var esb = new ESB();
                    esb.Proxy = new WebProxy(_WEBPROXY, 8080);
                    dp.SetControlPropertyValue(txtResponse, "Text", esb.Request(dyObj.esb, dyObj.req));
                    sw.Stop();
                }
                catch
                {
                }
                finally
                {
                    if (sw.IsRunning)
                        sw.Stop();
                    dp.SetControlPropertyValue(lblSoaTime, "Text", sw.ElapsedMilliseconds.ToString());
                    dp.SetControlPropertyValue(btnRequest, "Enabled", true);
                }
            }, new { esb = txtESBURL.Text, req = txtRequest.Text });
        }

        private void SOA2Request()
        {
            btnRequest.Enabled = false;
            string requestUrl, requestParam;
            requestUrl = txtESBURL.Text;
            requestParam = txtRequest.Text;
            Task task1 = new Task(() => ReqUrl(requestUrl, requestParam));
            task1.Start();
        }

        /// <summary>
        /// 发起请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="reqParam"></param>
        private void ReqUrl(string url, string reqParam)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = reqParam;
            byte[] payload;

            //System.Net.WebProxy proxy = new WebProxy(_WEBPROXY, 8080);
            //request.Proxy = proxy;
            request.Proxy = new WebProxy(_WEBPROXY, 8080);

            DelegateControlProxy dp = new DelegateControlProxy();
            try
            {
                payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.Stream s;
                s = response.GetResponseStream();
                string StrDate = "";
                string strValue = "";
                StreamReader Reader = new StreamReader(s, Encoding.UTF8);
                while ((StrDate = Reader.ReadLine()) != null)
                {
                    strValue += StrDate + "\r\n";
                }
                //return strValue;
                dp.SetControlPropertyValue(txtResponse, "Text", strValue);
            }
            catch (Exception e)
            {
                //MessageBox.Show("Err:" + e.Message.ToString());
            }
            finally
            {
                if (sw.IsRunning)
                    sw.Stop();
                dp.SetControlPropertyValue(lblSoaTime, "Text", sw.ElapsedMilliseconds.ToString());
                dp.SetControlPropertyValue(btnRequest, "Enabled", true);
            }
        }      

        private void SoaFrom_Load(object sender, EventArgs e)
        {
            this.cmbEnv.SelectedIndex = 0;
            txtRequest.Focus();
            cmbProAdr.DataSource = SOA_ProAddr;
            cmbProAdr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbProAdr.AutoCompleteCustomSource.AddRange(SOA_ProAddr.ToArray());
            if (String.IsNullOrEmpty(_type))
            {
                this.txtESBURL.Text = @"http://soa.fws.qa.nt.ctripcorp.com/SOA.ESB/" + _ESBSERVICE;             
            }
            else
            {
                if (_type.Equals("SOA1"))
                {
                    this.txtESBURL.Text = @"http://soa.fws.qa.nt.ctripcorp.com/SOA.ESB/" + _ESBSERVICE;
                }
                else
                {
                    this.txtESBURL.Text = @"http://corpws.fat25.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderServiceNew/api/json/AddPageView";
                }
            }

           
        }

        int pianyi = 0;
        int sizepianyi = 0;
        private void cmbEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtESBURL.Visible = false;
            if (pianyi != 0)
            {
                txtESBURL.Location = new Point(pianyi - 300, 13);
                txtESBURL.Size = new System.Drawing.Size(this.Size.Width - 300, 21);
            }
            //txtESBURL.Location = new Point(this.Size.Width - 863, 13);

            //txtESBURL.Size = new System.Drawing.Size(717, 21);
            cmbProAdr.Visible = false;

            if (String.IsNullOrEmpty(_type))
            {
                SetComboboxForSOA1();
            }
            else
            {
                if (_type.Equals("SOA1"))
                {
                    SetComboboxForSOA1();
                }
                else
                {
                    SetComboboxForSOA2();
                }
            }

            txtESBURL.Visible = true;
        }

        private void SetComboboxForSOA1()
        {
            if (this.cmbEnv.SelectedItem.ToString() == "FWS")
            {
                this.txtESBURL.Text = @"http://soa.fws.qa.nt.ctripcorp.com/SOA.ESB/" + _ESBSERVICE;
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "UAT")
            {
                this.txtESBURL.Text = @"http://soa.uat.sh.ctriptravel.com/SOA.ESB/" + _ESBSERVICE;
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "UATNT")
            {
                this.txtESBURL.Text = @"http://soa.uat.qa.nt.ctripcorp.com/SOA.ESB/" + _ESBSERVICE;
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "DEV")
            {
                this.txtESBURL.Text = @"http://soa.dev.sh.ctriptravel.com/SOA.ESB/" + _ESBSERVICE;
            }
            else
            {
                pianyi = cmbProAdr.Location.X + cmbProAdr.Size.Width + 20;
                sizepianyi = txtESBURL.Size.Width - (pianyi - txtESBURL.Location.X);
                txtESBURL.Location = new Point(pianyi, 13);
                txtESBURL.Size = new System.Drawing.Size(sizepianyi, 21);
                cmbProAdr.Visible = true;
                this.txtESBURL.Text = @"http://soa.sh.ctriptravel.com/SOA.ESB/" + _ESBSERVICE;
            }
        }

        private void SetComboboxForSOA2()
        {
            if (this.cmbEnv.SelectedItem.ToString() == "FWS")
            {
                this.txtESBURL.Text = @"http://corpws.fat25.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderServiceNew/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "UAT")
            {
                this.txtESBURL.Text = @"http://corpws.uat.qa.nt.ctripcorp.com/corp-order-corpflightorderservice/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "FAT1")
            {
                this.txtESBURL.Text = @"http://corpws.fat4.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "FAT2")
            {
                this.txtESBURL.Text = @"http://corpws.fat4.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "FAT3")
            {
                this.txtESBURL.Text = @"http://corpws.fat4.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "FAT4")
            {
                this.txtESBURL.Text = @"http://corpws.fat25.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderServiceNew/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "FAT5")
            {
                this.txtESBURL.Text = @"http://corpws.fat4.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "DEV")
            {
                this.txtESBURL.Text = @"http://corpws.fat25.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "LPT10")
            {
                this.txtESBURL.Text = @"http://corpws.lpt10.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "LPT1")
            {
                this.txtESBURL.Text = @"http://corpws.fat4.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else if (this.cmbEnv.SelectedItem.ToString() == "LPT2")
            {
                this.txtESBURL.Text = @"http://corpws.fat4.qa.nt.ctripcorp.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
            else
            {
                pianyi = cmbProAdr.Location.X + cmbProAdr.Size.Width + 20;
                sizepianyi = txtESBURL.Size.Width - (pianyi - txtESBURL.Location.X);
                txtESBURL.Location = new Point(pianyi, 16);
                txtESBURL.Size = new System.Drawing.Size(sizepianyi, 21);
                cmbProAdr.Visible = true;
                this.txtESBURL.Text = @"http://corpws.sh.ctriptravel.com/Corp-Order-CorpFlightOrderService/api/json/AddPageView";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProAdr_TextUpdate(object sender, EventArgs e)
        {
            GetSOAAddr();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProAdr_TextChanged(object sender, EventArgs e)
        {
            GetSOAAddr();
        }

        /// <summary>
        /// 获取SOA地址
        /// </summary>
        private void GetSOAAddr()
        {
            if (!string.IsNullOrWhiteSpace(cmbProAdr.Text))
            {
                string esbUrl = string.Empty;
                if (SOA_ADDR.TryGetValue(cmbProAdr.Text.Trim().ToUpper(), out esbUrl))
                {
                    txtESBURL.Text = esbUrl;
                }
            }
        }

    }

    /// <summary>
    /// ESB Client For 调用SOA1.0
    /// </summary>
    [WebServiceBinding(Name = "ESBSoap", Namespace = "http://tempuri.org/"), GeneratedCode("System.Web.Services", "4.0.30319.1"), DebuggerStepThrough, DesignerCategory("code")]
    public class ESB : SoapHttpClientProtocol
    {
        private static ESB instance = new ESB();
        public static ESB Instance { get { return instance; } }
        public ESB() { }

        public string Request(string Url, string requestXML)
        {
            this.Url = Url;
            return Request(requestXML);
        }
        // Properties
        public string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                base.Url = value;
            }
        }


        [SoapDocumentMethod("http://tempuri.org/Request", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public string Request(string requestXML)
        {
            return (string)base.Invoke("Request", new object[] { requestXML })[0];
        }
    }
}
