﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using XamarinClientApp.Model;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp.ViewModel
{
    class KategoriViewModel : BindableObject
    {
        private RestClient _client =
           new RestClient("http://http://tokoonderdil.azurewebsites.net/");

        private ObservableCollection<Kategori> listKategori;
        public ObservableCollection<Kategori> ListKategori
        {
            get { return listKategori; }
            set { listKategori = value; OnPropertyChanged("ListKategori"); }
        }

        private async void RefreshDataAsync()
        {
            RestRequest _request = new RestRequest("api/Kategori", Method.GET);
            var _response = await _client.Execute<List<Kategori>>(_request);
            ListKategori = new ObservableCollection<Kategori>(_response.Data);
        }

        public KategoriViewModel()
        {
            RefreshDataAsync();
        }
    }
}