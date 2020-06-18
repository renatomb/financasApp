using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace financasApp
{
    public partial class PageContas : ContentPage
    {
        public PageContas()
        {
            InitializeComponent();
            refreshContas();
        }

        async void refreshContas()
        {
            lvContas.ItemsSource = null;
            ObservableCollection<Conta> contas;
            var httpconta = new meuhttp();
            var respHttpConta = await httpconta.GetHttp("conta/");
            contas = JsonConvert.DeserializeObject<ObservableCollection<Conta>>(respHttpConta.mensagem);
            lvContas.ItemsSource = contas;
        }

        void lvContas_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
        }

        async void btAddConta_Clicked(System.Object sender, System.EventArgs e)
        {
            var httpc = new meuhttp();
            var respostaHttp = await httpc.Post("conta/", new Conta { nome = enNomeConta.Text, banco_code = enCodBanco.Text, banco_nome = enNomeBanco.Text, numero = enNumConta.Text });
            if (respostaHttp.processado)
            {
                refreshContas();
            }
            else
            {
                await DisplayAlert("ERRO", respostaHttp.mensagem, "OK");
            }
        }
    }
}
