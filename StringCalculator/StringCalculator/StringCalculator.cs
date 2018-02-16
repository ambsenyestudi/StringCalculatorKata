using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        readonly List<char> addmitedSeparators = new List<char>{ ',', '\n' };
        char defaultSeparator = ',';
        public int Add(string numbers)
        {
            var result = 0;
            if(numbers.Length>0)
            {
                CheckForNegatives(numbers);
                if (numbers.Length < 2)
                {
                    result = int.Parse(numbers);
                }
                else
                {
                    result = AddAnyAmmountofNumbers(numbers);
                }
            }
            return result;
        }
        private void CheckForNegatives(string numbers)
        {
            var negSeparator = '-';
            if (numbers.Contains(negSeparator))
            {
                numbers = NormalizeSeparators(numbers);
                string[] nums = numbers.Split(defaultSeparator);
                var negNumb = from num in nums
                              where num.Contains(negSeparator)
                              select num;
                string negNumbers = string.Join(", ", negNumb.ToList<string>());
                var msg = "Negatives not allowed " + negNumbers;
                throw new FormatException(msg);
            }
        }

        private int AddAnyAmmountofNumbers(string numbers)
        {
            var result = 0;
            numbers = NormalizeSeparators(numbers);
            if (numbers.Length > 0)
            {
                int currResult;
                string[] nums = numbers.Split(defaultSeparator);
                for (int i = 0; i < nums.Length; i++)
                {
                    if (int.TryParse(nums[i], out currResult))
                    {
                        result += currResult;
                    }
                }
            }
            return result;
        }
        private string NormalizeSeparators(string numbers)
        {
            defaultSeparator = addmitedSeparators[0];
            
            if (numbers.Contains('/'))
            {
                defaultSeparator = numbers[numbers.LastIndexOf('/') + 1];
                numbers = numbers.Substring(numbers.IndexOf(defaultSeparator)+1);
            }
            
            foreach(var sep in addmitedSeparators)
            {
                numbers=numbers.Replace(sep, defaultSeparator);
            }
            return numbers;
        }
    }
}
