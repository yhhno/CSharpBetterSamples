using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip38小心闭包里陷阱
{
    class Program
    {
        static void Main(string[] args)
        {

            //part1.1 介绍闭包的陷阱之前， 先看下面的代码 ，看下输出是什么

            //我们的设计意图是让匿名方法（在这里变现为Lambda表达式）。接收参数i，并输出

            //这段代码并不想我们想象的那样简单，要完全理解运行时代码是怎么运行的，首先要理解C#编译器为我们做了什么。查看IL
                    //List<Action> lists = new List<Action>();
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Action t = () =>
                    //    {
                    //        Console.WriteLine(i.ToString());
                    //    };
                    //    lists.Add(t);
                    //}

                    //foreach (var t in lists)
                    //{
                    //    t();
                    //}

            // part 1.2  避免闭包 等于

                    //List<Action> lists = new List<Action>();
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    int temp = i;
                    //    Action t = () =>
                    //    {
                    //        Console.WriteLine(temp.ToString());
                   
                    //    };
                    //    lists.Add(t);
                    //}

                    //foreach (var action in lists)
                    //{
                    //    action();
                    //}

            //part2.1  等同 part 1.1
            //这段代码所演示的就是闭包对象。所谓闭包对象，指的是下面的TempClass对象（也就是编译器为我生成的“<>c_DisplayClss2”对象）。如果匿名方法(Lambda表达式)引用了某个局部变量，编译器就会自动将该引用提升到该闭包对象中，既将for循环中的变量i修改成了引用闭包对象的公共变量i。这样一来，即使代码执行后离开了原局部变量i的作用域（如for循环），包含该闭包对象的作用域也还存在，理解这一点，就能理解代码的输出了
            //List<Action> lists = new List<Action>();
            //TempClass tempclass = new TempClass();
            //for (tempclass.i = 0; tempclass.i < 5; tempclass.i++)
            //{
            //    Action t = tempclass.TempFunc;
            //    lists.Add(t);
            //}
            //foreach (var t in lists)
            //{
            //    t();
            //}


            //part 2.2  等同于1.2
            List<Action> lists = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                TempClass tempclass = new TempClass();
                tempclass.i = i;
                Action t = tempclass.TempFunc;
                lists.Add(t);
            }
            foreach (var t in lists)
            {
                t();
            }


        }

        //part1 等同 部分

        public  class TempClass
        {
            public int i;

            public void TempFunc()
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}
