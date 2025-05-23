﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using your_four_legged_child.src.enums;
using your_four_legged_child.src.models;
using your_four_legged_child.src.models.accessories;
using your_four_legged_child.src.models.care;
using your_four_legged_child.src.models.services;

namespace your_four_legged_child.src.core
{
    /*
    TDA STORE (continuación)

    - Métodos:
    Vacío                   GenerarProductos()
    Vacío                   ImprimirTodosLosProductos()
    Vacío                   ImprimirProductosPorCategoría(ProductTypes _category)
    Entero                  LargoDelArrayProductos()
    Entero                  CantidadDeProductosCategoría(ProductTypes _category)
    Array de C. Caracteres  GetProductsId()
    Array de C. Caracteres  GetProductsIdByCategory(ProductTypes _category)
     */

    internal partial class Store
    {
        /// <summary>
        /// Instancia todos los productos que se van a utilizar en el programa y los pone el el array products[]
        /// </summary>
        public void GenerateProducts()
        {
            products[0] = new Food("dogfood1kg", "Purina Dog Chow 1kg", 5, "Perro", "Comida para Perro de 1kg", ProductTypes.care);
            products[1] = new Bed("catbeed", "Cama para Gato", 25, "Gato", "Cama para gatos - Todos los tamanos", ProductTypes.care);
            products[2] = new Toys("dogtoychewy", "Jueguete masticable para Perro", 15, "Perro", "Jueguete de gota masticable para perros - Razas Mediana - Grande", ProductTypes.care);
            products[3] = new Collars("dogharness", "Pechera para perro", 20, "Perro", "Perchera para Perro - Razas Pequena - Mediana", ProductTypes.care);
            products[4] = new Product("alltoothbrush", "Cepillo de dientes para animales", 3, "Todos", "Cepillo de dientes para todo tipo de animal", ProductTypes.care);
            products[5] = new SpecialService("training", "Entrenamiento personalizado", 40, "Todas", "Entrenamiento para tu mascota", ProductTypes.special);
            products[6] = new SpecialService("grooming", "Peliqueria para mascotas", 20, "Todas", "Peliqueria para tu mascota", ProductTypes.special);
            products[7] = new SpecialService("vetappointment", "Consulta veterinaria", 25, "Todas", "Consulta veterinaria para tu mascota", ProductTypes.special);
            products[8] = new SpecialService("lodging", "Alojamiento", 15, "Todas", "Alojamiento por noche para tu mascota", ProductTypes.special);
            products[9] = new SpecialService("photoshot", "Sesion de fotos", 25, "Todas", "Sesion de fotos para tu mascota en estudio profesional - 10 fotos", ProductTypes.special);
            products[10] = new Clothes("dogpinkdress", "Vestido rosado para perro", 50, "Perro", "Vestido rosado para perros pequenos", ProductTypes.accessories);
            products[11] = new Product("cattiara", "Tiara para gatos", 25, "Gato", "Tiara dorada con perlas para gato", ProductTypes.accessories);
            products[12] = new Backpack("petcarrier", "Transportador de mascotas mediano", 75, "Todas", "Transportador de mascotas personalizado", ProductTypes.accessories);
            products[13] = new Cups("coffecub", "Taza de cafe", 25, "Todas", "Taza de cafe impreso con una foto de tu mascota y una frase", ProductTypes.accessories);
            products[14] = new Product("doglamp", "Lampara con forma de perro", 45, "Todas", "Lampara de mesa con forma de Golder Retriever", ProductTypes.accessories);
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
        /// Retorna el numero de productos que se venden en la tienda
        /// </summary>
        /// <returns></returns>
        public int GetProductsLength()
        {
            return products.Length;
        }

        /// <summary>
        /// Retorna el numero de productos que hay en una categoria
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
        /// Retorna todos los ids de los productos
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
        /// Retorna todos los ids de productos de una categoria
        /// </summary>
        /// <param name="_category"></param>
        /// <returns></returns>
        public string[] GetProductsIdByCategory(ProductTypes _category)
        {
            int length = GetProductsByCategoryLength(_category);
            int count = 0;
            string[] ids = new string[length];

            foreach (var product in products)
            {
                if (product.GetProductType() == _category)
                {
                    ids[count] = product.GetId();
                    count++;
                }
            }

            return ids;
        }

    }
}
