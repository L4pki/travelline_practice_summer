import React from "react";
import { useStore } from "./hooks/useStore";
import "./App.css";
import { Container } from "./Container";
import { Deck } from "./entities/Deck";
import { Card } from "./entities/Card";
import DeckList from "./Components/DeckList";
import DeckDetails from "./Components/DeckDetails";
import AddDeckForm from "./Components/DeckForm";
import QuizCard from "./Components/QuizCard";

const App: React.FC = () => {
  const { decks, selectedDeck, showQuiz, setSelectedDeck, setShowQuiz, handleAnswer, addDeck, addCardToDeck } =
    useStore((state) => ({
      decks: state.decks,
      selectedDeck: state.selectedDeck,
      showQuiz: state.showQuiz,
      setSelectedDeck: state.setSelectedDeck,
      setShowQuiz: state.setShowQuiz,
      handleAnswer: state.handleAnswer,
      addDeck: state.addDeck,
      addCardToDeck: state.addCardToDeck,
    }));

  const handleSelectDeck = (deck: Deck) => {
    setSelectedDeck(deck);
    setShowQuiz(true);
  };

  const handleAddDeck = (newDeck: Deck) => {
    addDeck(newDeck);
  };

  const handleAddCardToDeck = (deckId: number, newCard: Card) => {
    addCardToDeck(deckId, newCard);
  };

  return (
    <div className="application">
      <Container>
        <div className="deck-container">
          <DeckList decks={decks} onSelectDeck={handleSelectDeck} />
          <AddDeckForm onAddDeck={handleAddDeck} />
        </div>
      </Container>
      <Container>{selectedDeck && <DeckDetails deck={selectedDeck} onAddCard={handleAddCardToDeck} />}</Container>
      <Container>
        {showQuiz && selectedDeck && (
          <QuizCard
            selectedDeck={selectedDeck}
            handleAnswer={handleAnswer}
            startGame={() => {
              console.log("Start Game");
            }}
          />
        )}
      </Container>
    </div>
  );
};

export default App;
