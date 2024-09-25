using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.accessories
{
    internal class Clothes : Product
    {
        Custom PeetName;

        public Clothes(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            PeetName = new Custom("Nombre bordado");
        }
        public Clothes(Clothes copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            PeetName = new Custom("Nombre bordado");
        }

        public string GetPeetName() => PeetName.GetValue();

        public override void PrintProductDetails()
        {
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            PeetName.PrintField();
            Menus.PrintRightText("Cantidad: " + base.GetCount());
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PeetName.SetValue(UserInput.String());
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PeetName.SetValue(UserInput.String());
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Clothes compareTo)
                if (PeetName.GetValue() == compareTo.GetPeetName()) return true;
            return false;
        }

        public override Product Clone()
        {
            Clothes newProduct = new Clothes(this);
            return newProduct;
        }
    }
}
