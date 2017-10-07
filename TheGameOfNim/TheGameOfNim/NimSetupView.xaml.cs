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
    /// Interaction logic for NimSetupView.xaml
    /// </summary>
    public partial class NimSetupView : UserControl {
        public NimSetupView() {
            InitializeComponent();
        }

        public BuiltGameCallback callback;

        private void SubmitGameStart(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(P1Name.Text)) {
                Fail();
            }

            if(!vsComputer && string.IsNullOrWhiteSpace(P2Name.Text)) {
                Fail();
            }

            if (callback != null) {
                if (vsComputer) {
                    callback(new Nim(diff, P1Name.Text));
                } else {
                    callback(new Nim(diff, P1Name.Text, P2Name.Text));
                }
            }
        }

        private void Fail() {
            Warning.Visibility = Visibility.Visible;
        }

        bool vsComputer = true;
        private void OpponentIsComputer_Checked(object sender, RoutedEventArgs e) {
            vsComputer = true;
            P2CPU.Visibility = Visibility.Visible;
            P2Name.Visibility = Visibility.Collapsed;
        }
        private void OpponentIsHuman_Checked(object sender, RoutedEventArgs e) {
            vsComputer = false;
            P2CPU.Visibility = Visibility.Collapsed;
            P2Name.Visibility = Visibility.Visible;
        }

        private Difficulty diff = Difficulty.EASY;
        private void DifficultyIsHard_Checked(object sender, RoutedEventArgs e) {
            diff = Difficulty.HARD;
        }
        private void DifficultyIsMedium_Checked(object sender, RoutedEventArgs e) {
            diff = Difficulty.MEDUIM;
        }
        private void DifficultyIsEasy_Checked(object sender, RoutedEventArgs e) {
            diff = Difficulty.EASY;
        }

        private void TryAgain(object sender, RoutedEventArgs e) {
            Warning.Visibility = Visibility.Collapsed;
        }
    }
    public delegate void BuiltGameCallback(Nim game);
}
