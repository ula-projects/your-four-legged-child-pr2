using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.product
{
    internal class Food : Product
    {
        string race;
        int age;
        string specialNeeds;

        public Food(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {

        }

        // Getters
        public string GetRace() => this.race;
        public int GetAge() => this.age;
        public string GetSpecialNeeds() => this.specialNeeds;
        // Setters

        // Methods

        public override void PrintProductDetails()
        {
            string countText = "Cantidad: " + base.GetCount();
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            Console.WriteLine("Raza: " + this.race);
            Console.WriteLine("Edad: " + this.age);
            if (this.specialNeeds.Length > 0)
                Console.WriteLine("Necesidades Especiales: " + this.specialNeeds);
            Console.WriteLine(countText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Que raza es tu " + base.GetAnimal() + "?");
            this.race = Console.ReadLine();
            Console.WriteLine("Que edad tiene tu " + base.GetAnimal() + "?");
            this.age = UserInput.Number(0);
            Console.WriteLine("Que necesidades especiales tiene tu " + base.GetAnimal() + "?");
            this.specialNeeds = Console.ReadLine();
            base.Personalize();
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Food compareTo)
                if (this.age == compareTo.GetAge() && this.race == compareTo.GetRace() && this.specialNeeds == compareTo.GetSpecialNeeds()) return true;
            return false;
        }
    }
}
