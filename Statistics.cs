using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace XO
{
    /// <summary>
    /// Класс для записи статистики
    /// </summary>
    [XmlType("statistics")]
    [DataContract]
    public class Statistics
    {
        /// <summary>
        /// Дата
        /// </summary>
        [XmlElement("date")]
        [DataMember]
        public DateTime Date { get; set; }

        /// <summary>
        /// Результат игры
        /// </summary>
        [XmlElement("result")]
        [DataMember]
        public GameStatus Result { get; set; }

        /// <summary>
        /// Имя победителя
        /// </summary>
        [XmlElement("name")]
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Количество ходов за игру
        /// </summary>
        [XmlElement("step")]
        [DataMember]
        public int StepCounter { get; set; }
    }
}
