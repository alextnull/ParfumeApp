using System.Windows.Controls;

namespace ParfumeApp
{
    /// <summary>
    /// Менеджер навигации.
    /// </summary>
    public static class NavigationManager
    {
        /// <summary>
        /// Фрейм заголовка приложения.
        /// </summary>
        public static Frame HeaderFrame { get; set; }

        /// <summary>
        /// Фрейм основной части приложения.
        /// </summary>
        public static Frame MainFrame { get; set; }

        /// <summary>
        /// Фрейм всего простанства приложения. Может использоваться для показа модальных окон.
        /// </summary>
        public static Frame FullFrame { get; set; }
    }
}
