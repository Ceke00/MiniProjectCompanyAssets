using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectCompanyAssets
{
    internal class ContinueProgram
    {
        //Give choice to user to continue adding asset or to quit
        public static void AskingUser(AssetManager assetManager)
        {
            while (true)
            {
                try
                {
                    Message.GenerateMessage("--------------------------------------", "Cyan");
                    Message.GenerateMessage("| Enter a new asset (A)  |  Quit (Q) |", "Cyan");
                    Message.GenerateMessage("--------------------------------------", "Cyan");

                    string input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input))
                    {
                        if (int.TryParse(input, out _))
                        {
                            throw new Exception("Not valid input, Don't use numbers.");
                        }
                        if (Enum.TryParse(input, true, out MenuOption choice))
                        {
                            if (choice == MenuOption.q)
                            {
                                Console.WriteLine("Exiting program...");
                                Environment.Exit(0);
                            }
                            else if (choice == MenuOption.a) { UserInput.GetUserInput(assetManager); }

                        }
                        else { throw new Exception("Not valid coice. Write A or Q."); }

                    }
                    else { throw new Exception("Empty input. Try again!"); }
                }
                catch (Exception e) { Message.GenerateMessage(e.Message, "Red"); }

            }
        }
    }
}
