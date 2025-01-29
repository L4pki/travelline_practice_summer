import { Deck } from "../entities/Deck";
import { Card } from "../entities/Card";

const sampleCard: Card = {
  id: 1,
  word: "Sample",
  translate: "Образец",
};

const sampleDeck: Deck = {
  id: 1,
  name: "Sample Deck",
  cards: [sampleCard],
};

describe("Deck functions", () => {
  describe("AddNewCard", () => {
    it("should add a new card to the deck if it does not already exist", () => {
      const newCard: Card = { id: 2, word: "New Card", translate: "Новая карта" };
      const updatedDeck = Deck.AddNewCard(newCard, sampleDeck);
      expect(updatedDeck.cards).toContainEqual(newCard);
    });

    it("should not add a new card if it already exists in the deck by id", () => {
      const newCard: Card = { id: 1, word: "Duplicate Card", translate: "Дубликат карты" };
      const updatedDeck = Deck.AddNewCard(newCard, sampleDeck);
      expect(updatedDeck.cards.length).toBe(1);
    });

    it("should not add a new card if it already exists in the deck by word", () => {
      const newCard: Card = { id: 2, word: "Sample", translate: "Образец" };
      const updatedDeck = Deck.AddNewCard(newCard, sampleDeck);
      expect(updatedDeck.cards.length).toBe(1);
    });
  });

  describe("DeleteCard", () => {
    it("should remove a card from the deck by id", () => {
      const updatedDeck = Deck.DeleteCard(1, sampleDeck);
      expect(updatedDeck.cards).not.toContainEqual(sampleCard);
    });

    it("should not remove any card if the id is not found in the deck", () => {
      const updatedDeck = Deck.DeleteCard(999, sampleDeck);
      expect(updatedDeck.cards).toEqual(sampleDeck.cards);
    });
  });
});
