using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.care
{
	/*
    TDA COLLAR (-> Hereda de Producto)
    
    - Propiedades
    Personalizable          NombreGrabado
    Personalizable          NumTlfGrabado

    - Métodos
                            Collar(...)
                            Collar(Collar copia)
    (Sobrescrito) Vacío     ImprimirDetalles()
    (Sobrescrito) Vacío     Personalizar()
    (Sobrescrito) Vacío     Actualizar()
    (Sobrescrito) Boolean   Comparar(Producto aComparar)
     */

	internal class Collars : Product
    {
        Custom EngravedName;
        Custom EngravedPhoneNumber;

        public Collars(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            EngravedName = new Custom("Nombre Grabado");
            EngravedPhoneNumber = new Custom("Telefono Gravado");
        }
        public Collars(Collars copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            EngravedName = new Custom("Nombre Grabado");
            EngravedPhoneNumber = new Custom("Telefono Grabado");
        }

        // Getters
        public string GetEngravedName() => EngravedName.GetValue();
        public string GetEngravedPhoneNumber() => EngravedPhoneNumber.GetValue();

        // Methods

        public override void PrintProductDetails()
        {
            string countText = "Cantidad: " + base.GetCount();
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            EngravedName.PrintField();
            EngravedPhoneNumber.PrintField();
            Console.WriteLine(countText.PadLeft(Console.WindowWidth));
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Nombre de tu mascota?");
            EngravedPhoneNumber.SetValue(UserInput.String());
            Console.WriteLine("Telefono de contacto?");
            EngravedName.SetValue(UserInput.String());
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Nombre de tu mascota?");
            EngravedPhoneNumber.SetValue(UserInput.String());
            Console.WriteLine("Telefono de contacto?");
            EngravedName.SetValue(UserInput.String());
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Collars compareTo)
                if (EngravedName.GetValue() == compareTo.GetEngravedName() && EngravedPhoneNumber.GetValue() == compareTo.GetEngravedPhoneNumber())
                    return true;
            return false;
        }

        public override Product Clone()
        {
            Collars newProduct = new Collars(this);
            return newProduct;

        }
    }
}
