# Сортировка объектов | Sort Objects
___
## Библиотеки 
✅ ***Runtime.CompilerServices*** - Предоставляет средства, позволяющие разработчикам компиляторов, использующим управляемый код, задавать в метаданных атрибуты, влияющие на поведение среды CLR во время выполнения.  
✅ ***System.Text*** - Содержит классы, которые представляют кодировки ASCII и Юникода.  
✅ ***System.Text.RegularExpressions*** - Предоставляет функциональные возможности регулярных выражений, которые могут быть использованы из любой платформы или языка, работающих в рамках платформы .NET. В дополнение к типам, содержащимся в данном пространстве имен, класс RegexStringValidator позволяет определить, совпадает ли определенная строка с шаблоном регулярного выражения.  
✅ ***System.Windows.Controls*** - Представляет базовый класс для элементов пользовательского интерфейса, которые используют ControlTemplate для определения своего внешнего вида.  
✅ ***System.Windows.Input*** - Предоставляет данные для событий клавиш доступа. Поддерживает регистрацию всех клавиш доступа и обработку команд клавиатуры.  
✅ ***System.Windows*** - Предоставляет возможность создавать, настраивать, показывать обычные и диалоговые окна, а также управлять временем их существования.  
✅ ***System.ComponentModel*** - Предоставляет базовую реализацию интерфейса IComponent и делает возможным совместное использование объектов разными приложениями.  
##### Примечание: все данные по используемым библиотекам взяты с официального сайта Microsoft.
___
## Фреймворки
✅ ***.NET*** - технология, которая поддерживает создание и выполнение веб-служб и приложений Windows.  
✅ ***WPF*** - технология, которая необходима для разработки интерфейсов под Windows с графической подсистемой, использующей язык XAML.  
___
## Шаблон проектирования
✅ ***MVVM (Model-View-ViewModel)*** - паттерн разработки, позволяющий разделить приложение на три функциональные части.
___
## Принципы разработки и проектирования
✅ ***DRY (Don't Repeat yourself)*** - принцип разработки программного обеспечения, нацеленный на снижение повторения информации различного рода.  
✅ ***KISS (Keep it simple, stupid)*** - принцип проектирования программного обеспечения, нацеленный на снижение уровня сложности системы с целью оптимизации.  
___
## Главное окно
!
___
## Функция сортировки
```C#
public string Sort(string input, string typeSort)
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
            return new string(_input).ToUpper();
```