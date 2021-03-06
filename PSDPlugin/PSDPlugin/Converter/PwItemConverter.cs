﻿using PsdBasesSetter.Repositories.Objects;
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

       public const string PASSWORD = "Password";
        private PwEntry _kpPassItem;

        internal PwItemConverter(PwEntry kpPassItem)
        {
            this._kpPassItem = kpPassItem;
        }

        internal PassItem ConvertToPSD()
        {
            PassItem passItem = new PassItem();
            passItem.UUID = _kpPassItem.Uuid.ToHexString();
            passItem.Tags = _kpPassItem.Tags.ToArray();
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
