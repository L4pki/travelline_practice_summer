import { Application } from "../entities/Application";
import { Deck } from "../entities/Deck";

const sampleDeck: Deck = {
  id: 1,
  name: "Sample Deck",
  cards: [],
};

const sampleApplication: Application = {
  deckList: [sampleDeck],
};

describe("Application functions", () => {
  describe("AddNewDeck", () => {
    it("should add a new deck to the application if it does not already exist", () => {
      const newDeck: Deck = { id: 2, name: "New Deck", cards: [] };
      const updatedApplication = Application.AddNewDeck(newDeck, sampleApplication);
      expect(updatedApplication.deckList).toContainEqual(newDeck);
    });

    it("should not add a new deck if it already exists in the application by id", () => {
      const newDeck: Deck = { id: 1, name: "Duplicate Deck", cards: [] };
      const updatedApplication = Application.AddNewDeck(newDeck, sampleApplication);
      expect(updatedApplication.deckList.length).toBe(1);
    });

    it("should not add a new deck if it already exists in the application by name", () => {
      const newDeck: Deck = { id: 2, name: "Sample Deck", cards: [] };
      const updatedApplication = Application.AddNewDeck(newDeck, sampleApplication);
      expect(updatedApplication.deckList.length).toBe(1);
    });
  });

  describe("DeleteDeck", () => {
    it("should remove a deck from the application by id", () => {
      const updatedApplication = Application.DeleteDeck(1, sampleApplication);
      expect(updatedApplication.deckList).not.toContainEqual(sampleDeck);
    });

    it("should not remove any deck if the id is not found in the application", () => {
      const updatedApplication = Application.DeleteDeck(999, sampleApplication);
      expect(updatedApplication.deckList).toEqual(sampleApplication.deckList);
    });
  });
});
