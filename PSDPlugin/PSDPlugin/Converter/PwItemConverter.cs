using PsdBasesSetter.Repositories.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeePassLib;

namespace PSDPlugin.Converter
{
    internal class PwItemConverter
    {

        const string PASSWORD = "Password";
        private PwEntry _kpPassItem;

        internal PwItemConverter(PwEntry kpPassItem)
        {
            this._kpPassItem = kpPassItem;
        }

        internal PassItem ConvertToPSD()
        {
            PassItem passItem = new PassItem();
            passItem.UUID = _kpPassItem.Uuid.ToString();
            passItem.Tags = _kpPassItem.Tags.ToArray();
            passItem.Login = _kpPassItem.Strings.GetSafe("UserName").ReadString();
            passItem.Title = _kpPassItem.Strings.GetSafe("Title").ReadString();
            passItem.Description = _kpPassItem.Strings.GetSafe("Notes").ReadString();
            passItem.SetPassFromString(_kpPassItem.Strings.GetSafe(PASSWORD).ReadString());
            FillStringsWithoutSensitiveData(passItem);
            return passItem;
        }

        private void FillStringsWithoutSensitiveData(PassItem passItem)
        {
            foreach (var str in _kpPassItem.Strings.Where(a => a.Key != PASSWORD && !a.Value.IsProtected))
            {
                passItem.Strings.TryAdd(str.Key, str.Value.ReadString());
            }
        }
    }
}
