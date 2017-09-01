﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12_task_9_11
{
    class Program
    {
        static void WriteMas(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }
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
            WriteMas(mas);
        }

        static int[] MakeSortedTree(int[] mas, int maxElem, int elem)
        {//функция, строящая сортировочное дерево
            int maxDescendant = elem;//индекс максимального из двух потомков данного элемента
            int LeftDescendant = elem * 2 + 1;//индекс левого потомка данного элемента
            int RightDescendant = elem * 2 + 2;//индекс правого потомка данного элемента

            while (LeftDescendant < maxElem)//пока не дойдем до границы неотсортированной части массива
            {
                if (RightDescendant >= maxElem) maxDescendant = LeftDescendant;//если мы дошли до последнего элемента в неотсортированной части и правый потомок уже в отсортированной части
                else//если мы еще не дошли до конца неотсортированной части и правый потомок тоже находится в ней
                if (mas[LeftDescendant] > mas[RightDescendant]) maxDescendant = LeftDescendant;//находим максимальный элемент и  записываем его индекс в maxDescendant
                else maxDescendant = RightDescendant;

                if (mas[maxDescendant] <= mas[elem]) break;//если потомок не больше данного элемента, то заканчивам построение сортировочного дерева
                else//если потомок больше данного элемента, то меняем их местами
                {
                    int k = mas[elem];//вспомогательна переменная
                    mas[elem] = mas[maxDescendant];
                    mas[maxDescendant] = k;
                    elem = maxDescendant;//данный элемент меняет индекс
                    LeftDescendant = elem * 2 + 1;//индекс левого потомка данного элемента
                    RightDescendant = elem * 2 + 2;//индекс правого потомка данного элемента
                }
            }
            return mas;
        }

        static void PyramidalSorting(int[] mas)
        {//функция, в которой выполняется два этапа пирамидальной сортировки

            //первый этап: составляем пирамиду, прогоняя по не ней элементы, имеющие потомков, начиная с самого нижнего
            for (int i = mas.Length / 2 - 1; i >= 0; i--)
                mas = MakeSortedTree(mas, mas.Length, i);//нижней границы пока нет, так как массив еще не начали сортировать
            WriteMas(mas);

            //второй этап: меняем местами первый и последний в неотсортированной части, затем прогоняем новый верхний элемент, составляя пирамиду
            for (int i=mas.Length-1; i>=1; i--)
            {
                //меняем местами верхний и нижний элементы неотсортированной части (последний элемент - новый край отсортированной части)
                int k = mas[i];
                mas[i] = mas[0];
                mas[0] = k;
                //составляем пирамиду, передвинув нижний край на один влево. Прогоняем по ней верхний элемент
                mas = MakeSortedTree(mas, i, 0);
                WriteMas(mas);
            }
            Console.WriteLine("Массив, отсортированный с помощью пирамидальной сортировки:");
        }

        static void Main(string[] args)
        {
            //int[] mas = { 4, 6, 7, 10, 7, 0, 9 };
            ////SimpleChoiceSorting(mas);
            //PyramidalSorting(mas);
            //Console.ReadLine();
        }
    }
}
