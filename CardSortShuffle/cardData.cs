using System;

namespace CardSortShuffle
{
    public class Card
    {
        string face;
        string suit;
        public Card()
        {
            throw new System.ArgumentException("No card data supplied");
        }
        public Card(string f, string s)
        {
            face = f;
            suit = s;
        }
        public override string ToString()
        {
            return string.Format("{0} of {1}", face, suit);
        }
        public string Face()
        {
            return face;
        }
        public string Suit()
        {
            return suit;
        }
    }
}
