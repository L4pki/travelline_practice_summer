import { useState } from "react";
import { Deck } from "../entities/Deck";
import React from "react";
import { Card } from "../entities/Card";
import { useStore } from "../hooks/useStore";

type DeckDetailsProps = {
  deck: Deck;
  onAddCard: (deckId: number, newCard: Card) => void;
};

const DeckDetails: React.FC<DeckDetailsProps> = ({ deck, onAddCard }) => {
  const [word, setWord] = useState("");
  const [translate, setTranslate] = useState("");
  const [showCards, setShowCards] = useState(false);
  const [showForm, setShowForm] = useState(false);

  const removeCard = useStore((state) => state.removeCardFromDeck);

  const handleAddCard = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const newCard: Card = {
      id: Date.now(),
      word,
      translate,
    };
    onAddCard(deck.id, newCard);
    setWord("");
    setTranslate("");
    setShowForm(false);
  };

  const handleRemoveCard = (cardId: number) => {
    if (window.confirm("Вы уверены, что хотите удалить эту карту?")) {
      removeCard(deck.id, cardId);
    }
  };

  return (
    <div className="deck-details">
      <h2 className="deck-title">{deck.name}</h2>
      <button
        onClick={() => {
          setShowCards((prev) => !prev);
        }}
        className="toggle-cards-button"
      >
        {showCards ? "Скрыть карты" : "Показать карты"}
      </button>
      {showCards && (
        <ul className="card-list">
          {deck.cards.map((card) => (
            <li key={card.id} className="card-item">
              {card.word} - {card.translate}
              <button
                onClick={() => {
                  handleRemoveCard(card.id);
                }}
                className="delete-button"
              >
                ❌
              </button>
            </li>
          ))}
        </ul>
      )}
      <button
        onClick={() => {
          setShowForm((prev) => !prev);
        }}
        className="toggle-form-button"
      >
        {showForm ? "Скрыть форму" : "Добавить карту"}
      </button>
      {showForm && (
        <form onSubmit={handleAddCard} className="add-card-form">
          <h3 className="form-title">Добавить новую карту</h3>
          <label className="form-label">
            Слово:
            <input
              type="text"
              value={word}
              onChange={(e) => {
                setWord(e.target.value);
              }}
              required
              className="form-input"
            />
          </label>
          <label className="form-label">
            Перевод:
            <input
              type="text"
              value={translate}
              onChange={(e) => {
                setTranslate(e.target.value);
              }}
              required
              className="form-input"
            />
          </label>
          <button type="submit" className="submit-button">
            Добавить карту
          </button>
        </form>
      )}
    </div>
  );
};

export default DeckDetails;
