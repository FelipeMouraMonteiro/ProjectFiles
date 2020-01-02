using System;
using System.IO;

namespace ProjectFile
{
    class Program
    {
        static void Main(string[] args)
        {
          
            try
            {
                AllFiles file = new AllFiles();


                string origin = @"C:\Users\Administrador\Desktop\TESTE";

                string destiny = @"C:\Users\Administrador\Desktop\SAIDA";


                if (file.CopyFiles(origin,destiny))
                {
                    
                    Console.WriteLine("Cópia efetuada com sucesso!");
   
                }
                else
                    Console.WriteLine("Cópia não efetuada!");



            }
            catch (IOException e)
            {
                Console.WriteLine("Error Files ");
                Console.WriteLine(e.Message);

            }
        }
    }
}
