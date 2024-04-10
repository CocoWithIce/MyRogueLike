using UnityEngine;

namespace GamePattern.Decarater
{
    public class Card: ICard
    {
        public int Value;
        public CardType Type;
        public int Play()
        {
            Debug.Log($"CardType : {Type.ToString()}");
            return Value;
        }
    }

    public enum CardType
    {
        Damage,
        Health,
        Buff,
        Decorate
    }

    public class DecorateCard : ICard
    {
        protected int Value;
        protected ICard Card;

        public int Play()
        {
            return (int)(Card?.Play() + Value);
        }

        public void Decorate(ICard card)
        {
            Card = card;
        }
    }
}