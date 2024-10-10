using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCompanyAssets
{
    public abstract class Asset
    {
        public DateTime PurchasedDate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Price Price { get; set; }
        public Country Country { get; set; }
        public bool IsOld { get; set; } = false;
        public bool IsVeryOld { get; set; } = false;


        //Check if asset is older than 3 years (IsOld) or older than 3 years and 3 months (IsVeryOld)
        public void checkAge()
        {
            DateTime todaysDate = DateTime.Now;
            DateTime timeLimit = PurchasedDate.AddYears(3);
            DateTime criticalLimit = timeLimit.AddMonths(3);

            if (todaysDate >= criticalLimit)
            {
                IsVeryOld = true;
                IsOld = false;
            }
            else if (todaysDate >= timeLimit)
            {
                IsOld = true;
                IsVeryOld = false;
            }
        }

        public virtual string GetAssetType() { return ""; }
    }
}

