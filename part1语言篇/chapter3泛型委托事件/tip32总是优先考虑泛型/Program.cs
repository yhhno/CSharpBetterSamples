using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip32总是优先考虑泛型
{

    class Program
    {
        static void Main(string[] args)
        {
        }

     //Generic泛型：泛型的优点是多方面的，无论是泛型类还是泛型方法都同时具备可重用性、类型安全和高效率等特性，这都是非泛型类和非泛型方法无法具备的，本建议将从可重用性、类型安全和高效率三个方面来阐述：为什么在实际的编码中为何总是优先考虑泛型。


       //1以可重用性为例，比如说要设计一个集合类

        //int类型集合
        public class MyList
        {
            int[] items;

            //集合索引
            public int this[int i]
            {
                get { return items[i]; }
                set { this.items[i] = value; }
            }
            public int Count
            {
                get { return items.Length; }
            }
            
            //省略其他方法
        }

        //1.1 此时  该类型只支持整形，如果要让类型支持字符串，有一个方法就是重新设计一个集合类，但是这两个类型的属性和方法都是非常接近的，如果有一个方法可以让类型接收一个通用的数据类型，这样就可以进行代码复用了，同时类型也只要一个就够了。不用写多个，造成代码冗余。----泛型就可以完成。

        //泛型集合类
        public class MyList<T>
        {
            T[] items;
            //集合索引
            public T this[int i]
            {
                get { return items[i]; }
                set { this.items[i] = value; }
            }

           public int Count
            {
                get { return items.Length; }
            }

            //省略其他方法
        }

        //1.2 可以把T理解为一个占位符，在c#泛型编译生成的IL代码中，T就是一个占位符的角色。在运行时，即时编译器(JIT)会用实际代码中输入的T来代替T，也就是说，在由JIT生成的本地代码中，已经使用了实际的数据类型。我们可以把MyList<int>和MyList<string> 视为两个完全不同的类型。但是，这仅是对本地代码而言的，对于实际的C#代码，它仅仅拥有一个类型，那就是泛型类型MyList<T>




        //1.3 以上从代码重用性的角度论证了泛型的优点。继续从类型MyList<T>的角度论述，如果不用泛型来实现代码复用，另一种方法是让MyList的编码从object的角度去设计。在C#的世界中，所有类型（包括值类型和引用类型）都是继承自object，如果要让MyList足够通用，就需要Mylist针对object编码

        public class MyListObject
        {
           object[] items;
            public object this[int i]
            {
                get { return items[i]; }
                set { this.items[i] = value; }
            }
            
            public int Count
            {
                get { return items.Length; }
            }
            //省略其他方法


           
        }




        /***1.4  这会让下面的代码编译通过： list[0]=123;  list[1="123";
        *上面两行代码带来的问题就是非“类型安全性”。
        *让类型支持类型安全，可以让程序在编译期间就过滤部分bug，同时也能让代码规避“转型为object类型”或者
        *“从object转型为实际类型”所带来的效率损耗，尤其是设计的操作类型是值类型，还会带来装箱和拆箱的性能损耗
        *上面的list[0]=123; 就是一次装箱操作，因为它首先被转型为object，继而存储在items这个object数组中
        *
        ******************************************************************************/

    }
}
