import { Card } from "./Card";

export interface Deck {
  id: number;
  name: string;
  cards: Card[];
}

const AddNewCard = (newCard: Card, deck: Deck): Deck => {
  if (deck.cards.some((c) => c.id == newCard.id || c.word == newCard.word)) {
    return deck;
  }
  return {
    ...deck,
    cards: [...deck.cards, newCard],
  };
};

const DeleteCard = (idCard: number, deck: Deck): Deck => {
  const index = deck.cards.findIndex((c) => c.id === idCard);
  if (index === -1) {
    return deck;
  }

  const newCards = [...deck.cards];
  newCards.splice(index, 1);
  return {
    ...deck,
    cards: [...newCards],
  };
};

export const Deck = { AddNewCard, DeleteCard };
