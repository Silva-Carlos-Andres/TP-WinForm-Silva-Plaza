using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Categoria(string nombre)
        {
            Nombre = nombre;
        }
        public override string ToString()
        {
            return Nombre;
        }
        public Categoria(int id)
        {
            Id = id;
        }
        public Categoria(int id, string nombre)
        {
           Id = id;
            Nombre = nombre;
        }
    }
}
