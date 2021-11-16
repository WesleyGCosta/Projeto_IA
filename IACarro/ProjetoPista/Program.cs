using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ProjetoPista
{
    class Program
    {
        static List<Rastro> rastros = new List<Rastro>();
        Bitmap myBit = new Bitmap("url"); //ERROR
        static int width = 0;
        static int height = 0;
        static int e = 0;


        static void Main(string[] args)
        {

            Iniciar();
        }

        static void Iniciar()
        {

        }
    }
}
