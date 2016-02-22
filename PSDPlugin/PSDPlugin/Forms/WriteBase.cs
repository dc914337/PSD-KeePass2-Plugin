using KeePassLib.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KeePassLib;

namespace PSDPlugin.Forms
{
    public partial class WriteBase : Form
    {
        private PwDatabase database;
        private ProtectedString masterkey;

        public WriteBase(ProtectedString masterkey, PwDatabase database)
        {
            this.masterkey = masterkey;
            this.database = database;
            InitializeComponent();
        }

    }
}
