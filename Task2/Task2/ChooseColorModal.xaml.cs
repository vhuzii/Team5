// <copyright file="ChooseColorModal.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task2
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    /// <summary>
    /// Interaction logic for ChooseColorModal.xaml
    /// </summary>
    public partial class ChooseColorModal : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChooseColorModal"/> class.
        /// </summary>
        public ChooseColorModal()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets color chosen in dialog window
        /// </summary>
        public Color ChosenColor { get; private set; } = Colors.Black;

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            this.ChosenColor = (Color)ColorConverter.ConvertFromString(pressed.Content.ToString());
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
