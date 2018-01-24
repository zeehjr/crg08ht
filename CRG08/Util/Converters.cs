using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRG08.Util
{
    public class Converters
    {
        //Converte binario para decimal
        public static int binarioParaDecimal(string valorBinario)
        {

            int expoente = 0;

            int numero;

            int soma = 0;

            string numeroInvertido = inverterString(valorBinario);

            for (int i = 0; i < numeroInvertido.Length; i++)
            {

                //pega dígito por dígito do número digitado

                numero = Convert.ToInt32(numeroInvertido.Substring(i, 1));

                //multiplica o dígito por 2 elevado ao expoente, e armazena o resultado em soma

                soma += numero * (int)Math.Pow(2, expoente);

                // incrementa o expoente

                expoente++;

            }

            return soma;

        }

        // Converte decimal para binario ( STRING )
        public static string decimalParaBinario(int numero)
        {

            string valor = "";
            int cont = 8;
            int dividendo = Convert.ToInt32(numero);

            while (valor.Length < 8)
            {

                valor += Convert.ToString(dividendo % 2);

                dividendo = dividendo / 2;

            }

            return inverterString(valor);
        }

        // Inverte a string... Ex: "123" -> "321"
        public static string inverterString(string str)
        {

            int tamanho = str.Length;

            char[] caracteres = new char[tamanho];

            for (int i = 0; i < tamanho; i++)
            {
                if (!(tamanho - i > str.Length))
                {
                    caracteres[i] = str[tamanho - 1 - i];
                }
                else
                {
                    caracteres[i] = '0';
                }
            }

            return new string(caracteres);

        }

        // Método de conversão customizado...
        // Parâmetros: 'binario' = valor que gostaria de converter...
        //             'comeco' = em que posicao da string gostaria de comecar a converter
        //             Ex: string: 'Ti' - Se o comeco for 2, começará a partir do char 'i'
        //             'fim' = em que posicao acaba a conversao
        //             Ex: string: 'Digisystem' - se o fim for 3, acabará no char 'g'
        public static float converterGeral(string binario, int comeco, int fim)
        {
            int resultado = 0;
            int aux = fim - comeco;

            binario = binario.Substring(comeco, fim - comeco);

            if (aux != 8)
            {
                aux = 8 - aux;

                for (int i = 0; i < aux; i++)
                {
                    binario = "0" + binario;
                }
            }

            resultado = binarioParaDecimal(binario);

            return resultado;
        }
    }
}
