﻿using Microsoft.ConfigurationManagement.AdminConsole;
using Microsoft.ConfigurationManagement.AdminConsole.DialogFramework;
using Microsoft.ConfigurationManagement.ManagementProvider;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace Zetta.ConfigMgr.QuickTools
{
    public partial class ResultDellWarrantyControl : SmsPageControl
    {
        private ModifyRegistry registry = new ModifyRegistry();

        private BackgroundWorker backgroundWorker;

        public ResultDellWarrantyControl(SmsPageData pageData)
          : base(pageData)
        {
            InitializeComponent();
            buttonSURefresh.Image = new Icon(Properties.Resources.update, new Size(16, 16)).ToBitmap();
            buttonOptions.Image = new Icon(Properties.Resources.cog, new Size(16, 16)).ToBitmap();
            Title = "Dell Warranty";
        }

        public override void InitializePageControl()
        {
            base.InitializePageControl();

            if (string.IsNullOrEmpty(registry.Read("DellApiKey")) || string.IsNullOrEmpty(registry.Read("DellAPIURI")))
            {
                labelHttpResponse.Text = "No Dell TechDirect API key set in options";
                buttonSURefresh.Enabled = false;
            }
            else
            {
                buttonSURefresh.Enabled = true;
            }

            if (!PropertyManager["IsClient"].BooleanValue)
            {
                buttonSURefresh.Enabled = false;
            }

            Initialized = true;
        }

        private void buttonSURefresh_Click(object sender, EventArgs e)
        {
            listViewListWarranty.IsLoading = true;
            listViewListWarranty.UpdateColumnWidth(columnHeaderDescription);
            listViewListWarranty.Items.Clear();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(infoWorker_DoWorkAsync);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(infoWorker_RunWorkerCompleted);
            backgroundWorker.WorkerSupportsCancellation = false;
            backgroundWorker.WorkerReportsProgress = false;
            buttonSURefresh.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            Form options = new DellWarrantyOptions(this);
            options.Show();
        }

        private async void infoWorker_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            try
            {
                string query = string.Format("SELECT * FROM SMS_G_System_COMPUTER_SYSTEM WHERE ResourceID = '{0}'", PropertyManager["ResourceID"].IntegerValue);
                IResultObject contentObject = Utility.GetFirstWMIInstance(ConnectionManager, query);

                if (contentObject["Manufacturer"].StringValue == "Dell Inc.")
                {
                    labelModel.Text = contentObject["Model"].StringValue;

                    query = string.Format("SELECT * FROM SMS_G_System_PC_BIOS WHERE ResourceID = '{0}'", PropertyManager["ResourceID"].IntegerValue);
                    contentObject = Utility.GetFirstWMIInstance(ConnectionManager, query);
                    string serviceTag = contentObject["SerialNumber"].StringValue;
                    labelServiceTag.Text = serviceTag;

                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            labelHttpResponse.Text = "Requesting data from API";

                            client.BaseAddress = new Uri(registry.Read("DellAPIURI"));
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                            HttpResponseMessage response = await client.GetAsync(string.Format("getassetwarranty/{0}?apikey={1}", serviceTag, registry.Read("DellApiKey")));
                            if (response.IsSuccessStatusCode)
                            {
                                labelHttpResponse.Text = "Success";
                                string resultContent = response.Content.ReadAsStringAsync().Result;
                                XElement assetInformation = XElement.Parse(resultContent);
                                XNamespace ns = assetInformation.GetDefaultNamespace();

                                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                                TextInfo textInfo = cultureInfo.TextInfo;

                                var headerData = assetInformation.Descendants(ns + "AssetHeaderData").First();

                                XElement node = headerData.Element(ns + "ShipDate");
                                if (node != null)
                                {
                                    string shipDate = DateTime.Parse(node.Value).ToString();
                                    labelShipDate.Text = shipDate;
                                }

                                IEnumerable<XElement> nodeList = assetInformation.Descendants(ns + "AssetEntitlement");
                                foreach (XElement entitlement in nodeList)
                                {
                                    string serviceLevelDescription = entitlement.Element(ns + "ServiceLevelDescription").Value;
                                    if (serviceLevelDescription != "")
                                    {
                                        string type = entitlement.Element(ns + "EntitlementType").Value;
                                        listViewListWarranty.Items.Add(new ListViewItem()
                                        {
                                            Text = serviceLevelDescription,
                                            SubItems = {
                                                textInfo.ToTitleCase(type.ToLower()),
                                                DateTime.Parse(entitlement.Element(ns + "StartDate").Value).ToShortDateString(),
                                                DateTime.Parse(entitlement.Element(ns + "EndDate").Value).ToShortDateString()
                                            }
                                        });
                                    }
                                }
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                labelHttpResponse.Text = "Unauthorized - Check API Key";
                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                            {
                                labelHttpResponse.Text = "Resource Not found";
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            throw new InvalidOperationException(string.Format("{0}: {1}", ex.GetType().Name, ex.Message));
                        }
                    }
                }
                else
                {
                    labelServiceTag.Text = "The device is not manufacutred by Dell Inc";
                    labelModel.Text = contentObject["Manufacturer"].StringValue;
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("{0}: {1}", ex.GetType().Name, ex.Message));
            }
        }

        private void infoWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    using (SccmExceptionDialog sccmExceptionDialog = new SccmExceptionDialog(e.Error))
                    {
                        int num = (int)sccmExceptionDialog.ShowDialog();
                    }
                }
            }
            finally
            {
                if (sender as BackgroundWorker == backgroundWorker)
                {
                    backgroundWorker.Dispose();
                    backgroundWorker = null;
                    Cursor = Cursors.Default;
                    listViewListWarranty.IsLoading = false;
                    listViewListWarranty.UpdateColumnWidth(columnHeaderDescription);
                    listViewListWarranty.Sorting = SortOrder.Ascending;
                    buttonSURefresh.Enabled = true;
                }
            }
        }

        private void listViewListSoftwareUpdates_CopyKeyEvent(object sender, EventArgs e)
        {
            StringBuilder buffer = new StringBuilder();
            foreach (ListViewItem item in listViewListWarranty.SelectedItems)
            {
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    buffer.Append(subitem.Text);
                    buffer.Append("\t");
                }
                buffer.AppendLine();
            }
            buffer.Remove(buffer.Length - 1, 1);
            Clipboard.SetData(DataFormats.Text, buffer.ToString());
        }
    }
}
