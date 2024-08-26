import { useState } from "react";
import { Deck } from "../entities/Deck";
import React from "react";

const AddDeckForm: React.FC<{ onAddDeck: (deck: Deck) => void }> = ({ onAddDeck }) => {
  const [name, setName] = useState("");
  const [isFormVisible, setIsFormVisible] = useState(false);

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const newDeck: Deck = {
      id: Date.now(),
      name,
      cards: [],
    };
    onAddDeck(newDeck);
    setName("");
    setIsFormVisible(false);
  };

  return (
    <div>
      <button
        className="show-form-button"
        onClick={() => {
          setIsFormVisible((prev) => !prev);
        }}
      >
        {isFormVisible ? "Скрыть форму" : "Добавить колоду"}
      </button>

      {isFormVisible && (
        <form onSubmit={handleSubmit} className="add-deck-form">
          <label>
            Название колоды:
            <input
              type="text"
              value={name}
              onChange={(e) => {
                setName(e.target.value);
              }}
              required
            />
          </label>
          <button type="submit">Добавить колоду</button>
        </form>
      )}
    </div>
  );
};

export default AddDeckForm;
