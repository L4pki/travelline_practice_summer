import { Play } from "../entities/Play";
import { Card } from "../entities/Card";

const sampleCard: Card = {
  id: 1,
  word: "Sample Card",
  translate: "Образец карты",
};

const sampleCards: Card[] = [sampleCard, { id: 2, word: "Another Card", translate: "Другая карта" }];

describe("LearningProcess functions", () => {
  describe("CreatePlay", () => {
    it("should create a play with the given cards for learning", () => {
      const play = Play.CreatePlay(sampleCards);
      expect(play.cardsForLearn).toEqual(sampleCards);
      expect(play.cardsLearnFinish).toEqual([]);
    });
  });

  describe("LearnCard", () => {
    it("should move a card from cardsForLearn to cardsLearnFinish", () => {
      const play = Play.CreatePlay(sampleCards);
      const updatedPlay = Play.LearnCard(play, sampleCard);
      expect(updatedPlay.cardsForLearn).not.toContain(sampleCard);
      expect(updatedPlay.cardsLearnFinish).toContain(sampleCard);
    });

    it("should not change play if the card is not in cardsForLearn", () => {
      const play = Play.CreatePlay(sampleCards);
      const newCard: Card = { id: 999, word: "Non-existent Card", translate: "Несуществующая карта" };
      const updatedPlay = Play.LearnCard(play, newCard);
      expect(updatedPlay.cardsForLearn).toEqual(sampleCards);
      expect(updatedPlay.cardsLearnFinish).toEqual([]);
    });

    it("should not change play if there are no cards left to learn", () => {
      const play = Play.CreatePlay(sampleCards);
      const updatedPlay = Play.LearnCard({ ...play, cardsForLearn: [] }, sampleCard);
      expect(updatedPlay.cardsForLearn).toEqual([]);
      expect(updatedPlay.cardsLearnFinish).toEqual([]);
    });
  });
});
