using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple 
    {
        //поля 
        private string[] _output;

        //свойства 
        public string[] Output => _output;

        //конструктор 
        public Purple_2(string input) : base(input)
        {
            _output = default(string[]); //до вызова ревью output будет возвращать базовое значение
        }

        //методы
        public override void Review()
        {
            //проверка
            if (_input == null) return;

            //сплитнуть по пробелам 
            string[] words = _input.Split(' ');

            //разделить текст на строки
            string[] result = new string[1] {""};
            int resultIndex = 0;
            for (int i = 0; i < words.Length; i++)
            {
              
                if (result[resultIndex].Length + words[i].Length == 50)
                {
                    result[resultIndex] = result[resultIndex] + words[i];
                }
                else if (result[resultIndex].Length + words[i].Length + 1 <= 50)
                {
                    //если последнее слово 
                    if (i == words.Length - 1)
                    {
                        result[resultIndex] = result[resultIndex] + words[i];
                    }
                    else
                    {
                        result[resultIndex] = result[resultIndex] + words[i] + " ";
                    }
                }
                else  //не можем запихнуть текущее 
                    
                {
                    //в предыдущей строке стояло с пробелом, запихнули не впритык 
                    if (Char.IsWhiteSpace(result[resultIndex][result[resultIndex].Length - 1]))
                    {
                        result[resultIndex] = result[resultIndex].Substring(0, result[resultIndex].Length - 1);
                    }


                    //если последнее слово 
                    if (i == words.Length - 1)
                    {
                        resultIndex++;
                        Array.Resize(ref result, result.Length + 1);
                        result[resultIndex] = words[i];
                    }
                    else
                    {
                        resultIndex++;
                        Array.Resize(ref result, result.Length + 1);
                        result[resultIndex] = words[i] + " ";
                    }
                   
                }
            }
            
            //ровно 50 символов 
            for (int i = 0; i < result.Length; i++)
            {
                int length = result[i].Length;
                string[] current = result[i].Split(' ');

                //добавить по пробелу 
                for (int j = 0; j < current.Length - 1; j++)
                {
                    current[j] = current[j] + " ";
                 
                }


                int index = 0;
                while (length < 50)
                {
                    if (index%current.Length != current.Length - 1) //не последнее слово 
                    {
                        current[index % current.Length] += " ";
                        length++;
                      
                    }
                    index++;
                    

                }

                //соединить все строки 
                result[i] = String.Join("", current);

            }
            _output = new string[]{ };
            Array.Resize(ref _output, result.Length) ;
            Array.Copy(result, _output, result.Length);

        }

        public override string ToString()
        {
            if (_output == null) return null;

            string answer = "";
            for (int i = 0; i < _output.Length; i++)
            {
                answer += _output[i] +"\n";
            }
            return answer;

        }

    
    }
}
