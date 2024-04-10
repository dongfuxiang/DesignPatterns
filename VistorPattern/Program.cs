using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//访问者模式是封装一些施加于某种数据结构之上的操作。一旦这些操作需要修改的话，接受这个操作的数据结构则可以保存不变。访问者模式适用于数据结构相对稳定的系统， 它把数据结构和作用于数据结构之上的操作之间的耦合度降低，使得操作集合可以相对自由地改变。

//抽象访问者角色（Vistor）:声明一个活多个访问操作，使得所有具体访问者必须实现的接口。
//具体访问者角色（ConcreteVistor）：实现抽象访问者角色中所有声明的接口。
//抽象节点角色（Element）：声明一个接受操作，接受一个访问者对象作为参数。
//具体节点角色（ConcreteElement）：实现抽象元素所规定的接受操作。
//结构对象角色（ObjectStructure）：节点的容器，可以包含多个不同类或接口的容器。

//访问者模式具有以下优点：

//访问者模式使得添加新的操作变得容易。如果一些操作依赖于一个复杂的结构对象的话，那么一般而言，添加新的操作会变得很复杂。而使用访问者模式，增加新的操作就意味着添加一个新的访问者类。因此，使得添加新的操作变得容易。
//访问者模式使得有关的行为操作集中到一个访问者对象中，而不是分散到一个个的元素类中。这点类似与"中介者模式"。
//访问者模式可以访问属于不同的等级结构的成员对象，而迭代只能访问属于同一个等级结构的成员对象。
//　　访问者模式也有如下的缺点：

//增加新的元素类变得困难。每增加一个新的元素意味着要在抽象访问者角色中增加一个新的抽象操作，并在每一个具体访问者类中添加相应的具体操作。

namespace 设计模式之访问者模式
{
    namespace VistorPattern
    {
        // 抽象元素角色
        public abstract class Element
        {
            public abstract void Accept(IVistor vistor);
            public abstract void Print();
        }

        // 具体元素A
        public class ElementA : Element
        {
            public override void Accept(IVistor vistor)
            {
                // 调用访问者visit方法
                vistor.Visit(this);
            }
            public override void Print()
            {
                Console.WriteLine("我是元素A");
            }
        }

        // 具体元素B
        public class ElementB : Element
        {
            public override void Accept(IVistor vistor)
            {
                vistor.Visit(this);
            }
            public override void Print()
            {
                Console.WriteLine("我是元素B");
            }
        }

        // 抽象访问者
        public interface IVistor
        {
            void Visit(ElementA a);
            void Visit(ElementB b);
        }

        // 具体访问者
        public class ConcreteVistor : IVistor
        {
            // visit方法而是再去调用元素的Accept方法
            public void Visit(ElementA a)
            {
                a.Print();
            }
            public void Visit(ElementB b)
            {
                b.Print();
            }
        }

        // 对象结构
        public class ObjectStructure
        {
            private ArrayList elements = new ArrayList();

            public ArrayList Elements
            {
                get { return elements; }
            }

            public ObjectStructure()
            {
                Random ran = new Random();
                for (int i = 0; i < 6; i++)
                {
                    int ranNum = ran.Next(10);
                    if (ranNum > 5)
                    {
                        elements.Add(new ElementA());
                    }
                    else
                    {
                        elements.Add(new ElementB());
                    }
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ObjectStructure objectStructure = new ObjectStructure();
                foreach (Element e in objectStructure.Elements)
                {
                    // 每个元素接受访问者访问
                    e.Accept(new ConcreteVistor());
                }

                Console.Read();
            }
        }
    }
}
