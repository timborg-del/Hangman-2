using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = { "sverige", "norge", "finland", "damnark" };                                   // Hemliga ord som är random             array
            words[0] = "sverige";
            words[1] = "norge";
            words[2] = "finland";
            words[3] = "danmark";

            var random = new Random();                                                      // deklarerar en random
            int index = random.Next(words.Length);                                          // deklarerar en index säger att indexen ska vara random

            string word = words[index];                                                     // nu vill vi plocka ut det ordet som kommit ut ur random och sparar den i sträng som heter word

            int health = 10;                                                                // 10 försök.                            sant eller flaskt

            Console.WriteLine("Welcome To My Hang Man");                                    // skriv till användre
            Console.WriteLine("What country do i think of in sacandinavia");
            Console.WriteLine("You have {0} in health", health);
            //---------------------------------------------------------------------------------------------------------------
            StringBuilder guessedLetters = new StringBuilder();                            // gissade bokstäver sätts in i StringBuilder
            string progress = CheckProgress(word, guessedLetters.ToString());              // jag behöver skriva en metod för att att skriva ut _ och sätta bokstäver som finns i strängar

            Console.WriteLine(progress);                                                   // Skriver ut fel eller rätt bokstav och _ alltså själva progressen 

            while (health > 0)
            {
                string input = Console.ReadLine();
                if (guessedLetters.ToString().Contains(input))
                {
                    Console.WriteLine(" you have enter letter {0} already", input);          // Skriver ut prövade bokstäver
                    Console.WriteLine("Try another Letter");

                }
                guessedLetters.Append(input);                                               // jag behöver en metod för att kolla om bokstäver finns i strängarna
                if (CheckCorrectWord(word, guessedLetters.ToString()))
                {
                    Console.WriteLine(word + "\n\n YOU GOT IT!!!");
                    break;

                }
                if (word.Contains(input))                                                   // om ordet ordet inhåller användarens val.
                {
                    Console.WriteLine("Keep Going");                                        // skriv  
                    progress = CheckProgress(word, guessedLetters.ToString());              // Skickar in bokstaven i CheckProgress 
                    Console.WriteLine(progress);                                            // 
                    continue;
                }
                Console.WriteLine("Letter is not in the Word      " + input);
                health--;
                Console.WriteLine("you have in health {0}", health);

                Console.WriteLine();
                if (health == 0)
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
            Console.ReadKey();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------
        static bool CheckCorrectWord(string word, string guessedLetters)
        {
            foreach (char wordLetter in word)     // delar upp strängen word till enskilda bokstäver foreach för att det är tydligare i koden vad jag gör.
            {
                if (!guessedLetters.Contains(wordLetter.ToString()))  // Om Inte bokstäverna finns i strängen 
                {
                    return false; //retunerar vi till inte sant.
                }
            }
            return true;
        }
        static string CheckProgress(string word, string guessedLetters)    // Glöm inte vart foreach och if {} börjar och slutar 
        {
            StringBuilder progress = new StringBuilder();

            foreach (char letter in word)                                 // för varje bokstav i ordet 
            {
                if (guessedLetters.Contains(letter.ToString()))          // om gissade bokstäver innehåller ordet
                {
                    progress.Append(letter);                             // så lägger vi till bokstaven
                    continue;
                }

                progress.Append("_ ");
            }
            return progress.ToString();
        }
    }
}

                
                          
        


    

            
            
            
            
            
            
            
            
        
        
        
        
 
    


        
        

                
                

                


