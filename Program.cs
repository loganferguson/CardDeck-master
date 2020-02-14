using System;
using System.Collections.Generic;
namespace CardDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck d = new Deck();
            

            foreach(CardSuit cs in Enum.GetValues(typeof(CardSuit)))
            {
                foreach(CardValue cv in Enum.GetValues(typeof(CardValue)))
                {
                    d.AddCard(new Card(cs, cv));
                }
            }
                DisplayMenu();
                string menuSelect = Console.ReadLine();

            // THIS IS THE GAME PLAY STUFF

         if (menuSelect == "w" || menuSelect == "W")
            {
                d.ShuffleDeck();
                d.Deal();
                bool stillPlaying = true;
                int handIndex = 0;
                while (stillPlaying == true && Deck.Hand1.Count > 0 && Deck.Hand2.Count > 0)
                {
                    Console.Write($"\nEnter (p) to play card: ");
                    string playInput = Console.ReadLine();
                    Console.WriteLine("");
                    if (playInput== "p" || playInput == "P")
                    {
                        Console.WriteLine($"Your Card: {d.PrintYourCard(handIndex)}");
                        Console.WriteLine($"Enemy Card: {d.PrintEnemyCard(handIndex)}");
                        if (Deck.Hand1[handIndex] > Deck.Hand2[handIndex])
                        {
                            Console.WriteLine("--------Round won!--------");
                            Deck.Hand1.Add(Deck.Hand2[handIndex]);
                        }
                        else if (Deck.Hand1[handIndex] < Deck.Hand2[handIndex])
                        {
                            Console.WriteLine("--------Round lost--------. :( ");
                            Deck.Hand2.Add(Deck.Hand1[handIndex]);
                        }
                        else if (Deck.Hand1[handIndex] == Deck.Hand2[handIndex])
                        {
                            bool war = true;
                            while (war == true)
                            {
                                Console.WriteLine("--------WAR!!!--------");
                                handIndex += 3;
                                d.PrintWar(handIndex);
                                if (Deck.Hand1[handIndex] > Deck.Hand2[handIndex])
                                {
                                    Console.WriteLine("----YOU WON THE WAR!----");
                                    Deck.Hand1.Add(Deck.Hand2[handIndex]);
                                    Deck.Hand1.Add(Deck.Hand2[handIndex - 1]);
                                    Deck.Hand1.Add(Deck.Hand2[handIndex - 2]);
                                    war = false;
                                }
                                else if (Deck.Hand1[handIndex] < Deck.Hand2[handIndex])
                                {
                                    Console.WriteLine("----YOU LOST THE WAR!----");
                                    Deck.Hand2.Add(Deck.Hand1[handIndex]);
                                    Deck.Hand2.Add(Deck.Hand1[handIndex - 1]);
                                    Deck.Hand2.Add(Deck.Hand1[handIndex - 2]);
                                    war = false;
                                }
                            }
                        }
                        
                    }

                    handIndex++;
                }         
            }           
        }    
        static void DisplayMenu()
            {
                Console.WriteLine("  -----       GAME MENU        -----   ");
                Console.WriteLine("   -----                      -----    ");
                Console.WriteLine("    ---Enter (W) to declare WAR!--     ");
                Console.WriteLine("     ----         --         ----      ");
                Console.WriteLine("      ---- Enter (E) to exit----       ");
                Console.WriteLine("       ----     ------     ----        ");
                Console.WriteLine("        ----   --------   ----         ");
                Console.WriteLine("         ---- ----  ---- ----          ");
                Console.WriteLine("          -------    -------           ");
                Console.WriteLine("           -----      -----            ");
            }

    }
}
