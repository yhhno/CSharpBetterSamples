using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tip39了解委托的实质
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder ss = new StringBuilder();
            //ss.Append("手机,电脑,");
            //Console.WriteLine(ss);
            //ss.Remove(ss.Length-1 , 1);
            //Console.WriteLine(ss);
            //Console.ReadKey();
        }
        //理解C#中的委托把握两个要点： 1委托是方法指针。2委托是一个类，当对其进行实例化的时候，要将引用方法作为它的构造方法的参数
        //基于第一点，设想这样的一个场景：在点对点的文件传输过程中，我们设计一个文件传输类，该文件传输类起码要满足下面几项功能  
        //1：传输文件
        //2：按照百分制通知传输进度
        //3:文件传输类能够同时被控制台应用程序和winform应用--程序使用
        //我们知道，由于要让通知本身能被控制台应用程序和winform应用程序使用，因此我们在设计这个文件传输类在进行进度通知的时候，就不能显性地调用：
        //Console.WriteLine("当前进度: "+fileProgress); 或者


    }
}
