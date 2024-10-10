using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCompanyAssets
{
    internal class UserInput
    {
        public static void GetUserInput(AssetManager assetManager)
        {
            //assetManager.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", Country.germany));
            //assetManager.AddAsset(new Phone(new Price(200, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Motorola", "X3", Country.usa));
            //assetManager.AddAsset(new Phone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", Country.usa));
            //assetManager.AddAsset(new Phone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", Country.usa));
            //assetManager.AddAsset(new Phone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", Country.sweden));
            //assetManager.AddAsset(new Phone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", Country.sweden));
            //assetManager.AddAsset(new Phone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", Country.sweden));
            //assetManager.AddAsset(new Phone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", Country.sweden));
            //assetManager.AddAsset(new Phone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", Country.germany));
            //assetManager.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", Country.usa));
            //assetManager.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", Country.usa));
            //assetManager.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", Country.usa));
            //assetManager.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", Country.usa));
            //assetManager.AddAsset(new Computer(new Price(500, Currency.USD), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", Country.usa));
            //assetManager.AddAsset(new Computer(new Price(1500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", Country.sweden));
            //assetManager.AddAsset(new Computer(new Price(1400, Currency.SEK), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", Country.sweden));
            //assetManager.AddAsset(new Computer(new Price(1300, Currency.SEK), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", Country.sweden));
            //assetManager.AddAsset(new Computer(new Price(1600, Currency.EUR), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", Country.germany));
            //assetManager.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", Country.germany));
            //assetManager.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", Country.germany));
            //assetManager.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-42), "Asus", "ROG 500", Country.germany));


            while (true)
            {
                //Getting properties of the asset
                TypeOfAsset assetType = GetEnumInput<TypeOfAsset>("What kind of asset? Computer or phone?");
                string brand = GetStringInput("What brand is the " + assetType + "?");
                string model = GetStringInput("What model is the " + brand + "?");
                decimal priceInUSD = GetDecimalInput("What did the " + assetType + " cost(in USD)?");
                Country country = GetEnumInput<Country>("Where is the " + assetType + "? USA, Germany or Sweden?");
                DateTime purchaseDate = GetDateInput("When was the " + assetType + " bought? Format date yyyy-MM-dd.");
                Currency currency = GetCurrency(country);

                //Creates object and adds to list
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

            //Displays list with assets, then menu with choce to continue or not
            assetManager.DisplayList();
            ContinueProgram.AskingUser(assetManager);

        }

        //Getting input of enum type
        public static T GetEnumInput<T>(string prompt) where T : struct
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (int.TryParse(input, out _))
                        {
                            throw new Exception("Not valid input, Don't use numbers.");
                        }
                        if (Enum.TryParse(input, true, out T result))

                        {
                            Message.GenerateMessage("You entered " + result, "Green");
                            return result;
                        }
                        else
                        {
                            throw new Exception("Not a correct choice, try again!");

                        }
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }
                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }

        //Getting input of decimal type (price)
        private static decimal GetDecimalInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (decimal.TryParse(input, out decimal price))
                        {
                            return price;
                        }
                        else
                        {
                            throw new FormatException("Not a correct number.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }
                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }
        //Getting input of string type
        private static string GetStringInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        return input;
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }
                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }

        //Getting input of DateTime type
        private static DateTime GetDateInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine().Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        if (DateTime.TryParse(input, out DateTime date))
                        {
                            return date;
                        }
                        else
                        {
                            throw new FormatException("Not a correct date. Format yyyy-MM-dd.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("No input registered. Try again!");
                    }
                }
                catch (Exception e)
                {
                    Message.GenerateMessage(e.Message, "Red");
                }
            }
        }

        //Getting currency according to current country
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
}
