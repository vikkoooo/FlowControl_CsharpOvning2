using System;

namespace FlowControl
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool isRunning = true;

			while (isRunning)
			{
				MainMenu(); // Show Main Menu
				string choice = Console.ReadLine(); // Fetch choice

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
					case "4":
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
			Console.WriteLine("Main Menu");
			Console.WriteLine("1. Ungdom eller Pensionär");
			Console.WriteLine("2. Option 2");
			Console.WriteLine("3. Option 3");
			Console.WriteLine("0. Avsluta Programmet");
			Console.Write("Skriv ditt val: ");
		}

		static void YouthOrSenior()
		{
			Console.WriteLine("Här räknas priset ut beroende på ålder. Välj ett menyval");
			Console.WriteLine("1. Räkna ut för en person");
			Console.WriteLine("2. Räkna ut för ett helt sällskap");
		}

		static void RepeatTenTimes()
		{
			Console.WriteLine();
		}

		static void TheThirdWord()
		{
			Console.WriteLine();
		}
	}
}
