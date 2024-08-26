import { Deck } from "../entities/Deck";
import DeckItem from "./DeckItem";
import React from "react";

type DeckListProps = {
  decks: Deck[];
  onSelectDeck: (deck: Deck) => void;
};

const DeckList: React.FC<DeckListProps> = ({ decks, onSelectDeck }) => {
  return (
    <div>
      <h2 className="deck-title">Колоды</h2>
      <ul>
        {decks.map((deck) => (
          <li
            key={deck.id}
            onClick={() => {
              onSelectDeck(deck);
            }}
          >
            <DeckItem deck={deck} />
          </li>
        ))}
      </ul>
    </div>
  );
};

export default DeckList;
