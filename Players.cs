namespace XO
{
    /// <summary>
    /// Класс игрока за которого играет человек
    /// </summary>
    class Players : IPlayer
    {
        /// <summary>
        /// Маркер игрока
        /// </summary>
        private CellStatus mark;

        /// <summary>
        /// Имя игрока
        /// </summary>
        private string player_name;

        /// <summary>
        /// Номер ячейки, которую выбрал в текущем ходе игрок
        /// </summary>
        private int index;

        /// <summary>
        /// Устанавливаем номер ячейки, которую выбрал игрок в текущем ходе
        /// </summary>
        /// <param name="index">Индекс ячейки</param>
        public void SetIndex(int index)
        {
            this.index = index;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mark">Маркер игрока</param>
        public Players(CellStatus mark)
        {
            this.mark = mark;
            index = -1;
        }

        /// <summary>
        /// Возвращает маркер игрока
        /// </summary>
        /// <returns>Маркер игрока</returns>
        public CellStatus GetMark()
        {
            return mark;
        }

        /// <summary>
        /// Устанавливает имя игрока
        /// </summary>
        /// <param name="name">Имя игрока</param>
        public void SetPlayerName(string name)
        {
            player_name = name;
        }

        /// <summary>
        /// Возвращает имя игрока
        /// </summary>
        /// <returns>Имя игрока</returns>
        public string GetPlayerName()
        {
            return player_name;
        }

        /// <summary>
        /// Возвращает тип игрока - человек
        /// </summary>
        /// <returns>Тип игрока</returns>
        public PlayerType GetPlayerType()
        {
            return PlayerType.Human;
        }

        /// <summary>
        /// Устанавливает маркер игрока
        /// </summary>
        /// <param name="mark">Маркер игрока</param>
        public void SetMark(CellStatus mark)
        {
            this.mark = mark;
        }
        
        /// <summary>
        /// Возвращаем номер ячейки текущего хода игрока
        /// </summary>
        /// <returns>Индекс ячейки</returns>
        public int Step()
        {
            return index;
        }
    }
}
