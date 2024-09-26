using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.care
{
	/*
    TDA COMIDA (-> Hereda de Producto)
    
    - Compuesto por:
    Personalizable

    - Propiedades
    Personalizable          Edad
    Personalizable          Raza
    Personalizable          NecesidadesEspeciales

    - Métodos
                            Comida(...)
                            Comida(Comida copia)
    (Sobrescrito) Vacío     ImprimirDetalles()
    (Sobrescrito) Vacío     Personalizar()
    (Sobrescrito) Vacío     Actualizar()
    (Sobrescrito) Boolean   Comparar(Producto aComparar)
     */

	internal class Food : Product
    {
        Custom Age;
        Custom Race;
        Custom SpecialNeeds;

        public Food(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            Age = new Custom("Edad");
            Race = new Custom("Raza");
            SpecialNeeds = new Custom("Necesidades Especiales");
        }
        public Food(Food copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            Age = new Custom("Edad");
            Race = new Custom("Raza");
            SpecialNeeds = new Custom("Necesidades Especiales");
        }

        // Getters
        public string GetAge() => Age.GetValue();
        public string GetRace() => Race.GetValue();
        public string GetSpecialNeeds() => SpecialNeeds.GetValue();

        // Methods

        public override void PrintProductDetails()
        {
            string countText = "Cantidad: " + base.GetCount();
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            Race.PrintField();
            Age.PrintField();
            SpecialNeeds.PrintField();
            Console.WriteLine(countText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Que raza es tu " + base.GetAnimal() + "?");
            Race.SetValue(UserInput.String());
            Console.WriteLine("Que edad tiene tu " + base.GetAnimal() + "?");
            Age.SetValue(UserInput.Number(0).ToString());
            Console.WriteLine("Que necesidades especiales tiene tu " + base.GetAnimal() + "?");
            SpecialNeeds.SetValue(UserInput.String(true));
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Que raza es tu " + base.GetAnimal() + "?");
            Race.SetValue(UserInput.String());
            Console.WriteLine("Que edad tiene tu " + base.GetAnimal() + "?");
            Age.SetValue(UserInput.Number(0).ToString());
            Console.WriteLine("Que necesidades especiales tiene tu " + base.GetAnimal() + "?");
            SpecialNeeds.SetValue(UserInput.String(true));
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Food compareTo)
                if (Age.GetValue() == compareTo.GetAge() && Race.GetValue() == compareTo.GetRace() && SpecialNeeds.GetValue() == compareTo.GetSpecialNeeds())
                    return true;
            return false;
        }

        public override Product Clone()
        {
            Food newProduct = new Food(this);
            return newProduct;

        }
    }
}
