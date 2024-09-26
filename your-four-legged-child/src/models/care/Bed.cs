using System;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.care
{
    /*
    TDA CAMA (-> Hereda de Producto)
    
    - Compuesto por:
    Personalizable

    - Propiedades
    Personalizable          Diseño
    Personalizable          NombreMascota

    - Métodos
                            Cama(...)
                            Cama(Cama copia)
    (Sobrescrito) Vacío     ImprimirDetalles()
    (Sobrescrito) Vacío     Personalizar()
    (Sobrescrito) Vacío     Actualizar()
    (Sobrescrito) Boolean   Comparar(Producto aComparar)
     */

    internal class Bed : Product
    {
        Custom Design;
        Custom PetName;

        public Bed(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            Design = new Custom("Diseño");
            PetName = new Custom("Nombre Bordado");
        }
        public Bed(Bed copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            Design = new Custom("Diseño");
            PetName = new Custom("Nombre Bordado");
        }

        // Getters
        public string GetPetName() => PetName.GetValue();
        public string GetDesign() => Design.GetValue();

        // Methods

        public override void PrintProductDetails()
        {
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            PetName.PrintField();
            Design.PrintField();
            Menus.PrintRightText("Cantidad: " + base.GetCount());
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Que tipo de diseño te gustaria? (Huesos, Huellas, etc.)");
            Design.SetValue(UserInput.String());
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PetName.SetValue(UserInput.String());
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Que tipo de diseño te gustaria? (Huesos, Huellas, etc.)");
            Design.SetValue(UserInput.String());
            Console.WriteLine("Cual es el nombre de tu mascota?");
            PetName.SetValue(UserInput.String());
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Bed compareTo)
                if (PetName.GetValue() == compareTo.GetPetName() && Design.GetValue() == compareTo.GetDesign()) return true;
            return false;
        }

        public override Product Clone()
        {
            Bed newProduct = new Bed(this);
            return newProduct;
        }
    }
}
