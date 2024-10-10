using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCompanyAssets
{
    public class AssetManager
    {
        public List<Asset> AssetList { get; set; }
        public AssetManager()
        {
            AssetList = new List<Asset>();
        }

        //Adding new assets. Checking age of asset to get properties of age.
        public void AddAsset(Asset asset)
        {
            AssetList.Add(asset);
            asset.checkAge();
        }

        //Ordering assets by country and purchase date
        public List<Asset> OrderList()
        {
            var sortedAssets = AssetList
              .OrderBy(asset => asset.Country)
              .ThenBy(asset => asset.PurchasedDate)
              .ToList();
            return sortedAssets;
        }

        //Displays list of asset.
        //Red color if asset is old (older than 3 years, but newer than 3 years and 3 months).
        //Yellow color if its older than that.
        public void DisplayList()
        {
            var sortedAssets = OrderList();
            Message.GenerateMessage("-----------------------------------------------------------------------------------------------------------------", "Blue");
            Message.GenerateMessage("###### COMPANY ASSETS ######", "Blue");
            Message.GenerateMessage("RED=end of life passed  ", "Red", true);
            Message.GenerateMessage("YELLOW=end of life passed with more than 3 months", "Yellow");
            Message.GenerateMessage("-----------------------------------------------------------------------------------------------------------------", "Blue");

            Message.GenerateMessage("TYPE".PadRight(12) + "BRAND".PadRight(12) + "MODEL".PadRight(18) + "OFFICE".PadRight(12) + "PURCHASE DATE".PadRight(18) + "LOCAL PRICE".PadRight(12) + "CURRENCY".PadRight(12) + "PRICE IN USD", "Cyan");
            foreach (Asset asset in sortedAssets)
            {
                string assetInfo = asset.GetAssetType().PadRight(12) + asset.Brand.PadRight(12) + asset.Model.PadRight(18) + asset.Country.ToString().PadRight(12) + asset.PurchasedDate.ToString("yyyy-MM-dd").PadRight(18) + asset.Price.ConvertFromUSD().ToString("F2").ToString().PadRight(12) + asset.Price.Currency.ToString().PadRight(12) + asset.Price.Value;
                if (asset.IsOld)
                {
                    Message.GenerateMessage(assetInfo, "Red");
                }
                else if (asset.IsVeryOld)
                {
                    Message.GenerateMessage(assetInfo, "Yellow");
                }
                else Console.WriteLine(assetInfo);
            }

        }
    }
}
