import React from "react";
import { Deck } from "../entities/Deck";

type DeckProps = {
  deck: Deck;
  onDeleteDeck: (deckId: number) => void;
};

const DeckComponent: React.FC<DeckProps> = ({ deck, onDeleteDeck }) => {
  const handleDeleteDeck = () => {
    if (window.confirm("Вы уверены, что хотите удалить эту колоду?")) {
      onDeleteDeck(deck.id);
    }
  };

  return (
    <div className="deck">
      <h2>{deck.name}</h2>
      <button className="delete-button" onClick={handleDeleteDeck}>
        ❌
      </button>
      <ul>
        {deck.cards.map((card) => (
          <li key={card.id}>{card.word}</li>
        ))}
      </ul>
    </div>
  );
};

export default DeckComponent;
