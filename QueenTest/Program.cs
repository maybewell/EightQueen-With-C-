using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenTest
{
    internal class Program
    {
        public static int _queenLot = 8;
        public static int[] PositionArray = new int[_queenLot];
        public static int _answer = 0;

        private static void Main(string[] args)
        {
            Check(0);

            Console.WriteLine($"共{ _answer}種解法");
            Console.Read();
        }

        private static void Check(int _queenNumber)//初始傳進0，代表從第一個皇后開始
        {
            if (_queenNumber == 8)
            {
                Print();
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                PositionArray[_queenNumber] = i;//i初始為0，代表將當下傳進的皇后從第一列開始放

                if (collision(_queenNumber))//若檢測到沒有衝突，則將下一位皇后傳進check，進行遞迴
                {
                    Check(_queenNumber + 1);
                }
            }
        }

        private static bool collision(int _queenNumber)//將當下傳進來的皇后檢查是否跟其它皇后位置衝突
        {
            for (int i = 0; i < _queenNumber; i++)
            {
                if (PositionArray[i] == PositionArray[_queenNumber] || Math.Abs(_queenNumber - i) == Math.Abs(PositionArray[_queenNumber] - PositionArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Print()
        {
            _answer++;
            string[] positionForPrint;
            Console.WriteLine($"//第{_answer}種解法//");

            foreach (var item in PositionArray)
            {
                positionForPrint = new string[8] { ".", ".", ".", ".", ".", ".", ".", "." };
                positionForPrint[item] = "Q";
                Console.Write(string.Join("", positionForPrint));
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}