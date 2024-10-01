using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_v2.Storage
{
    public class StorageWriter
    {
        private string filePath;

        public StorageWriter(string path)
        {
            filePath = path;
        }

        public void SaveCommand(string command)
        {
            //команда записывается в конец файла (параметр true)
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                //записывает данные, только после записи добавляет в файл символ окончания строки
                sw.WriteLineAsync(command);
            }
        }
        //добавить сохранитель кооординат

        // метод для очистки файла
        public void ClearFile()
        {
            File.WriteAllTextAsync(filePath, string.Empty);

        }


    }
}
