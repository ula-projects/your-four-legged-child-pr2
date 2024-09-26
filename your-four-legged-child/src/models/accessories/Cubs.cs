using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.utilities;

namespace your_four_legged_child.src.models.accessories
{
	/*
    TDA TAZA (-> Hereda de Producto)
    
    - Compuesto por:
    Personalizable

    - Propiedades
    Personalizable          Frase

    - Métodos
                            Taza(...)
                            Taza(Taza copia)
    (Sobrescrito) Vacío     ImprimirDetalles()
    (Sobrescrito) Vacío     Personalizar()
    (Sobrescrito) Vacío     Actualizar()
    (Sobrescrito) Boolean   Comparar(Producto aComparar)
     */

	internal class Cubs : Product
    {
        Custom Phrase;

        public Cubs(string _id, string _name, float _price, string _animal, string _details, ProductTypes _type) : base(_id, _name, _price, _animal, _details, _type)
        {
            Phrase = new Custom("Frase para imprimir");
        }
        public Cubs(Cubs copy) : base(copy.GetId(), copy.GetName(), copy.GetPrice(), copy.GetAnimal(), copy.GetDetails(), copy.GetProductType())
        {
            Phrase = new Custom("Frase para imprimir");
        }

        public string GetPhrase() => Phrase.GetValue();

        public override void PrintProductDetails()
        {
            base.PrintProductDetails();
            Menus.DeleteLastLine(2);
            Phrase.PrintField();
            Menus.PrintRightText("Cantidad: " + base.GetCount());
            Menus.PrintLine();
        }

        public override void Personalize()
        {
            Console.WriteLine("Que frase deseas agregar?");
            Phrase.SetValue(UserInput.String());
            base.Personalize();
        }

        public override void Update()
        {
            Console.WriteLine("Que frase deseas agregar?");
            Phrase.SetValue(UserInput.String());
        }

        public override bool Compare(Product _compareTo)
        {
            if (_compareTo is Cubs compareTo)
                if (Phrase.GetValue() == compareTo.GetPhrase()) return true;
            return false;
        }

        public override Product Clone()
        {
            Cubs newProduct = new Cubs(this);
            return newProduct;
        }
    }
}
