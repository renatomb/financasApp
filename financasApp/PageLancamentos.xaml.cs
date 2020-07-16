using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace financasApp
{
    public partial class PageLancamentos : ContentPage
    {
        public PageLancamentos(int tipo)
        {
            InitializeComponent();
            carregaLancamentosAsync(tipo);
        }
        async void carregaLancamentosAsync(int tipo)
        {
            lvLancamentos.ItemsSource = null;
            ObservableCollection<Lancamento> lancamentos;
            var httplancam = new meuhttp();
            Resposta resphttplanc = new Resposta();
            switch (tipo)
            {
                case 1:
                    resphttplanc = await httplancam.GetHttp("debito/");
                    break;
                case 2:
                    resphttplanc = await httplancam.GetHttp("credito/");
                    break;
            }
            lancamentos = JsonConvert.DeserializeObject<ObservableCollection<Lancamento>>(resphttplanc.mensagem);
            lvLancamentos.ItemsSource = lancamentos;
        }
    }
}
