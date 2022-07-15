using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var line = Console.ReadLine().Split().Select(int.Parse).ToList();
            var list = new List<int>();
            var counts = 0;
            while (counts < 3)
            {
              
                try
                {
                    var cmd = Console.ReadLine();
                    if (cmd == "End")
                    {
                        break;
                    }
                    var tokens = cmd.Split();
                    var someCommand = tokens[0];                  
                    if (someCommand == "Replace")
                    {
                        var index = int.Parse(tokens[1]);
                        var element = int.Parse(tokens[2]);
                        if(index < line.Count - 1)
                        {
                            line.Insert(index, element);
                            line.Remove(index + 1);
                        }

                        if (index > line.Count - 1)
                        {
                            counts++;
                            throw new IndexOutOfRangeException();
                        }
                       

                    }
                    if (someCommand == "Print")
                    {
                        var startIndex = int.Parse(tokens[1]);
                        var endIndex = int.Parse(tokens[2]);
                        if(startIndex < 0 || startIndex > line.Count - 1 || endIndex < 0 || endIndex > line.Count - 1)
                        {
                            counts++;
                            throw new IndexOutOfRangeException();
                        }
                        else
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                list.Add(line[i]);

                            }
                            Console.WriteLine(string.Join(", ",list));
                            list.Clear();
                            
                        }
                        

                    }
                    if(someCommand == "Show")
                    {
                        
                        var index = int.Parse(tokens[1]);
                        if(index < 0 || index > line.Count - 1)
                        {
                            counts++;
                            throw new IndexOutOfRangeException();
                        }
                        Console.WriteLine(line[index]);
                        
                    }
                  
                 
                }
                catch (IndexOutOfRangeException)
                {

                    Console.WriteLine("The index does not exist!");


                }
                catch (Exception)
                {
                    counts++;
                    Console.WriteLine("The variable is not in the correct format!");
                }

            }
            Console.WriteLine(String.Join(", ",line));
           
        }


    }
}

