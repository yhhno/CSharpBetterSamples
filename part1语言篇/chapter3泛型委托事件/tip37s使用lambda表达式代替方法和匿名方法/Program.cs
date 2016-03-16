using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tip37使用lambda表达式代替方法和匿名方法
{
    class Program
    {
        static void Main(string[] args)
        {
            ////part 1
            //Func<int, int, int> add = Add;
            //Action<string> print = Print;
            //print(add(1, 2).ToString());



            //实际上要完成相同的功能，还有很多中编码方式，先来看一个最中规中矩的，同时也是最繁琐的写法
            //part 2  这种语法虽然繁琐，但是我们可以从中加深度委托本质的认识，委托也是一种类型，跟任何FCL中的引用类型没有区别
            //Func<int,int,int> add=new  Func<int, int, int>(Add);
            //Action<string > print=new Action<string>(Print);
            //print(add(1, 2).ToString());

            //从part1 和part2 以上的写法注意到，Add 方法和 Print 方法实际上都只有一条语句，因此，使用匿名方法也许是一种更好的选择
            //part 3

            //Func<int,int,int> add=new Func<int, int, int>(delegate(int i, int j)
            //{
            //    return i + j;
            //});
            //Action<string> print = new Action<string>(delegate(string msg)
            //{
            //    Console.WriteLine(msg);
            //});
            //使用匿名方法后，我们以后不需要在Main 方法外部声明两个方法了，可以直接在Main这个工作方法中完成所有的代码编写，而且不会影响代码清晰性，实际上，所有的代码行数不超过3行的方法（条件是它不被重用）。我们都建议采用这种方式来编写。
            //part 3 改进版

            //Func<int, int, int> add = delegate(int i, int j)
            //{
            //    return i + j;
            //};

            //Action<string> print = delegate(string msg)
            //{
            //    Console.WriteLine(msg);
            //};

            //以上的代码看上去更简化了， 不过最终级的改进是使用Lambda表达式
            Func<int, int, int> add = (i, j) =>
            {
                return i + j;
            };
            Func<int, int, int> addbetter = (i, j) => i + j;

            Action<string> print = (msg) =>
            {
                Console.WriteLine(msg);
            };
            print(add(1, 2).ToString());

            //Lambda表达式操作符“=>”的左侧是方法的参数，右侧是方法体，其本质是匿名方法。实际上，经过编译后的Lambda表达式就是一个匿名方法。我们应该在实际的编码中熟练运用它，避免写出繁琐且不美观的代码；

            //下面以List<T>的Find 方法为例，让我们感受下Lambda 表达式在简化代码上的威力：



        }


        //第一种方法 
        public Student Test1()
        {
            List<Student> lists = new List<Student> {new Student {Name = "test"}};
            string name = "test";

            return lists.Find(new Predicate<Student>(delegate(Student target)
            {
                if (target.Name == name) return true;
                else return false;
            }));
        }

        //第二种方法
        public Student Test2()
        {
            List<Student> lists = new List<Student> {new Student {Name = "test"}};
            string name = "test";
            return lists.Find(new Predicate<Student>((target) =>
            {
                if (target.Name == name) return true;
                else return false;
            }));
        }

        //第三种方法

        public Student Test3()
        {
            List<Student> lists = new List<Student> { new Student { Name = "test" } };
            string name = "test";
            return lists.Find((target) =>
            {
                if (target.Name == name) return true;
                else return false;
            });
        }

        //第四种方法
        public Student Test4()
        {
            List<Student> lists = new List<Student> { new Student { Name = "test" } };
            string name = "test";
            return lists.Find(target => target.Name == name);
        }


        public class Student
        {
            public string Name { get; set; }
        }



    public static int Add(int i, int j)
        {
            return i + j;
        }

        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
}
}
