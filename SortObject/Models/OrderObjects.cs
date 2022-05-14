using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SortObject.Models
{
    public class OrderObjects
    {
        public string Sort(string input, string typeSort)
        {
            // Проверка на заполненность полей и правильность введенных данных CheckNullAndTrueData(string input, string typeSort)
            if (CheckNullAndTrueData(input, typeSort))
            {
                // Преобразование в массив символов 
                char[] _typeSort = typeSort.ToCharArray();
                char[] _input = input.ToCharArray();

                // Указатель на уже отсортированную часть строки
                int countElement = 0;

                for (int i = 0; i < _typeSort.Length; i++)
                {
                    for (int j = countElement; j < _input.Length; j++)
                    {
                        for (int k = j; k < _input.Length; k++)
                        {
                            // В случае если найден символ в входной строке, который равен символу по выбранному шаблону 
                            if (Regex.IsMatch(_input[k].ToString(), _typeSort[i].ToString(), RegexOptions.IgnoreCase))
                            {
                                // меняем местами
                                char buff = _input[j];
                                _input[j] = _input[k];
                                _input[k] = buff;
                                // повышаем указатель 
                                countElement++;
                                // выходим из цикла, так как в рамках заменненого символа уже ничего менять не требуется
                                break;
                            }
                        }
                    }
                }
                // возвращаем строку с отсортированным массивом символов
                return new string(_input);
            }
            else
            {
                return "";
            }
        }

        // Вспомогательные функции
        public bool CheckNullAndTrueData(string input, string typeSort)
        {
            StringBuilder error = new StringBuilder();
            int countError = 1;
            if (input == null || input == "")
            {
                error.Append(countError + ". Не введены входные данные\n\n");
                countError++;
            }
            if (!CheckTrueString(input))
            {
                error.Append(countError + ". Входные данные не соответствуют представленному шаблону\n\n");
                countError++;
            }
            if (typeSort == null)
            {
                error.Append(countError + ". Не выбран тип сортировки");
                countError++;
            }
            if (Regex.Matches(typeSort, @"(КСЗ)|(КЗС)|(СКЗ)|(СЗК)|(СЗК)|(СКЗ)", RegexOptions.IgnoreCase).Count != 1)
            {
                error.Append(countError + ". Узазан неверный формат сортировки");
            }

            if (error.Length == 0)
            {
                return true;
            }
            else
            {
                //MessageBox.Show(error.ToString());
                return false;
            }
        }
        public bool CheckTrueString(string input)
        {
            MatchCollection matchCollection = Regex.Matches(input, @"К|С|З", RegexOptions.IgnoreCase);
            if (matchCollection.Count == input.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
