using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip34_为泛型参数设定约束
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        //1.约束这个词可能会引起歧义，有些人可能认为对泛型参数设定约束是限制参数的使用，实际情况正好相反，
        //没有约束的泛型参数作用很有限，到是“约束”让泛型参数具有更多的行为和属性

        //2.Compare方法：查看下面的代码，我们会发现参数t1或参数t2仅仅具有object的属性和行为，所有在几乎不能在方法中对它们做任何的操作
        //3.Compare2方法：但是，在加了约束之后，我们会发现参数t1和t2变成了一个有用的对象，由于为其制定了对应的类型，t1和t2现在就是一个Salary，在方法的内部，它拥有了属性BaseSalary和Bonus

        public class SalaryComputer
        {
            public int Compare<T>(T t1,T t2)
            {
                return 0;
            }

            public int Compare2<T>(T t1, T t2) where T :salary
            {
                if (t1.Basesalary > t2.Basesalary)
                    return 1;
                else if (t1.Basesalary == t2.Basesalary)
                    return 0;
                else
                    return -1;
            }
        }
        public class salary
        {
            public int Basesalary { get; set; }
            public  int Bonus { get; set; }
        }


        //4. 那么可以为泛型参数指定那些约束呢： 
        //4.1 指定的参数是值类型（除Nullable） 可以有如下形式
        public void Method1<T>(T t) where T :struct
        {

        }

        //4.2 指定参数是引用类型，可以有如下形式，注意object不能作为约束
        public void Method2<T>(T t) where T : class
        {

        }
        public  void Method3<T>(T t)where T : salary
        {

        }
        //4.3 指定的参数具有无参数的公共构造方法，可以有如下形式
        public void Method4<T>(T t) where T : new()
        {

        }
        //注意，CLR目前只支持无参构造方法约束
        //4.4 指定参数必须是指定的基类，或者派生自指定的基类。
        //4.5 指定参数必须是指定的接口，或者实现指定的接口。
        //4.6 指定T提供的类型参数必须是为U提供的参数，或者派生自为U提供的参数。
        class Sample<U>
        {
            public void Method1<T> (T t) where T : U
            {

            }
        }
        //4.7 可以对同一类型的参数应用，多个约束，并且约束自身可以是泛型类型

    }
}
