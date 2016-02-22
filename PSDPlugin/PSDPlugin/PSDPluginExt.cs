﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePass.Forms;
using KeePass.Resources;

using KeePassLib;
using KeePassLib.Security;

namespace PSDPlugin
{
    public sealed class PSDPluginExt : Plugin
    {
        // The sample plugin remembers its host in this variable.
        private IPluginHost m_host = null;

        private ToolStripSeparator m_tsSeparator = null;
        private ToolStripMenuItem m_tsmiPopup = null;
        private ToolStripMenuItem m_tsmiAddGroups = null;
        private ToolStripMenuItem m_tsmiAddEntries = null;

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
            m_tsmiPopup.Text = "Sample Plugin for Developers";
            tsMenu.Add(m_tsmiPopup);

            // Add menu item 'Add Some Groups'
            m_tsmiAddGroups = new ToolStripMenuItem();
            m_tsmiAddGroups.Text = "Add Some Groups";
            m_tsmiAddGroups.Click += OnMenuAddGroups;
            m_tsmiPopup.DropDownItems.Add(m_tsmiAddGroups);

            // Add menu item 'Add Some Entries'
            m_tsmiAddEntries = new ToolStripMenuItem();
            m_tsmiAddEntries.Text = "Add Some Entries";
            m_tsmiAddEntries.Click += OnMenuAddEntries;
            m_tsmiPopup.DropDownItems.Add(m_tsmiAddEntries);

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
            tsMenu.Remove(m_tsmiAddGroups);
            tsMenu.Remove(m_tsmiAddEntries);

            // Important! Remove event handlers!
            m_host.MainWindow.FileSaved -= OnFileSaved;
        }

        private void OnMenuAddGroups(object sender, EventArgs e)
        {

            var v = m_host.Database.RootGroup.GetEntries(true);
            MessageBox.Show(v.UCount.ToString());
            foreach (var entry in v)
            {
                MessageBox.Show(entry.Strings.Get(PwDefs.PasswordField).ReadString());
            }


            /*
            if (!m_host.Database.IsOpen)
            {
                MessageBox.Show("You first need to open a database!", "Sample Plugin");
                return;
            }

            Random r = new Random();

            // Create 10 groups
            for (int i = 0; i < 10; ++i)
            {
                // A new group with a random icon
                PwGroup pg = new PwGroup(true, true, "Sample Group #" + i.ToString(),
                    (PwIcon)r.Next(0, (int)(PwIcon.Count - 1)));

                m_host.Database.RootGroup.AddGroup(pg, true);
            }

            m_host.MainWindow.UpdateUI(false, null, true, m_host.Database.RootGroup,
                true, null, true);*/
        }

        private void OnMenuAddEntries(object sender, EventArgs e)
        {
            if (!m_host.Database.IsOpen)
            {
                MessageBox.Show("You first need to open a database!", "Sample Plugin");
                return;
            }

            // Create 10 groups
            for (int i = 0; i < 10; ++i)
            {
                // Create a new entry
                PwEntry pe = new PwEntry(true, true);

                // Set some of the string fields
                pe.Strings.Set(PwDefs.TitleField, new ProtectedString(false, "Sample Entry"));
                pe.Strings.Set(PwDefs.UserNameField, new ProtectedString(false,
                    Guid.NewGuid().ToString()));

                // Finally tell the parent group that it owns this entry now
                m_host.Database.RootGroup.AddEntry(pe, true);
            }

            m_host.MainWindow.UpdateUI(false, null, true, m_host.Database.RootGroup,
                true, null, true);
        }

        private void OnFileSaved(object sender, FileSavedEventArgs e)
        {
            MessageBox.Show("Notification received: the user has tried to save the current database to:\r\n" +
                m_host.Database.IOConnectionInfo.Path + "\r\n\r\nResult:\r\n" +
                (e.Success ? "Success" : "Failed"), "Sample Plugin",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
