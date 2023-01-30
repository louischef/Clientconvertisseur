// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using ClientconvertisseurV1.Models;
using ClientconvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientconvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadSync();
        }

        private double montantRentre;

        public double MontantRentre
        {
            get { return montantRentre; }
            set { montantRentre = value;
                OnPropertyChanged("MontantRentre");
            }
        }

        private ObservableCollection<Devise> devises;

        public ObservableCollection<Devise> Devises
        {
            get { return devises; }
            set { devises = value;
                OnPropertyChanged("Devises");
            }
        }



        private Devise deviseSelected;

        public Devise DeviseSelected
        {
            get { return deviseSelected; }
            set { deviseSelected = value;
                OnPropertyChanged("DeviseSelected");
            }
        }

        private double res;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public double Res
        {
            get { return res; }
            set { res = value;
                OnPropertyChanged("Res");
            }
        }


        private async void GetDataOnLoadSync()
        {
            WSService service = new WSService("https://localhost:7164/api/");
            List<Devise> result = await service.GetDevisesAsync("devise");
            Devises = new ObservableCollection<Devise>(result);
        }

        private void bt_convert_Click(object sender, RoutedEventArgs e)
        {
            WSService service = new WSService();
            Res = service.Calcul(MontantRentre, DeviseSelected);
        }
    }


}
