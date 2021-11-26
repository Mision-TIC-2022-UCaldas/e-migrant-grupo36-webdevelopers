using System;

namespace IMC.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELLCOME TO WEB DEVELOPERS \n");
            DiagnosticoIMC();
        }
   
   private static void DiagnosticoIMC()
        {   
            double peso;
            double altura;
            Console.WriteLine("Introduzca su peso (Kgrs): ");
            peso=double.Parse(Console.ReadLine());
            Console.WriteLine("Introduzca su altura (mts): ");
            altura=double.Parse(Console.ReadLine());

            double CalculoIMC= peso/(altura*altura);

            if (CalculoIMC < 16)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Delgadez Severa");
            }else if (CalculoIMC > 16 && CalculoIMC <= 16.99)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Delagadez Moderada");
            }else if (CalculoIMC > 17 && CalculoIMC <= 18.49)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Delagadez aceptable");
            }else if (CalculoIMC > 18.49 && CalculoIMC <= 24.99)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Peso Normal");
            }else if (CalculoIMC > 24.99 && CalculoIMC <= 29.99)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Sobrepeso");
            }else if (CalculoIMC > 29.99 && CalculoIMC <= 34.99)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Obesidad tipo I");
            }else if (CalculoIMC > 34.99 && CalculoIMC <= 39.99)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Obesidad tipo II");
            }else if (CalculoIMC > 39.99 && CalculoIMC <= 49.99)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Obesidad tipo III o Mórbida");
            }else if (CalculoIMC > 50)
            {
                Console.WriteLine("Su IMC es: "+CalculoIMC+"\nSu diagnostico es: Obesidad tipo IV o extrema");
            }else{
                Console.WriteLine("Valida tus datos!!!");
            } 
            

        }

    }

}

