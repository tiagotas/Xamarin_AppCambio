using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/**
 * Aqui estamos adicionando dois using de componentes que usaremos neste projeto.
 * a plataforma .NET é bem completa e muitas coisas já estão prontas. Por exemplo
 * aqui vamos utilizar a System.Globalization para colocar o R$ em nossa moeda e
 * usaremos a RegularExpressions para remover as vírgulas que podem ser digitadas
 * nos valores.
 */ 
using System.Globalization;
using System.Text.RegularExpressions;

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
            /**
             * Início do laço try { } catch que é usado para tratamento de exceções.
             * Uma exceção pode ser disparada quando há um erro no App, e podemos tratra-la
             * no catch, ou seja, ao invés do app travar ou dar crash podemos mostrar uma
             * mensagem de erro para o usuário.
             */ 
            try
            {
                /**
                 * Nesta etapa estamos usando expressões regulares para remover as vígulas
                 * dos números, trocando por pontos. Caso não façamos isso, mais abaixo no 
                 * código teremos erros de conversão. As linguagens de programação
                 * usam o ponto para separar as casas decimais, por exemplo: 1.2 e usam as
                 * vírgulas para separar as casas de milhar, como 1,200
                 */ 
                string cotacao_sem_virgula = Regex.Replace(txt_cotacao.Text, @"\D", "");
                string valor_dolares_sem_virgula = Regex.Replace(txt_quantia_usd.Text, @"\D", "");              


                /**
                 * Convertendo os valores já "limpos" para decimal. Todos os dados pegos na interface
                 * (entry) vem como String, então para realiar operações matemáticas, temos que converter
                 * para para tipos de dados númericos, neste caso Decimal por estar trabalhando com dinheiro.
                 */ 
                decimal cotacao = Convert.ToDecimal(cotacao_sem_virgula);
                decimal dolares = Convert.ToDecimal(valor_dolares_sem_virgula);

                /**
                 *  Fazendo a conversão de valores.
                 */ 
                decimal reais = cotacao * dolares;

                /**
                 * Aqui estamos instânciando a classe NumberFormatInfo, onde devemos informar "em qual
                 * país estamos". Assim, poderemos adicionar o R$ antes dos valores. O Objetivo disso é
                 * mostrar o usuário uma informação mais correta e conforme os padrões, por exemplo
                 * R$ 45.000,00
                 */ 
                NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;

                /**
                 * Aqui estamos definindo que o valor da propriedade Text do elemento txt_reais ( que é
                 * um label) será igual a reais, que é uma variável decimal. Note que estamos chamando o
                 * método ToString que recebe dois argumentos: "C" e nfi. O "C" define que vamos mostrar
                 * o cifrão e as casas decimais, por exemplo: R$ 45.500,00 Já o nfi é a instância do objeto
                 * quecriamos acima, ele é o responsável por adicionar o número do valor monetário
                 * no formato que usamos.
                 */
                txt_reais.Text = reais.ToString("C", nfi);

            } catch (Exception ex)
            {
                txt_reais.Text = "Ops, ocorreu um erro: \n " + ex.Message;                
            } // Fecha o laço try catch.
        } // fecha o método.
    } // fecha a classe MainPage
} // fecha o nomespace.