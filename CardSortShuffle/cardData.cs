/// <summary>
/// Card Sorting & Shuffling methods
/// Written by Tony Bureker for Shiftwise
/// </summary>

using System;

namespace CardSortShuffle
{
    public class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }
        public Card()
        {
            throw new System.ArgumentException("No card data supplied");
        }
        public Card(string f, string s)
        {
            Face = f;
            Suit = s;
        }
        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
    }
}
