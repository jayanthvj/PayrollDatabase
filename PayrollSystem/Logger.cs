using System;
using System.IO;

namespace PayrollSystem
{
    class MyException : Exception
        {
            public MyException(string Message) : base(Message)
            {
            }
        }
        class FileLogger
        {
            public static bool Writing(string message)
            {
                try
                {
                    StreamWriter Object = new StreamWriter(@"C:\Users\Public\Documents\Readfile.txt");
                    Object.WriteLine(message);
                    Object.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Error Message : " + e.Message);
                    return false;
                }
            }
        }
    }

