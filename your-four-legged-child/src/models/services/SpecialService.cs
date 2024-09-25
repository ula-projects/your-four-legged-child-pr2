using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.services
{
    internal class SpecialService : Product
    {
        Custom Age;
        Custom Race;
        Custom SpecialNeeds;
        Custom Species;

        public SpecialService(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            Age = new Custom("Edad");
            Race = new Custom("Raza");
            SpecialNeeds = new Custom("Necesidades Especiales");
            Species = new Custom("Animal");
        }
        public SpecialService(SpecialService copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            Age = new Custom("Edad");
            Race = new Custom("Raza");
            SpecialNeeds = new Custom("Necesidades Especiales");
            Species = new Custom("Animal");
        }


        // Getters
        public string GetAge() => Age.GetValue();
        public string GetRace() => Race.GetValue();
        public string GetSpecialNeeds() => SpecialNeeds.GetValue();

        public override void PrintProductDetails()
        {
            string countText = "Cantidad: " + base.GetCount();
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            Species.PrintField();
            Race.PrintField();
            Age.PrintField();
            SpecialNeeds.PrintField();
            Console.WriteLine(countText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Que animal es tu mascota?");
            Species.SetValue(UserInput.String());
            Console.WriteLine("Que raza es tu mascota?");
            Race.SetValue(UserInput.String());
            Console.WriteLine("Que edad tiene tu mascota?");
            Age.SetValue(UserInput.Number(0).ToString());
            Console.WriteLine("Que necesidades especiales tiene tu mascota?");
            SpecialNeeds.SetValue(UserInput.String(true));
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Que animal es tu mascota?");
            Species.SetValue(UserInput.String());
            Console.WriteLine("Que raza es tu mascota");
            Race.SetValue(UserInput.String());
            Console.WriteLine("Que edad tiene tu mascota?");
            Age.SetValue(UserInput.Number(0).ToString());
            Console.WriteLine("Que necesidades especiales tiene tu mascota?");
            SpecialNeeds.SetValue(UserInput.String(true));
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is SpecialService compareTo)
                if (Age.GetValue() == compareTo.GetAge() && Race.GetValue() == compareTo.GetRace() && SpecialNeeds.GetValue() == compareTo.GetSpecialNeeds())
                    return true;
            return false;
        }

        public override Product Clone()
        {
            SpecialService newProduct = new SpecialService(this);
            return newProduct;

        }
    }
}
