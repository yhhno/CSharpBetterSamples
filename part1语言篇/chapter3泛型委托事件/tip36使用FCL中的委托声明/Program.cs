using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace tip36使用FCL中的委托声明
{
    class Program
    {
        static void Main(string[] args)
        {

            //part1 下面的委托声明AddHandler和PrintHandler 完全是可以被Func和Action取代的
                    //AddHandler add = Add;
                    //PrintHandler print = Print;
                    //print(add(1, 2).ToString());

            //part2  Func 和Action 替代版本

                    //Func<int, int, int> add = Add;
                    //Action<string> print = Print;
                    //print(add(1, 2).ToString());

            //part 3
            //我们应该习惯在代码中使用这类委托来代替自己的委托声明。
         

      


        }

        //除了Action、Func、和Predicate外，FCL 中还有用于表示特殊含义的委托声明。

        // part 4 如用于表示注册事件方法的委托声明
        public delegate void EventHandler(object sender, EventArgs e);

        public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);

        //part 5 表示线程方法的委托方法
        public delegate void ThreadStart();

        public delegate void ParameterizedThreadStart(object obj);

        //part 6 表示异步回调的委托声明
        public delegate void AsyncCallback(IAsyncResult ar);

        //part 7
        // 在fcl中每一类委托声明都代表一类特殊的用途，虽然可以使用自己的委托声明来代替，，但是这样做不仅没有必要，而且会让代码失去简洁性和标准性，在我们实现自己的委托声明前，应该首先查看MSDN，确信有必要之后才这样做、
        



         
        //要注意fcl中存在三类这样的委托声明，分别为Action、Func、Predicate。尤其是它们的泛型版本出来后，已经能满足我们在实际编码中的大部分需要。
        //下面是这三种委托的简要描述
        //Action 表示接受0个或者多个输入参数，执行一段代码，没有任何返回值；
        //Func表示接受0个或者多个输入参数，执行一段代码，带有返回值；
        //Predicate 表示定义一组条件并判断参数是否符合条件  返回bool值
        //Action和 Func 有17个重载版本。很少有方法的参数能够超过16个，如果真有这样的参数，我们首先需要考虑是否自家的设计有问题，另外我们也可以使用params关键字来减少参数的声明。 如static void Method1(params int[] i);



        delegate int AddHandler(int i, int j);

        delegate void PrintHandler(string msg);

        static int Add(int i, int j)
        {
            return i + j;
        }

        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
