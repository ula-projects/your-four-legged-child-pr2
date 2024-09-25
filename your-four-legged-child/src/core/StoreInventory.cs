using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.models.care;
using your_four_legged_child.src.models.services;

namespace your_four_legged_child.src.core
{
    internal partial class Store
    {
        public void GenerateProducts()
        {
            products[0] = new Food("dogfood1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para Perro de 1kg", ProductTypes.care);
            products[1] = new Beed("catbeed", "Cama para Gato", 25, "Gato", "Cama para gatos - Todos los tamanos", ProductTypes.care);
            products[2] = new Toys("dogtoychewy", "Jueguete masticable para Perro", 15, "Perro", "Jueguete de gota masticable para perros - Razas Mediana - Grande", ProductTypes.care);
            products[3] = new Collars("dogharness", "Pechera para perro", 20, "Perro", "Perchera para Perro - Razas Pequena - Mediana", ProductTypes.care);
            products[4] = new Product("alltoothbrush", "Cepillo de dientes para animales", 3, "Todos", "Cepillo de dientes para todo tipo de animal", ProductTypes.care);
            products[5] = new SpecialService("training", "Entrenamiento personalizado", 40, "Todas", "Entrenamiento para tu mascota", ProductTypes.special);
            products[6] = new SpecialService("grooming", "Peliqueria para mascotas", 20, "Todas", "Peliqueria para tu mascota", ProductTypes.special);
            products[7] = new SpecialService("vetappointment", "Consulta veterinaria", 25, "Todas", "Consulta veterinaria para tu mascota", ProductTypes.special);
            products[8] = new SpecialService("lodging", "Alojamiento", 15, "Todas", "Alojamiento por noche para tu mascota", ProductTypes.special);
            products[9] = new SpecialService("photoshot", "Sesion de fotos", 25, "Todas", "Sesion de fotos para tu mascota en estudio profesional - 10 fotos", ProductTypes.special);

            //products[0] = new Food("dogfood1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para Perro de 1kg", ProductTypes.care);
            //products[1] = new Food("catfood1kg", "Purina Cat Chow 1kg", 5, "Gato", "Comida para Gato de 1kg", ProductTypes.care);
            //products[2] = new Beed("docbeedsm", "Cama para Perro", 30, "Perro", "Cama para perros - Pequena", ProductTypes.care);
            //products[3] = new Beed("docbeedmd", "Cama para Perro", 40, "Perro", "Cama para perros - Mediana", ProductTypes.care);
            //products[4] = new Beed("docbeedlg", "Cama para Perro", 40, "Perro", "Cama para perros - Grande", ProductTypes.care);
            //products[5] = new Beed("catbeed", "Cama para Gato", 25, "Gato", "Cama para gatos - Todos los tamanos", ProductTypes.care);

        }

        /// <summary>
        /// Imprime todos los productos
        /// </summary>
        public void PrintAllProducts()
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(i + 1 + ")");
                Console.ResetColor();
                products[i].PrintProduct();
            }
        }

        /// <summary>
        /// Imprime los productos de una categoria
        /// </summary>
        /// <param name="_category"></param>
        public void PrintProductsByCategory(ProductTypes _category)
        {
            int count = 0;
            foreach (var product in products)
            {
                if (product.GetProductType() == _category)
                {
                    count++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(count + ")");
                    Console.ResetColor();
                    product.PrintProduct();
                }
            }
            if (count == 0)
            {
                string message = "0 productos encontrados";
                Console.WriteLine(message.PadLeft(Console.WindowWidth / 2 + message.Length / 2));
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetProductsLength()
        {
            return products.Length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_category"></param>
        /// <returns></returns>
        public int GetProductsByCategoryLength(ProductTypes _category)
        {
            int count = 0;
            foreach (var product in products)
            {
                if (product.GetProductType() == _category)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetProductsId()
        {
            int length = GetProductsLength();
            string[] ids = new string[length];
            for (int i = 0; i < length; i++)
            {
                ids[i] = products[i].GetId();
            }
            return ids;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_category"></param>
        /// <returns></returns>
        public string[] GetProductsIdByCategory(ProductTypes _category)
        {
            int length = GetProductsByCategoryLength(_category);
            string[] ids = new string[length];

            for (int i = 0; i < length; i++)
            {
                if (products[i].GetProductType() == _category)
                {
                    ids[i] = products[i].GetId();
                }
            }
            return ids;
        }

    }
}
