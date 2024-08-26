import create from "zustand";
import { persist } from "zustand/middleware";
import { Deck } from "../entities/Deck";
import { Card } from "../entities/Card";

type StoreState = {
  decks: Deck[];
  selectedDeck: Deck | null;
  showQuiz: boolean;
  setSelectedDeck: (deck: Deck) => void;
  setShowQuiz: (show: boolean) => void;
  handleAnswer: (isCorrect: boolean) => void;
  addDeck: (newDeck: Deck) => void;
  addCardToDeck: (deckId: number, newCard: Card) => void;
  removeDeck: (deckId: number) => void;
  removeCardFromDeck: (deckId: number, cardId: number) => void;
};

export const useStore = create(
  persist<StoreState>(
    (set) => ({
      decks: [],
      selectedDeck: null,
      showQuiz: false,
      setSelectedDeck: (deck) => {
        set({ selectedDeck: deck, showQuiz: true });
      },
      setShowQuiz: (show) => {
        set({ showQuiz: show });
      },
      handleAnswer: (isCorrect) => {
        alert(isCorrect ? "Правильно!" : "Неправильно, попробуйте еще раз!");
        set({ showQuiz: false });
      },
      addDeck: (newDeck) => {
        set((state) => ({
          decks: [...state.decks, newDeck],
        }));
      },
      addCardToDeck: (deckId, newCard) => {
        set((state) => ({
          decks: state.decks.map((deck) => (deck.id === deckId ? { ...deck, cards: [...deck.cards, newCard] } : deck)),
        }));
      },
      removeDeck: (deckId) => {
        set((state) => ({
          decks: state.decks.filter((deck) => deck.id !== deckId),
        }));
      },
      removeCardFromDeck: (deckId, cardId) => {
        set((state) => ({
          decks: state.decks.map((deck) =>
            deck.id === deckId ? { ...deck, cards: deck.cards.filter((card) => card.id !== cardId) } : deck,
          ),
        }));
      },
    }),
    {
      name: "my-store",
    },
  ),
);
