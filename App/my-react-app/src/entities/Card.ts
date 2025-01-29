export type Card = {
  id: number;
  word: string;
  translate: string;
};

const ChangeCard = (translate: string, card: Card) => {
  return {
    ...card,
    word: card.word,
    translate: translate,
  };
};

export const Card = { ChangeCard };
