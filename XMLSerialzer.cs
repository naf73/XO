using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace XO
{
    /// <summary>
    /// Класс xml сериализатора
    /// </summary>
    static class XMLSerialzer
    {
        /// <summary>
        /// Читаем xml-файл тип Statistics
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Statistics> GetData(string filePath)
        {
            var xs = new XmlSerializer(typeof(List<Statistics>));

            using (var sr = new StreamReader(filePath))
            {
                return xs.Deserialize(sr) as List<Statistics>;
            }
        }

        /// <summary>
        /// Записываем xml-файп тип Statistics
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public static void SetData(string filePath, List<Statistics> data)
        {
            var xs = new XmlSerializer(typeof(List<Statistics>));

            using (var sw = new StreamWriter(filePath))
            {
                xs.Serialize(sw, data);
            }
        }
    }
}
