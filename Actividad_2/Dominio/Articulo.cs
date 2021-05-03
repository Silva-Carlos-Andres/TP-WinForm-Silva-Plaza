﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public Decimal Precio { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        //public Articulo(int codigo, string nombre, string descripcion, string imagenUrl, decimal precio)
        //   // public Articulo(int id)
        //{
        //    Id = id;
        //    Codigo = codigo;
        //    Nombre = nombre;
        //    Descripcion = descripcion;
        //    ImagenUrl = imagenUrl;
        //    Precio = precio;
        //}

    }
}
