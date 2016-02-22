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

using PsdBasesSetter.Repositories;
using PSDPlugin.Locales;
using PsdBasesSetter.Repositories.Objects;
using PSDPlugin.Converter;

namespace PSDPlugin.Forms
{
    public partial class WriteBase : Form
    {
        private PwDatabase _kpDatabase;
        private DataConnections DataConnections { get; set; } = new DataConnections();
        private String _phoneBasePath;



        public WriteBase(ProtectedString masterkey, PwDatabase database)
        {
            DataConnections.UserPass = masterkey.ReadString();
            this._kpDatabase = database;
            InitializeComponent();
        }

        private void WriteBase_Load(object sender, EventArgs e)
        {
            ReinitPsds();
            Base psdBase = new PwBaseConverter(_kpDatabase).ConvertToPSD();

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

        private void btnBrowseAndroid_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            _phoneBasePath = saveFileDialog.FileName;
            txtAndroidBasePath.Text = _phoneBasePath;
        }

        private void btnWriteAll_Click(object sender, EventArgs e)
        {
            if (!DataConnections.TryCreateAndSetPhoneBase(_phoneBasePath))
            {
                MessageBox.Show(Localization.CantLoadFileString);
                return;
            }


            switch (DataConnections.TrySetPsdBase((PSDDevice)cmbPsds.SelectedItem))
            {
                case PSDRepository.SetPsdResult.NotConnected:
                    MessageBox.Show(Localization.PsdConnectionError);
                    break;
                case PSDRepository.SetPsdResult.WrongPassword:
                    MessageBox.Show(Localization.WrongPasswordPSD);
                    FlushPassword();
                    break;
            }
        }



        private void FlushPassword()
        {
            if (MessageBox.Show("Do you want to set new password on PSD?", "Reset PSD password", MessageBoxButtons.YesNo)
                 == DialogResult.Yes)
            {
                DataConnections.PsdBase.Reset();
            }
        }


    }
}
