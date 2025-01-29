import { Card } from "./Card";

export interface Play {
  cardsForLearn: Card[];
  cardsLearnFinish: Card[];
}

const CreatePlay = (cards: Card[]): Play => {
  return {
    cardsForLearn: [...cards],
    cardsLearnFinish: [],
  };
};

const LearnCard = (play: Play, card: Card) => {
  if (play.cardsForLearn.length == 0) {
    return play;
  }

  const index = play.cardsForLearn.findIndex((c) => c.id === card.id);
  if (index === -1) {
    return play;
  }

  const newCards = [...play.cardsForLearn];
  newCards.splice(index, 1);

  return {
    ...play,
    cardsForLearn: [...newCards],
    cardsLearnFinish: [...play.cardsLearnFinish, card],
  };
};

export const Play = { CreatePlay, LearnCard };
