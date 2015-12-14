/// <summary>
/// Card Sorting & Shuffling program
/// Written by Tony Bureker for Shiftwise
/// </summary>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardSortShuffle;

namespace cardSortShuffleTest
{
    [TestClass]
    public class cardTest
    {
        Card[] trustedDeck = cardMethods.buildDeck();
        [TestMethod]
        public void happyPath()  //Basic happy path test, tests shuffle & sort functions
        {
            Card[] testDeck = cardMethods.buildDeck();
            cardMethods.shuffleDeck(ref testDeck);
            int differentCard = 0;
            for (int i = 0; i < trustedDeck.Length; i++)  //Verifies the test deck against the trusted deck. Fails test on null card and counts number of differences.
            {
                Assert.IsNotNull(testDeck[i]);
                if (testDeck[i] != trustedDeck[i]) differentCard += 1;
            }
            if (differentCard < 30) Assert.Fail("Deck not shuffled properly");  //fails the test if a sufficient number of cards are the same
            cardMethods.sortByAscending(ref testDeck);
            for (int i = 0; i < trustedDeck.Length; i++)
            {
                Assert.AreEqual(trustedDeck[i], testDeck[i]);
            }
        }

        [TestMethod]
        public void cardCreate()  //Tests card creation & ToString functionality
        {
            Card testCard = new Card("Two", "Clubs");
            Assert.AreEqual("Two", testCard.Face);
            Assert.AreEqual("Clubs", testCard.Suit);
            Assert.AreEqual("Two of Clubs", testCard.ToString());
        }

        [TestMethod]
        public void cardEquality() //Tests card Equal overload 
        {
            Card testCard1 = new Card("Two", "Spades");
            Card testCard2 = new Card("Two", "Spades");
            Assert.AreEqual(testCard1, testCard2);
            testCard2 = new Card("Two", "Diamonds");
            Assert.AreNotEqual(testCard1, testCard2);
            testCard2 = new Card("Three", "Spades");
            Assert.AreNotEqual(testCard1, testCard2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void largeDeckShuffle()  //Tries to shuffle a deck that has too many cards
        {
            Card[] largeDeck = new Card[53];
            for (int i = 0; i < largeDeck.Length - 1; i++)
            {
                largeDeck[i] = trustedDeck[i];
            }
            largeDeck[52] = new Card("Two", "Diamonds");
            cardMethods.shuffleDeck(ref largeDeck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void smallDeckSort()  //Tries to sort a deck that has too few cards
        {
            Card[] smallDeck = new Card[25];
            for (int i = 0; i < smallDeck.Length; i++)
            {
                smallDeck[i] = trustedDeck[i];
            }
            cardMethods.sortByAscending(ref smallDeck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void invalidCardFaceShuffle()  //Tries to shuffle a deck with an invalid card face
        {
            Card[] invalidFaceDeck = cardMethods.buildDeck();
            invalidFaceDeck[25] = new Card("Seventeen", "Diamonds");
            cardMethods.shuffleDeck(ref invalidFaceDeck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void invalidCardSuitSort()  //Tries to sort a deck with an invalid suit
        {
            Card[] invalidSuitDeck = cardMethods.buildDeck();
            invalidSuitDeck[18] = new Card("Two", "Stars");
            cardMethods.sortByAscending(ref invalidSuitDeck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void duplicateCardShuffle()  //Tries to shuffle a deck with a duplicate card
        {
            Card[] duplicateCardDeck = cardMethods.buildDeck();
            duplicateCardDeck[32] = new Card("Two", "Clubs");
            cardMethods.shuffleDeck(ref duplicateCardDeck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void emptyCardSort()  //Tries to sort a deck with an empty card
        {
            Card[] emptyCardDeck = cardMethods.buildDeck();
            emptyCardDeck[45] = new Card("", "");
            cardMethods.sortByAscending(ref emptyCardDeck);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void nullDeckSort()  //Tries to sort a deck with null cards
        {
            Card[] nullDeck = new Card[52];
            cardMethods.sortByAscending(ref nullDeck);
        }

        [TestMethod]
        public void lowerCaseSort()  //Tries to sort a deck with lower case faces & suits
        {
            Card[] lowerCaseDeck = cardMethods.buildDeck();
            for (int i = 0; i < lowerCaseDeck.Length; i++)
            {
                lowerCaseDeck[i] = new Card(lowerCaseDeck[i].Face.ToLower(), lowerCaseDeck[i].Suit.ToLower());
            }
            cardMethods.sortByAscending(ref lowerCaseDeck);
        }

        /*
                     
                    
                //These tests are redundant.  They are commented out because in a black-box testing scenario I wouldn't know that both Shuffle and Sort call the same "checkDeck" function, and so would be included in a testing suite.

                [TestMethod]
                [ExpectedException(typeof(ArgumentException))]
                public void largeDeckSort()
                {
                    Card[] largeDeck = new Card[53];
                    for (int i = 0; i < largeDeck.Length - 2; i++)
                    {
                        largeDeck[i] = trustedDeck[i];
                    }
                    largeDeck[52] = new Card("Two", "Diamonds");
                    cardMethods.sortByAscending(ref largeDeck);
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentException))]
                public void smallDeckShuffle()
                {
                    Card[] smallDeck = new Card[25];
                    for (int i = 0; i < smallDeck.Length; i++)
                    {
                        smallDeck[i] = trustedDeck[i];
                    }
                    cardMethods.shuffleDeck(ref smallDeck);
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentException))]
                public void invalidCardFaceSort()
                {
                    Card[] invalidFaceDeck = cardMethods.buildDeck();
                    invalidFaceDeck[25] = new Card("Seventeen", "Diamonds");
                    cardMethods.sortByAscending(ref invalidFaceDeck);
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentException))]
                public void invalidCardSuitShuffle()
                {
                    Card[] invalidSuitDeck = cardMethods.buildDeck();
                    invalidSuitDeck[25] = new Card("Two", "Stars");
                    cardMethods.shuffleDeck(ref invalidSuitDeck);
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentException))]
                public void duplicateCardSort()
                {
                    Card[] duplicateCardDeck = cardMethods.buildDeck();
                    duplicateCardDeck[25] = new Card("Two", "Clubs");
                    cardMethods.sortByAscending(ref duplicateCardDeck);
                }

                [TestMethod]
                [ExpectedException(typeof(ArgumentException))]
                public void emptyCardShuffle()
                {
                    Card[] emptyCardDeck = cardMethods.buildDeck();
                    emptyCardDeck[45] = new Card("", "");
                    cardMethods.shuffleDeck(ref emptyCardDeck);
                }

                [TestMethod]
                [ExpectedException(typeof(NullReferenceException))]
                public void nullDeckShuffle()  
                {
                    Card[] nullDeck = new Card[52];
                    cardMethods.shuffleDeck(ref nullDeck);
                }

                [TestMethod]
                public void lowerCaseShuffle()  
                {
                    Card[] lowerCaseDeck = cardMethods.buildDeck();
                    for (int i = 0; i < lowerCaseDeck.Length; i++)
                    {
                        lowerCaseDeck[i] = new Card(lowerCaseDeck[i].Face.ToLower(), lowerCaseDeck[i].Suit.ToLower());
                    }
                    cardMethods.shuffleDeck(ref lowerCaseDeck);
                }

            */
    }
}
