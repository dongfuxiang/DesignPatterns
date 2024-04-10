using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//代理模式——就是给某一个对象提供一个代理，并由代理对象控制对原对象的引用。

//抽象主题角色（Person）：声明了真实主题和代理主题的公共接口，这样一来在使用真实主题的任何地方都可以使用代理主题。
//代理主题角色（Friend）：代理主题角色内部含有对真实主题的引用，从而可以操作真实主题对象；代理主题角色负责在需要的时候创建真实主题对象；代理角色通常在将客户端调用传递到真实主题之前或之后，都要执行一些其他的操作，而不是单纯地将调用传递给真实主题对象。例如这里的PreBuyProduct和PostBuyProduct方法就是代理主题角色所执行的其他操作。
//真实主题角色（RealBuyPerson）：定义了代理角色所代表的真是对象。

//优点：

//代理模式能够将调用用于真正被调用的对象隔离，在一定程度上降低了系统的耦合度；
//代理对象在客户端和目标对象之间起到一个中介的作用，这样可以起到对目标对象的保护。代理对象可以在对目标对象发出请求之前进行一个额外的操作，例如权限检查等。
//缺点：

// 由于在客户端和真实主题之间增加了一个代理对象，所以会造成请求的处理速度变慢
//实现代理类也需要额外的工作，从而增加了系统的实现复杂度。
namespace 设计模式之代理模式
{
    // 客户端调用
    class Client
    {
        static void Main(string[] args)
        {
            // 创建一个代理对象并发出请求
            Person proxy = new Friend();
            proxy.BuyProduct();
            Console.Read();
        }
    }

    // 抽象主题角色
    public abstract class Person
    {
        public abstract void BuyProduct();
    }

    //真实主题角色
    public class RealBuyPerson : Person
    {
        public override void BuyProduct()
        {
            Console.WriteLine("帮我买一个IPhone和一台苹果电脑");
        }
    }

    // 代理角色
    public class Friend : Person
    {
        // 引用真实主题实例
        RealBuyPerson realSubject;

        public override void BuyProduct()
        {
            Console.WriteLine("通过代理类访问真实实体对象的方法");
            if (realSubject == null)
            {
                realSubject = new RealBuyPerson();
            }

            this.PreBuyProduct();
            // 调用真实主题方法
            realSubject.BuyProduct();
            this.PostBuyProduct();
        }

        // 代理角色执行的一些操作
        public void PreBuyProduct()
        {
            // 可能不知一个朋友叫这位朋友带东西，首先这位出国的朋友要对每一位朋友要带的东西列一个清单等
            Console.WriteLine("我怕弄糊涂了，需要列一张清单，张三：要带相机，李四：要带Iphone...........");
        }

        // 买完东西之后，代理角色需要针对每位朋友需要的对买来的东西进行分类
        public void PostBuyProduct()
        {
            Console.WriteLine("终于买完了，现在要对东西分一下，相机是张三的；Iphone是李四的..........");
        }
    }
}
