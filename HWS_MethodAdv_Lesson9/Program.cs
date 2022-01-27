using System;

namespace HWS_Method_Adv_Lesson9
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Qst 1 REF-OUT
            string errorMessage;
            string s = "";
            string ss = s;
            ss = "value is empty";
            if (!TryDoWork(out errorMessage))
                Console.WriteLine(errorMessage);
            int x = 5;
            Foo(ref x);
            Goo(out x);
            Console.WriteLine(x);

            #endregion

            #region Qst 4 REF-OUT


            string error;
            if (!ValidateValues("meir", "sadon", "0543", "20214012313", 45, out error))
            {
                Console.WriteLine(error);
            }
            if (!ValidateValues("meir", "sadon", "05439218734", "202140123", 45, out error))
            {
                Console.WriteLine(error);
            }
            #endregion

            #region Qst 2 optional parameters

            int x1 = MultipleNumbers(3, 3, 3);//Optional Arguments
            int x2 = MultipleNumbers(3, 2);//Optional Arguments
            int x3 = MultipleNumbers(4);//Optional Arguments
            int x4 = MultipleNumbers(n3: 4, n1: 7);//Named Arguments With Optional Arguments


            #endregion

            #region Qst 4 in keyword

            MultipleBy3(4);

            #endregion

        }

        public static int MultipleNumbers(int n1, int n2 = 1, int n3 = -1)
        {
            return n1 * n2 * n3;
        }

        #region Qst 4 in keyword
        public static void Doo(in Test test)
        {
            test.age = 5;
            //test = new Test();
        }

        public static int MultipleBy3(in int num)
        {
            return num * 3;
        }
        #endregion

        public static bool ValidateValues(string fName, string lName, string phone, string id, int age, out string errorMessage)
        {
            errorMessage = "";
            if (string.IsNullOrEmpty(fName) || string.IsNullOrEmpty(lName))
            {
                errorMessage = "first name or last name is empty";
            }
            if (phone[0] != '0' || phone.Length < 9)
            {
                errorMessage += "\nphone is not valid";
            }
            if (id.Length != 9)
            {
                errorMessage += "\nid is not valid";
            }
            if (age < 1 || age > 100)
            {
                errorMessage += "\nage is not valid";
            }

            return string.IsNullOrEmpty(errorMessage);
        }

        static bool TryDoWork(out string errorMessage)
        {
            errorMessage = "value is empty";
            return false;
        }
        static void Foo(ref int x)
        {
            x++;
        }

        static void Goo(out int x)
        {
            x = 10;
            int y = 10;
        }
    }
    class Test
    {
        public int age;
    }
}
