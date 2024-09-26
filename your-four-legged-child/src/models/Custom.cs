using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace your_four_legged_child.src.models
{
    /*
    TDA PERSONALIZABLE

    - Propiedades
    C. de caracteres    etiqueta
    C. de caracteres    valor

    - Métodos
    Vacío               Imprimir()
     */

    internal class Custom
    {
        string label;
        string value;

        public Custom(string _label)
        {
            this.label = _label;
            value = "";
        }

        // Getters
        public string GetLabel() => this.label;
        public string GetValue() => this.value;

        // Setters
        public void SetValue(string _value) { this.value = _value; }

        public void PrintField()
        {
            if (value.Length > 0)
                Console.WriteLine(label + ": " + value);
        }
    }
}
