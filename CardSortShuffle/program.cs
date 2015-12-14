/// <summary>
/// Card Sorting & Shuffling methods
/// Written by Tony Bureker for Shiftwise
/// </summary>
using System;

namespace CardSortShuffle
{
    class Program
    {
        static void Main(string[] args)  //Quick run-through of the functions defined in the exercise
        {
            Card[] demoDeck = cardMethods.buildDeck();
            Console.WriteLine("Brand New Deck\n\n");
            foreach (Card c in demoDeck)
            {
                string temp = c.ToString();
                Console.WriteLine(temp);
            }
            cardMethods.shuffleDeck(ref demoDeck);
            Console.WriteLine("\nShuffled Deck\n\n");
            foreach (Card c in demoDeck)
            {
                string temp = c.ToString();
                Console.WriteLine(temp);
            }
            cardMethods.sortByAscending(ref demoDeck);
            Console.WriteLine("\nSorted Deck\n\n");
            foreach (Card c in demoDeck)
            {
                string temp = c.ToString();
                Console.WriteLine(temp);
            }
        }
    }
}
