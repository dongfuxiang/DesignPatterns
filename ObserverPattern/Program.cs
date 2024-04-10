using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//观察者模式定义了一种一对多的依赖关系，让多个观察者对象同时监听某一个主题对象，这个主题对象在状态发生变化时，会通知所有观察者对象，使它们能够自动更新自己的行为。

//抽象主题角色（Subject）：抽象主题把所有观察者对象的引用保存在一个列表中，并提供增加和删除观察者对象的操作，抽象主题角色又叫做抽象被观察者角色，一般由抽象类或接口实现。
//抽象观察者角色（Observer）：为所有具体观察者定义一个接口，在得到主题通知时更新自己，一般由抽象类或接口实现。
//具体主题角色（ConcreteSubject）：实现抽象主题接口，具体主题角色又叫做具体被观察者角色。
//具体观察者角色（ConcreteObserver）：实现抽象观察者角色所要求的接口，以便使自身状态与主题的状态相协调。

//观察者模式有以下几个优点：

//观察者模式实现了表示层和数据逻辑层的分离，并定义了稳定的更新消息传递机制，并抽象了更新接口，使得可以有各种各样不同的表示层，即观察者。
//观察者模式在被观察者和观察者之间建立了一个抽象的耦合，被观察者并不知道任何一个具体的观察者，只是保存着抽象观察者的列表，每个具体观察者都符合一个抽象观察者的接口。
//观察者模式支持广播通信。被观察者会向所有的注册过的观察者发出通知。
//观察者也存在以下一些缺点：

//如果一个被观察者有很多直接和间接的观察者时，将所有的观察者都通知到会花费很多时间。
//虽然观察者模式可以随时使观察者知道所观察的对象发送了变化，但是观察者模式没有相应的机制使观察者知道所观察的对象是怎样发生变化的。
//如果在被观察者之间有循环依赖的话，被观察者会触发它们之间进行循环调用，导致系统崩溃，在使用观察者模式应特别注意这点。
namespace 设计模式之观察值模式
{
    // 订阅号抽象类
    public abstract class TenXun
    {
        // 保存订阅者列表
        private List<IObserver> observers = new List<IObserver>();

        public string Symbol { get; set; }
        public string Info { get; set; }
        public TenXun(string symbol, string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        #region 新增对订阅号列表的维护操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }
        #endregion

        public void Update()
        {
            // 遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.ReceiveAndPrint(this);
                }
            }
        }
    }

    // 具体订阅号类
    public class TenXunGame : TenXun
    {
        public TenXunGame(string symbol, string info)
            : base(symbol, info)
        {
        }
    }

    // 订阅者接口
    public interface IObserver
    {
        void ReceiveAndPrint(TenXun tenxun);
    }

    // 具体的订阅者类
    public class Subscriber : IObserver
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void ReceiveAndPrint(TenXun tenxun)
        {
            Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }

    // 客户端测试
    class Program
    {
        static void Main(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");

            // 添加订阅者
            tenXun.AddObserver(new Subscriber("Learning Hard"));
            tenXun.AddObserver(new Subscriber("Tom"));

            tenXun.Update();

            Console.ReadLine();
        }
    }
}
