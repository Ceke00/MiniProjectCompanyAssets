using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCompanyAssets
{
    internal class Phone : Asset
    {
        public Phone(Price price, DateTime purchasedDate, string brand, string model, Country country)
        {
            Price = price;
            PurchasedDate = purchasedDate;
            Brand = brand;
            Model = model;
            Country = country;
        }
        public override string GetAssetType()
        {
            return "Phone";
        }
    }
}
