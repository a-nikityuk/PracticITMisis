using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9.Purple
{
    public class Task1 : Purple
    {
        private string _outPut;

        public string Output => _outPut;
        public Task1(string input) : base(input) 
        {
            _outPut = "";
        }
        

        public override void Review()
        {

            var res = new StringBuilder();
            var array = Input.Split(' ');
            foreach (var word in array)
            {
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    if ((char.IsLetter(word[i]) && !char.IsDigit(word[i]) && word[i] != '\n' && word[i] != '\r') || (word[i] == '\'') || (word[i] == '-'))
                        if (i > 2 && word[i] == 'h' && word[i - 1] == 't' && char.IsDigit(word[i - 2]))
                        {
                            res.Append("th");
                            i--;
                        }
                        else
                            res.Append(word[i]);
                }
                res.Append(" ");
            }

            for (int i = 0; i < Input.Length; i++)
            {
                if ((char.IsPunctuation(Input[i]) || char.IsDigit(Input[i]) || Input[i] == '\n' || Input[i] == '\r') && (Input[i] != '\'') && (Input[i] != '-'))
                {
                    res.Insert(i, Input[i]);
                }

            }
            _outPut += res.ToString().Trim();

        }

        public override string ToString() {
            return _outPut;
        }
    }
}
