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
				string choice = Console.ReadLine()!; // Fetch choice

				// Switch case depending on user case
				switch (choice)
				{
					case "1":
						YouthOrSenior();
						break;
					case "2":
						RepeatTenTimes();
						break;
					case "3":
						TheThirdWord();
						break;
					case "0":
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
			string choice = Console.ReadLine()!;

			switch (choice)
			{
				case "1":
					Console.WriteLine("Räknar ut för en person");
					FindPriceOnce();
					break;
				case "2":
					Console.WriteLine("Räknar ut för flera personer");
					// Try parse input to number
					Console.WriteLine("Skriv antalet personer i sällskapet");
					string nStr = Console.ReadLine()!; // get number of persons
					int totalSum = 0;
					bool success = int.TryParse(nStr, out int n);

					if (success && n > 0) // correct user input
					{
						for (int i = 0; i < n; i++)
						{
							int price = FindPriceOnce();
							totalSum += price;
						}
						Console.WriteLine($"Antal personer: {n}");
						Console.WriteLine($"Totalsumma: {totalSum}");
					}
					else
					{
						Console.WriteLine("Felaktig inmatning av antal personer i sällskapet, måste vara positivt och anges i siffror. Börjar om");
						YouthOrSenior();
					}
					break;
				case "0":
					Console.WriteLine("Går tillbaka till huvudmenyn");
					break;
				default:
					Console.WriteLine("Felaktigt menyval, försök igen");
					YouthOrSenior();
					break;
			}
		}

		private static void RepeatTenTimes()
		{
			Console.WriteLine("Skriv en text så upprepar jag den åt dig tio gånger");
			string text = Console.ReadLine()!;

			if (string.IsNullOrWhiteSpace(text))
			{
				Console.WriteLine("Du måste skriva något. Försöker igen");
				RepeatTenTimes();
			}
			else
			{
				StringBuilder sb = new StringBuilder();

				for (int i = 0; i < 10; i++)
				{
					sb.Append($"{i + 1}. {text}, ");
				}
				sb.Remove(sb.Length - 2, 2); // remove trailing ", "
				Console.WriteLine(sb.ToString()); // print result
			}
		}

		private static void TheThirdWord()
		{
			Console.WriteLine("Skriv en text så delar jag upp den vid varje blanksteg/space/mellanslag (ange minst 3 ord)");
			string text = Console.ReadLine()!;

			if (string.IsNullOrWhiteSpace(text))
			{
				Console.WriteLine("Du måste skriva något. Försöker igen");
				TheThirdWord();
			}
			else
			{
				var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries); // split string AND remove leading/trailing spaces

				// check for at least three words
				if (words.Length < 3)
				{
					Console.WriteLine("Du skriva minst tre ord. Försöker igen");
					TheThirdWord();
				}
				else
				{
					string thirdWord = words[2];
					Console.WriteLine($"Det tredje ordet var: {thirdWord}");
				}
			}
		}


		private static int FindPriceOnce()
		{
			Console.WriteLine("Ange en ålder i siffror");
			string ageStr = Console.ReadLine()!;

			// Try parse input to number
			bool success = int.TryParse(ageStr, out int age);
			if (success) // correct user input
			{
				if (age < 20 && age >= 0) // is youth and born
				{
					Console.WriteLine("Ungdomspris: 80kr");
					return 80;
				}
				else if (age > 64) // is senior
				{
					Console.WriteLine("Pensionärspris: 90kr");
					return 90;
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
	}
}
