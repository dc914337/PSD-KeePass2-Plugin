using PsdBasesSetter.Repositories.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeePassLib;

namespace PSDPlugin.Converter
{
    internal class PwGroupConverter
    {
        private PwGroup _kpGroup;


        internal PwGroupConverter(PwGroup kpGroup)
        {
            this._kpGroup = kpGroup;
        }

        internal PassGroup ConvertToPSD()
        {
            PassGroup resGroup = new PassGroup();
            FillGroupInfo(resGroup);
            resGroup.PassGroups = GetSubgroups();
            resGroup.Passwords = GetPasses();
            return resGroup;
        }


        private void FillGroupInfo(PassGroup group)
        {
            group.Name = _kpGroup.Name;
            group.Notes = _kpGroup.Notes;
            group.UUID = _kpGroup.Uuid.ToString();
        }

        private PassGroupsList GetSubgroups()
        {
            var subgroups = new PassGroupsList();
            foreach (var subgroup in _kpGroup.Groups)
            {
                subgroups.Add(new PwGroupConverter(subgroup).ConvertToPSD());
            }
            return subgroups;
        }

        private PasswordList GetPasses()
        {
            var passes = new PasswordList();
            foreach (var kpPassItem in _kpGroup.Entries)
            {
                passes.AddPass(new PwItemConverter(kpPassItem).ConvertToPSD());
            }
            return passes;
        }


    }
}
