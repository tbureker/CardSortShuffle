﻿using System;
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
            Assert.AreNotSame(trustedDeck, testDeck);
            cardMethods.sortByAscending(ref testDeck);
            for (int i = 0; i < trustedDeck.Length - 1; i++)
            {
                Assert.AreEqual(trustedDeck[i].ToString(), testDeck[i].ToString());
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void largeDeckShuffle()  //Tries to shuffle a deck that has too many cards
        {
            Card[] largeDeck = new Card[53];
            for (int i = 0; i < largeDeck.Length-2; i++)
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

            */
    }
}