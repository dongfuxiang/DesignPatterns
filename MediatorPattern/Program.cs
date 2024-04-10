using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//中介者模式，定义了一个中介对象来封装一系列对象之间的交互关系。中介者使各个对象之间不需要显式地相互引用，从而使耦合性降低，而且可以独立地改变它们之间的交互行为。

//中介者模式具有以下几点优点：

//简化了对象之间的关系，将系统的各个对象之间的相互关系进行封装，将各个同事类解耦，使得系统变为松耦合。
//提供系统的灵活性，使得各个同事对象独立而易于复用。
//　　然而，中介者模式也存在对应的缺点：

//中介者模式中，中介者角色承担了较多的责任，所以一旦这个中介者对象出现了问题，整个系统将会受到重大的影响。例如，QQ游戏中计算欢乐豆的程序出错了，这样会造成重大的影响。
//新增加一个同事类时，不得不去修改抽象中介者类和具体中介者类，此时可以使用观察者模式和状态模式来解决这个问题。
namespace 设计模式之中介者模式
{
    namespace MediatorPattern
    {
        // 抽象牌友类
        public abstract class AbstractCardPartner
        {
            public int MoneyCount { get; set; }

            public AbstractCardPartner()
            {
                MoneyCount = 0;
            }

            public abstract void ChangeCount(int Count, AbstractMediator mediator);
        }

        // 牌友A类
        public class ParterA : AbstractCardPartner
        {
            // 依赖与抽象中介者对象
            public override void ChangeCount(int Count, AbstractMediator mediator)
            {
                mediator.AWin(Count);
            }
        }

        // 牌友B类
        public class ParterB : AbstractCardPartner
        {
            // 依赖与抽象中介者对象
            public override void ChangeCount(int Count, AbstractMediator mediator)
            {
                mediator.BWin(Count);
            }
        }

        // 抽象中介者类
        public abstract class AbstractMediator
        {
            protected AbstractCardPartner A;
            protected AbstractCardPartner B;
            public AbstractMediator(AbstractCardPartner a, AbstractCardPartner b)
            {
                A = a;
                B = b;
            }

            public abstract void AWin(int count);
            public abstract void BWin(int count);
        }

        // 具体中介者类
        public class MediatorPater : AbstractMediator
        {
            public MediatorPater(AbstractCardPartner a, AbstractCardPartner b)
                : base(a, b)
            {
            }

            public override void AWin(int count)
            {
                A.MoneyCount += count;
                B.MoneyCount -= count;
            }

            public override void BWin(int count)
            {
                B.MoneyCount += count;
                A.MoneyCount -= count;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                AbstractCardPartner A = new ParterA();
                AbstractCardPartner B = new ParterB();
                // 初始钱
                A.MoneyCount = 20;
                B.MoneyCount = 20;

                AbstractMediator mediator = new MediatorPater(A, B);

                // A赢了
                A.ChangeCount(5, mediator);
                Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是25
                Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是15

                // B 赢了
                B.ChangeCount(10, mediator);
                Console.WriteLine("A 现在的钱是：{0}", A.MoneyCount);// 应该是15
                Console.WriteLine("B 现在的钱是：{0}", B.MoneyCount); // 应该是25
                Console.Read();
            }
        }
    }
}
