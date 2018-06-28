using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzLib
{
    public static class Extensions
    {
        public static bool IsDivisibleBy(this int sourceNumber, int targetNumber)
        {
            return (sourceNumber % targetNumber) == 0;
        }

        public static void Add<T1, T2>(this IList<Tuple<T1, T2>> list,
            T1 item1, T2 item2)
        {
            list.Add(Tuple.Create(item1, item2));
        }
    }

    public class FizzBuzzResult
    {
        public int InputValue { get; set; }
        public string OutputValue { get; set; }
    }

    public class FizzBuzz
    {
        public IEnumerable<FizzBuzzResult> GetFizzBuzz(List<Tuple<int, string>> evaluations, int minVal = 1, int maxVal = 100)
        {
            List<FizzBuzzResult> result = new List<FizzBuzzResult>();

            for (int i = minVal; i <= maxVal; i++)
            {
                var evaluatedDivisibleOutput = String.Empty;

                if (evaluations.Any(j => i.IsDivisibleBy(j.Item1)))
                {
                    evaluatedDivisibleOutput = evaluations.Where(j => i.IsDivisibleBy(j.Item1)).Select(h => h.Item2).Aggregate((a, b) => a + b);
                }

                result.Add(new FizzBuzzResult
                {
                    InputValue = i,
                    OutputValue = string.IsNullOrEmpty(evaluatedDivisibleOutput) ? i.ToString() : evaluatedDivisibleOutput
                });             
            }

            return result;
        }
        
    }

    
}
