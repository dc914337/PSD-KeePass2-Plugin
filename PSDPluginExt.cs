using System;
using System.Collections.Generic;
using System.Text;
using KeePass.Plugins;


namespace PSDPlugin
{
    public class PSDPluginExt : Plugin
    {
        private IPluginHost m_host = null;

        public override bool Initialize(IPluginHost host)
        {
            m_host = host;
            return true;
        }
    }
}
