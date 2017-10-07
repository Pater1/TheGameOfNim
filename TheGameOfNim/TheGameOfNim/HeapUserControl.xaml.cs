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

namespace TheGameOfNim {
    /// <summary>
    /// Interaction logic for HeapUserControl.xaml
    /// </summary>
    public partial class HeapUserControl : UserControl {
        public HeapUserControl() {
            InitializeComponent();
        }

        public event StoneBuilderDelegate stoneBuilder;

        public int CollumnInt {
            set {
                HeapNumberLabel.Content = value;
            }
        }

        private Heap heapRef;
        public Heap HeapRef {
            get {
                return heapRef;
            }
            set {
                heapRef = value;
                if (value != null) {
                    if (value.Display != this) {
                        value.Display = this;
                    }
                } else {
                    if (heapRef != null) {
                        value.Display = null;
                    }
                }

                Render();
            }
        }

        public void Render() {
            if(stoneBuilder == null) {
                stoneBuilder += DefaultStoneBuilder;
            }

            StonesPanel.Children.Clear();
            for(int i = 0; i < HeapRef.StonesLeft; i++) {
                StonesPanel.Children.Add(stoneBuilder());
            }
        }

        private static UIElement DefaultStoneBuilder() {
            Label l = new Label();
            l.Content = "Stone";
            l.HorizontalContentAlignment = HorizontalAlignment.Center;

            Border b = new Border();
            b.Child = l;
            b.BorderBrush = Brushes.Black;
            b.BorderThickness = new Thickness(1.5);

            return b;
        }
    }
    public delegate UIElement StoneBuilderDelegate();
}
