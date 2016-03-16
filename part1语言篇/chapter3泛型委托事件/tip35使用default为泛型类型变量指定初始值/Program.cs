using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip35使用default为泛型类型变量指定初始值
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        //有些算法，比如泛型集合List<T>的Find算法，所查询的对象有可能是值类型，也有可能是引用类型，在这种算法内部，我们常常会为这些值类型变量或者引用类型变量指定默认值，问题来了：之类型变量的默认初始值是0值，而引用类型变量的默认初始值是null值，

         //C#编译器会阻止这样的代码通过编译。一个泛型类型参数指定一个初始值，最妥当的办法是default关键字。
         //这样，如果它在运行时碰到的T是一个整型，那么运行时会为其赋值为0， 如果T在运行时是一个person这样的引用类型，则为其赋为null值
         //在FCL中的泛型类型，很多地方用到了default关键字。。

        //public T Find(Predicate<T> match)
        //{
        //    if(match==null)
        //    { ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match)}
        //    for (int i = 0; i < this._size; i++)
        //    {
        //        if (match(this._items[i]))
        //        {
        //            return this._items[i];
        //        }
        //    }
        //    return default(T);
        //}

        public T Func<T>()
        {
            //T t = null; //Cannot convert null to type parameter 'T' because it could be a non-nullable value type. Consider using 'default(T)'//不能将NUll 转换为类型形参T，因为它可能是不可以为null 的值类型，请考虑使用 default(T); 

            //T t = 0;// Cannot implicitly convert type 'int' to 'T'  无法将类型 int 隐式 转换为 T

            T t = default(T);

            return t;
        }
    }
}
