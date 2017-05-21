using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;

namespace XO
{
    /// <summary>
    /// Класс json сериализатора
    /// </summary>
    static class JSONSerialzer
    {
        /// <summary>
        /// Читаем json-файл тип Statistics
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Statistics> GetData(string filePath)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Statistics>));

            using (var fs = new FileStream(filePath,FileMode.OpenOrCreate))
            {
                List<Statistics> result = new List<Statistics>();
                result = (List<Statistics>)jsonFormatter.ReadObject(fs);
                return result;
            }
        }

        /// <summary>
        /// Записываем json-файп тип Statistics
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public static void SetData(string filePath, List<Statistics> data)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Statistics>));

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, data);
            }
        }
    }
}
