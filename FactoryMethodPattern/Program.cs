using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设计模式之工厂方法模式;

//工厂方法模式之所以可以解决简单工厂的模式，
//是因为它的实现把具体产品的创建推迟到子类中，
//此时工厂类不再负责所有产品的创建，
//而只是给出具体工厂必须实现的接口，
//这样工厂方法模式就可以允许系统不修改工厂类逻辑的情况下来添加新产品，
//这样也就克服了简单工厂模式中缺点。

//使用工厂方法实现的系统，如果系统需要添加新产品时，
//我们可以利用多态性来完成系统的扩展，
//对于抽象工厂类和具体工厂中的代码都不需要做任何改动。
//例如，我们我们还想点一个“肉末茄子”，
//此时我们只需要定义一个肉末茄子具体工厂类和肉末茄子类就可以，
//很好的符合了开闭原则（对扩展开放，对修改封闭）

//Creator类：充当抽象工厂角色，任何具体工厂都必须继承该抽象类

//TomatoScrambledEggsFactory和ShreddedPorkWithPotatoesFactory类：充当具体工厂角色，用来创建具体产品

//Food类：充当抽象产品角色，具体产品的抽象类。任何具体产品都应该继承该类

//TomatoScrambledEggs和ShreddedPorkWithPotatoes类：充当具体产品角色，实现抽象产品类对定义的抽象方法，由具体工厂类创建，它们之间有一一对应的关系。
namespace 设计模式之工厂方法模式
{
    /// <summary>
    /// 菜抽象类
    /// </summary>
    public abstract class Food
    {
        //输出点了什么菜
        public abstract void Print();
    }


    /// <summary>
    /// 西红柿炒鸡蛋这道菜
    /// </summary>
    public class TomatoScrambledEggs : Food
    {
        public override void Print()
        {
            Console.WriteLine("西红柿炒鸡蛋好了！");
        }
    }


    /// <summary>
    /// 土豆肉丝这道菜
    /// </summary>
    public class ShreddedPorkWithPotatoes : Food
    {
        public override void Print()
        {
            Console.WriteLine("土豆肉丝好了！");
        }
    }


    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Creator
    {
        //工厂方法
        public abstract Food CreateFoddFactory();
    }

    /// <summary>
    /// 西红柿炒蛋工厂类
    /// </summary>
    public class TomatoScrambledEggsFactory : Creator
    {
        /// <summary>
        /// 负责创建西红柿炒蛋这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new TomatoScrambledEggs();
        }
    }


    /// <summary>
    /// 土豆肉丝工厂类
    /// </summary>
    public class ShreddedPorkWithPotatoesFactory : Creator
    {
        /// <summary>
        /// 负责创建土豆肉丝这道菜
        /// </summary>
        /// <returns></returns>
        public override Food CreateFoddFactory()
        {
            return new ShreddedPorkWithPotatoes();
        }
    }


    /// <summary>
    /// 客户端调用
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // 初始化做菜的两个工厂（）
            Creator shreddedPorkWithPotatoesFactory = new ShreddedPorkWithPotatoesFactory();
            Creator tomatoScrambledEggsFactory = new TomatoScrambledEggsFactory();

            // 开始做西红柿炒蛋
            Food tomatoScrambleEggs = tomatoScrambledEggsFactory.CreateFoddFactory();
            tomatoScrambleEggs.Print();

            //开始做土豆肉丝
            Food shreddedPorkWithPotatoes = shreddedPorkWithPotatoesFactory.CreateFoddFactory();
            shreddedPorkWithPotatoes.Print();

            Console.Read();
        }
    }
}
