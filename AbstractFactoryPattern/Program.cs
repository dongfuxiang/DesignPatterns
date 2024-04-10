using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//工厂方法模式是为了克服简单工厂模式的缺点而设计出来的, 
//简单工厂模式的工厂类随着产品类的增加需要增加额外的代码），
//而工厂方法模式每个具体工厂类只完成单个实例的创建,
//所以它具有很好的可扩展性。但是在现实生活中，
//一个工厂只创建单个产品这样的例子很少，因为现在的工厂都多元化了，
//一个工厂创建一系列的产品，如果我们要设计这样的系统时，
//工厂方法模式显然在这里不适用，然后抽象工厂模式却可以很好地解决一系列产品创建的问题

//抽象工厂模式将具体产品的创建延迟到具体工厂的子类中，
//这样将对象的创建封装起来，可以减少客户端与具体产品类之间的依赖，
//从而使系统耦合度低，这样更有利于后期的维护和扩展，这真是抽象工厂模式的优点所在
//，然后抽象模式同时也存在不足的地方。下面就具体看下抽象工厂的缺点（缺点其实在前面的介绍中以已经涉及了）：

//抽象工厂模式很难支持新种类产品的变化。
//这是因为抽象工厂接口中已经确定了可以被创建的产品集合，
//如果需要添加新产品，此时就必须去修改抽象工厂的接口，
//这样就涉及到抽象工厂类的以及所有子类的改变，这样也就违背了“开发——封闭”原则。


namespace 设计模式之抽象工厂模式
{
    /// <summary>
    /// 下面以绝味鸭脖连锁店为例子演示下抽象工厂模式
    /// 因为每个地方的喜欢的口味不一样，有些地方喜欢辣点的，有些地方喜欢吃不辣点
    /// 客户端调用
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // 南昌工厂制作南昌的鸭脖和鸭架
            AbstractFactory nanChangFactory = new NanChangFactory();
            YaBo nanChangYabo = nanChangFactory.CreateYaBo();
            nanChangYabo.Print();
            YaJia nanChangYajia = nanChangFactory.CreateYaJia();
            nanChangYajia.Print();

            // 上海工厂制作上海的鸭脖和鸭架
            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            shangHaiFactory.CreateYaBo().Print();
            shangHaiFactory.CreateYaJia().Print();

            Console.Read();
        }
    }

    /// <summary>
    /// 抽象工厂类，提供创建两个不同地方的鸭架和鸭脖的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        // 抽象工厂提供创建一系列产品的接口，这里作为例子，只给出了绝味中鸭脖和鸭架的创建接口
        public abstract YaBo CreateYaBo();
        public abstract YaJia CreateYaJia();
    }

    /// <summary>
    /// 南昌绝味工厂负责制作南昌的鸭脖和鸭架
    /// </summary>
    public class NanChangFactory : AbstractFactory
    {
        // 制作南昌鸭脖
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }
        // 制作南昌鸭架
        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }

    /// <summary>
    /// 上海绝味工厂负责制作上海的鸭脖和鸭架
    /// </summary>
    public class ShangHaiFactory : AbstractFactory
    {
        // 制作上海鸭脖
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }
        // 制作上海鸭架
        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();
        }
    }

    /// <summary>
    /// 鸭脖抽象类，供每个地方的鸭脖类继承
    /// </summary>
    public abstract class YaBo
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 鸭架抽象类，供每个地方的鸭架类继承
    /// </summary>
    public abstract class YaJia
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 南昌的鸭脖类，因为江西人喜欢吃辣的，所以南昌的鸭脖稍微会比上海做的辣
    /// </summary>
    public class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭脖");
        }
    }

    /// <summary>
    /// 上海的鸭脖没有南昌的鸭脖做的辣
    /// </summary>
    public class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭脖");
        }
    }

    /// <summary>
    /// 南昌的鸭架
    /// </summary>
    public class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭架子");
        }
    }

    /// <summary>
    /// 上海的鸭架
    /// </summary>
    public class ShangHaiYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭架子");
        }
    }
}
