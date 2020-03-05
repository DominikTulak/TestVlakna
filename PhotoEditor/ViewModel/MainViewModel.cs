using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using PhotoEditor.Model;

namespace PhotoEditor.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private BitmapImage picture;

        public Command LoadCommand { get; private set; }
        public Command Edit_1Command { get; private set; }
        public Command Edit_2Command { get; private set; }
        public Command Edit_3Command { get; private set; }
        public Command Edit_4Command { get; private set; }

        private Functions fnc;
        
        public MainViewModel()
        {
            LoadCommand = new Command(LoadCommand_Execute);
            Edit_1Command = new Command(Edit_1Command_Execute);
            Edit_2Command = new Command(Edit_2Command_Execute);
            Edit_3Command = new Command(Edit_3Command_Execute);
            Edit_4Command = new Command(Edit_4Command_Execute);

            fnc = new Functions();
        }

        public BitmapImage Picture
        {
            get { return picture; }
            set
            {
                picture = value;
                ChangeProperty("Picture");
            }
        }
        private void Edit_1Command_Execute()
        {
            if (Picture != null)
            {
                Picture = fnc.Uprava_1(Picture);
            }
            else
            {
                MessageBox.Show("No picture!");
            }
        }
        private void Edit_2Command_Execute()
        {
            if (Picture != null)
            {
                Picture = fnc.Uprava_2(Picture);
            }
            else
            {
                MessageBox.Show("No picture!");
            }
        }
        private void Edit_3Command_Execute()
        {
            if (Picture != null)
            {
                Picture = fnc.Uprava_3(Picture);
            }
            else
            {
                MessageBox.Show("No picture!");
            }
        }
        private void Edit_4Command_Execute()
        {
            if (Picture != null)
            {
                Picture = fnc.Uprava_4(Picture);
            }
            else
            {
                MessageBox.Show("No picture!");
            }
        }

        private void LoadCommand_Execute()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "Obrázek ().jpg |*.jpg| Všechny soubory| *.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                picture = new BitmapImage();
                picture.BeginInit();
                picture.UriSource = new Uri(filename, UriKind.Relative);
                picture.CacheOption = BitmapCacheOption.OnLoad;
                picture.EndInit();
                fnc.src = picture;

                ChangeProperty("Picture");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ChangeProperty(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
