using System;
using System.Windows.Forms;

namespace XO
{
    public partial class FormGame : Form
    {
        #region Область объявления переменных
        public string game_name = "Игра XO";
        private CurrentPlayer player_current; // текущий игрок
        private ComputerLevel computer_level_current; // текущий уровень компьютера

        private IPlayer player1; // игрок 1
        private IPlayer player2; // игрок 2

        GameLogics logic;

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public FormGame()
        {
            InitializeComponent();
            InitField(false);
            logic = new GameLogics();
            GameSetting(true);
            // Настройки по умолчанию
            LoadDefaultSetting();
        }

        #region Область методов игры

        /// <summary>
        /// Загрузка настроек игры при первом запуске
        /// </summary>
        private void LoadDefaultSetting()
        {
            // Инициализируем игрока 1
            switch ((PlayerType)Properties.Settings.Default.player1)
            {
                case PlayerType.Human:
                    player1 = new Players((CellStatus)Properties.Settings.Default.player1_mark);
                    cmb_player_1.SelectedIndex = 0;
                    break;
                case PlayerType.Computer:
                    player1 = new Computers((CellStatus)Properties.Settings.Default.player1_mark, (ComputerLevel)Properties.Settings.Default.computer_level_current);
                    cmb_player_1.SelectedIndex = 1;
                    break;
            }

            // Инициализируем игрока 2
            switch ((PlayerType)Properties.Settings.Default.player2)
            {
                case PlayerType.Human:
                    if ((CellStatus)Properties.Settings.Default.player1_mark == CellStatus.Cell_X)
                    {
                        player2 = new Players(CellStatus.Cell_O);
                    }
                    else
                    {
                        player2 = new Players(CellStatus.Cell_X);
                    }
                    cmb_player_2.SelectedIndex = 0;
                    break;
                case PlayerType.Computer:
                    if ((CellStatus)Properties.Settings.Default.player1_mark == CellStatus.Cell_X)
                    {
                        player2 = new Computers(CellStatus.Cell_X, (ComputerLevel)Properties.Settings.Default.computer_level_current);
                    }
                    else
                    {
                        player2 = new Computers(CellStatus.Cell_O, (ComputerLevel)Properties.Settings.Default.computer_level_current);
                    }
                    cmb_player_2.SelectedIndex = 1;
                    break;
            }

            // Выставляем маркер первого игрока в combobox
            switch ((CellStatus)Properties.Settings.Default.player1_mark)
            {
                case CellStatus.Cell_X:
                    cmb_player_1_mark.SelectedIndex = 0;
                    break;
                case CellStatus.Cell_O:
                    cmb_player_1_mark.SelectedIndex = 1;
                    break;
            }

            // Номер игрока, который должен совершить ход
            player_current = (CurrentPlayer)Properties.Settings.Default.player_current;
            switch (player_current)
            {
                case CurrentPlayer.Player1:
                    cmb_first_step.SelectedIndex = 0;
                    break;
                case CurrentPlayer.Player2:
                    cmb_first_step.SelectedIndex = 1;
                    break;
            }

            // Активируем блок настройки компьютера, если хотя бы один из игроков компьютер
            if (cmb_player_1.SelectedIndex == 1 || cmb_player_2.SelectedIndex == 1)
            {
                gbx_type_comp.Enabled = true;
            }
            else
            {
                gbx_type_comp.Enabled = false;
            }

            // === Устанавливаем уровень сложности игроков компьютеров
            computer_level_current = (ComputerLevel)Properties.Settings.Default.computer_level_current;
            SetComputerLevel(computer_level_current);
            // ===
            switch ((ComputerLevel)Properties.Settings.Default.computer_level_current)
            {
                case ComputerLevel.easy:
                    rbtn_easy.Checked = true;
                    break;
                case ComputerLevel.hard:
                    rbtn_hard.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// Обновление состояния игры после шага
        /// </summary>
        /// <param name="player">Игрок, который должен выполнить ход</param>
        private void UpdateGame(IPlayer player)
        {
            if (logic.GetGameStatus() == GameStatus.InProgress)
            {
                // === Если текущий игрок компьютер, то передаем ему текущее состояние поля
                if (player.GetPlayerType() == PlayerType.Computer)
                {
                    ((Computers)player).SetField(logic.GetField());
                }

                // === Совершаем ход в игре
                logic.GameStep(player.Step(), player.GetMark());

                //=== Передаем ход другому игроку
                if (player_current == CurrentPlayer.Player1)
                {
                    player_current = CurrentPlayer.Player2;
                }
                else
                {
                    player_current = CurrentPlayer.Player1;
                }


                // === Отисовываем игровое поле
                int i = 0;
                CellStatus[] field = logic.GetField();
                foreach (Button btn in GameField.Controls)
                {
                    if (field[i] == CellStatus.Cell_X)
                    {
                        btn.Text = "X";
                    }
                    else if (field[i] == CellStatus.Cell_O)
                    {
                        btn.Text = "O";
                    }
                    i++;
                }
            }

            // === Выключаем таймер
            if (logic.GetGameStatus() != GameStatus.InProgress)
            {
                ComputerTimer.Enabled = false;
            }

            // === Определеяем статус игры и выводим соответствующее сообщение
            string message = String.Empty;
            switch (logic.GetGameStatus())
            {
                case GameStatus.PlayerXWin:
                    message = player.GetPlayerName() + " выиграл";
                    break;
                case GameStatus.PlayerOWin:
                    message = player.GetPlayerName() + " выиграл";
                    break;
                case GameStatus.NoWin:
                    message = "Ничья";
                    break;
            }

            if (logic.GetGameStatus() == GameStatus.PlayerXWin ||
                logic.GetGameStatus() == GameStatus.PlayerOWin ||
                logic.GetGameStatus() == GameStatus.NoWin)
            {
                if(MessageBox.Show(message, game_name, MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    logic.GameReset();
                    InitField(false);
                    GameSetting(true);
                }
            }

        }

        /// <summary>
        /// Метод инициализирует игровое поле
        /// </summary>
        /// <param name="enabled">true - кнопки активны, false - кнопки не активны</param>
        public void InitField(bool enabled)
        {
            int i = 0;
            foreach (Button btn in GameField.Controls)
            {
                btn.Enabled = enabled;
                btn.Text = String.Empty;
                btn.Tag = i;
                i++;
            }
        }

        /// <summary>
        /// Метод активирует/деактивирует виджеты настроек игры
        /// </summary>
        /// <param name="active">true - настройки активы, false - настройки не активны</param>
        private void GameSetting(bool active)
        {
            cmb_first_step.Enabled = active;
            cmb_player_1.Enabled = active;
            cmb_player_1_mark.Enabled = active;
            cmb_player_2.Enabled = active;
            if (cmb_player_1.SelectedIndex == 1 || cmb_player_2.SelectedIndex == 1)
            {
                gbx_type_comp.Enabled = true;
            }
            else
            {
                gbx_type_comp.Enabled = false;
            }
            label1.Enabled = active;
            label2.Enabled = active;
            label3.Enabled = active;
            label4.Enabled = active;
        }

        /// <summary>
        /// Первый ход в игре (если первый ход за компьютером, либо игра между компьютерами
        /// </summary>
        private void FirstStep()
        {
            IPlayer player;
            if(player_current == CurrentPlayer.Player1)
            {
                player = player1;
            }
            else
            {
                player = player2;
            }

            // Если первый ход за компьютером, то делаем ход
            if(player.GetPlayerType() == PlayerType.Computer)
            {
                UpdateGame(player);
            }

            // Если игра между компьютерами, то переименовываем игроков (присваиваем индекс)
            // И включаем таймер
            if(player1.GetPlayerType() == PlayerType.Computer && player2.GetPlayerType() == PlayerType.Computer)
            {
                player1.SetPlayerName("Компьютер 1");
                player2.SetPlayerName("Компьютер 2");
                ComputerTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Присваивает имя Игрок, если играет человек - компьютер, человек - человек
        /// </summary>
        private void SetPlayersName()
        {
            if(player1.GetPlayerType() == PlayerType.Human)
            {
                player1.SetPlayerName("Игрок");
            }

            if (player2.GetPlayerType() == PlayerType.Human)
            {
                player2.SetPlayerName("Игрок");
            }

            // Если играют 2 человека между собой, то добавляем индексы
            if(player1.GetPlayerType() == PlayerType.Human && player2.GetPlayerType() == PlayerType.Human)
            {
                player1.SetPlayerName("Игрок 1");
                player2.SetPlayerName("Игрок 2");
            }
        }

        /// <summary>
        /// Устанавливаем для игроков - компьютеров уровень сложности
        /// </summary>
        /// <param name="level">Уровень сложности компьютера</param>
        private void SetComputerLevel(ComputerLevel level)
        {
            if (player1.GetPlayerType() == PlayerType.Computer)
            {
                ((Computers)player1).SetComputerLevel(level);
            }

            if (player2.GetPlayerType() == PlayerType.Computer)
            {
                ((Computers)player2).SetComputerLevel(level);
            }
        }
        
        #endregion

        #region События формы

        /// <summary>
        /// Метод для события клика мыши на игровом поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            IPlayer player;
            if (player_current == CurrentPlayer.Player1)
            {
                player = player1;
            }
            else
            {
                player = player2;
            }

            if (player.GetPlayerType() == PlayerType.Human)
            {
                ((Players)player).SetIndex(Convert.ToInt32(((Button)sender).Tag));
            }

            // Обновляем состояние игры после хода игрока
            UpdateGame(player);

            // Меняем очередь хода
            if (player_current == CurrentPlayer.Player1)
            {
                player = player1;
            }
            else
            {
                player = player2;
            }

            // Делаем ход компьютером
            if(player.GetPlayerType() == PlayerType.Computer)
            {
                UpdateGame(player);
            }

        }

        /// <summary>
        /// Метод для события нажатия кнопки "Старт игры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (logic.GetGameStatus() == GameStatus.NotStarted)
            {
                InitField(true);
                GameSetting(false);
                logic.GameStart();
                player_current = (CurrentPlayer)Properties.Settings.Default.player_current;
                SetPlayersName();
                FirstStep();
            }
            else
            {
                //throw new Exception();
            }
        }

        /// <summary>
        /// Событие переключения уровня сложности компьтера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_Changed(object sender, EventArgs e)
        {

            if (rbtn_easy.Checked)
            {
                computer_level_current = ComputerLevel.easy;
            }

            if (rbtn_hard.Checked)
            {
                computer_level_current = ComputerLevel.hard;
            }
            // ==== Устанавливаем новый уровень компьютеру
            SetComputerLevel(computer_level_current);
            // ==== Записываем изменение параметра
            Properties.Settings.Default.computer_level_current = Convert.ToInt32(computer_level_current);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Событие меняет очередность первого хода для игроков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_first_step_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_first_step.SelectedIndex)
            {
                case 0:
                    player_current = CurrentPlayer.Player1;
                    break;
                case 1:
                    player_current = CurrentPlayer.Player2;
                    break;
            }

            // ==== Записываем изменение параметра
            Properties.Settings.Default.player_current = Convert.ToInt32(player_current);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Событие изменяет тип игрока для игрока 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_player_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            player1 = null;
            switch(cmb_player_1.SelectedIndex)
            {
                case 0:
                    Properties.Settings.Default.player1 = Convert.ToInt32(PlayerType.Human);
                    player1 = new Players((CellStatus)Properties.Settings.Default.player1_mark);
                    break;
                case 1:
                    Properties.Settings.Default.player1 = Convert.ToInt32(PlayerType.Computer);
                    player1 = new Computers((CellStatus)Properties.Settings.Default.player1_mark, (ComputerLevel)Properties.Settings.Default.computer_level_current);
                    break;
            }

            // ==== Если один из игроков компьютер, то включаем бокс с настройкой уровня сложности
            if (cmb_player_1.SelectedIndex == 1 || cmb_player_2.SelectedIndex == 1)
            {
                gbx_type_comp.Enabled = true;
            }
            else
            {
                gbx_type_comp.Enabled = false;
            }

            // ==== Записываем изменение параметра
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Событие меняет маркеры между игроками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_player_1_mark_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmb_player_1_mark.SelectedIndex)
            {
                case 0:
                    player1.SetMark(CellStatus.Cell_X);
                    player2.SetMark(CellStatus.Cell_O);
                    break;
                case 1:
                    player1.SetMark(CellStatus.Cell_X);
                    player2.SetMark(CellStatus.Cell_O);
                    break;
            }
            // ==== Записываем изменение параметра
            Properties.Settings.Default.player1_mark = Convert.ToInt32(player1.GetMark());
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Событие изменяет тип игрока для игрока 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_player_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            player2 = null;
            switch (cmb_player_2.SelectedIndex)
            {
                case 0:
                    Properties.Settings.Default.player2 = Convert.ToInt32(PlayerType.Human);
                    if (Properties.Settings.Default.player1_mark == Convert.ToInt32(CellStatus.Cell_X))
                    {
                        player2 = new Players(CellStatus.Cell_O);
                    }
                    else
                    {
                        player2 = new Players(CellStatus.Cell_X);
                    }
                    break;
                case 1:
                    Properties.Settings.Default.player2 = Convert.ToInt32(PlayerType.Computer);
                    if (Properties.Settings.Default.player1_mark == Convert.ToInt32(CellStatus.Cell_X))
                    {
                        player2 = new Computers(CellStatus.Cell_O, (ComputerLevel)Properties.Settings.Default.computer_level_current);
                    }
                    else
                    {
                        player2 = new Computers(CellStatus.Cell_X, (ComputerLevel)Properties.Settings.Default.computer_level_current);
                    }
                    break;
            }

            // ==== Если один из игроков компьютер, то включаем бокс с настройкой уровня сложности
            if (cmb_player_1.SelectedIndex == 1 || cmb_player_2.SelectedIndex == 1)
            {
                gbx_type_comp.Enabled = true;
            }
            else
            {
                gbx_type_comp.Enabled = false;
            }

            // ==== Записываем изменение параметра
            Properties.Settings.Default.Save();
        }
        
        /// <summary>
        /// Событие 1 тика таймера (для игры компьютер - компьютер)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompTimer_Tick(object sender, EventArgs e)
        {
            IPlayer player;
            if (player_current == CurrentPlayer.Player1)
            {
                player = player1;
            }
            else
            {
                player = player2;
            }
            UpdateGame(player);
        }
        
        #endregion
    }
}
