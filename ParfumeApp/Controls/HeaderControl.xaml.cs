using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParfumeApp
{
    /// <summary>
    /// Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            InitializeComponent();
        }

        public void ChangeButtonsState()
        {
            ButtonsStackPanel.Visibility = NavigationManager.MainFrame.Content is AuthorizationPage
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        /// <summary>
        /// Возвращает пользователя на окно авторизации.
        /// </summary>
        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new AuthorizationPage());
        }

        /// <summary>
        /// Возвращает пользователя на предыдущую страницу.
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!NavigationManager.MainFrame.CanGoBack)
                return;
            NavigationManager.MainFrame.GoBack();
        }
    }
}
