﻿using System;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Navigation;
using ApiReviewList.Reports;
using ApiReviewList.ViewModels;

namespace ApiReviewList
{
    internal partial class NotesDialog : Window
    {
        public NotesDialog()
        {
            InitializeComponent();

            DataContext = new NotesViewModel();
        }

        protected override async void OnClosed(EventArgs e)
        {
            if (DialogResult == true)
            {
                if (DataContext is NotesViewModel viewModel)
                {
                    await viewModel.SendAsync();
                    MessageBox.Show("Notes sent.", "API Review List", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            base.OnClosed(e);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Shell.Execute(e.Uri.ToString());
            e.Handled = true;
        }
    }
}
