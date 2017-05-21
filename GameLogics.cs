using System.Collections.Generic;

namespace XO
{
    /// <summary>
	/// Класс, храняищий информацию по полю
	/// </summary>
    class GameLogics
    {
        /// <summary>
        /// Игровое поле
        /// </summary>
        private List<CellStatus> cells;

        /// <summary>
        /// размер поля
        /// </summary>
        private int size = 3;

        /// <summary>
        /// Статус игры
        /// </summary>
        private GameStatus game_status;

        /// <summary>
        /// Cписок комбинаций победы
        /// </summary>
        private List<int[]> win_combinations;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameLogics()
        {
            game_status = GameStatus.NotStarted;

            // Инициализируем игровое поле
            cells = new List<CellStatus>();

            // Инициализация выигрышных комбинаций
            win_combinations = new List<int[]>();

            // по горизонтали
            win_combinations.Add(new int[] { 0, 1, 2 });
            win_combinations.Add(new int[] { 3, 4, 5 });
            win_combinations.Add(new int[] { 6, 7, 8 });

            // по вертикали
            win_combinations.Add(new int[] { 0, 3, 6 });
            win_combinations.Add(new int[] { 1, 4, 7 });
            win_combinations.Add(new int[] { 2, 5, 8 });

            // по диагоналям
            win_combinations.Add(new int[] { 0, 4, 8 });
            win_combinations.Add(new int[] { 2, 4, 6 });
        }

        /// <summary>
        /// Старт игры
        /// </summary>
        public void GameStart()
        {
            game_status = GameStatus.InProgress;

            for (int i = 0; i < size * size; i++)
            {
                cells.Add(CellStatus.Empty);
            }
        }

        /// <summary>
        /// Сбор игры
        /// </summary>
        public void GameReset()
        {
            game_status = GameStatus.NotStarted;
            cells.Clear();
        }

        /// <summary>
        /// Проверяет условие окончания игры
        /// </summary>
        /// <returns>true - игра не окончена, false - игра завершена</returns>
        private bool GameCheckEnd()
        {
            foreach (CellStatus cell in cells)
            {
                if (cell == CellStatus.Empty) return false;
            }
            return true;
        }

        /// <summary>
        /// Проверяет победу игрока
        /// </summary>
        /// <param name="mark">Метка игрока</param>
        /// <returns>true - игрок выиграл, false - игрок не выиграл</returns>
        private bool GameCheckWinner(CellStatus mark)
        {
            foreach (int[] combinate in win_combinations)
            {
                int i = 0;
                foreach (int number in combinate)
                {
                    for (int j = 0; j < cells.Count; j++)
                    {
                        if (j == number)
                        {
                            if (cells[j] == mark) i++;
                        }
                    }
                }
                if (i == size) return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращаем игровое поле в виде массива
        /// </summary>
        /// <returns>массив CellStatus</returns>
        public CellStatus[] GetField()
        {
            CellStatus[] array= new CellStatus[cells.Count];
            cells.CopyTo(array);
            return array;
        }

        /// <summary>
        /// Возвращаем статус игры
        /// </summary>
        /// <returns></returns>
        public GameStatus GetGameStatus()
        {
            return game_status;
        }

        /// <summary>
        /// Ход игрока
        /// </summary>
        public GameStatus GameStep(int index, CellStatus mark)
        {
            // === Проверяем что игра еще не окончена
            if(game_status != GameStatus.InProgress)
            {
                return game_status;
            }

            // === Добавляем маркер на поле
            if (index > -1 && index < cells.Count)
            {
                if (cells[index] == CellStatus.Empty)
                {
                    cells[index] = mark;
                }
                else
                {
                    throw new XOFilledCellException()
                    {
                        row = index % 3 + 1,
                        col = index / 3 + 1
                    };
                }
            }

            // === Проверяем игру на выигрыш игрока
            if(GameCheckWinner(mark))
            {
                switch(mark)
                {
                    case CellStatus.Cell_X:
                        game_status = GameStatus.PlayerXWin;
                        break;
                    case CellStatus.Cell_O:
                        game_status = GameStatus.PlayerOWin;
                        break;
                }
            }

            // === Проверяем завершение игры на ничью
            if(!GameCheckWinner(mark) && GameCheckEnd())
            {
                game_status = GameStatus.NoWin;
            }

            return game_status;
        }

        /// <summary>
        /// Вовращаем выигрышные комбинации
        /// </summary>
        /// <returns>Массив числовых комбинаций</returns>
        public int[][] GetWinCombiinations()
        {
            int[][] result = new int[win_combinations.Count][];
            win_combinations.CopyTo(result);
            return result;
        }

    }
}
