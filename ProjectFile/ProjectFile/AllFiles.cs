using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProjectFile
{
    class AllFiles
    {


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
        #endregion




    }
}
