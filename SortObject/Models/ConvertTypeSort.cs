using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SortObject.Models
{
    internal class ConvertTypeSort
    {
        internal static string ConvertTypeSortToString(StackPanel TypeSort)
        {
            string typeSort = "";

            if (typeSort == null)
            {

                return null;
            }
            else
            {
                for (int i = 0; i <= TypeSort.Children.Count; i += 2)
                {
                    typeSort += (TypeSort.Children[i] as TextBlock).Text.Replace(" ", "");
                }
                return typeSort;
            }


        }
    }
}
