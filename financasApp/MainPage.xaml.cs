using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace financasApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static String authToken=null;
        public MainPage()
        {
            InitializeComponent();
        }



        async void btAdd_Clicked(System.Object sender, System.EventArgs e)
        {

            var httpc = new meuhttp();
            var respostaHttp = await httpc.Post("user/", new Credencial { email = enEmail.Text, password = enPass.Text });
            if (respostaHttp.processado)
            {
                authToken = respostaHttp.mensagem;
                await DisplayAlert("FEITO!", respostaHttp.mensagem, "OK");
            }
            else
            {
                await DisplayAlert("ERRO", respostaHttp.mensagem, "OK");
            }
        }

        async void btLog_Clicked(System.Object sender, System.EventArgs e)
        {
            var httpc = new meuhttp();
            var respostaLogin = await httpc.Post("auth/", new Credencial { email = enEmail.Text, password = enPass.Text });
            if (respostaLogin.processado)
            {
                authToken = respostaLogin.mensagem;
                await Navigation.PushAsync(new MenuPrincipal());
            }
            else
            {
                await DisplayAlert("ERRO", respostaLogin.mensagem, "OK");
            }

        }

        private class Credencial
        {
            public String email { get; set; }
            public String password { get; set; }
            public String confirm { get; set; }
        }
    }
}
