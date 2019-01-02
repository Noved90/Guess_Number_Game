using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Guess_The_Number_Game
{
    class Program
    {
        public static int tries = 0;
        public static int count = 10;
        static int GenNumber = 0;
        static void GenerateNumber()
        {
            Random rand = new Random();
            GenNumber = rand.Next(0, 5);
        }
        static int GetInput()
        {

            string inputString;
            Console.WriteLine("Guess a Number between 0-100");
            inputString = Console.ReadLine();
            int parseNum;
            Int32.TryParse(inputString, out parseNum);
            return parseNum;
        }

        static void CheckAnswer(int genNum, int answerNum)
        {
            tries++;
            
            if (answerNum == genNum && tries <= 10)
            {
                
                Console.WriteLine("Right! GOOD ANSWER! YOU WIN!");
                Thread.Sleep(1200);
               
                Environment.Exit(0);
            }
            if (answerNum != genNum && tries >= 10)
            {
                count--;
                Console.WriteLine("Try Again.");
                Thread.Sleep(2000);

                Environment.Exit(0);
            }
            if(genNum != answerNum && count   >= 0)
            {
                
                Console.WriteLine("You have" + " " + count.ToString() + " " + "tries left");
            }

        }
        static void GuessTheNum(int genNum)
        {

            int inputNum = GetInput();
            while (genNum != inputNum)
            {
               
                CheckAnswer(genNum, inputNum);
                UserQuit();
            }

        }
        static void UserQuit()
        {
           
            Console.WriteLine("DO you wnat to quit? press ESC ");
            
            if(Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            
            
            
        }
        static void ExecuteCode()
        {
          
            GuessTheNum(GenNumber);
           
        }

        static void Main(string[] args)
        {
            GenerateNumber();
            ExecuteCode();
        }
    }
}
