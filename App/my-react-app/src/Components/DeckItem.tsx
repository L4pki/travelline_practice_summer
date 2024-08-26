import React from "react";
import { Deck } from "../entities/Deck";
import { useStore } from "../hooks/useStore";

type DeckItemProps = {
  deck: Deck;
};

const DeckItem: React.FC<DeckItemProps> = ({ deck }) => {
  const { removeDeck } = useStore();

  const handleDeleteDeck = () => {
    if (window.confirm("Вы уверены, что хотите удалить эту колоду?")) {
      removeDeck(deck.id);
    }
  };

  const progress = Math.round((deck.cards.length / 100) * 100);
  const width = String(progress) + "%";

  return (
    <div className="deck-item">
      <h2>
        {deck.name} ({deck.cards.length} карт)
        <button className="delete-button" onClick={handleDeleteDeck}>
          ❌
        </button>
      </h2>
      <div className="progress-bar">
        <div className="progress-bar-fill" style={{ width }}></div>
      </div>
    </div>
  );
};

export default DeckItem;
