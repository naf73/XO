using System;
using System.Collections.Generic;

namespace XO
{
    /// <summary>
    /// Класс, игрока за которого играет компьютер
    /// </summary>
    class Computers : IPlayer
    {
        /// <summary>
        /// Маркер компьютера
        /// </summary>
        private CellStatus mark;

        /// <summary>
        /// Уровень компьютера
        /// </summary>
        private ComputerLevel level;

        /// <summary>
        /// Текущее состояние поля
        /// </summary>
        private CellStatus[] cells;

        /// <summary>
        /// Имя компьютера
        /// </summary>
        private string player_name;

        /// <summary>
        /// 2-массив выигрышных комбинаций
        /// </summary>
        private int[][] win_combinations;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mark"></param>
        /// <param name="level"></param>
        public Computers(CellStatus mark, ComputerLevel level)
        {
            this.mark = mark;
            this.level = level;
            player_name = "Компьютер";

            // === Получаем выигрышные комбинации
            GameLogics logic = new GameLogics();
            win_combinations = logic.GetWinCombiinations();
        }
        
        /// <summary>
        /// Возвращаем маркер компьютера
        /// </summary>
        /// <returns></returns>
        public CellStatus GetMark()
        {
            return mark;
        }

        /// <summary>
        /// Устанавливает текущее состояние ячеек на игровом поле
        /// </summary>
        /// <param name="field"></param>
        public void SetField(CellStatus[] field)
        {
            cells = field;
        }

        /// <summary>
        /// Компьютер делает шаг
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="mark"></param>
        /// <returns></returns>
        public int Step()
        {
            int result = -1;
            switch(level)
            {
                case ComputerLevel.easy:
                    result = ComputerEasy(cells);
                    break;
                case ComputerLevel.hard:
                    result = ComputerHard(cells);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Метод делает ход за компьютера уровень Глупый
        /// </summary>
        private int ComputerEasy(CellStatus[] cells)
        {
            int res = -1;
            // Определяем пустые ячейки
            List<int> empty_cells = new List<int>();

            for (int i = 0; i < cells.Length; i++)
            {
                if(cells[i] == CellStatus.Empty)
                {
                    empty_cells.Add(i);
                }
            }

            //Случайная постановка маркера в клетку
            if (empty_cells.Count > 1)
            {
                bool stop = true;
                Random rnd = new Random();
                int number;
                while (stop)
                {
                    number = empty_cells[rnd.Next(0, empty_cells.Count)];
                    for (int i = 0; i < cells.Length; i++)
                    {
                        if (i == number)
                        {
                            if (cells[i] == CellStatus.Empty)
                            {
                                res = i;
                                stop = false;
                            }
                        }
                    }
                }
            }
            else
            {
                res = empty_cells[0];
            }
            return res;
        }

        /// <summary>
        /// Возвращает тип игрока - компьютер
        /// </summary>
        /// <returns></returns>
        public PlayerType GetPlayerType()
        {
            return PlayerType.Computer;
        }

        /// <summary>
        /// Возвращает имя игрока - компьютер
        /// </summary>
        /// <returns></returns>
        public string GetPlayerName()
        {
            return player_name;
        }

        /// <summary>
        /// Устанавливаем маркер для компьютера
        /// </summary>
        /// <param name="mark"></param>
        public void SetMark(CellStatus mark)
        {
            this.mark = mark;
        }

        /// <summary>
        /// Устанавливает имя игроку компьютер
        /// </summary>
        /// <param name="name"></param>
        public void SetPlayerName(string name)
        {
            player_name = name;
        }

        /// <summary>
        /// Устанавливает уровень сложности компьтера
        /// </summary>
        /// <param name="level"></param>
        public void SetComputerLevel(ComputerLevel level)
        {
            this.level = level;
        }

        /// <summary>
        /// Метод делает ход за компьютера уровень Умный
        /// </summary>
        private int ComputerHard(CellStatus[] cells)
        {
            int res = -1;
            #region 0. Получаем маркер противника
            CellStatus opponent_mark;
            if (mark == CellStatus.Cell_X)
            {
                opponent_mark = CellStatus.Cell_O;
            }
            else
            {
                opponent_mark = CellStatus.Cell_X;
            }
            #endregion
            
            #region 1. Занимаем центр
            if (cells[4] == CellStatus.Empty)
            {
                res = 4;
                return res;
            }
            #endregion

            #region 2. Определяем клетку победного хода компьютера

            foreach (int[] combinate in win_combinations)
            {
                int i;
                int cell_number;
                i = 0;
                cell_number = 0;
                // Определяем линию с двумя заполнеными одинаковыми маркера (свою)
                foreach (int number in combinate)
                {
                    for (int j = 0; j < cells.Length; j++)
                    {
                        if (j == number)
                        {
                            if (cells[j] == mark)
                            {
                                i++;
                            }
                            else
                            {
                                cell_number = number;
                            }
                        }
                    }
                }
                // Если нашли такую линию, то получаем индекс свободной ячейки
                if (i == 2)
                {
                    for (int j = 0; j < cells.Length; j++)
                    {
                        if (j == cell_number)
                        {
                            if (cells[j] == CellStatus.Empty)
                            {
                                res = j;
                                return j;
                            }
                        }
                    }
                }
            }
            #endregion

            #region 3. Определяем клетки победного хода противника
            foreach (int[] combinate in win_combinations)
            {
                int i;
                int cell_number;
                i = 0;
                cell_number = 0;
                // Определяем линию с двумя заполнеными одинаковыми маркера (противника)
                foreach (int number in combinate)
                {
                    for (int j = 0; j < cells.Length; j++)
                    {
                        if (j == number)
                        {
                            if (cells[j] == opponent_mark)
                            {
                                i++;
                            }
                            else
                            {
                                cell_number = number;
                            }
                        }
                    }
                }
                // Если нашли такую линию, то получаем индекс свободной ячейки
                if (i == 2)
                {
                    for (int j = 0; j < cells.Length; j++)
                    {
                        if (j == cell_number)
                        {
                            if (cells[j] == CellStatus.Empty)
                            {
                                res = j;
                                return j;
                            }
                        }
                    }
                }
            }
            #endregion

            #region 4. Ставим второй маркер в свободной линии
            foreach (int[] combinate in win_combinations)
            {
                int i;
                i = 0;
                // Определяем свободную линию
                foreach (int number in combinate)
                {
                    for (int j = 0; j < cells.Length; j++)
                    {
                        if (j == number)
                        {
                            if (cells[j] == CellStatus.Empty)
                            {
                                i++;
                            }
                        }
                    }
                    // Если нашли свободную линию, то получаем первый индекс свободной ячейки
                    if (i == 3)
                    {
                        for (int j = 0; j < cells.Length; j++)
                        {
                            if (j == number)
                            {
                                if (cells[j] == CellStatus.Empty)
                                {
                                    res = j;
                                    return j;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 5. Ставим маркер в оставщихся свободных ячейках (рандомно)

            // Получаем случайную свободную ячейку
            res = ComputerEasy(cells);
            
            #endregion

            return res;
        }

    }
}
