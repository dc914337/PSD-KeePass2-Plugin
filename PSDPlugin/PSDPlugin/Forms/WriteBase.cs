using KeePassLib.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeePassLib;
using PsdBasesSetter;
using PsdBasesSetter.Device.Hid;
using System.Linq;
using PSD.Locales;

namespace PSDPlugin.Forms
{
    public partial class WriteBase : Form
    {
        private PwDatabase database;
        private ProtectedString masterkey;
        public DataConnections DataConnections { get; set; } = new DataConnections();



        public WriteBase(ProtectedString masterkey, PwDatabase database)
        {
            this.masterkey = masterkey;
            this.database = database;
            InitializeComponent();
        }

        private void WriteBase_Load(object sender, EventArgs e)
        {


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!ReinitPsds())
                MessageBox.Show(Localization.NoPSDsError);
        }


        private bool ReinitPsds()
        {
            var finder = new PSDFinder();
            var psds = finder.FindConnectedPsds();
            cmbPsds.Items.Clear();
            cmbPsds.Items.AddRange(psds);
            if (psds.Any())
                cmbPsds.SelectedIndex = 0;
            return psds.Any();
        }



    }
}
