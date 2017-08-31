using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_task_9_11
{
    class Program
    {
        static void SimpleChoiceSorting(int[] mas)
        {//сортировка простым выбором
            int min;//минимальный элемент в неотсортированной части массива
            int mini;//индекс минимального элемента в неотсортированной части массива
            for (int i=0; i<mas.Length; i++)//сдвигаем край отсортированной части массива вправо
            {
                min = mas[i];
                mini = i;
                for (int j=i+1; j<mas.Length; j++)//перебираем неотсортированную часть массива
                {
                    if (min>mas[j])//ищем минимальный элемент в неотсортированной части
                    {
                        min = mas[j];
                        mini = j;//запоминем его индекс                       
                    }
                }
                int k = mas[i];//вспомогательная переменная для пересылки
                mas[i] = min;//меняем минимальный элемент и первый в неотсортированной части местами
                mas[mini] = k;
            }
            Console.WriteLine("Массив, отсортированный с методом простого выбора: ");
            for (int i=0; i<mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //int[] mas = { 4, 6, 7, 10, 7, 0, 9 };
            //SimpleChoiceSorting(mas);
            //Console.ReadLine();
        }
    }
}
