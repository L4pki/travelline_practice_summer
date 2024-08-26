import React, { useState } from "react";
import { Card } from "../entities/Card";

const getOptions = (cards: Card[], correctAnswer: string, count: number): string[] => {
  const otherOptions = cards
    .filter((card) => card.translate !== correctAnswer)
    .sort(() => 0.5 - Math.random())
    .slice(0, count - 1)
    .map((card) => card.translate);

  const options = [...otherOptions, correctAnswer];
  return options.sort(() => 0.5 - Math.random());
};

type QuizCardProps = {
  selectedDeck?: {
    cards: Card[];
  };
  handleAnswer: (isCorrect: boolean) => void;
  startGame?: () => void;
};

const QuizCard: React.FC<QuizCardProps> = ({ selectedDeck, startGame }) => {
  const [gameStarted, setGameStarted] = useState<boolean>(false);
  const [currentCardIndex, setCurrentCardIndex] = useState<number>(0);
  const [correctAnswers, setCorrectAnswers] = useState<number>(0);

  const canStartGame = selectedDeck && selectedDeck.cards.length > 4;

  const handleAnswerClick = (isCorrect: boolean) => {
    console.log(isCorrect);
    if (isCorrect) {
      setCorrectAnswers(correctAnswers + 1);
      alert("Правильно!");
      if (currentCardIndex < (selectedDeck?.cards.length || 0) - 1) {
        setCurrentCardIndex(currentCardIndex + 1);
      } else {
        alert("Поздравляем, вы ответили на все вопросы правильно!");
        setGameStarted(false);
        setCurrentCardIndex(0);
        setCorrectAnswers(0);
      }
    } else {
      alert("Неправильно, попробуйте еще раз.");
    }
  };

  if (gameStarted) {
    if (!selectedDeck?.cards.length) {
      return <div>No cards available</div>;
    }

    const card = selectedDeck.cards[currentCardIndex];
    const options = getOptions(selectedDeck.cards, card.translate, 4);

    return (
      <div className="quiz-card">
        <h3 className="deck-title">Какой перевод слова &quot;{card.word}&quot;?</h3>
        <div className="options">
          {options.map((option) => (
            <button
              key={option}
              className="option-button"
              onClick={() => {
                handleAnswerClick(option === card.translate);
              }}
            >
              {option}
            </button>
          ))}
        </div>
      </div>
    );
  }

  return (
    <div className="quiz-card">
      <button
        onClick={() => {
          setGameStarted(true);
          if (startGame) startGame();
        }}
        disabled={!canStartGame}
      >
        Запустить игру
      </button>
      {!canStartGame && <p>Для начала игры необходимо минимум 5 слов в словаре.</p>}
    </div>
  );
};

export default QuizCard;
