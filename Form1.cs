using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        #region Область объявления переменных
        private string player1_mark; // маркер игрока 1
        private string player2_mark; // маркер игрока 2
        private int player_current; // текущий игрок
        private int computer_level_current; // текущий уровень компьютера

        private List<int[]> win_combinations = new List<int[]>(); // список комбинаций победы

        private enum Player // номер игрока
        {
            number1 = 1,
            number2 = 2
        }

        private enum ComputerLevel // уровень компьютера
        {
            easy = 1,
            hard = 2
        }
        #endregion

        /// <summary>
        /// Дефолтовый конструктор
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Init(false);

            // Настройки по умолчанию
            cmb_player_mark.SelectedIndex = 0;
            cmb_player_2.SelectedIndex = 0;
            rbtn_easy.Checked = true;
            GameSetting(true);

            player1_mark = "X";
            player2_mark = "O";
            player_current = (int)Player.number1;
            computer_level_current = (int)ComputerLevel.easy;

            // Комбинации выигрыша
            // по горизонтали
            win_combinations.Add(new int[] { 1, 2, 3 });
            win_combinations.Add(new int[] { 4, 5, 6 });
            win_combinations.Add(new int[] { 7, 8, 9 });

            // по вертикали
            win_combinations.Add(new int[] { 1, 4, 7 });
            win_combinations.Add(new int[] { 2, 5, 8 });
            win_combinations.Add(new int[] { 3, 6, 9 });

            // по диагоналям
            win_combinations.Add(new int[] { 1, 5, 9 });
            win_combinations.Add(new int[] { 3, 5, 7 });
        }

        #region События формы
        /// <summary>
        /// Метод для события клика мыши на игровом поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (player_current) // (Для режима Человек-Человек)
            {
                case (int)Player.number1: // Игрок 1 - человек
                    if (btn.Text == String.Empty) // Клетка пустая
                    {
                        btn.Text = player1_mark;

                        if (CheckWinPlayer(player1_mark)) // Игрок 1 - выиграл
                        {
                            MessageBox.Show("Выиграл игрок 1", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Init(false);
                            GameSetting(true);
                            return;
                        }

                        if (cmb_player_2.SelectedIndex == 0) // Игрок 2 - Комьютер
                        {
                            if (CheckEndGame()) // Игра еще не закончена
                            {
                                switch (computer_level_current) // Получаем заданный уровень интеллекта компьютера
                                {
                                    case (int)ComputerLevel.easy:
                                        ComputerEasy();
                                        break;
                                    case (int)ComputerLevel.hard:
                                        ComputerHard();
                                        break;
                                }
                                if (CheckWinPlayer(player2_mark)) // Игрок 2 выиграл
                                {
                                    MessageBox.Show("Выиграл игрок 2", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Init(false);
                                    GameSetting(true);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            player_current = (int)Player.number2;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Это поле уже занято!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case (int)Player.number2: // Игрок 2 - человек
                    if (btn.Text == String.Empty) // Клета пуста
                    {
                        btn.Text = player2_mark;
                        player_current = (int)Player.number1;
                        if (CheckWinPlayer(player2_mark)) // Игрок 2 выиграл
                        {
                            MessageBox.Show("Выиграл игрок 2", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Init(false);
                            GameSetting(true);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Это поле уже занято!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }

            if (!CheckEndGame()) // Игра завершена
            {
                MessageBox.Show("Ничья", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Init(false);
                GameSetting(true);
            }

        }

        /// <summary>
        /// Метод для события нажатия кнопки "Старт игры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, EventArgs e)
        {
            Init(true);
            GameSetting(false);
            player_current = (int)Player.number1;
        }

        /// <summary>
        /// Метод для события изменения маркера для игрока 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_player_mark_TextChanged(object sender, EventArgs e)
        {
            player1_mark = cmb_player_mark.Text;
            if (player1_mark == "X")
            {
                player2_mark = "O";
            }
            else
            {
                player2_mark = "X";
            }
        }

        /// <summary>
        /// Метод для события измениние типа игрока 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_player_2_TextChanged(object sender, EventArgs e)
        {
            if (gbx_type_comp.Enabled)
            {
                gbx_type_comp.Enabled = false;
            }
            else
            {
                gbx_type_comp.Enabled = true;
            }
        }
        
        /// <summary>
        /// Метод для события переключения уровня сложности компьтера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtn_Changed(object sender, EventArgs e)
        {

            if(rbtn_easy.Checked)
            {
                computer_level_current = (int)ComputerLevel.easy;
            }

            if(rbtn_hard.Checked)
            {
                computer_level_current = (int)ComputerLevel.hard;
            }

        }
        #endregion

        #region Логика игры
        /// <summary>
        /// Метод инициализирует игровое поле
        /// </summary>
        /// <param name="enabled">true - кнопки активны, false - кнопки не активны</param>
        public void Init(bool enabled)
        {
            foreach (Button btn in GameField.Controls)
            {
                btn.Enabled = enabled;
                btn.Text = String.Empty;
            }
        }

        /// <summary>
        /// Метод активирует/деактивирует виджеты настроек игры
        /// </summary>
        /// <param name="active">true - настройки активы, false - настройки не активны</param>
        private void GameSetting(bool active)
        {
            cmb_player_mark.Enabled = active;
            cmb_player_2.Enabled = active;
            if (cmb_player_2.Enabled && cmb_player_2.SelectedIndex == 0)
            {
                gbx_type_comp.Enabled = true;
            }
            else
            {
                gbx_type_comp.Enabled = false;
            }
            label1.Enabled = active;
            label2.Enabled = active;
        }

        /// <summary>
        /// Метод проверяет условие окончания игры
        /// </summary>
        /// <returns>true - игра не окончена, false - игра завершена</returns>
        private bool CheckEndGame()
        {
            foreach(Button btn in GameField.Controls)
            {
                if (btn.Text == String.Empty) return true;
            }
            return false;
        }

        /// <summary>
        /// Метод проверяет победу игрока
        /// </summary>
        /// <param name="mark">Метка игрока</param>
        /// <returns>true - игрок выиграл, false - игрок не выиграл</returns>
        private bool CheckWinPlayer(string mark)
        {
            foreach (int[] combinate in win_combinations)
            {
                int i = 0;
                foreach (int number in combinate)
                {
                    foreach (Button btn in GameField.Controls)
                    {
                        if(btn.Name == "button" + number.ToString())
                        {
                            if (btn.Text == mark) i++;
                        }
                    }
                }
                if (i == 3) return true;
            }
            return false;
        }
        #endregion

        #region Логика игрока 2 - компьютера
        /// <summary>
        /// Метод делает ход за компьютера уровень Глупый
        /// </summary>
        private void ComputerEasy()
        {
            //Случайная постановка маркера в клетку
            bool stop = true;
            Random rnd = new Random();
            int number;
            while (stop)
            {
                number = rnd.Next(1, 9);
                foreach(Button btn in GameField.Controls)
                {
                    if(btn.Name == "button" + number.ToString())
                    {
                        if(btn.Text == String.Empty)
                        {
                            btn.Text = player2_mark;
                            stop = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод делает ход за компьютера уровень Умный
        /// </summary>
        private void ComputerHard()
        {
            #region 1. Занимаем центр
            if (button5.Text == String.Empty)
            {
                button5.Text = player2_mark;
                return;
            }
            #endregion

            #region 2. Определяем клетку победного хода компьютера
            foreach (int[] combinate in win_combinations)
            {
                int i;
                int cell_number;
                i = 0;
                cell_number = 0;
                foreach (int number in combinate)
                {
                    foreach (Button btn in GameField.Controls)
                    {
                        if (btn.Name == "button" + number.ToString())
                        {
                            if (btn.Text == player2_mark)
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
                if (i == 2)
                {
                    foreach (Button btn in GameField.Controls)
                    {
                        if (btn.Name == "button" + cell_number.ToString())
                        {
                            if (btn.Text == String.Empty)
                            {
                                btn.Text = player2_mark;
                                return;
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
                foreach (int number in combinate)
                {
                    foreach (Button btn in GameField.Controls)
                    {
                        if (btn.Name == "button" + number.ToString())
                        {
                            if (btn.Text == player1_mark)
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
                if (i == 2)
                    {
                        foreach (Button btn in GameField.Controls)
                        {
                            if (btn.Name == "button" + cell_number.ToString())
                            {
                                if (btn.Text == String.Empty)
                                {
                                    btn.Text = player2_mark;
                                    return;
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
                foreach (int number in combinate)
                {
                    foreach (Button btn in GameField.Controls)
                    {
                        if (btn.Name == "button" + number.ToString())
                        {
                            if (btn.Text == String.Empty)
                            {
                                i++;
                            }
                        }
                    }
                    if (i == 3)
                    {
                        foreach (Button btn in GameField.Controls)
                        {
                            if (btn.Name == "button" + number.ToString())
                            {
                                if (btn.Text == String.Empty)
                                {
                                    btn.Text = player2_mark;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 5. Ставим маркер в любую свободную клетку
            ComputerEasy();
            #endregion
        }
        #endregion
    }
}
