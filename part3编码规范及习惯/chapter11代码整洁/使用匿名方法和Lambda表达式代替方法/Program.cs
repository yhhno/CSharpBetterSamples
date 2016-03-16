using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip150使用匿名方法和Lambda表达式代替方法
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        //方法体如果过小 （如果小于3行），专门为此定义一个方法就显得过于繁琐
        //比如 part1
        static void SampleMethod()
        {
            List<string> list = new List<string>() {"Mike", "Rose", "Steve"};
            var mike = list.Find(new Predicate<string>(HaveLengthFive));
            Console.WriteLine(mike);
        }

        static bool HaveLengthFive(string value)
        {
            return value.Length == 5;
        }

        //part1 的代码中，SampleMethod方法需要完成的功能是查看list有没有长度等于5的元素，Predicate是一个委托，它接收元素值，并返回 元素是否符合要求 这一结果。真正的工作代码只有1行，决定繁琐？就重构吧。

        //part2
        static void SampleMethod2()
        {
            List<string> list = new List<string>() { "Mike", "Rose", "Steve" };
            var mike = list.Find(delegate(string value)
            {
                return value.Length == 5;
            });
            Console.WriteLine(mike);
        }
        // 由delegate引领的语句就是一个匿名方法。其次匿名方法经过编译器编译之后，就和普通方法没有任何区别。匿名方法带来的知识简化了程序员的部分工作而已。
        //不过我们还有更好的方法简化匿名方法。就是Lambda表达式。Lambda表达式由符号“=>”连接，符号左边是参数列表。右边是方法体。Lambda表达式更进一步简化了匿名方法的语法。
        //以下是Lambda表达式版本

        //part 3  Lambda表达式

        static void SampleMethod3()
        {
            List<string> list = new List<string>() { "Mike", "Rose", "Steve" };
          
            var mike = list.Find((value) =>
            {
                return value.Length == 5;
            });

            //更简化版本
            //var mike = list.Find((value) => value.Length == 5);
        }
    }
}
