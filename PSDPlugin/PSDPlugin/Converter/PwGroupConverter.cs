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
            group.UUID = _kpGroup.Uuid.ToHexString();
        }

        private PassGroupsList GetSubgroups()
        {
            var subgroups = new PassGroupsList();
            foreach (var subgroup in _kpGroup.Groups.Where(a=>a.EnableSearching==null || a.EnableSearching.Value))
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
                var convertedPass = new PwItemConverter(kpPassItem).ConvertToPSD();
                if (convertedPass.Pass.Length > 0)
                    passes.AddPass(convertedPass);
            }
            return passes;
        }


    }
}
