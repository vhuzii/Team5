// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Task2
{
    using System.Windows;
    using System.Windows.Documents;
    using Data_Access.Repositories;
    using Data_Access.Repositories.Interfaces;
    using Data_Access.Repositories.Models.Abstract;
    using Figure = Data_Access.Repositories.Models.Abstract.Figure;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRepository<Figure> figureRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.figureRepository = new FigureRepository();
        }
    }
}
