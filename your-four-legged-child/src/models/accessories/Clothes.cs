using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.accessories
{
    /*
    TDA ROPA (-> Hereda de Producto)

    - Compuesto por:
    Personalizable

    - Propiedades
    Personalizable          NombreMascota

    - Métodos
                            Ropa(...)
                            Ropa(Ropa copia)
    (Sobrescrito) Vacío     ImprimirDetalles()
    (Sobrescrito) Vacío     Personalizar()
    (Sobrescrito) Vacío     Actualizar()
    (Sobrescrito) Boolean   Comparar(Producto aComparar)
     */

    internal class Clothes : Product
    {
        Custom PetName;

        public Clothes(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            PetName = new Custom("Nombre bordado");
        }
        public Clothes(Clothes copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            PetName = new Custom("Nombre bordado");
        }

        public string GetPetName() => PetName.GetValue();

        public override void PrintProductDetails()
        {
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            PetName.PrintField();
            Menus.PrintRightText("Cantidad: " + base.GetCount());
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PetName.SetValue(UserInput.String());
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PetName.SetValue(UserInput.String());
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Clothes compareTo)
                if (PetName.GetValue() == compareTo.GetPetName()) return true;
            return false;
        }

        public override Product Clone()
        {
            Clothes newProduct = new Clothes(this);
            return newProduct;
        }
    }
}
