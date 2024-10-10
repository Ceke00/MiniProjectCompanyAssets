
//Asset Tracking database.
//Input possibilities
// - purchase date
// -price,
// -model name
//-brand
//office
//price in dollars

// Each item should have currency according to country


using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Xml.Schema;

class Program
{
    public static void Main(string[] args)
    {
        AssetManager assetManager = new AssetManager();
        UserInput.GetUserInput(assetManager);
    }
}

public class UserInput
{
    public static void GetUserInput(AssetManager assetManager)
    {
        assetManager.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", Country.germany));
        assetManager.AddAsset(new Phone(new Price(200, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Motorola", "X3", Country.usa));
        assetManager.AddAsset(new Phone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", Country.usa));
        assetManager.AddAsset(new Phone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", Country.usa));
        assetManager.AddAsset(new Phone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", Country.sweden));
        assetManager.AddAsset(new Phone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", Country.sweden));
        assetManager.AddAsset(new Phone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", Country.sweden));
        assetManager.AddAsset(new Phone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", Country.sweden));
        assetManager.AddAsset(new Phone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", Country.germany));
        assetManager.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", Country.usa));
        assetManager.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", Country.usa));
        assetManager.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", Country.usa));
        assetManager.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", Country.usa));
        assetManager.AddAsset(new Computer(new Price(500, Currency.USD), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", Country.usa));
        assetManager.AddAsset(new Computer(new Price(1500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", Country.sweden));
        assetManager.AddAsset(new Computer(new Price(1400, Currency.SEK), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", Country.sweden));
        assetManager.AddAsset(new Computer(new Price(1300, Currency.SEK), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", Country.sweden));
        assetManager.AddAsset(new Computer(new Price(1600, Currency.EUR), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", Country.germany));
        assetManager.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", Country.germany));
        assetManager.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", Country.germany));
        assetManager.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-42), "Asus", "ROG 500", Country.germany));

        ///ta emot inpbrand, model, price in usd, country/office, purchase date
        while (true)
        {
            TypeOfAsset assetType;
            string brand;
            string model;
            decimal priceInUSD;
            Country country;
            DateTime purchaseDate;
            Currency currency;

            //Asset type
            while (true)
            {
                try
                {
                    Console.WriteLine("What kind of asset? Computer or phone?");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (Validator.ValidateIfEmpty(input))
                    {
                        if (int.TryParse(input, out _))
                        {
                            throw new Exception("Not valid input, Don't use numbers.");
                        }
                        if (Enum.TryParse(input, out assetType))
                        {
                            Message.GenerateMessage("You entered " + assetType, "Green");

                            break;
                        }
                        else { throw new Exception("Not valid input. Write computer or phone."); }
                    }
                    else { throw new ArgumentException("No input registered. Try again!"); }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }
            //Brand
            while (true)
            {
                try
                {
                    Console.WriteLine("What brand is the " + assetType + "?");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (Validator.ValidateIfEmpty(input))
                    {
                        brand = input;
                        break;
                    }
                    else { throw new ArgumentException("No input registered. Try again!"); }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }
            //Model
            while (true)
            {
                try
                {
                    Console.WriteLine("What model?");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (Validator.ValidateIfEmpty(input))
                    {
                        model = input;
                        break;
                    }
                    else { throw new ArgumentException("No input registered. Try again!"); }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }
            //Price in USD
            while (true)
            {
                try
                {
                    Console.WriteLine("What did the " + assetType + " cost(in USD)?");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (Validator.ValidateIfEmpty(input))
                    {
                        if (Validator.ValidateDecimal(input))
                        {
                            priceInUSD = decimal.Parse(input);
                            break;
                        }
                        else { throw new FormatException("Not a correct number."); }
                    }
                    else { throw new ArgumentException("No input registered. Try again!"); }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }
            //Country
            while (true)
            {
                try
                {
                    Console.WriteLine("Where is the " + assetType + "? USA, Germany or Sweden?");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (Validator.ValidateIfEmpty(input))
                    {
                        if (int.TryParse(input, out _))
                        {
                            throw new Exception("Not valid input, Don't use numbers.");
                        }
                        if (Enum.TryParse(input, out country))
                        {
                            Message.GenerateMessage("You entered " + country, "Green");

                            break;
                        }
                        else { throw new Exception("Not valid input. Write USA, Germany or Sweden."); }
                    }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("When was the " + assetType + " bought? Format date yyyy-MM-dd.");
                    string input = Console.ReadLine().ToLower().Trim();
                    if (Validator.ValidateIfEmpty(input))
                    {
                        if (DateTime.TryParse(input, out DateTime date))
                        {
                            purchaseDate = date;
                            break;
                        }

                        else { throw new FormatException("Not valid format. Use format yyyy-MM-dd."); }
                    }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
            }


            currency = GetCurrency(country);


            try
            {
                if (assetType == TypeOfAsset.computer)
                {
                    assetManager.AddAsset(new Computer(new Price(priceInUSD, currency), purchaseDate, brand, model, country));

                    break;
                }
                else if (assetType == TypeOfAsset.phone)
                {
                    assetManager.AddAsset(new Phone(new Price(priceInUSD, currency), purchaseDate, brand, model, country));
                    break;
                }
                else { throw new Exception("Couldn't add the asset"); }
            }
            catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }
        }

        assetManager.DisplayList();
    }
    public static Currency GetCurrency(Country country)
    {
        switch (country)
        {
            case Country.usa: return Currency.USD;
            case Country.sweden: return Currency.SEK;
            case Country.germany: return Currency.EUR;
            default:
                throw new ArgumentException("Invalid country");
        }
    }
}
internal class Validator
{
    //Control if string is empty
    public static bool ValidateIfEmpty(string inputString)
    {
        return !string.IsNullOrEmpty(inputString);

    }
    //Control if value is a decimal
    public static bool ValidateDecimal(string inputPrice)
    {
        return decimal.TryParse(inputPrice, out decimal price);
    }

    public static bool ValidatedEnum<T>(string inputEnum) where T : struct
    {
        if (Enum.TryParse(inputEnum, out T result) && !int.TryParse(inputEnum, out _)) { return true; }
        else { return false; }
    }

    public static bool ValidateDate(string inputString)
    {
        //kolla hur kontrollera datum
        return true;
    }
}


public enum TypeOfAsset { computer, phone }
public enum Country { usa, germany, sweden }
public enum MenuOption { q, a }

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


public class Computer : Asset
{
    public Computer()
    {
    }

    public Computer(Price price, DateTime purchasedDate, string brand, string model, Country country)
    {
        Price = price;
        PurchasedDate = purchasedDate;
        Brand = brand;
        Model = model;
        Country = country;
    }
    public override string GetAssetType()
    {
        return "Computer";
    }
}

public class Phone : Asset
{
    public Phone()
    {
    }

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

public enum Currency
{
    USD,
    EUR,
    SEK
}
public class Price
{
    public Price(decimal value, Currency currency)
    {
        Value = value;
        Currency = currency;
    }

    public decimal Value { get; set; }
    public Currency Currency { get; set; }

    //Convert from USD to EURO and SEK
    public decimal ConvertFromUSD()
    {
        decimal rateEURO = 0.91M;
        decimal rateSEK = 10.397M;
        decimal newValue = Value;
        if (Currency == Currency.EUR)
        {
            newValue = Value * rateEURO;
        }
        if (Currency == Currency.SEK)
        {
            newValue = Value * rateSEK;
        }
        return newValue;
    }
}

public class AssetManager
{
    public List<Asset> AssetList { get; set; }
    public AssetManager()
    {
        AssetList = new List<Asset>();
    }


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

    //Displyas list of asset.
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
public class Message
{
    //Generating colorized messages 
    public static void GenerateMessage(string message, string color, bool sameLine = false)
    {
        switch (color)
        {
            case "Red": Console.ForegroundColor = ConsoleColor.Red; break;
            case "Green": Console.ForegroundColor = ConsoleColor.Green; break;
            case "Yellow": Console.ForegroundColor = ConsoleColor.Yellow; break;
            case "Cyan": Console.ForegroundColor = ConsoleColor.Cyan; break;
            case "Blue": Console.ForegroundColor = ConsoleColor.Blue; break;
        }
        if (sameLine) Console.Write(message);
        else Console.WriteLine(message);
        Console.ResetColor();
    }
}
