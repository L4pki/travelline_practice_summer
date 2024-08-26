import { Deck } from "./Deck";

export type Application = {
  deckList: Deck[];
};

const AddNewDeck = (newDeck: Deck, app: Application): Application => {
  if (app.deckList.some((d) => d.id === newDeck.id || d.name === newDeck.name)) {
    return app;
  }

  return {
    deckList: [...app.deckList, newDeck],
  };
};

const DeleteDeck = (id: number, app: Application): Application => {
  const index = app.deckList.findIndex((d) => d.id === id);

  if (index === -1) {
    return app;
  }

  const newDecks = [...app.deckList];
  newDecks.splice(index, 1);

  return {
    deckList: newDecks,
  };
};

export const Application = { AddNewDeck, DeleteDeck };
