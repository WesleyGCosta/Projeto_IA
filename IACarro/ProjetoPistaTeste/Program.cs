using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace ProjetoPistaTeste
{
    internal class Program
    {
        static List<Rastro> rastros = new List<Rastro>();
        static Bitmap mapaImg = new Bitmap("C:\\Users\\Wesle\\Mapa.bmp"); 
        static int width = 0;
        static int height = 0;
        static int e = 0;


        static void Main(string[] args)
        {
            Iniciar();
        }

        static void Iniciar()
        {
            width = mapaImg.Width;
            height = mapaImg.Height;

            Rastro primeiroRastro = new Rastro();
            primeiroRastro.x = 310;
            primeiroRastro.y = 100;
            primeiroRastro.distancia = 0;

            rastrear(primeiroRastro);
            rastrearTudo();
        }

        static void rastrearTudo()
        {
            while (true)
            {
                e++;
                if(e >= rastros.Count - 1)
                    break;
                rastrear(rastros[e]);
            }

            Gravar(new Mapas() { map = rastros });
        }


        static void Gravar(Mapas mapas)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Mapas));
            TextWriter tw = new StreamWriter(@"C:\Users\Wesle\Mapa.xml");
            xs.Serialize(tw, mapas);
            tw.Close();
        }

        static void rastrear(Rastro rastro)
        {
            if (rastro.x > width) return;
            if (rastro.y > width) return;
            if (rastro.x < 0) return;
            if (rastro.y < 0) return;

            Adicionar(rastro.x + 0, rastro.y + 0, rastro.distancia);
            Adicionar(rastro.x + 1, rastro.y + 0, rastro.distancia);
            Adicionar(rastro.x + 1, rastro.y + 1, rastro.distancia);
            Adicionar(rastro.x + 0, rastro.y + 1, rastro.distancia);
            Adicionar(rastro.x + 1, rastro.y + 1, rastro.distancia);
            Adicionar(rastro.x + 1, rastro.y + 0, rastro.distancia);
            Adicionar(rastro.x + 1, rastro.y + 1, rastro.distancia);
            Adicionar(rastro.x + 0, rastro.y + 1, rastro.distancia);
            Adicionar(rastro.x + 1, rastro.y + 1, rastro.distancia);

        }

        static void Adicionar(int x, int y, int pai)
        {
            if(y >= height) return;
            if(x >= width) return;
            if(y <= 0) return;
            if(y <= 0) return;

            Color c = mapaImg.GetPixel(x, y);

            if (c.R <= 10 && c.G <= 10 && c.B <= 10)
            {
                mapaImg.SetPixel(x, y, Color.Red);

                Rastro novoRastro = new Rastro();
                novoRastro.x = x;
                novoRastro.y = y;
                novoRastro.distancia = pai + 1;
                rastros.Add(novoRastro);
            }         
        }
    }
}
