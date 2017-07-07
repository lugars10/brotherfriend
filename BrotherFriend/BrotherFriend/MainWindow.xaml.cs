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
using System.Windows.Controls.Primitives;


namespace BrotherFriend
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
            
            
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string mensaje = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            Message text = new Message();
            Thickness margin = text.Margin;
            //margin.Bottom = 5;
           

            int sizeWidth;
            int PsizeHeight;

            //n.CornerRadius = CornerRadius;


            if (mensaje.Length <= 7)
            {
                sizeWidth = mensaje.Length * 19;
                text.box.Width = sizeWidth;
                text.textBlock.Width = sizeWidth;
                text.box.Height = 80;
                text.textBlock.FontSize = 50;
                text.textBlock.Text = mensaje;
                text.Margin = new Thickness(0, 0, 0, 20);
            }
            else
            {
                sizeWidth = mensaje.Length * 10;
                text.box.Width = sizeWidth;
                text.textBlock.Width = sizeWidth;
                if (mensaje.Length >= 40)
                {
                    PsizeHeight = mensaje.Length / 40;
                    if (mensaje.Length % 40 != 0)
                    {
                        PsizeHeight++;
                    }
                    PsizeHeight *= 30;
                    text.box.Height = PsizeHeight;
                    text.textBlock.Height = PsizeHeight;
                    int NewLine = mensaje.Length / 40;
                    int LetterCount = 40;
                    StringBuilder newMessage = new StringBuilder(mensaje);
                    while (NewLine > 0)
                    {
                        newMessage.Insert(LetterCount, Environment.NewLine);
                        LetterCount += 40;
                        NewLine--;
                    }
                    text.textBlock.Text = newMessage.ToString();
                    text.Margin = new Thickness(0, 0, 0, -20);
                }
                else
                {
                    text.box.Height = 40;
                    text.textBlock.Text = mensaje;
                    text.Margin = new Thickness(0, 0, 0, -20);
                }
                text.textBlock.FontSize = 20;
            }


            text.textBlock.TextAlignment = TextAlignment.Left;
            text.box.Fill = new SolidColorBrush(Color.FromRgb(164, 81, 248));
            text.box.StrokeThickness = 0;
            
            text.textBlock.FontFamily = new FontFamily("Noto Sans");
            text.textBlock.Foreground = Brushes.White;
            //text.Margin = margin;
            //text.box.Margin = margin;
            text.HorizontalAlignment = HorizontalAlignment.Right;
            
 
            panel.Children.Add(text);
            

            

           
        }
    }
}
