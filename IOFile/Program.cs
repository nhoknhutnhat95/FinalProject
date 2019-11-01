using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IOFile
{
    class Program
    {
        static int start, end;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            #region Nhập xuất file
            //using (StreamWriter writer = new StreamWriter("tuando.txt"))
            //{
            //    writer.Write("asdsad");
            //    Console.WriteLine("Ghi file thanh cong");
            //}
            //string line = "";
            //using (StreamReader reader = new StreamReader("tuando.txt"))
            //{
            //    while ((line=reader.ReadLine())!=null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
            #endregion
            #region Datetime
            //DateTime now = DateTime.Now;
            //Console.WriteLine(now.DayOfWeek);
            #endregion
            #region Stack Queue
#region toPostFix
            Stack<char> dau = new Stack<char>();
            Queue<String> postFix = new Queue<String>();
            String bieuThuc = "((1-2*3)-(3*2-5)/(4-3*1))";
            
            for (int i = 0; i < bieuThuc.Length; i++)
            {
                
                string temp;
                if ((int)bieuThuc[i]>=48 && (int)bieuThuc[i] <=57)
                {
                    start = i;
                    for (int j = i+1; j <= bieuThuc.Length; j++)
                    {
                        if (j== bieuThuc.Length)
                        {
                            end = j;
                            break;
                        }
                        if ((int)bieuThuc[j] < 48 || (int)bieuThuc[j] > 57)
                        {
                            end = j;
                            i = j;
                            break;
                        }
                    }  
                    temp = bieuThuc.Substring(start, end - start);
                    postFix.Enqueue(temp);
                }
                if (bieuThuc[i] == '(')
                {
                    dau.Push(bieuThuc[i]);
                    continue;
                    
                }
                if (bieuThuc[i] == '+' || bieuThuc[i] == '-' || bieuThuc[i] == '*' || bieuThuc[i] == '/')
                {
                    if (dau.Count == 0)
                    {
                        dau.Push(bieuThuc[i]);
                        continue;
                    }
                    else
                    {
                        if (uuTien(bieuThuc[i]) == uuTien(dau.Peek()))
                        {
                            dau.Pop();
                            postFix.Enqueue(bieuThuc[i].ToString());
                            continue;
                        }
                        while (uuTien(bieuThuc[i]) < uuTien(dau.Peek()))
                        {
                            postFix.Enqueue(dau.Pop().ToString());
                        }
                        dau.Push(bieuThuc[i]);
                        continue;
                    }
                }
                if (bieuThuc[i] == ')')
                {
                    while (dau.Peek() != '(')
                    {
                        postFix.Enqueue(dau.Pop().ToString());
                    }
                    dau.Pop();
                    
                }
                if (i==bieuThuc.Length-1)
                {
                    while (dau.Count!=0)
                    {
                        postFix.Enqueue(dau.Pop().ToString());
                    }
                }

            }
            #endregion
            #region Tính toán
            Stack<String> KQ = new Stack<string>();
            while (postFix.Count!=0)
            {
                if (isNumber(postFix.Peek()))
                {
                    KQ.Push(postFix.Dequeue());
                }
                else
                {
                    double so1 = Convert.ToDouble(KQ.Pop());
                    double so2 = Convert.ToDouble(KQ.Pop());
                    KQ.Push(THTT(so1, so2, postFix.Dequeue()).ToString());
                }
            }
            #endregion
            #endregion
            Console.WriteLine("Kết quả của phép toán là: {0}",KQ.Peek());
            Console.ReadKey();
        }
        private static int uuTien(char a)
        {
            switch (a)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '(':
                    return 0;
            }
            return -1;
        }
        private static bool isNumber(String input)
        {
            if (input.Length>1)
            {
                return true;
            }
            else
            {
                switch (input)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        return true;
                        break;
                }
            }
            return false;
        }
        private static double THTT(double so1,double so2,String dau)
        {
            switch (dau)
            {
                case "+":
                    return so2 + so1;
                case "-":
                    return so2 - so1;
                case "*":
                    return so2 * so1;
                case "/":
                    return so2 / so1;             
            }
            return 0;
        }

    }
}
