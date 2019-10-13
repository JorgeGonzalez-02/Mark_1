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
using System.Speech.Recognition;//reconocedor
using System.Speech.Synthesis;//edith

namespace Mark_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine reconocedor = new SpeechRecognitionEngine();
        SpeechSynthesizer edith = new SpeechSynthesizer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            reconocedor.SetInputToDefaultAudioDevice();
            Choices palabras = new Choices(new string[] {"edith","como estas","como te llamas"});//palabras
            GrammarBuilder gb = new GrammarBuilder();//constructor de gramaticas
            gb.Append(palabras);//le pasamos las palabras al constructor de grmaticas
            Grammar gramaticas = new Grammar(gb);//la pasamos a una gramatica general
            reconocedor.LoadGrammar(gramaticas);
            reconocedor.RecognizeAsync(RecognizeMode.Multiple);
            reconocedor.SpeechRecognized += Reconocedor_SpeechRecognized;

        }

        private void Reconocedor_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "edith":
                    edith.Speak("Hola Jorge");
                    break;
                case "como estas":
                    edith.Speak("Muy bien y tu.");
                    break;
                case "abre el google":
                    edith.SpeakAsync("abriendo google");
                    System.Diagnostics.Process.Start("www.google.com");
                    edith.Speak("youtube abierto");
                    break;
                default:
                    break;
            }
        }
    }
}
