using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeGame
{
    public partial class MainWindow : Window
    {
        private enum Player { None, X, O }

        private Player currentPlayer;
        private Dictionary<Button, Player> buttonPlayerMap;
        private bool gameEnded;
        private Button button00;
        private Button button02;
        private Button button01;

        public MainWindow()
        {
            InitializeComponent();

            buttonPlayerMap = new Dictionary<Button, Player>();
            currentPlayer = Player.X;
            gameEnded = true;

        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {

            foreach (var button in buttonPlayerMap.Keys)
            {
                button.Content = "";
                button.IsEnabled = true;
            }


            currentPlayer = Player.X;
            gameEnded = false;
            resultText.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
                return;

            Button button = (Button)sender;


            if (buttonPlayerMap.ContainsKey(button))
                return;


            buttonPlayerMap.Add(button, currentPlayer);
            button.Content = currentPlayer.ToString();


            if (IsWinner(currentPlayer))
            {
                gameEnded = true;
                resultText.Text = currentPlayer.ToString() + " wins!";
                foreach (var btn in buttonPlayerMap.Keys)
                    btn.IsEnabled = false;
                return;
            }


            if (buttonPlayerMap.Count == 9)
            {
                gameEnded = true;
                resultText.Text = "It's a tie!";
                return;
            }


            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;


            if (currentPlayer == Player.O)
            {
                MakeRobotMove();
            }
        }

        private void MakeRobotMove()
        {
            throw new NotImplementedException();
        }

        private bool IsWinner(Player player)
        {
            if (buttonPlayerMap.ContainsKey(button00) && buttonPlayerMap[button00] == player &&
            buttonPlayerMap.ContainsKey(button01) && buttonPlayerMap[button01] == player &&
                buttonPlayerMap.ContainsKey(button02) && buttonPlayerMap[button02] == player)
            {
                return true;
            }

        }
    }
    }


