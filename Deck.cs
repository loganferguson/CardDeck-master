using System;
using System.Collections.Generic;

namespace CardDeck
{
    class Deck
    {
        List<Card> Cards { get; set; }
        public static List<Card> Hand1 = new List<Card>();
        public static List<Card> Hand2 = new List<Card>();
        public int NumCards { get => Cards.Count; }

        public Deck()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card newCard)
        {
            Cards.Add(newCard);
        }

        public Card RemoveTopCard()
        {
            Card cardToRemove = Cards[0];
            Cards.RemoveAt(0);
            return cardToRemove;
        }

        public void PrintDeck()
        {
            foreach(Card c in Cards)
            {
                System.Console.WriteLine(c);
            }
        }

        public Card PrintYourCard(int handIndex)
        {
            return Hand1[handIndex];
        }

        public Card PrintEnemyCard(int handIndex)
        {
            return Hand2[handIndex];
        }

        public void PrintWar(int handIndex)
        {
            Console.WriteLine("----facedown cards----");
            Console.WriteLine("----facedown cards----");
            Console.WriteLine($"You: {Hand1[handIndex]}");
            Console.WriteLine($"Enemy: {Hand2[handIndex]}");
        }

        public void ShuffleDeck()
        {
            Random r = new Random();

            for (int i = 0; i < 10000 ; i++)
            {
                int min = 0;
                int max = 52;
                int randomPlace = (r.Next(min, max));
                Card randomCard = Cards[randomPlace];
                this.Cards.Add(randomCard);
                this.Cards.RemoveAt(randomPlace);
            }
        }

        public void Deal()
        {
            for (int i = 0; i < NumCards; i+=2)
            {
                Hand1.Add(Cards[i]);
                Hand2.Add(Cards[i+1]);
            }
        }

        public void SortDeck()
        {
            Cards.Sort();
        }
    }
}