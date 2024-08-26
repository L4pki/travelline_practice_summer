import { Deck } from "../entities/Deck";
import React from "react";

type DeckItemProps = {
  deck: Deck;
};

const DeckItem: React.FC<DeckItemProps> = ({ deck }) => {
  const progress = Math.round((deck.cards.length / 100) * 100);
  const width = String(progress);
  return (
    <div className="deck-item">
      <h2 style={{ margin: "0" }}>
        {deck.name} ({deck.cards.length} карт)
      </h2>
      <div className="progress-bar">
        <div className="progress-bar-fill" style={{ width: width }}></div>
      </div>
    </div>
  );
};

export default DeckItem;
