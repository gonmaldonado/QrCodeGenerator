using QrCodeGenerator.Models;
using QrCodeGenerator.Helpers;
using System.Windows.Input;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace QrCodeGenerator.ViewModels
{
    public class MainViewModel:  INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _code;
        private BitmapImage _qr;
        private ICommand _sendCode;
        private ICommand _export;
        string Memory;
        private readonly MainModel _model= new MainModel();


        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("Code");
            }
        }
        public BitmapImage Qr
        {
            get { return _qr; }
            set
            {
                _qr = value;
                OnPropertyChanged("Qr");
            }
        }

        public ICommand SendCodeCommand
        {
            get { return _sendCode ?? (_sendCode = new RelayCommand(SendCodeExecute)); }
            
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ICommand Export
        {
            get { return _export ?? (_export = new RelayCommand(ExportExecute)); }

        }
        public void ExportExecute(object parameter)
        {
            try
            {

                _model.ExportFile(_model.DoQr(Memory));
            }
            catch (ApplicationException e)
            {

            }
        }
        public void SendCodeExecute(object parameter)
        {
            try
            {
                CleanControls();
                Memory = Code;
               Qr = _model.DoQr(Memory);
 
            }
            catch (ApplicationException e)
            {
                CleanControls();
            }
            CleanTextBox();

        }


        private void CleanControls()
        {

            
        }
        private void CleanTextBox()
        {
            Code = null;
        }
    }
}
