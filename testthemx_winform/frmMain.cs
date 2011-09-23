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
                    txtErrMessage.Text = "OK - ex : " + records[0].DomainName;
                }
                else
                {
                    btnCheck.BackColor = nokColor;
                    txtErrMessage.Text = "NOK";
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
    }
}
