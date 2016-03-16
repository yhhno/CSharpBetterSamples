using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip33避免在泛型类型中声明静态成员
{
    class Program
    {
        static void Main(string[] args)
        {
            //在上个建议中，已经解释了应该将MyList<int>和MyList<string>视为两个不同的类型，所以不能讲MyList<T>中的静态成员理解为MyList<int>和MyList<string>共有的成员。

            ////对于一个非泛型类型
            //MyList list1 = new MyList();
            //MyList list2 = new MyList();
            //Console.WriteLine(MyList.Count);//Count为MyList属性


            //对于一个泛型类型
            //MyGenericList<int> genericlist1 = new MyGenericList<int>();
            //MyGenericList<int> genericlist2 = new MyGenericList<int>();
            //MyGenericList<string> genericlist3 = new MyGenericList<string>();
            //Console.WriteLine(MyGenericList<int>.Count);
            //Console.WriteLine(MyGenericList<string>.Count);

            //s实际上，随着你为T制定不同的数据类型，MyList<T>相应地也变成不同的数据类型，在他们之间是不共享静态成员
            //不过，我们从上文也察觉到了，若T所指定的数据类型是一致的，那么两个泛型对象间还是可以共享静态成员的，如上文中的list1和list2.但是为了规避因此而引起的混淆，仍然建议在实际的编码工作中，尽量避免声明泛型类型的静态成员。

            //上面的例子是基于泛型类型的，非泛型类型中静态泛型方法看起来很接近该例子，但是应该始终这样来理解
            //非泛型类型中的泛型方法并不会在运行时的本地代码中生成不同的类型

            //对于一个非泛型类型的泛型方法
            Console.WriteLine(Mylist2.Test<int>());
            Console.WriteLine(Mylist2.Test<int>());
            Console.WriteLine(Mylist2.Test<string>());

        }

        #region  非泛型集合
       public class MyList
        {
            private int Id = 1;
            public static int Count { get; set; }//静态属性
            public MyList()
            {
                Count++;
            }
        }
        #endregion



        #region 泛型集合
        public class MyGenericList<T>
        {
            public static int Count { get; set; }//静态属性
            public MyGenericList()
            {
                Count++;
            }
        }

        #endregion

        #region 非泛型类型中的泛型方法
        public class Mylist2
        {
            static int count;
            public static int Test<T>()
            {
                return count++;
            }
        }
        #endregion

    }
}
