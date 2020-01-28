using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Task_QuipuGmbH
{
    public partial class MainWindow : Window
    {
        private readonly Model model;
        private readonly AsyncWorker _worker;
        public MainWindow()
        {
            InitializeComponent();

            _worker = new AsyncWorker();
            _worker.UpdateProgressChanged += Worker_UpdateProgressChanged;
            _worker.UpdateStateChanged += Worker_UpdateStateChanged;
            model = new Model();
        }
        private void Button_Start(object sender, RoutedEventArgs e)
        {
            _worker.DoWork();

            List<MyTable> result = new List<MyTable>();
            string[] resultFile = model.FileReaderUrl();

            for (int i = 0; i < resultFile.Length; i++)
            {
                result.Add(new MyTable(i, resultFile[i], model.NamberOfTags(resultFile[i])));
            }
            GridUrl.ItemsSource = result;
        }
        private void Worker_UpdateStateChanged(object sender, UpdateStateEventArgs e)
        {
            switch (e.NewState)
            {
                case UpdateState.None:
                    break;

                case UpdateState.Started:
                    _infoBlock.Text = "Выполняется...";
                    _startButton.IsEnabled = false;
                    break;

                case UpdateState.Completed:
                    _infoBlock.Text = "Работа выполнена";
                    _startButton.IsEnabled = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void Worker_UpdateProgressChanged(object sender, ProgressEventArgs e)
        {
            _progressBar.Value = e.Progress;
        }
    }
}
