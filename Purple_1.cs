using System;
using System.Globalization;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        //поля 
        private string _output;

        //свойства 
        public string Output => _output;

        //конструктор 
        public Purple_1(  string input) : base(input)
        {
            _output=default(string); //до вызова ревью output будет возвращать базовое значение
        }

        //методы
        public override void Review()
        {
            if (_input == null) return;

            //разделить текст на слова по пробелам 
            string[] words = _input.Split(' ');
            
            //перевернуть все слова 
            for (int i = 0; i < words.Length; i++)
            {
                // найти начало и конец того что надо перевернуть 
                int start = 0, end = words[i].Length-1;
                while (!char.IsLetter(words[i][start]) || !char.IsLetter(words[i][end])) //пока начало не является буквой или конец не является буквой
                {
                    if (start >= end) break;
                    if (!char.IsLetter(words[i][start])) start++;
                    if (!char.IsLetter(words[i][end])) end--;
                }

                if (start >= end) continue;//если нет букв
                //отделить начало
                string startString = words[i].Substring(0, start);

                //середина и развернуть
                string middleString = words[i].Substring(start, end-start+1);
                char[] chars = middleString.ToCharArray();
                Array.Reverse(chars);
                middleString = String.Join("", chars);

                //конец
                string endString = words[i].Substring(end+1, words[i].Length - end - 1);
               
                //соединили
                words[i] = startString + middleString + endString;

                //if (char.IsLetter(words[i][0]))
                //{
                //    if (Char.IsPunctuation(words[i][words[i].Length - 1])) // если последний символ пунктуация
                //    {
                //        char[] chars = words[i].ToCharArray();//разделить слово на символы

                //        char last_char = chars[chars.Length - 1];//отделить последнюю букву

                //        Array.Resize(ref chars, chars.Length - 1);//сократить
                //        Array.Reverse(chars);//перевернула 
                //        Array.Resize(ref chars, chars.Length + 1);
                //        chars[chars.Length - 1] = last_char;

                //        words[i] = String.Join("", chars);


                //    }
                    
                //    else
                //    {
                //        char[] chars = words[i].ToCharArray();//разделить слово на символы
                //        Array.Reverse(chars);//перевернула 
                //        words[i] = String.Join("", chars); //соединить 
                //    }
                //}
                
            }

            //соединить все слова в одну строку в аутпут 
            _output = String.Join(" ", words);

        }

        public override string ToString()
        {
            if (_output == null) return null;
            return _output;
        }


    }
}
