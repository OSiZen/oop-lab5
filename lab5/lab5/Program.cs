using System;

namespace lab5
{
    //Task 1
    interface IFigure 
    {
        string sizeFigure { get; }
        string Type();
        string Square();
        string Length();
    }

    interface IColoredFigure : IFigure
    {
        string name { get; }
    }

    class Rectangle : IFigure
    {
        protected double a { get; set; }
        protected double b { get; set; }

        public Rectangle(double A, double B)
        {
            this.a = A;
            this.b = B;
        }

        public string sizeFigure
        {
            get
            {
                return $"Розмiр фiгури: A = {a}, B = {b}";
            }
        }

        public string Length()
        {
            double d = Math.Round(Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2)), 2);
            return $"Довжина дiагоналi фiгури  = {d}";
        }

        public string Square()
        {
            double s = Math.Round(a * b, 2);
            return $"Площа фiгури  = {s}";
        }

        public string Type()
        {
            return "Тип: прямокутник";
        }
    }

    class ColoredRectangle : Rectangle, IColoredFigure
    {
        protected string color { get; set; }
        public string name { get; set; }

        public ColoredRectangle(double A, double B, string C) : base (A, B) 
        {
            this.color = C;
        }
    }

    //Task 2
    interface ITool
    {
        //string KEY { set { KEY = "До мажор"; } }
        void play();
    }

    class Guitar : ITool
    {
        protected int quantity { get; set; }
        public Guitar(int quantity)
        {
            this.quantity = quantity;
        }
        public void play()
        {
            Console.WriteLine($"Грає гiтара з кiлькiстю струн - {quantity}");
        }
    }

    class Drum : ITool
    {
        protected double size { get; set; }
        public Drum(double size)
        {
            this.size = size;
        }
        public void play()
        {
            Console.WriteLine($"Грає барабан з розмiром - {size} см");
        }
    }

    class Trumpet : ITool
    {
        protected double diameter { get; set; }
        public Trumpet(double diameter)
        {
            this.diameter = diameter;
        }
        public void play()
        {
            Console.WriteLine($"Грає труба з дiаметром - {diameter}");
        }
    }

    //Task 3
    class Shop
    {
        protected string[] sizeClothes = { "XXS", "XS", "S", "M", "L" };
        protected string euroSize;

        public Shop(string euroSize)
        {
            this.euroSize = euroSize;
        }

        public string GetSize
        {
            get
            {
                return euroSize;
            }
        }

        public string EuroSize
        {
            set
            {
                euroSize = value;
                if (euroSize == "32")
                {
                    euroSize = sizeClothes[0];
                }
                else if (euroSize == "34")
                {
                    euroSize = sizeClothes[1];
                }
                else if (euroSize == "38")
                {
                    euroSize = sizeClothes[2];
                }
                else if (euroSize == "40")
                {
                    euroSize = sizeClothes[3];
                }
            }
        }
        public void getDescription()
        {
            if (euroSize == sizeClothes[0])
            {
                Console.WriteLine("Дитячий розмiр");
            }
            else
            {
                Console.WriteLine("Дорослий розмiр");
            }
            Console.WriteLine();
        }
    }
    interface IMenswear
    {
        void dressMan();
    }

    interface IWomenswear
    {
        void dressWoman();
    }

    abstract class Clothes
    {
        protected int sizeClothes;
        protected double price;
        protected string color;
        protected Clothes(int sizeClothes, double price, string color)
        {
            this.sizeClothes = sizeClothes;
            this.price = price;
            this.color = color;
        }
    }

    class TShirt : Clothes, IMenswear, IWomenswear
    {
        public TShirt(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressMan()
        {
            Console.WriteLine("Футболка чоловiча:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
        public void dressWoman()
        {
            Console.WriteLine("Футболка жiноча:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Pants : Clothes, IMenswear, IWomenswear
    {
        public Pants(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressMan()
        {
            Console.WriteLine("Штани чоловiчi:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
        public void dressWoman()
        {
            Console.WriteLine("Штани жiночi:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Skirt : Clothes, IWomenswear
    {
        public Skirt(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressWoman()
        {
            Console.WriteLine("Спiдниця жiноча:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Necktie : Clothes, IMenswear
    {
        public Necktie(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressMan()
        {
            Console.WriteLine("Краватка чоловiча:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Atelier
    {
        public void dressMan()
        {
            Console.WriteLine("Одягнути Чоловiка");
            IMenswear[] menswears = { new TShirt(38, 325.50, "бiлий"), new Pants(43, 725.99, "чорний"), new Necktie(8, 90.45, "чорний") };
            foreach (IMenswear str in menswears)
            {
                str.dressMan();
            }
            Console.WriteLine();
        }
        public void dressWoman()
        {
            Console.WriteLine("Одягнути Жiнку: ");
            IWomenswear[] womenswears = { new TShirt(35, 336.10, "оранжеий"), new Pants(38, 825.15, "бiлий"), new Skirt(6, 85.99, "бiлий") };
            foreach (IWomenswear str in womenswears)
            {
                str.dressWoman();
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle[] rectangle = {
                new Rectangle (2.75, 1.25),
                new Rectangle (6.25, 3),
                new Rectangle (7.5, 5.15)
            };
            foreach (Rectangle str in rectangle)
            {
                Console.WriteLine($"{str.Type()}\n{str.sizeFigure}\n{str.Square()}\n{str.Length()}");
            }
            Console.WriteLine();
            ITool[] tools = { new Guitar(6), new Drum(45.5), new Trumpet(5) };
            foreach (ITool t in tools)
            {
                t.play();
            }
            Console.WriteLine();
            Console.Write("Введiть один iз запропонованих розмiрiв (32, 34, 36, 38, 40): ");
            string size = Console.ReadLine();
            Shop shop = new Shop(size);
            shop.EuroSize = shop.GetSize;
            shop.getDescription();
            Atelier atelier = new Atelier();
            atelier.dressMan();
            atelier.dressWoman();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
