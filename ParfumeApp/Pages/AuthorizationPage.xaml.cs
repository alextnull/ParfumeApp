using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AuthorizationPag.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private StringBuilder _captcha;

        public AuthorizationPage()
        {
            InitializeComponent();
            var textblock = new TextBlock();
        }

        /// <summary>
        /// Авторизует пользователя.
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var user = ParfumEntities.GetContext().Users.FirstOrDefault(u =>
                u.Login == LoginTextBox.Text && u.Password == PasswordPasswordBox.Password);
            if (user is null && _captcha is null)
            {
                MessageBox.Show("Неверный логин или пароль.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowCaptcha();
                return;
            }
            else if (user is null && !(_captcha is null) && _captcha.ToString() != CaptchaTextBox.Text)
            {
                MessageBox.Show($"Капча введена неправильно.{Environment.NewLine}Возможность входа будет заблокирована на 10 секунд.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Task.Run(async () =>
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        LoginButton.IsEnabled = false;
                        ShowCaptcha();
                    });
                    await Task.Delay(TimeSpan.FromSeconds(10));
                    App.Current.Dispatcher.Invoke(() => LoginButton.IsEnabled = true);
                });
                return;
            }
            else if (user is null)
            {
                MessageBox.Show("Неверный логин или пароль.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowCaptcha();
                return;
            }

            if (user.UserRole.ID == 2)
            {
                NavigationManager.MainFrame.Navigate(new ProductsPage());
            }
        }

        /// <summary>
        /// Показывает капчу пользователю.
        /// </summary>
        private void ShowCaptcha()
        {
            _captcha = new StringBuilder(12);
            CaptchaContent.Children.Clear();
            CaptchaTextBox.Clear();

            var chars = "qwertyuiopasdfghjklzxcvbnm1234567890";
            var random = new Random();
            for (var i = 0; i < random.Next(4, 9); i++)
            {
                var symbol = chars[random.Next(0, chars.Length)];
                _captcha.Append(symbol);
                var textBlock = new TextBlock();
                textBlock.Margin = new Thickness(0, random.Next(0, 12), 2, 0);
                textBlock.Foreground = new SolidColorBrush(Color.FromRgb((byte)random.Next(230), (byte)random.Next(230), (byte)random.Next(230)));
                textBlock.Text = symbol.ToString();
                textBlock.TextDecorations = TextDecorations.Strikethrough;
                textBlock.FontSize = 16;
                CaptchaContent.Children.Add(textBlock);
            }
            CaptchaStackPanel.Visibility = Visibility.Visible;
        }
    }
}
