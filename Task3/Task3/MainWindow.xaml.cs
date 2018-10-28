// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task3
{
    using System;
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

            this.NumbOfKilometres.GotFocus += this.RemoveText;
            this.NumbOfKilometres.LostFocus += this.AddText;
        }

        private void NewCustomer(object sender, RoutedEventArgs e)
        {
            ITaxiClient newClient = new TaxiClient();
            this.service = new OrderTaxiService(newClient);
            this.CommandPanel.Visibility = Visibility.Visible;
            this.Balance.Text = "Balance = " + this.service.GetBalance().ToString() + " $";
            //this.BeginMessage.Visibility = Visibility.Collapsed;
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
                this.Balance.Text = "Balance = " + this.service.GetBalance().ToString() + " $";
                //BeginMessage.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveText(object sender, EventArgs e)
        {
            this.NumbOfKilometres.Text = String.Empty;
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.NumbOfKilometres.Text))
            {
                this.NumbOfKilometres.Text = "Number of kilometres";
            }
        }
    }
}
