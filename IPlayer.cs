using System;

namespace XO
{
    /// <summary>
    /// Интерфейс для классов игрока и компьютера
    /// </summary>
    interface IPlayer
    {
        /// <summary>
        /// Устанавливает маркер игрока
        /// </summary>
        /// <param name="mark"></param>
        void SetMark(CellStatus mark);

        /// <summary>
        /// Возвращает маркер игрока
        /// </summary>
        /// <returns>Маркер</returns>
        CellStatus GetMark();

        /// <summary>
        /// Возвращает тип игрока
        /// </summary>
        /// <returns>Тип игрока</returns>
        PlayerType GetPlayerType();

        /// <summary>
        /// Вовращает имя игрока
        /// </summary>
        /// <returns>Имя игрока</returns>
        String GetPlayerName();

        /// <summary>
        /// Устанавливает имя игрока
        /// </summary>
        /// <param name="name">Имя игрока</param>
        void SetPlayerName(string name);

        /// <summary>
        /// Шаг игрока
        /// </summary>
        /// <returns>индекс ячейки</returns>
        int Step();
    }
}
