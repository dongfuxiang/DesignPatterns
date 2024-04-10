using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//模板方法模式——在一个抽象类中定义一个操作中的算法骨架（对应于生活中的大家下载的模板），而将一些步骤延迟到子类中去实现
//把相同的部分抽象出来到抽象类中去定义，具体子类来实现具体的不同部分，这个思路也正式模板方法的实现精髓所在

//抽象模板角色（Vegetable扮演这个角色）：定义了一个或多个抽象操作，以便让子类实现，这些抽象操作称为基本操作。
//具体模板角色（ChineseCabbage和Spinach扮演这个角色）：实现父类所定义的一个或多个抽象方法。

//优点：

//实现了代码复用
//能够灵活应对子步骤的变化，符合开放-封闭原则
//缺点：
//    因为引入了一个抽象类，如果具体实现过多的话，需要用户或开发人员需要花更多的时间去理清类之间的关系。
namespace 设计模式之模板方法
{
    // 客户端调用
    class Client
    {
        static void Main(string[] args)
        {
            // 创建一个菠菜实例并调用模板方法
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
            Console.Read();
        }
    }

    public abstract class Vegetabel
    {
        // 模板方法，不要把模版方法定义为Virtual或abstract方法，避免被子类重写，防止更改流程的执行顺序
        public void CookVegetabel()
        {
            Console.WriteLine("抄蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetable();
            this.stir_fry();
        }

        // 第一步倒油
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }

        // 把油烧热
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }

        // 油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
        public abstract void pourVegetable();

        // 开发翻炒蔬菜
        public void stir_fry()
        {
            Console.WriteLine("翻炒");
        }
    }

    // 菠菜
    public class Spinach : Vegetabel
    {

        public override void pourVegetable()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }

    // 大白菜
    public class ChineseCabbage : Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }
}
