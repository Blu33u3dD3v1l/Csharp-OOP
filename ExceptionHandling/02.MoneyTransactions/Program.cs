using System;
using System.Linq;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main()
        {
            var line = Console.ReadLine().Split(",").ToList();
            var dict = new Dictionary<string, double>();
           
            for (int i = 0; i < line.Count; i++)
            {

                var some = line[i].Split("-");
                var agsdg = string.Empty;
                var money = 0.0;

                for (int a = 0; a < some.Length; a++)
                {
                   
                    if (a % 2 == 0)
                    {

                        agsdg += some[a].ToString();
                    }
                    else
                    {
                        money = double.Parse(some[a]);
                    }                
               
                }
                if (!dict.ContainsKey(agsdg))
                {
                    dict.Add(agsdg, money);
                }               

            }
            while (true)
            {
                try
                {
                    var cmd = Console.ReadLine();
                    if (cmd == "End")
                    {
                        break;
                    }
                    var tokens = cmd.Split();
                    if (tokens[0] == "Deposit")
                    {
                        var thisAcc = tokens[1];
                        var thisMoney = double.Parse(tokens[2]);
                        if (!dict.Any(x => x.Key == thisAcc))
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            dict[thisAcc] += thisMoney;
                            Console.WriteLine($"Account {thisAcc} has new balance: {dict[thisAcc]:f2}");
                            Console.WriteLine("Enter another command");

                        }
                        
                    }
                    else if (tokens[0] == "Withdraw")
                    {
                        var thisAcc = tokens[1];
                        var thisMoney = double.Parse(tokens[2]);
                        if (dict.Any(x => x.Key == thisAcc))
                        {
                            if (dict[thisAcc] - thisMoney < 0)
                            {
                                throw new AccessViolationException();
                            }
                            else
                            {
                                dict[thisAcc] -= thisMoney;
                                Console.WriteLine($"Account {thisAcc} has new balance: {dict[thisAcc]:f2}");
                                Console.WriteLine("Enter another command");
                            }
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                        

                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (ArgumentException)
                {

                    Console.WriteLine("Invalid account!");
                    Console.WriteLine("Enter another command");
                }
                catch (AccessViolationException)
                {
                    Console.WriteLine("Insufficient balance!");
                    Console.WriteLine("Enter another command");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid command!");
                    Console.WriteLine("Enter another command");
                }
                
  
            }
        }
    }
}
