using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bdev.Net.Dns;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace testthemx_winform
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>

        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        /// <summary>
        /// Check MX.
        /// </summary>

        private void Check()
        {
            Color okColor = Color.LightGreen;
            Color pendingColor = Color.Orange;
            Color nokColor = Color.LightPink;

            try
            {
                btnCheck.Text = string.Empty;
                btnCheck.BackColor = pendingColor;
                txtErrMessage.Text = string.Empty;

                IPAddress dnsServer = null;

                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                    foreach (IPAddress addr in dnsServers)
                    {
                        if (addr.AddressFamily == AddressFamily.InterNetwork)
                        {
                            dnsServer = addr;
                            break;
                        }
                    }
                }

                MXRecord[] records = Resolver.MXLookup(txtDn.Text, dnsServer);
                if (records.Length > 0)
                {
                    btnCheck.BackColor = okColor;
                    txtErrMessage.Text = "OK";

                    string[] mxList = new string[records.Length];

                    for (int i = 0; i < records.Length; ++i)
                        mxList[i] = records[i].DomainName;

                    cbx_list.DataSource = mxList;
                    cbx_list.Visible = true;
                    btn_clipboardCopy.Visible = true;
                    btn_clipboardCopyAll.Visible = true;
                }
                else
                {
                    btnCheck.BackColor = nokColor;
                    txtErrMessage.Text = "NOK";

                    cbx_list.Visible = false;
                    btn_clipboardCopy.Visible = false;
                    btn_clipboardCopyAll.Visible = false;
                }
            }
            catch (Exception exp)
            {
                btnCheck.BackColor = nokColor;
                txtErrMessage.Text = exp.Message;
            }

            btnCheck.Text = "Check";
            btnCheck.Image = null;
        }

        /// <summary>
        /// Shortcut key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Check();
        }

        /// <summary>
        /// Copy selected server address to clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_clipboardCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(cbx_list.Text);
        }

        /// <summary>
        /// Copy all servers to clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btn_clipboardCopyAll_Click(object sender, EventArgs e)
        {
            string str = string.Empty;

            string[] data = (string[])cbx_list.DataSource;

            for (int i = 0; i < data.Length; ++i)
            {
                str += data[i] + System.Environment.NewLine;
            }

            Clipboard.SetText(str);
        }
    }
}
