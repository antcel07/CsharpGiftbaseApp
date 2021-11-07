using System;
using System.Collections.Generic;

namespace exams7
{
    class Program
    {
        static void Main(string[] args)
        {
            GiftBase phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            Console.WriteLine("Composite gift.");
            
            CompositeGift baseBox = new CompositeGift("RootBox", 0);

            
            GiftBase truckToy = new SingleGift("TruckToy", 289);
            GiftBase plainToy = new SingleGift("PlainToy", 587);

            baseBox.Add(truckToy);
            baseBox.Add(plainToy);

          
            CompositeGift childBox = new CompositeGift("ChildBox", 1000);
            
            GiftBase soldierToy = new SingleGift("SoldierToy", 200);
           
            childBox.Add(soldierToy);
            
            baseBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {baseBox.CalculateTotalPrice()}");
        }

        public abstract class GiftBase
        {
            
            protected string _name;

           
            protected int _price;

            protected GiftBase(string name, int price)
            {
                _name = name;
                _price = price;
            }

            
            public abstract int CalculateTotalPrice();
        }

        public interface IGiftOperation
        {
            void Add(GiftBase giftBase);
            void Remove(GiftBase giftBase);
        }
        public class SingleGift : GiftBase
        {
            public SingleGift(string name, int price) : base(name, price) { }

            public override int CalculateTotalPrice()
            {
                Console.WriteLine($"{_name} with the price {_price}");

                return _price;
            }
        }
        public class CompositeGift : GiftBase, IGiftOperation
        {
           
            private readonly List<GiftBase> _giftBases;

            public CompositeGift(string name, int price) : base(name, price)
            {
                _giftBases = new List<GiftBase>();
            }

            
            public void Add(GiftBase giftBase)
            {
                _giftBases.Add(giftBase);
            }

           
            public void Remove(GiftBase giftBase)
            {
                _giftBases.Remove(giftBase);
            }

            public override int CalculateTotalPrice()
            {
                int total = 0;

                Console.WriteLine($"{_name} contains the following products with prices:");
                foreach (GiftBase gift in _giftBases)
                {
                    total += gift.CalculateTotalPrice();
                }

                return total;
            }
        }
    }
}
