// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3
{
    using System;
    using System.Linq;
    using System.Windows;
    using BLL.Interfaces;
    using BLL.Services;
    using DLL.Interfaces;
    using DLL.Models;
    using Microsoft.Win32;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        private IOrderTaxiService service;

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this.service;
            this.service = new OrderTaxiService(null);

            this.NumbOfKilometres.GotFocus += this.RemoveText;
            this.NumbOfKilometres.LostFocus += this.AddText;
        }

        private void NewCustomer(object sender, RoutedEventArgs e)
        {
            ITaxiClient newClient = new TaxiClient();
            this.service = new OrderTaxiService(newClient);
            this.CommandPanel.Visibility = Visibility.Visible;
            this.UpdateBalanceText();
            this.BeginMessage.Visibility = Visibility.Collapsed;
            this.CommandPanel.Visibility = Visibility.Visible;
            this.Log.Text = string.Empty;
        }

        private void SaveCustomer(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text file (*.json)|*.json";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string path = System.IO.Path.GetFullPath(dialog.FileName);
                this.service.SaveChanges(path);
            }
        }

        private void OpenCustomer(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*.json)|*.json";
            dialog.ShowDialog();
            if (dialog.FileName != string.Empty)
            {
                string fullPath = System.IO.Path.GetFullPath(dialog.FileName);
                ITaxiClient client = this.service.DeserealizeClient(fullPath);
                this.service = new OrderTaxiService(client);
                this.CommandPanel.Visibility = Visibility.Visible;
                this.UpdateBalanceText();
                this.BeginMessage.Visibility = Visibility.Collapsed;
                this.Log.Text = string.Empty;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double price = Convert.ToDouble(this.AddBalance.Text);
                this.service.AddBalance(price);
                this.UpdateBalanceText();
                this.AddBalance.Text = string.Empty;
            }
            catch (FormatException)
            {
                MessageBox.Show("Balance is not valid", "Invalid balance", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                double numOfKilometres = Convert.ToDouble(this.NumbOfKilometres.Text);
                if (this.NormalButton.IsChecked == true)
                {
                    this.service.GetNormalTaxi(numOfKilometres);
                }
                else
                {
                    this.service.GetBusinessTaxi(numOfKilometres);
                }

                var lastOrder = this.service.GetHistory().Last();
                this.Log.Text = lastOrder.ToString() + Environment.NewLine;
                this.NumbOfKilometres.Text = "Number of kilometres";
                this.UpdateBalanceText();
            }
            catch (FormatException)
            {
                MessageBox.Show("Number of kilometres is not valid value", "Invalid value", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid operation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var orders = this.service.GetHistory();
            if (orders.Count == 0)
            {
                this.Log.Text = "No orders yet" + Environment.NewLine;
            }
            else
            {
                this.Log.Text = "All Orders: " + Environment.NewLine;
                foreach (var order in orders)
                {
                    this.Log.Text += order.ToString() + Environment.NewLine;
                }
            }
        }

        private void RemoveText(object sender, EventArgs e)
        {
            this.NumbOfKilometres.Text = string.Empty;
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.NumbOfKilometres.Text))
            {
                this.NumbOfKilometres.Text = "Number of kilometres";
            }
        }

        private void UpdateBalanceText()
        {
            this.Balance.Text = "Balance = " + this.service.GetBalance().ToString() + " $";
        }
    }
}
