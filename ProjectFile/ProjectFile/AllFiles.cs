using System;
using System.IO;
using ClosedXML.Excel;
using System.Collections.Generic;


namespace ProjectFile
{
    class AllFiles
    {
        public List<MovimentoFileExecel> Movimento;


        #region Method

        public bool DeleteFiles(string directory)
        {

            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory);

                if (files.Length > 0)
                {
                    foreach (string item in files)
                    {
                        var file = new FileInfo(item);
                        file.Delete();
                    }
                    return true;
                }
                else
                    return false;

            }
            else
                return false;

        }


        public bool DeleteDirectory(string directory)
        {

            if (Directory.Exists(directory))
            {
                DeleteFiles(directory);
                Directory.Delete(directory);

                return true;
            }

            else
                return false;
        }

        public bool CopyFiles(string origin, string destiny)
        {
            if (Directory.Exists(origin))
            {
                string[] files = Directory.GetFiles(origin);

                if (Directory.Exists(destiny))
                {
                    DeleteDirectory(destiny);
                    Directory.CreateDirectory(destiny);
                }
                else
                    Directory.CreateDirectory(destiny);

                foreach (string fil in files)
                {
                    var item = new FileInfo(fil);
                    Console.WriteLine(" - " + item.Name);
                    item.CopyTo(Path.Combine(destiny, item.Name));
                }

                if (Directory.Exists(destiny))
                {
                    string[] dest = Directory.GetFiles(destiny);

                    if (dest.Length > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;

            }
            else
                return false;

        }

        public void MovimentExcel(string directory) {
            var wb = new XLWorkbook(directory);
            var planilha = wb.Worksheet(1);

  
            Console.WriteLine("".PadRight(50, '-'));
            Console.WriteLine("Sinistro".PadRight(35) + "Valor do Movimento".PadLeft(15));
            Console.WriteLine("".PadRight(50, '-'));

            var linha = 3;

            while (true)
            {
             



                var movimento = planilha.Cell("A" + linha.ToString()).Value.ToString();
                var data = planilha.Cell("B" + linha.ToString()).Value.ToString();
                var placa = planilha.Cell("C" + linha.ToString()).Value.ToString();
                var diversos = planilha.Cell("D" + linha.ToString()).Value.ToString();
                var local = planilha.Cell("E" + linha.ToString()).Value.ToString();
                var estado = planilha.Cell("F" + linha.ToString()).Value.ToString();
                var total = planilha.Cell("J" + linha.ToString()).Value.ToString();

                if (string.IsNullOrEmpty(movimento)) break;

                Console.WriteLine(movimento + " - "
                                    + data + " - "
                                    + placa + " - "
                                    + diversos + " - "
                                    + local + " - "
                                    + estado + " - "
                                    + total);

                linha++;
            }

            planilha.Dispose();
            wb.Dispose();

            Console.WriteLine("".PadRight(50, '-'));
            Console.WriteLine("Feito");

            Console.ReadKey();



        }



        #endregion




    }
}
