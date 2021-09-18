using System;
using System.Collections.Generic;
using System.Linq;
namespace Practica_de_linq
{
    class Program
    {
        static void Main(string[] args)
        {

            List<producto> Productos = new List<producto>(){

                new producto() { id=1,Nombre = "Cloro ", categoriaId = 1,marca="JAJA",modelo="Generico",precio=10000},
                new producto() { id=2,Nombre = "Pollo ", categoriaId = 2,marca="Don tomas",modelo="Generico",precio=35000 },
                new producto() { id=2, Nombre = "Jugo de Chinola ", categoriaId = 3 ,marca="Fripom",modelo="Generico",precio=4000},
                new producto() { id=1,Nombre = "Pan Ultramas ", categoriaId = 4,marca="El panadero",modelo="Generico",precio=2500 },
                new producto() { id=2,Nombre = "Tapas de banos", categoriaId = 5,marca="Cagadin",modelo="Generico",precio=4700 },
                new producto() { id=2, Nombre = "Mango pom ", categoriaId = 3 ,marca="Rica",modelo="Generico",precio=3100},
                new producto() { id=1,Nombre = "Mistolin ", categoriaId = 1,marca="El perfume",modelo="Generico",precio=8000 },
                new producto() { id=2,Nombre = "Jane lomo de cerdo", categoriaId = 2,marca="Pedro Pecho",modelo="Generico",precio=7000 },
                new producto() { id=2, Nombre = "Joe bam ", categoriaId = 5 ,marca="Bambino",modelo="Generico",precio=15000},
                new producto() { id=1,Nombre = "Ultramas Doe", categoriaId = 5,marca="Dante doe",modelo="Generico",precio=3400 }
        
         };

            List<Categoria> Categorias = new List<Categoria>() { 
                new Categoria() {Id= 1,Nombre="Limpieza" },
                new Categoria() {Id= 2,Nombre="Carniceria" },
                new Categoria() {Id= 3,Nombre="Juegos" },
                new Categoria() {Id= 4,Nombre="Panaderia" },
                new Categoria() {Id= 5,Nombre="General" }



            };


            var lista_producto = (from x in Productos where x.categoriaId == 5
                                 select x).ToList();

            var listado_mayores = (from e in Productos
                                   where e.precio >= 3000 && e.precio < 5000
                                   orderby e.id descending
                                   select e).ToList();

            var uniones  = (from e in Productos
                                   join a in Categorias 
                                   on e.categoriaId equals a.Id
                                   select new {Id=e.id,Nombre=e.Nombre, Categoria=a.Nombre }).ToList();



            Console.WriteLine(" Productos por una categoría en especifico. ");
            foreach (var item in lista_producto)
            {
                
                Console.WriteLine(" {0},{1},{2},{3},{4},{5}", item.id, item.Nombre, item.categoriaId, item.marca, item.modelo, item.precio);


            }
            Console.WriteLine(" Los productos con precios mayores de 3,000 pesos pero menores de 5000 pesos, ordenados descendente mente. ");
            foreach (var iteme in listado_mayores)
            {
                
                Console.WriteLine(" {0},{1},{2},{3},{4},{5}", iteme.id, iteme.Nombre, iteme.categoriaId, iteme.marca, iteme.modelo, iteme.precio);


            }
            Console.WriteLine(" Los nombres de las categorías de los productos registrado. ");

            foreach (var iteme in uniones)
            {

                Console.WriteLine(" {0},{1},{2}", iteme.Id  ,iteme.Nombre, iteme.Categoria );


            }

           

            Console.ReadKey();
        }
    }




    public class producto
    {
        public int id {get; set;}
        public string Nombre {get; set;}
        public int categoriaId { get; set;}
        public string marca { get; set;}
        public string modelo { get; set;}
        public decimal precio { get; set; }

    
    }
    public class Categoria 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
     }



}
