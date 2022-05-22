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
using System.Windows.Xps.Packaging;

namespace PdfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FixedDocument doc = new FixedDocument();
            FixedPage page = new FixedPage();
            var talon = Talon;
            if (talon != null)
            {
                var talonParent = (Grid)Talon.Parent;
                talonParent.Children.Remove(talon);
            }
            page.Children.Add(talon);
            PageContent pageContent = new PageContent();
            pageContent.Child = page;
            doc.Pages.Add(pageContent);
            DocViewer.Document = doc;
            XpsDocument xpsDoc = new XpsDocument(DocViewer.Document);
            doc.
        }
    }
}
