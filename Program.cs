using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabalho_Gabriel_Romeu_Coelho
{
    class Program
    {
        static void Main(string[] args)
        {
            // Escreva seus códigos Aqui ;)
            // Nome : Gabriel Romeu Coelho

            int[][] prod1 = new int[6][];
            int[][] prod2 = new int[6][];
            int[][] prod3 = new int[6][];
            int[][] prod4 = new int[6][];
            CriaMatriz(prod1, prod2, prod3, prod4);
            Preenchimento(prod1, prod2, prod3, prod4);//preenche metade do estoque

            List<string> carga = new List<string>();//gera lista que recebe a carga
            List<int> cargaInt = new List<int>(); //lista que receberá carga convertida para int

            int a = 0;
            while (a < 6)
            {
                Console.WriteLine("***Dia " + (a + 1) + "***");
                Console.WriteLine();

                int qtdCarga = Geradores.Qtd();
                Console.WriteLine("Foi recebido " + qtdCarga + " carga(s): ");
                for (int h = 0; h < qtdCarga; h++)
                {
                    carga = Geradores.GeraEntrada(); //carga recebe valor
                    cargaInt = ConverterLista(carga); //chama função que converte a carga

                    foreach (var item in cargaInt) //mostra a carga
                    {
                        Console.Write(item);
                    }
                    Console.WriteLine();

                    RecebeCarga(cargaInt, prod1, prod2, prod3, prod4);
                }

                Console.WriteLine();
                MostraEstoque(prod1, prod2, prod3, prod4);
                Console.WriteLine();
                Console.WriteLine("------------------------");

                double OrdemDouble = 0;
                string OrdemServico;

                Console.WriteLine("Ordem serviço:");
                for (int i = 0; i < Geradores.Qtd(); i++)
                {
                    OrdemServico = Geradores.OrdemDeServico();
                    OrdemServico = SortManual(OrdemServico);//organiza

                    OrdemDouble = Convert.ToDouble(OrdemServico); //converte OrdemServico(string) em int
                    Console.WriteLine(OrdemDouble);

                    char[] separa = new char[OrdemServico.Length];//vetor de char para separar os valores da OrdemDeServico
                    for (int j = 0; j < OrdemServico.Length; j++)
                    {
                        separa[j] = OrdemServico[j];
                    }

                    int[] entrega = new int[separa.Length];
                    EnviaEntrega(entrega, OrdemServico, separa, prod1, prod2, prod3, prod4);
                }
                Console.WriteLine("------------------------");
                Console.WriteLine();

                MostraEstoque(prod1, prod2, prod3, prod4);
                Console.WriteLine();

                Console.WriteLine("Pressione qualquer tecla para continuar... ");
                string entrada;
                entrada = Console.ReadLine();
                if (entrada == "")
                {
                    a++;
                    Console.Clear();
                }
                else
                {
                    a++;
                    Console.Clear();
                }
            }
        }
        public static void CriaMatriz(int[][] produto1, int[][] produto2, int[][] produto3, int[][] produto4)
        {
            for (int i = 0; i < produto1.Length; i++)
            {
                produto1[i] = new int[6];
                produto2[i] = new int[6];
                produto3[i] = new int[6];
                produto4[i] = new int[6];
            }
        }
        public static void Preenchimento(int[][] produto1, int[][] produto2, int[][] produto3, int[][] produto4)
        {
            //preenche metade do estoque de produtos
            for (int i = 0; i < produto1.Length; i++)
            {
                for (int j = 0; j < produto1[i].Length; j++)
                {
                    if (produto1[i][j] == 0)
                    {
                        if (produto1[2][5] == 1)
                        {
                            break;
                        }
                        produto1[i][j] = 1;
                    }
                }
            }

            for (int i = 0; i < produto2.Length; i++)
            {
                for (int j = 0; j < produto2[i].Length; j++)
                {
                    if (produto2[i][j] == 0)
                    {
                        if (produto2[2][5] == 1)
                        {
                            break;
                        }
                        produto2[i][j] = 1;
                    }
                }
            }

            for (int i = 0; i < produto3.Length; i++)
            {
                for (int j = 0; j < produto3[i].Length; j++)
                {
                    if (produto3[i][j] == 0)
                    {
                        if (produto3[2][5] == 1)
                        {
                            break;
                        }
                        produto3[i][j] = 1;
                    }
                }
            }

            for (int i = 0; i < produto4.Length; i++)
            {
                for (int j = 0; j < produto4[i].Length; j++)
                {
                    if (produto4[i][j] == 0)
                    {
                        if (produto4[2][5] == 1)
                        {
                            break;
                        }
                        produto4[i][j] = 1;
                    }
                }
            }
        }
        public static List<int> ConverterLista(List<string> ListaString)
        {
            List<int> listaInt = new List<int>();  //cria a lista int que vai receber a lista string

            for (int i = 0; i < ListaString.Count; i++)
            {
                //lista int vai receber (add) a lista string convertida (convert.toint32)
                listaInt.Add(Convert.ToInt32(ListaString[i]));
            }
            return listaInt;
        }
        public static string SortManual(string entrega)
        {
            char[] palavra = new char[entrega.Length];
            for (int i = 0; i < entrega.Length; i++)
            {
                palavra[i] = entrega[i];
            }

            for (int i = 0; i < entrega.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (Convert.ToInt32(palavra[j]) < Convert.ToInt32(palavra[j - 1]))
                    {
                        char a;
                        a = palavra[j];
                        palavra[j] = palavra[j - 1];
                        palavra[j - 1] = a;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            entrega = "";
            for (int i = 0; i < palavra.Length; i++)
            {
                entrega += palavra[i].ToString();
            }
            return entrega;
        }
        public static void RecebeCarga(List<int> lista, int[][] produto1, int[][] produto2, int[][] produto3, int[][] produto4)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == 1)
                {
                    for (int j = 0; j < produto1.Length; j++)
                    {
                        for (int k = 0; k < produto1[j].Length; k++)
                        {
                            if (produto1[j][k] == 0)
                            {
                                produto1[j][k] = 1;

                                lista[i] = 0;
                                break;
                            }
                        }
                        if (lista[i] == 0)
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == 2)
                {
                    for (int j = 0; j < produto2.Length; j++)
                    {
                        for (int k = 0; k < produto2[j].Length; k++)
                        {
                            if (produto2[j][k] == 0)
                            {
                                produto2[j][k] = 1;

                                lista[i] = 0;
                                break;
                            }
                        }
                        if (lista[i] == 0)
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == 3)
                {
                    for (int j = 0; j < produto3.Length; j++)
                    {
                        for (int k = 0; k < produto3[j].Length; k++)
                        {
                            if (produto3[j][k] == 0)
                            {
                                produto3[j][k] = 1;

                                lista[i] = 0;
                                break;
                            }
                        }
                        if (lista[i] == 0)
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == 4)
                {
                    for (int j = 0; j < produto4.Length; j++)
                    {
                        for (int k = 0; k < produto4[j].Length; k++)
                        {
                            if (produto4[j][k] == 0)
                            {
                                produto4[j][k] = 1;

                                lista[i] = 0;
                                break;
                            }
                        }
                        if (lista[i] == 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
        public static void MostraEstoque(int[][] produto1, int[][] produto2, int[][] produto3, int[][] produto4)
        {

            Console.WriteLine("Estoque produto 1: ");
            for (int i = 0; i < produto1.Length; i++)
            {
                for (int j = 0; j < produto1[i].Length; j++)
                {
                    Console.Write(produto1[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Estoque produto 2: ");
            for (int i = 0; i < produto2.Length; i++)
            {
                for (int j = 0; j < produto2[i].Length; j++)
                {
                    Console.Write(produto2[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Estoque produto 3: ");
            for (int i = 0; i < produto3.Length; i++)
            {
                for (int j = 0; j < produto3[i].Length; j++)
                {
                    Console.Write(produto3[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Estoque produto 4: ");
            for (int i = 0; i < produto4.Length; i++)
            {
                for (int j = 0; j < produto4[i].Length; j++)
                {
                    Console.Write(produto4[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void EnviaEntrega(int[] entrega, string OrdemServico, char[] separa, int[][] prod1, int[][] prod2, int[][] prod3, int[][] prod4)
        {
            //verifica a OrdemDeServico e remove do estoque dos produtos
            for (int j = 0; j < OrdemServico.Length; j++)
            {
                if (separa[j] == '1')
                {
                    entrega[j] = 1;

                    for (int k = 5; k >= 0; k--)
                    {
                        for (int l = 5; l >= 0; l--)
                        {
                            if (prod1[k][l] == 1)
                            {
                                prod1[k][l] = 0;

                                entrega[j] = 0;
                                break;
                            }
                        }
                        if (entrega[j] == 0)
                        {
                            break;
                        }
                    }
                }

                if (separa[j] == '2')
                {
                    entrega[j] = 2;

                    for (int k = 5; k >= 0; k--)
                    {
                        for (int l = 5; l >= 0; l--)
                        {
                            if (prod2[k][l] == 1)
                            {
                                prod2[k][l] = 0;

                                entrega[j] = 0;
                                break;
                            }
                        }
                        if (entrega[j] == 0)
                        {
                            break;
                        }
                    }
                }

                if (separa[j] == '3')
                {
                    entrega[j] = 3;

                    for (int k = 5; k >= 0; k--)
                    {
                        for (int l = 5; l >= 0; l--)
                        {
                            if (prod3[k][l] == 1)
                            {
                                prod3[k][l] = 0;

                                entrega[j] = 0;
                                break;
                            }
                        }
                        if (entrega[j] == 0)
                        {
                            break;
                        }
                    }
                }

                if (separa[j] == '4')
                {
                    entrega[j] = 4;

                    for (int k = 5; k >= 0; k--)
                    {
                        for (int l = 5; l >= 0; l--)
                        {
                            if (prod4[k][l] == 1)
                            {
                                prod4[k][l] = 0;

                                entrega[j] = 0;
                                break;
                            }
                        }
                        if (entrega[j] == 0)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}