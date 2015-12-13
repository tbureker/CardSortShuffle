using System;

namespace CardSortShuffle
{
    public class Card
    {
        public string Face { get; }
        public string Suit { get; }
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
