using System;
using System.Collections.Generic;

namespace Задача_1
{
    public class Gives
    {
        public static string[,] ReadGives(int givesArgs)
        {
            string[,] gives = new string[givesArgs * 2, 2];

            for (int i = 0; i < givesArgs; i+=2)
            {
                Console.WriteLine("Введите название переменной(рецессивной)");
                gives[i, 0] = Console.ReadLine();
                gives[i + 1, 0] = gives[i, 0].ToLower(); 
                Console.WriteLine("Введите описание");
                gives[i, 1] = Console.ReadLine();
                gives[i + 1, 1] = "Отсутствие " + gives[i, 1].ToLower();
            }

            return gives;
        }

        public static void WriteGives(string[,] gives)
        {
            for (int i = 0; i < gives.GetLength(0); i++)
            {
                Console.Write(gives[i, 0]);
                Console.Write(" - " + gives[i, 1] + "\n");
            }
        }
    }

    public class P
    {
        public static List<char> ReadP()
        {
            string p = Console.ReadLine();

            char[] charP = p.ToCharArray();
            List<char> listChar = new List<char>(charP.Length);

            foreach (char lc in charP)
            {
                listChar.Add(lc);
            }

            return listChar;
        }

        public static void WriteP(List<char> par)
        {
            foreach (char p in par)
                Console.Write(p);
        }

        public List<char> Mom { get; set; }
        public List<char> Dad { get; set; }
    }

    public class G
    {
        public static List<List<char>> CheckG(List<char> listParents)
        {
            List<List<char>> result = new List<List<char>>();
            List<List<char>> variablesHaveBeen = new List<List<char>>();

            static bool CheckVariables(ref List<List<char>> variablesHaveBeen, List<char> args)
            {
                bool flag = false;

                foreach (List<char> subList in variablesHaveBeen)
                {
                    for (int i = 0; i < subList.Count; i++)
                    {
                        if (i == subList.Count - 1)
                        {                            
                            char temp = subList[0];
                            for (int j = 1; j < subList.Count; j++)
                            {
                                if (temp == subList[i - 1])
                                {
                                    flag = true;
                                    temp = subList[i];
                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                        }                        
                    }                    
                }

                if (!flag)
                    variablesHaveBeen.Add(new List<char>(args));                    

                return flag;
            }
            
            foreach (char lp in listParents)
            {
                foreach (char lp1 in listParents)
                {
                    List<char> args = new List<char>
                    {
                        lp,
                        lp1
                    };

                    if (lp != lp1 && CheckVariables(ref variablesHaveBeen, args))
                    {
                        result.Add(new List<char>(args));
                    }
                }
            }
            

            return result;
        }

        public static void WriteG(List<List<char>> listParents)
        {
            foreach (List<char> subList in listParents)
            {
                foreach (char item in subList)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        public List<List<char>> MomInG { get; set; }
        public List<List<char>> DadInG { get; set; }
    }

    public class F
    {
        public string[,] MatrixF { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите количество аргументов");
            //int givesArgs = int.Parse(Console.ReadLine());
            //
            //string[,] gives = Gives.ReadGives(givesArgs);
            //Console.Clear();
            //Gives.WriteGives(gives);

            P p = new P
            {
                Mom = P.ReadP()/*,
                Dad = P.ReadP()*/
            };

            Console.WriteLine();
            //P.WriteP(p.Dad);

            G g = new G
            {
                MomInG = G.CheckG(p.Mom)/*,
                DadInG = G.CheckG(p.Dad)*/
            };

            G.WriteG(g.MomInG);
            //G.WriteG(g.DadInG);
        }
    }
}