using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/**
 * Declaração do Namespace do App, geralmente o nome do projeto.
 * Classes que não estão neste namespace não serão reconhecidas pelo App.
 * Mais a frente no curso vamos utilizar a palavra-chave using para referênciar
 * classes em projetos diferentes.
 */
namespace AppCambio
{
    /**
     * Classe C# que está vinculada ao arquivo XAML de mesmo nome. Observe que
     * editamos o arquivo MainPage.xaml e este arquivo se chama MainPage.xaml.cs
     * Toda a programação dos comportamentos da interface será realizada aqui, mas
     * sempre dentro dos métodos. Os métodos sempre estão no corpo da classe, ou seja,
     * sempre dentro do bloco { } abre e fecha chaves.
     */ 
    public partial class MainPage : ContentPage
    {
        /**
         * Método construtor da classe MainPage. Este método é responsável por
         * construir a interface gráfica da tela do App, tanto que o primeiro
         * método a ser chamado é o InitializeComponent(), da classe ContentPage.
         * Este método é herdado e é chamado para mostrar na tela todos aqueles
         * componentes que definimos no arquivo XAML.
         */ 
        public MainPage()
        {
            InitializeComponent();
        }

        /**
         * Método que trata o evento disparado quando o botão é clicado, ou seja,
         * toda vez que houver um clique naquele botão esse método será chamado
         * e todo o código dentro dele será executado. Entendemos que o código está
         * dentro do método, depois do { e antes do }
         */
        private void Button_Clicked(object sender, EventArgs e)
        {
            double cotacao = Convert.ToDouble(txt_cotacao.Text);
            double dolares = Convert.ToDouble(txt_quantia_usd.Text);

            double reais = cotacao * dolares;

            txt_reais.Text = reais.ToString();

        } // fecha o método.

    } // fecha a classe MainPage
} // fecha o nomespace.
