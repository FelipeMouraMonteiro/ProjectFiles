using System;
using System.Collections.Generic;


namespace ProjectFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string origin = @"C:\Users\Administrador\Desktop\TESTE\PLANILHA.xlsx";

            AllFiles file = new AllFiles();

            List<MovimentoFileExecel> list = file.MovimentExcel(origin);

            
            int contador = 0;

            foreach (var mov in list)
            {

                contador++;
                Console.WriteLine(" " + mov.ToString());
                
            }


        }
    }
}
