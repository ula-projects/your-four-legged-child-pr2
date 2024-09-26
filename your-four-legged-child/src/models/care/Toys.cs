using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.care
{
    /*
    TDA JUGUETES (-> Hereda de Producto)
    
    - Compuesto por:
    Personalizable

    - Propiedades
    Personalizable          NombreMascota

    - Métodos
                            Juguete(...)
                            Juguete(Juguete copia)
    (Sobrescrito) Vacío     ImprimirDetalles()
    (Sobrescrito) Vacío     Personalizar()
    (Sobrescrito) Vacío     Actualizar()
    (Sobrescrito) Boolean   Comparar(Producto aComparar)
     */

    internal class Toys : Product
    {
        Custom PetName;

        public Toys(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            PetName = new Custom("Nombre Grabado");
        }
        public Toys(Toys copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            PetName = new Custom("Nombre Grabado");
        }

        // Getters
        public string GetPetName() => PetName.GetValue();

        // Methods

        public override void PrintProductDetails()
        {
            string countText = "Cantidad: " + base.GetCount();
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            PetName.PrintField();
            Console.WriteLine(countText.PadLeft(Console.WindowWidth));
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
            if (_compareTo is Toys compareTo)
                if (PetName.GetValue() == compareTo.GetPetName()) return true;
            return false;
        }

        public override Product Clone()
        {
            Toys newProduct = new Toys(this);
            return newProduct;
        }
    }
}
