using System;

namespace CardSortShuffle
{
    public class cardMethods
    {
        public static void sortByAscending(ref Card[] cardDeck)
        {
            checkDeck(cardDeck);
            Card[] rankDeck = new Card[52];   //Creates temporary deck based on individual card "rankings"
            int tempRank = 0;
            foreach (Card c in cardDeck)
            {
                tempRank = 0;
                switch (c.Face.ToLower())
                {
                    case "two":
                        tempRank = 0;
                        break;
                    case "three":
                        tempRank = 1;
                        break;
                    case "four":
                        tempRank = 2;
                        break;
                    case "five":
                        tempRank = 3;
                        break;
                    case "six":
                        tempRank = 4;
                        break;
                    case "seven":
                        tempRank = 5;
                        break;
                    case "eight":
                        tempRank = 6;
                        break;
                    case "nine":
                        tempRank = 7;
                        break;
                    case "ten":
                        tempRank = 8;
                        break;
                    case "jack":
                        tempRank = 9;
                        break;
                    case "queen":
                        tempRank = 10;
                        break;
                    case "king":
                        tempRank = 11;
                        break;
                    case "ace":
                        tempRank = 12;
                        break;
                }
                switch (c.Suit.ToLower())
                {
                    case "clubs":
                        break;
                    case "diamonds":
                        tempRank += 13;
                        break;
                    case "hearts":
                        tempRank += 26;
                        break;
                    case "spades":
                        tempRank += 39;
                        break;
                }
                rankDeck[tempRank] = c;   //Each card is assigned to its sorted position in the temp deck
            }
            cardDeck = rankDeck;
        }

        public static Card[] sortByAscendingEZ(ref Card[] cardDeck) //Given a known defined output, there should be no problem creating a new deck and sending it back in the right order
        {
            return buildDeck();
        }

        static void checkDeck(Card[] cardDeck)  //function to error-check the deck prior to manipulation
        {
            int[] testDeck = new int[52];
            if (cardDeck.Length < 52)
                throw new System.ArgumentException("Deck cannot contain fewer than 52 cards");
            else if (cardDeck.Length > 52)
                throw new System.ArgumentException("Deck cannot contain more than 52 cards");
            foreach (Card c in cardDeck)  //These switch segments determine whether all 52 unique cards occupy the deck
            {
                if (c == null)
                {
                    throw new System.NullReferenceException("Card value cannot be null");
                }
                int deckPos = 0;
                switch (c.Face.ToLower())
                {
                    case "two":
                        deckPos = 0;
                        break;
                    case "three":
                        deckPos = 1;
                        break;
                    case "four":
                        deckPos = 2;
                        break;
                    case "five":
                        deckPos = 3;
                        break;
                    case "six":
                        deckPos = 4;
                        break;
                    case "seven":
                        deckPos = 5;
                        break;
                    case "eight":
                        deckPos = 6;
                        break;
                    case "nine":
                        deckPos = 7;
                        break;
                    case "ten":
                        deckPos = 8;
                        break;
                    case "jack":
                        deckPos = 9;
                        break;
                    case "queen":
                        deckPos = 10;
                        break;
                    case "king":
                        deckPos = 11;
                        break;
                    case "ace":
                        deckPos = 12;
                        break;
                    default:
                        throw new System.ArgumentException("Invalid card face in the deck.  Check input deck and try again");
                }
                switch (c.Suit.ToLower())
                {
                    case "clubs":
                        break;
                    case "diamonds":
                        deckPos += 13;
                        break;
                    case "hearts":
                        deckPos += 26;
                        break;
                    case "spades":
                        deckPos += 39;
                        break;
                    default:
                        throw new System.ArgumentException("Invalid card suit in the deck.  Check input deck and try again");
                }
                testDeck[deckPos] = 1;
            }
            foreach (int i in testDeck)
            {
                if (i != 1)
                    throw new System.ArgumentException("Cards missing from the deck.  Check input deck and try again");
            }

        }
        public static void shuffleDeck(ref Card[] cardDeck)
        {
            checkDeck(cardDeck);
            Random rand = new Random();
            int k = 0;
            while (k < 3)  //Shuffles 3 times for "poker-ready" deck
            {
                for (int i = cardDeck.Length - 1; i > 0; i--)  //Using a Knuth-Fisher-Yates shuffle
                {
                    int n = rand.Next(i + 1);
                    Card temp = cardDeck[i];
                    cardDeck[i] = cardDeck[n];
                    cardDeck[n] = temp;
                }
                k++;
            }
        }
        public static Card[] buildDeck()   //Creates a basic deck to work with
        {
            Card[] cardDeck = new Card[52];
            string[] faceValues = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] cardSuits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            int i = 0;
            foreach (string s in cardSuits)
            {
                foreach (string f in faceValues)
                {
                    cardDeck[i] = new Card(f, s);
                    i++;
                }
            }
            return cardDeck;
        }
    }
}
