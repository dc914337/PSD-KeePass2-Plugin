using KeePassLib;
using PsdBasesSetter.Repositories.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSDPlugin.Converter
{
    class PwBaseConverter
    {
        PwDatabase _kpBase;


        public PwBaseConverter(PwDatabase kpBase)
        {
            _kpBase = kpBase;
        }


        public Base ConvertToPSD()
        {
            Base resBase = new Base();
            resBase.PassGroup = new PwGroupConverter(_kpBase.RootGroup).ConvertToPSD();
            return resBase;
        }

    }
}
