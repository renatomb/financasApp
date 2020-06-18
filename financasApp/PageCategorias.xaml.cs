﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace financasApp
{
    public partial class PageCategorias : ContentPage
    {
        public PageCategorias()
        {
            InitializeComponent();
            refreshCateg();
        }

        async void refreshCateg()
        {
            lvCategorias.ItemsSource = null;
            ObservableCollection<Conta> categorias;
            var httpconta = new meuhttp();
            var respHttpConta = await httpconta.GetHttp("categ/");
            categorias = JsonConvert.DeserializeObject<ObservableCollection<Conta>>(respHttpConta.mensagem);
            lvCategorias.ItemsSource = categorias;
        }

        void lvCategorias_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }

        async void btAddCategoria_Clicked(System.Object sender, System.EventArgs e)
        {
            var httpc = new meuhttp();
            var respostaHttp = await httpc.Post("categ/", new Categoria { nome = enNomeCategoria.Text });
            if (respostaHttp.processado)
            {
                refreshCateg();
            }
            else
            {
                await DisplayAlert("ERRO", respostaHttp.mensagem, "OK");
            }
        }
    }
}