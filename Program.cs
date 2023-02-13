using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrimeiraProva
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] collection = File.ReadAllLines("Arquivo.txt");
                // Criar o array com tamanho das linhas para serem executadas.
                int[] array = new int[collection.Length];

                for (int i = 0; i < collection.Length; i++)
                {
                    array[i] = int.Parse(collection[i]);
                }

                Console.WriteLine("[1] - Selection Sort");
                Console.WriteLine("Selecione sua opção: ");
                int op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        {
                            SortArray(array);
                            break;
                        }
                    
                }

            }
              // caso o arquivo não exite ou não pode ser encontrado 
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }

        static void SortArray(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }

            File.WriteAllLines("Array.txt", array.Select(x => x.ToString()));

            SortedSet<int> orderedCollection = new SortedSet<int>(array);
            File.WriteAllLines("Colectionsalvo.txt", orderedCollection.Select(x => x.ToString()));

            Console.WriteLine("Coleção ordenada:");
            foreach (int numero in orderedCollection)
            {
                Console.WriteLine(numero);
            }

            Console.WriteLine("Array ordenado no método:");
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }

       

    }
}