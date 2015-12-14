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
        public Card(string f, string s)
        {
            Face = f;
            Suit = s;
        }
        public override string ToString()
        {
            return string.Format("{0} of {1}", Face, Suit);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Card compCard = obj as Card;
            return (Face == compCard.Face) && (Suit == compCard.Suit);
        }
        public override int GetHashCode()
        {
            return Face.GetHashCode() ^ Suit.GetHashCode();
        }
    }
}
