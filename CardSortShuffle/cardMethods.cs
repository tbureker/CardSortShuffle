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
                switch (c.Face())
                {
                    case "Two":
                        tempRank = 0;
                        break;
                    case "Three":
                        tempRank = 1;
                        break;
                    case "Four":
                        tempRank = 2;
                        break;
                    case "Five":
                        tempRank = 3;
                        break;
                    case "Six":
                        tempRank = 4;
                        break;
                    case "Seven":
                        tempRank = 5;
                        break;
                    case "Eight":
                        tempRank = 6;
                        break;
                    case "Nine":
                        tempRank = 7;
                        break;
                    case "Ten":
                        tempRank = 8;
                        break;
                    case "Jack":
                        tempRank = 9;
                        break;
                    case "Queen":
                        tempRank = 10;
                        break;
                    case "King":
                        tempRank = 11;
                        break;
                    case "Ace":
                        tempRank = 12;
                        break;
                }
                switch (c.Suit())
                {
                    case "Clubs":
                        break;
                    case "Diamonds":
                        tempRank += 13;
                        break;
                    case "Hearts":
                        tempRank += 26;
                        break;
                    case "Spades":
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
                throw new System.ArgumentException("Deck cannot contain fewer than 52 cards.");
            else if (cardDeck.Length > 52)
                throw new System.ArgumentException("Deck cannot contain more than 52 cards.");
            foreach (Card c in cardDeck)  //These switch segments determine whether all 52 unique cards occupy the deck
            {
                int deckPos = 0;
                switch (c.Face())
                {
                    case "Two":
                        deckPos = 0;
                        break;
                    case "Three":
                        deckPos = 1;
                        break;
                    case "Four":
                        deckPos = 2;
                        break;
                    case "Five":
                        deckPos = 3;
                        break;
                    case "Six":
                        deckPos = 4;
                        break;
                    case "Seven":
                        deckPos = 5;
                        break;
                    case "Eight":
                        deckPos = 6;
                        break;
                    case "Nine":
                        deckPos = 7;
                        break;
                    case "Ten":
                        deckPos = 8;
                        break;
                    case "Jack":
                        deckPos = 9;
                        break;
                    case "Queen":
                        deckPos = 10;
                        break;
                    case "King":
                        deckPos = 11;
                        break;
                    case "Ace":
                        deckPos = 12;
                        break;
                    default:
                        throw new System.ArgumentException("Invalid card face in the deck.  Check input deck and try again");
                }
                switch (c.Suit())
                {
                    case "Clubs":
                        break;
                    case "Diamonds":
                        deckPos += 13;
                        break;
                    case "Hearts":
                        deckPos += 26;
                        break;
                    case "Spades":
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
