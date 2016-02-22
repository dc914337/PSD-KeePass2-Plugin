using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePass.Forms;
using KeePass.Resources;

using KeePassLib;
using KeePassLib.Security;
using PSDPlugin.Forms;
using KeePassLib.Keys;

namespace PSDPlugin
{
    public sealed class PSDPluginExt : Plugin
    {
        // The sample plugin remembers its host in this variable.
        private IPluginHost m_host = null;

        private ToolStripSeparator m_tsSeparator = null;
        private ToolStripMenuItem m_tsmiPopup = null;
        private ToolStripMenuItem m_tsmiWrite = null;
        private ToolStripMenuItem m_tsmiMerge = null;
        private ToolStripMenuItem m_tsmiFirmware = null;
        private ToolStripMenuItem m_tsmiKeysSync = null;


        /// <summary>
        /// The <c>Initialize</c> function is called by KeePass when
        /// you should initialize your plugin (create menu items, etc.).
        /// </summary>
        /// <param name="host">Plugin host interface. By using this
        /// interface, you can access the KeePass main window and the
        /// currently opened database.</param>
        /// <returns>You must return <c>true</c> in order to signal
        /// successful initialization. If you return <c>false</c>,
        /// KeePass unloads your plugin (without calling the
        /// <c>Terminate</c> function of your plugin).</returns>
        public override bool Initialize(IPluginHost host)
        {
            Debug.Assert(host != null);
            if (host == null) return false;
            m_host = host;
            // Get a reference to the 'Tools' menu item container
            ToolStripItemCollection tsMenu = m_host.MainWindow.ToolsMenu.DropDownItems;

            // Add a separator at the bottom
            m_tsSeparator = new ToolStripSeparator();
            tsMenu.Add(m_tsSeparator);

            // Add the popup menu item
            m_tsmiPopup = new ToolStripMenuItem();
            m_tsmiPopup.Text = "PSD";
            tsMenu.Add(m_tsmiPopup);

            // Add menu item 
            m_tsmiWrite = new ToolStripMenuItem();
            m_tsmiWrite.Text = "Write base to PSD and Android";
            m_tsmiWrite.Click += OnWrite;
            m_tsmiPopup.DropDownItems.Add(m_tsmiWrite);

            // Add menu item
            m_tsmiMerge = new ToolStripMenuItem();
            m_tsmiMerge.Text = "Merge and update";
            m_tsmiMerge.Click += OnMerge;
            m_tsmiPopup.DropDownItems.Add(m_tsmiMerge);

            // Add menu item
            m_tsmiKeysSync = new ToolStripMenuItem();
            m_tsmiKeysSync.Text = "Synchronize keys";
            m_tsmiKeysSync.Click += OnKeysSync;
            m_tsmiPopup.DropDownItems.Add(m_tsmiKeysSync);

            // Add menu item
            m_tsmiFirmware = new ToolStripMenuItem();
            m_tsmiFirmware.Text = "Update firmware on PSD";
            m_tsmiFirmware.Click += OnFirmwareUpdate;
            m_tsmiPopup.DropDownItems.Add(m_tsmiFirmware);

            // We want a notification when the user tried to save the
            // current database
            m_host.MainWindow.FileSaved += OnFileSaved;

            return true; // Initialization successful
        }

        /// <summary>
        /// The <c>Terminate</c> function is called by KeePass when
        /// you should free all resources, close open files/streams,
        /// etc. It is also recommended that you remove all your
        /// plugin menu items from the KeePass menu.
        /// </summary>
        public override void Terminate()
        {
            // Remove all of our menu items
            ToolStripItemCollection tsMenu = m_host.MainWindow.ToolsMenu.DropDownItems;
            tsMenu.Remove(m_tsSeparator);
            tsMenu.Remove(m_tsmiPopup);
            tsMenu.Remove(m_tsmiWrite);
            tsMenu.Remove(m_tsmiMerge);
            tsMenu.Remove(m_tsmiFirmware);

            // Important! Remove event handlers!
            m_host.MainWindow.FileSaved -= OnFileSaved;
        }

        private void OnWrite(object sender, EventArgs e)
        {
            if (!m_host.Database.IsOpen)
            {
                MessageBox.Show("You first need to open a database!", "PSD plugin");
                return;
            }
            var database = m_host.Database;
            
            ProtectedString masterkey = ((KcpPassword)m_host.Database.MasterKey.GetUserKey(typeof(KcpPassword))).Password;

            WriteBase form = new WriteBase(masterkey, database);
            form.ShowDialog();

        }

        private void OnMerge(object sender, EventArgs e)
        {
            if (!m_host.Database.IsOpen)
            {
                MessageBox.Show("You first need to open a database!", "PSD plugin");
                return;
            }


        }


        private void OnKeysSync(object sender, EventArgs e)
        {
            MessageBox.Show("Keys Sync");
        }


        private void OnFirmwareUpdate(object sender, EventArgs e)
        {
            MessageBox.Show("Update firmware");
        }



        private void OnFileSaved(object sender, FileSavedEventArgs e)
        {

        }




    }
}
