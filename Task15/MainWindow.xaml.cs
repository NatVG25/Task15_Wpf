using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) //обработчик для очистки файла
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //обработчик для сохранения файла
        {
            using (FileStream fs = File.Open("1.xaml", FileMode.Create)) //используем FileStream
            { //для сохранения обращаемся к классу  XamlWriter, у него есть метод Save, принимающий аргументы (источник - документа, приемникдокумента)
               
                XamlWriter.Save(docViewer.Document, fs);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //обработчик для открытия файла
        {
            using (FileStream fs = File.Open("1.xaml", FileMode.Open)) //используем FileStream (класс для записи и чтения файлов)
            { //для сохранения обращаемся к классу XamlWriter, у него есть метод Save, принимающий аргументы (источник - документа, приемникдокумента)

                docViewer.Document = XamlReader.Load(fs) as FlowDocument;
            }
        }
    }
}

