using System;
using System.Diagnostics;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.care
{
    internal class Beed : Product
    {
        Custom Design;
        Custom PeetName;

        public Beed(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            Design = new Custom("Diseño");
            PeetName = new Custom("Nombre Bordado");
        }
        public Beed(Beed copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            Design = new Custom("Diseño");
            PeetName = new Custom("Nombre Bordado");
        }

        // Getters
        public string GetPeetName() => PeetName.GetValue();
        public string GetDesign() => Design.GetValue();

        // Methods

        public override void PrintProductDetails()
        {
            string countText = "Cantidad: " + base.GetCount();
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            PeetName.PrintField();
            Design.PrintField();
            Console.WriteLine(countText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Que tipo de diseño te gustaria? (Huesos, Huellas, etc.)");
            Design.SetValue(UserInput.String());
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PeetName.SetValue(UserInput.String());
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Que tipo de diseño te gustaria? (Huesos, Huellas, etc.)");
            Design.SetValue(UserInput.String());
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PeetName.SetValue(UserInput.String());
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Beed compareTo)
                if (PeetName.GetValue() == compareTo.GetPeetName() && Design.GetValue() == compareTo.GetDesign()) return true;
            return false;
        }

        public override Product Clone()
        {
            Beed newProduct = new Beed(this);
            return newProduct;
        }
    }
}
