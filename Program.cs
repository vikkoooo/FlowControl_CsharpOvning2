using System.Text;

namespace FlowControl
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			bool isRunning = true;

			while (isRunning)
			{
				MainMenu(); // Show Main Menu
				string choiceStr = Console.ReadLine()!; // Fetch choice as string

				// if invalid input, return user 
				if (!Enum.TryParse(choiceStr, out MainMenuChoice choice))
				{
					Console.WriteLine("Felaktig inmatning, försök igen.");
					continue; // break out of the loop but only once
				}

				// Switch case depending on user case
				switch (choice)
				{
					case MainMenuChoice.YouthOrSenior:
						YouthOrSenior();
						break;
					case MainMenuChoice.RepeatTenTimes:
						RepeatTenTimes();
						break;
					case MainMenuChoice.TheThirdWord:
						TheThirdWord();
						break;
					case MainMenuChoice.Exit:
						isRunning = false;
						Console.WriteLine("Avslutar applikationen");
						break;
					default:
						Console.WriteLine("Felaktigt menyval, försök igen.");
						break;
				}
			}
		}
		private static void MainMenu()
		{
			Console.WriteLine("Huvudmeny");
			Console.WriteLine("1. Ungdom eller Pensionär");
			Console.WriteLine("2. Repetera tio gånger");
			Console.WriteLine("3. Det tredje ordet");
			Console.WriteLine("0. Avsluta Programmet");
			Console.Write("Skriv ditt val: ");
		}

		private static void YouthOrSenior()
		{
			Console.WriteLine("Här räknas priset ut beroende på ålder. Välj ett menyval");
			Console.WriteLine("1. Räkna ut för en person");
			Console.WriteLine("2. Räkna ut för ett helt sällskap");
			Console.WriteLine("0. Backa till huvudmeny");

			string choiceStr = Console.ReadLine()!;
			if (!Enum.TryParse(choiceStr, out YouthOrSeniorChoice choice))
			{
				Console.WriteLine("Felaktig inmatning, försök igen.");
				YouthOrSenior();
				return;
			}

			switch (choice)
			{
				case YouthOrSeniorChoice.SinglePerson:
					Console.WriteLine("Räknar ut för en person");
					FindPriceSingle();
					break;
				case YouthOrSeniorChoice.Group:
					Console.WriteLine("Räknar ut för flera personer");
					FindPriceGroup();
					break;
				case YouthOrSeniorChoice.Back:
					Console.WriteLine("Går tillbaka till huvudmenyn");
					break;
				default:
					Console.WriteLine("Felaktigt menyval, försök igen");
					YouthOrSenior();
					break;
			}
		}

		// Function that finds the price for a certain age category and returns it
		private static int FindPriceSingle()
		{
			Console.WriteLine("Ange en ålder i siffror");
			string ageStr = Console.ReadLine()!;

			// Try parse input to number
			bool success = int.TryParse(ageStr, out int age);
			if (success) // correct user input
			{
				if (age < 20 && age >= 5) // is youth
				{
					Console.WriteLine("Ungdomspris: 80kr");
					return 80;
				}
				if (age >= 0 && age < 5) // child is free
				{
					Console.WriteLine("Barnpris under fem: 0kr");
					return 0;
				}
				else if (age > 64 && age <= 100) // is senior
				{
					Console.WriteLine("Pensionärspris: 90kr");
					return 90;
				}
				else if (age > 100) // super senior is free
				{
					Console.WriteLine("Pensionärspris över hundra: 0kr");
					return 0;
				}
				else if (age < 0) // invalid age (negative number)
				{
					Console.WriteLine("Felaktig inmatning av ålder, ålder kan inte vara negativ. Börjar om");
					YouthOrSenior();
					return 0;
				}
				else // is between 20 and 64, inclusive
				{
					Console.WriteLine("Standardpris: 120kr");
					return 120;
				}
			}
			else // invalid user input
			{
				Console.WriteLine("Felaktig inmatning av ålder, ange ålder i siffror. Börjar om");
				YouthOrSenior();
				return 0;
			}
		}

		// Function that calculates a total price for a group
		private static void FindPriceGroup()
		{
			Console.WriteLine("Skriv antalet personer i sällskapet");
			string nStr = Console.ReadLine()!; // get number of persons as a string
			bool success = int.TryParse(nStr, out int n); // Try parse input to number
			int totalSum = 0; // holding return value

			// correct user input
			if (success && n > 0)
			{
				// find price for each person and add to totalSum counter
				for (int i = 0; i < n; i++)
				{
					int price = FindPriceSingle();
					totalSum += price;
				}
				Console.WriteLine($"Antal personer: {n}");
				Console.WriteLine($"Totalsumma: {totalSum}");
			}
			else
			{
				Console.WriteLine("Felaktig inmatning av antal personer i sällskapet, måste vara positivt och anges i siffror. Börjar om");
				FindPriceGroup();
			}
		}

		// Function that repeats the text written by user ten times
		private static void RepeatTenTimes()
		{
			Console.WriteLine("Skriv en text så upprepar jag den åt dig tio gånger");
			var (text, success) = GetUserInput();

			// Check for valid user input, return user to same state otherwise
			if (success)
			{
				StringBuilder sb = new StringBuilder(); // stringbuilder is more efficient

				// build the string
				for (int i = 0; i < 10; i++)
				{
					sb.Append($"{i + 1}. {text}, ");
				}
				sb.Remove(sb.Length - 2, 2); // remove trailing ", "
				Console.WriteLine($"Resultat: {sb.ToString()}"); // print result
			}
			else
			{
				RepeatTenTimes(); // send user to the same function
			}
		}

		// Method to find the third word in user input
		private static void TheThirdWord()
		{
			Console.WriteLine("Skriv en text så delar jag upp den vid varje blanksteg/space/mellanslag (ange minst 3 ord)");
			var (text, success) = GetUserInput();

			// Check for valid user input, return user to same state otherwise
			if (success)
			{
				// split string with blankspaces AND at the same time remove leading/trailing spaces
				var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				// check for at least three words, otherwise return user to the same state
				if (words.Length > 2)
				{
					string thirdWord = words[2]; // third word is on index 2
					Console.WriteLine($"Det tredje ordet var: {thirdWord}");
				}
				else
				{
					Console.WriteLine("Du skriva minst tre ord. Försöker igen");
					TheThirdWord();
				}
			}
			else
			{
				TheThirdWord(); // return user to same state
			}
		}

		// Function gets user input and returns the string along with bool message if we have valid input
		private static (string text, bool success) GetUserInput()
		{
			string text = Console.ReadLine()!;
			if (string.IsNullOrWhiteSpace(text))
			{
				Console.WriteLine("Du måste skriva något. Försöker igen");
				return (text, false);
			}
			else
			{
				return (text, true);
			}
		}
	}
}

// For choices in the main menu
enum MainMenuChoice
{
	Exit = 0,
	YouthOrSenior = 1,
	RepeatTenTimes = 2,
	TheThirdWord = 3
}

// For choices in the sub menu "youth or senior case"
enum YouthOrSeniorChoice
{
	Back = 0,
	SinglePerson = 1,
	Group = 2
}