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
using System.Windows.Shapes;

namespace TheGameOfNim {
    /// <summary>
    /// Interaction logic for NimGamePage.xaml
    /// </summary>
    public partial class NimGamePage : Window {
        public NimGamePage() {
            InitializeComponent();
            GameBuilder.callback += SetupGameCallback;

            NewGame(null, null);
        }

        private void SetupGameCallback(Nim _game) {
            if (_game != null) {
                Game = _game;

                Setup.Visibility = Visibility.Collapsed;
                GameGrid.Visibility = Visibility.Visible;
            }
        }

        private Nim game;
        public Nim Game {
            get {
                return game;
            }
            set {
                game = value;
                if (value != null) {
                    if (value.Display != this) {
                        value.Display = this;
                    }
                    InitializeHeaps();
                    UpdatePlayerTurnLabel();
                } else {
                    if (game != null) {
                        value.Display = null;
                    }
                }
            }
        }

        public void Update() {
            if (Game != null) {
                InitializeHeaps();
                UpdatePlayerTurnLabel();
            }
        }
        public void Win() {
            GameGrid.Visibility = Visibility.Hidden;
            WinDisplay.Visibility = Visibility.Visible;

            WinLabel.Content = "The winner is: " + Game.Winner.Name;
        }

        private void InitializeHeaps() {
            if (Game.Heaps != null) {
                heapsPanel.Children.Clear();
                foreach (Heap h in Game.Heaps) {
                    HeapUserControl huc = new HeapUserControl();
                    huc.HeapRef = h;
                    heapsPanel.Children.Add(huc);

                    huc.CollumnInt = heapsPanel.Children.IndexOf(huc);
                }
            }
        }
        private void UpdatePlayerTurnLabel() {
            playerTurn.Content = "The current player is: " + Game.CurrentPlayer.Name;
        }

        private void SubmitMove(object sender, RoutedEventArgs e) {
            int heap = 0, quantity = 0;
            bool goodInput = ValidateInput(out heap, out quantity);

            if (!goodInput) return;

            bool goodMove = Game.RemoveStones(quantity, heap);

            if (!goodMove) return;

            Game.SwitchTurn();
        }

        private bool ValidateInput(out int heap, out int quantity) {
            bool goodHeap = int.TryParse(heapInput.Text, out heap);
            
            bool goodQuantity = int.TryParse(quantityInput.Text, out quantity);

            return goodHeap && goodQuantity;
        }
        private void GoToRules(object sender, RoutedEventArgs e) {
            Setup.Visibility = Visibility.Collapsed;
            HowToPlay.Visibility = Visibility.Visible;
        }
        private void ReturnToGameSetup(object sender, RoutedEventArgs e) {
            Setup.Visibility = Visibility.Visible;
            HowToPlay.Visibility = Visibility.Collapsed;
        }

        private void NewGame(object sender, RoutedEventArgs e) {
            Setup.Visibility = Visibility.Visible;
            GameGrid.Visibility = Visibility.Collapsed;
            WinDisplay.Visibility = Visibility.Collapsed;
        }
    }
}
