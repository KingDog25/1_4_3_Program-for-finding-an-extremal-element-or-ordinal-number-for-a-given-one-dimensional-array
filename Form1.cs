/*Условие: Составить программу нахождения экстремального элемента
или его порядкового номера при заданном одномерном массиве А из n элементов*/
/**Задача 1.4.3 Условие:Определить найменьшее значение сумм Ai  + Ai - 1*/

/*Condition: Write a program for finding an extremal element
or its ordinal number for a given one-dimensional array A of n elements */
/**Task 1.4.3 Condition: Determine the smallest value of the sums Ai + Ai - 1*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_variant_CSarp_1_4_3
{
    public partial class MinSum : Form
    {
        public MinSum()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] param = textBoxInputEl.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = param.Length;                                          //кол-во эл. массива
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(param[i]);
            }
            double[,] tableXY = new double[1, n];
            dataGridView1.RowCount = 1;                             //кол-во строк
            dataGridView1.ColumnCount = n;                          //столбцов
            dataGridView1.Rows[0].HeaderCell.Value = "Введен массив: ";
            int minsum = 0;                                           //кол-во полож. значений

            for (int j = 0; j < n; j++)
            {
                tableXY[0, j] = arr[j];
                dataGridView1.Rows[0].Cells[j].Value = tableXY[0, j];
            }
            //int[] arrA = new int[n];
            int rightEl = n - 1, leftEl = n - 2;                      //счетчики индексов для массива справа налево
            minsum = arr[rightEl] + arr[leftEl];                     // Присваиваем переменной сумму последних двух элементов массива
            for (int i = n - 1; i > 0; i--)
            {
                if (arr[i] + arr[i - 1] < minsum)                     //Если их сумма  < текущего, то перезаписываем переменную
                {
                    minsum = arr[i] + arr[i - 1];                     //запоминаем индексы
                    rightEl = i; leftEl = i - 1;
                }
            }
                                                                       //добавляем фон элементам
            dataGridView1.Rows[0].Cells[rightEl].Style.BackColor = Color.Green;   
            dataGridView1.Rows[0].Cells[leftEl].Style.BackColor = Color.Green;
            labelMinSum.Text = "Найменьшее значение сумм Ai + Ai - 1 = " + minsum.ToString();
            minsum = 0;                                                 //сбросить счетчик
            
        }
    }
}