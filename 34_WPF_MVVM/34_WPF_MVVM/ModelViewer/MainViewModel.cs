using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using _34_WPF_MVVM.Helper;

namespace _34_WPF_MVVM.ModelViewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private byte a;
        public byte A { get { return a; } set { a = value; OnPropertyChanged("A"); } }
        private byte r;
        public byte R { get { return r; } set { r = value; OnPropertyChanged("R"); } }
        private byte g;
        public byte G { get { return g; } set { g = value; OnPropertyChanged("G"); } }
        private byte b;
        public byte B { get { return b; } set { b = value; OnPropertyChanged("B"); } }
        private Brush myBrush;
        public Brush MyBrush { get { return myBrush; } set { myBrush = value; OnPropertyChanged("MyBrush"); } }
        private Brush selectBrush;
        public Brush SelectBrush { get { return selectBrush; } set { selectBrush = value; OnPropertyChanged("SelectBrush"); } }
        public ObservableCollection<Brush> LstBrush { get; set; } = new ObservableCollection<Brush>();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged
                    ([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this,
                      new PropertyChangedEventArgs(prop));
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                (addCommand = new RelayCommand(obj =>
                {
                    LstBrush.Add(myBrush);
                }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                (removeCommand = new RelayCommand(obj =>
                {
                    Brush br = (Brush)obj;
                    LstBrush.Remove(br);
                }));

            }
        }
        public MainViewModel()
        {
            PropertyChanged += GetMyBrush;
        }
        public void GetMyBrush(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "A" || e.PropertyName == "R" || e.PropertyName == "G" || e.PropertyName == "B")
                MyBrush = new SolidColorBrush(Color.FromArgb(A, R, G, B));
        }
    }
}
