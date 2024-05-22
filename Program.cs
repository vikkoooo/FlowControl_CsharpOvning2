﻿namespace FlowControl
{
	internal class Program
	{
		static void Main(string[] args)
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

		static void YouthOrSenior()
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

		static void RepeatTenTimes()
		{
			Console.WriteLine();
		}

		static void TheThirdWord()
		{
			Console.WriteLine();
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
