﻿using System;
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

        public List<MovimentoFileExecel> MovimentExcel(string directory)
        {


            var wb = new XLWorkbook(directory);
            var planilha = wb.Worksheet(1);

            var movimento = new List<MovimentoFileExecel>();

            var linha = 3;

            while (true)
            {

                if (string.IsNullOrEmpty(planilha.Cell("A" + linha.ToString()).Value.ToString())) break;

                movimento.Add(new MovimentoFileExecel
                    (
                                                       planilha.Cell("A" + linha.ToString()).Value.ToString()
                                                     , planilha.Cell("B" + linha.ToString()).Value.ToString().Split(' ')[0]
                                                     , planilha.Cell("C" + linha.ToString()).Value.ToString()
                                                     , planilha.Cell("D" + linha.ToString()).Value.ToString()
                                                     , planilha.Cell("E" + linha.ToString()).Value.ToString()
                                                     , planilha.Cell("F" + linha.ToString()).Value.ToString()
                                                     , planilha.Cell("J" + linha.ToString()).Value.ToString())
                    );

                linha++;
            }

            planilha.Dispose();
            wb.Dispose();


            return movimento;

        }



        #endregion




    }
}
