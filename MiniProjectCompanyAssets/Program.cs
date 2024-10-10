using MiniProjectCompanyAssets;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Xml.Schema;

class Program
{
    public static void Main(string[] args)
    {
        AssetManager assetManager = new AssetManager();
        AddInitialAssets(assetManager);
        UserInput.GetUserInput(assetManager);
    }
    //adding data at begining of program
    public static void AddInitialAssets(AssetManager assetManager)
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
    }
}
