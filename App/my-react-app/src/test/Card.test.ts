import { Card } from "../entities/Card";

describe("ChangeCard", () => {
  const card: Card = { id: 1, word: "дом", translate: "house" };

  it("edit with right words", () => {
    const expected = {
      id: 1,
      word: "дом",
      translate: "home",
    };

    expect(Card.ChangeCard("home", card)).toEqual(expected);
  });

  it("return new card in success editing", () => {
    expect(Card.ChangeCard(card.translate, card)).not.toBe(card);
  });
});
