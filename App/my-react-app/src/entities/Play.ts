import { Card } from "./Card";

export type Play = {
  cardsForLearn: Card[];
  cardsLearnFinish: Card[];
};

const CreatePlay = (cards: Card[]): Play => {
  console.log("Создание игры с карточками:", cards); // Добавьте это сообщение
  return {
    cardsForLearn: [...cards],
    cardsLearnFinish: [],
  };
};

const LearnCard = (play: Play, card: Card) => {
  console.log("Игра до изучения карточки:", play); // Добавьте это сообщение
  console.log("Изучаемая карточка:", card); // Добавьте это сообщение

  if (play.cardsForLearn.length === 0) {
    return play;
  }

  const index = play.cardsForLearn.findIndex((c) => c.id === card.id);
  if (index === -1) {
    return play;
  }

  const newCards = [...play.cardsForLearn];
  newCards.splice(index, 1);

  const updatedPlay = {
    ...play,
    cardsForLearn: [...newCards],
    cardsLearnFinish: [...play.cardsLearnFinish, card],
  };

  console.log("Игра после изучения карточки:", updatedPlay); // Добавьте это сообщение
  return updatedPlay;
};

export const Play = { CreatePlay, LearnCard };
