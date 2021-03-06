﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Model;
using XamarinClientApp.ViewModel;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class MainMenuPage : MasterDetailPage
    {
        public List<Menu> menuList { get; set; }

        public MainMenuPage()
        {
            InitializeComponent();
            menuList = new List<Menu>();
            var page2 = new Menu() { Title = "Barang", TargetType = typeof(BarangPage) };
            var page3 = new Menu() { Title = "Kategori", TargetType = typeof(KategoriPage) };
            var page4 = new Menu() { Title = "Jenis Motor", TargetType = typeof(JenisMotorPage) };
            
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);

            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainPage)));
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Menu)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}