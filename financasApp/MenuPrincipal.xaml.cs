using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace financasApp
{
    public partial class MenuPrincipal : ContentPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        void btContas_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageContas());
        }

        void btCategorias_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageCategorias());
        }

        void btDespesas_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageDespesas());
        }

        void btReceitas_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageReceitas());
        }

        void btListDesp_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageLancamentos(1));
        }

        void btListRece_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new PageLancamentos(2));
        }
    }
}
