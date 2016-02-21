using System;
using System.Collections.Generic;
using System.Text;
using KeePass.Plugins;


namespace PSDPlugin
{
    public sealed class PSDPluginExt : Plugin
    {
        private IPluginHost m_host = null;

        public override bool Initialize(IPluginHost host)
        {
            throw new Exception("Sup!");

            m_host = host;
            return true;
        }
    }
}
