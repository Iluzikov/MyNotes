﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        public NotesPage()
        {
            InitializeComponent();

            //Read the file
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }

        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Save te file
            File.WriteAllText(_fileName, editor.Text);
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            // Delete the file
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }
    }
}