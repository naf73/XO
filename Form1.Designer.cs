﻿namespace XO
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameField = new System.Windows.Forms.TableLayoutPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.cmb_player_mark = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_player_2 = new System.Windows.Forms.ComboBox();
            this.gbx_type_comp = new System.Windows.Forms.GroupBox();
            this.rbtn_hard = new System.Windows.Forms.RadioButton();
            this.rbtn_easy = new System.Windows.Forms.RadioButton();
            this.GameField.SuspendLayout();
            this.gbx_type_comp.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameField.ColumnCount = 3;
            this.GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameField.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameField.Controls.Add(this.button9, 2, 2);
            this.GameField.Controls.Add(this.button8, 1, 2);
            this.GameField.Controls.Add(this.button7, 0, 2);
            this.GameField.Controls.Add(this.button6, 2, 1);
            this.GameField.Controls.Add(this.button5, 1, 1);
            this.GameField.Controls.Add(this.button4, 0, 1);
            this.GameField.Controls.Add(this.button3, 2, 0);
            this.GameField.Controls.Add(this.button2, 1, 0);
            this.GameField.Controls.Add(this.button1, 0, 0);
            this.GameField.Location = new System.Drawing.Point(12, 12);
            this.GameField.Name = "GameField";
            this.GameField.RowCount = 3;
            this.GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameField.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.GameField.Size = new System.Drawing.Size(189, 185);
            this.GameField.TabIndex = 1;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(129, 125);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(57, 57);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button_Click);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(66, 125);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(57, 57);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(3, 125);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(57, 57);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(129, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 55);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(66, 64);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(57, 55);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(3, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(57, 55);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(129, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 55);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(66, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 55);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 55);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // btn_start
            // 
            this.btn_start.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_start.Location = new System.Drawing.Point(158, 220);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(111, 40);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Новая игра";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cmb_player_mark
            // 
            this.cmb_player_mark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_player_mark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_player_mark.FormattingEnabled = true;
            this.cmb_player_mark.Items.AddRange(new object[] {
            "X",
            "O"});
            this.cmb_player_mark.Location = new System.Drawing.Point(314, 34);
            this.cmb_player_mark.Name = "cmb_player_mark";
            this.cmb_player_mark.Size = new System.Drawing.Size(121, 21);
            this.cmb_player_mark.TabIndex = 3;
            this.cmb_player_mark.TextChanged += new System.EventHandler(this.cmb_player_mark_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Маркер игрока 1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Игрок 2";
            // 
            // cmb_player_2
            // 
            this.cmb_player_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_player_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_player_2.FormattingEnabled = true;
            this.cmb_player_2.Items.AddRange(new object[] {
            "Компьютер",
            "Человек"});
            this.cmb_player_2.Location = new System.Drawing.Point(314, 61);
            this.cmb_player_2.Name = "cmb_player_2";
            this.cmb_player_2.Size = new System.Drawing.Size(121, 21);
            this.cmb_player_2.TabIndex = 6;
            this.cmb_player_2.TextChanged += new System.EventHandler(this.cmb_player_2_TextChanged);
            // 
            // gbx_type_comp
            // 
            this.gbx_type_comp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_type_comp.Controls.Add(this.rbtn_hard);
            this.gbx_type_comp.Controls.Add(this.rbtn_easy);
            this.gbx_type_comp.Location = new System.Drawing.Point(218, 101);
            this.gbx_type_comp.Name = "gbx_type_comp";
            this.gbx_type_comp.Size = new System.Drawing.Size(217, 100);
            this.gbx_type_comp.TabIndex = 7;
            this.gbx_type_comp.TabStop = false;
            this.gbx_type_comp.Text = " Интеллект компьютера ";
            // 
            // rbtn_hard
            // 
            this.rbtn_hard.AutoSize = true;
            this.rbtn_hard.Location = new System.Drawing.Point(17, 60);
            this.rbtn_hard.Name = "rbtn_hard";
            this.rbtn_hard.Size = new System.Drawing.Size(61, 17);
            this.rbtn_hard.TabIndex = 1;
            this.rbtn_hard.TabStop = true;
            this.rbtn_hard.Text = "Умный";
            this.rbtn_hard.UseVisualStyleBackColor = true;
            this.rbtn_hard.CheckedChanged += new System.EventHandler(this.rbtn_Changed);
            // 
            // rbtn_easy
            // 
            this.rbtn_easy.AutoSize = true;
            this.rbtn_easy.Location = new System.Drawing.Point(17, 28);
            this.rbtn_easy.Name = "rbtn_easy";
            this.rbtn_easy.Size = new System.Drawing.Size(62, 17);
            this.rbtn_easy.TabIndex = 0;
            this.rbtn_easy.TabStop = true;
            this.rbtn_easy.Text = "Глупый";
            this.rbtn_easy.UseVisualStyleBackColor = true;
            this.rbtn_easy.CheckedChanged += new System.EventHandler(this.rbtn_Changed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 272);
            this.Controls.Add(this.gbx_type_comp);
            this.Controls.Add(this.cmb_player_2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_player_mark);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.GameField);
            this.MinimumSize = new System.Drawing.Size(460, 310);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game XO";
            this.GameField.ResumeLayout(false);
            this.gbx_type_comp.ResumeLayout(false);
            this.gbx_type_comp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel GameField;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox cmb_player_mark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_player_2;
        private System.Windows.Forms.GroupBox gbx_type_comp;
        private System.Windows.Forms.RadioButton rbtn_hard;
        private System.Windows.Forms.RadioButton rbtn_easy;
    }
}

