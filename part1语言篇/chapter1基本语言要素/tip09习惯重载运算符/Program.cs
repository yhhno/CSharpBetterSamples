using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip09习惯重载运算符
{
    class Program
    {
        static void Main(string[] args)
        {
            Salary s1=new Salary() {RMB=100};
            Salary s2 = new Salary() {RMB = 33};
            Salary total = s1 + s2;
            Console.WriteLine("哈哈 可以相加了");
        }
        //在开发过程中，应该习惯于使用微软提供给我们的语法特性，我想每个人都希望看到这样的语法特性。
                //int x = 1;
                //int y = 1;
                //int total = x + y;
        //而不是用下面的语法来完成一样的事情。
                //int xx = 1;
                //int yy = 2;
                //int totals = int.Add(xx, yy);

        //同理，在构建自己的类型时，我们应该始终考虑该类型是否可以用于运算符重载。如果考虑类型Salary，下面的这段代码看起来就不舒服

                //Salary mikeIncome = new Salary() {RMB = 22};
                //Salary roseIncome=new Salary() {RMB=33};
                //Salary familyIncome = new Salary.Add(mikeIncome, roseIncome);
        
        //应该使类型支持：
                //Salary familyIncome = mikeIncome + roseIncome;

        //后者读起来一目了然，CLR支持在类型中，通过使用operator关键字定义静态成员函数来重载运算符，让开发人员可以像使用内置元类型一样使用该类型。
        //Salary重载“+”运算符 如下

        public class Salary
        {
            public int RMB { get; set; }

            public static Salary operator +(Salary s1, Salary s2)
            {
                s2.RMB += s1.RMB;
                return s2;
            }
        }

    }
}
