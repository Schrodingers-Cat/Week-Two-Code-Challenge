using System;

namespace Disemvoweler
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Disemvoweler ("Nickleback is my favorite band. Their songwriting can’t be beat!");
			Console.WriteLine ();
			Disemvoweler ("How many bears could bear grylls grill if bear grylls could grill bears?");
			Console.WriteLine ();
			Disemvoweler ("I’m a code ninja, baby. I make the functions and I make the calls.");
			Console.WriteLine ();

			ChangeMaker (3.18);
			Console.WriteLine ();
			ChangeMaker (0.99);
			Console.WriteLine ();
			ChangeMaker (12.93);
			Console.WriteLine ();

			DiceThrower1000 ("10d6 3d20 100d6");
			Console.WriteLine ();

			GuessThatNumber ();
		}

		/// <summary>
		/// Prints input string without spaces or vowels
		/// </summary>
		/// <param name="input">Input string</param>
		static void Disemvoweler (string input)
		{

			string disemvoweled = "";
			string vowelspace = "";

			foreach (var c in input) {
				string s = c.ToString ().ToUpper ();
				if ("AEIOU".Contains (s)) {
					vowelspace = vowelspace + c;
				} else if (c == ' ') {
				} else {
					disemvoweled = disemvoweled + c;
				}
			}
			Console.Write ("Disemvoweled: " + disemvoweled);
			Console.WriteLine ("Vowels: " + vowelspace);
		}

		/// <summary>
		/// Gives change for amount of money
		/// </summary>
		/// <param name="amount">Amount of money.</param>
		static void ChangeMaker (double amount)
		{
			Console.WriteLine ("Change for "+amount+" is: ");
			//declare vars to store # of coins
			double quarters = 0;
			double dimes = 0;
			double nickels = 0;
			double pennies = 0;
			//test if amount is bigger than coin
			int amountC = Convert.ToInt32 (amount * 100);
			quarters = (int)(amountC / 25);
			amountC = (amountC % 25);

			dimes = (int)(amountC / 10);
			amountC = (amountC % 10);

			nickels = (int)(amountC / 05);
			amountC = (amountC % 05);

			pennies = (int)(amountC / 01);
			amountC = (amountC % 01);

			//Output values
			Console.WriteLine ("Quarters: " + quarters);
			Console.WriteLine ("Dimes: " + dimes);
			Console.WriteLine ("Nickels: " + nickels);
			Console.WriteLine ("Pennies: " + pennies);
		}

		/// <summary>
		/// Throws dice based on input number of faces and number of rolls
		/// </summary>
		/// <param name="NdM">N is the number of faces and M is the number of rolls. D is a placeholder.</param>
		static void DiceThrower1000 (string NdM)
		{
			//splits individual NdM commands by space and N's and M's by d's
			string[] splitTemp = NdM.Split ('d', ' ');
			//variables to add random numbers to and divide by number of iterations for averages
			double averageCount = 0;
			double averageCountTotal = 0;
			//first loop through the NdM commands, increment by two because commands span two indexes
			for (int i = 1; i < splitTemp.Length; i = i + 2) {
				//Takes interger versions of elements in string array and stores them in N and M. M is always one index ahead of N.
				int N = Convert.ToInt32 (splitTemp [i - 1]);
				int M = Convert.ToInt32 (splitTemp [i]);
				Console.WriteLine ("Throwing <" + N + "d" + M + ">");
				Console.Write ("Results: ");
				//declare randomnumber generator outside of loop so you don't reuse same seed
				Random randomNumberGenerator = new Random ();
				//Handle randoms for the number of rolls specified by NdM command
				for (int j = 0; j < M; j++) {
					int randomNumber = randomNumberGenerator.Next (1, N);
					Console.Write (randomNumber + " ");
					averageCount += randomNumber;
				}
				averageCount = (averageCount / M);
				Console.WriteLine ("The average roll on this throw is: " + averageCount);
				Console.WriteLine ();
				averageCountTotal += averageCount;
			}
			averageCountTotal = averageCountTotal / (splitTemp.Length * 0.5);
			Console.WriteLine ("The overall average is: " + averageCountTotal);
		}

		static void GuessThatNumber ()
		{
			//generate number <100

			//take user guess
			string guess;
			int guessNum;
			int guessCount = 0;
			bool playing = true;
			while (playing) {
				//generate number <100
				Random randomNumberGenerator = new Random ();
				int randomNumber = randomNumberGenerator.Next (1, 101);
				Console.WriteLine ("Enter your guess!");
				guess = Console.ReadLine ();
				//convert guess to int
				guessNum = Convert.ToInt32 (guess);
				//test for equals
				if (guessNum == randomNumber) {
					Console.WriteLine ("You win!");
					guessCount++;
					Console.WriteLine ("It took you " + guessCount + " guesses! Play again? Y/N");
					string play = Console.ReadLine ();
					if (play == "n" || play == "N") {
						playing = false;
					}
				}
			//test for too big
			else if (guessNum > randomNumber) {
					Console.WriteLine ("You guess was too high.");
					if ((randomNumber - guessNum) < 10) {
						Console.WriteLine ("Hot!");
					} else if (randomNumber - guessNum > 40) {
						Console.WriteLine ("Cold!");
					}
					guessCount++;
				}
			//test for too small
			else if (guessNum < randomNumber) {
					Console.WriteLine ("You guess was too low.");
					if ((randomNumber - guessNum) < 10) {
						Console.WriteLine ("Hot!");
					} else if (randomNumber - guessNum > 40) {
						Console.WriteLine ("Cold!");
					}
					guessCount++;
				}
			}

		}

	}
}
