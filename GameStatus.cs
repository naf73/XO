namespace XO
{
    /// <summary>
    /// Состояние игры
    /// </summary>
    enum GameStatus
    {
        /// <summary>
		/// Игра не началась
		/// </summary>
		NotStarted,

        /// <summary>
        /// Игра в прогрессе
        /// </summary>
        InProgress,

        /// <summary>
        /// Игрок, играющий крестиками выиграл
        /// </summary>
        PlayerXWin,

        /// <summary>
        /// Игрок, играющий ноликами выиграл
        /// </summary>
        PlayerOWin,

        /// <summary>
        /// Ничья
        /// </summary>
        NoWin
    }
}
