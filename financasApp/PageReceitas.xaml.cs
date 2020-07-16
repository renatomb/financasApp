using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace financasApp
{
    public partial class PageReceitas : ContentPage
    {
        public PageReceitas()
        {
            InitializeComponent();
            carregaDados();
        }
        public async void carregaDados()
        {
            pkConta.ItemsSource = null;
            pkCategoria.ItemsSource = null;
            ObservableCollection<Categoria> categorias;
            var httpcategoria = new meuhttp();
            var respHttpCateg = await httpcategoria.GetHttp("categ/");
            categorias = JsonConvert.DeserializeObject<ObservableCollection<Categoria>>(respHttpCateg.mensagem);
            pkCategoria.ItemsSource = categorias;
            ObservableCollection<Conta> contas;
            var httpconta = new meuhttp();
            var respHttpConta = await httpconta.GetHttp("conta/");
            contas = JsonConvert.DeserializeObject<ObservableCollection<Conta>>(respHttpConta.mensagem);
            pkConta.ItemsSource = contas;

        }
        async void btAddCredito_Clicked(System.Object sender, System.EventArgs e)
        {
            if ((pkConta.SelectedIndex == -1) || (pkCategoria.SelectedIndex == -1))
            {
                await DisplayAlert("Incompleto", "Por gentileza selecione uma conta e uma categoria.", "OK");
            }
            else
            {
                var selConta = (Conta)pkConta.SelectedItem;
                var selCateg = (Categoria)pkCategoria.SelectedItem;
                var httpc = new meuhttp();
                var respostaHttp = await httpc.Post("credito/", new Lancamento { data = dpData.Date, beneficiario = enPagador.Text, categoriaId = selCateg._id, contaId = selConta._id, descricao = enDescr.Text, valor = Convert.ToDecimal(enValor.Text) });
                if (respostaHttp.processado)
                {
                    enPagador.Text = "";
                    enDescr.Text = "";
                    enValor.Text = "";
                    carregaDados();
                }
            }
        }
    }
}
