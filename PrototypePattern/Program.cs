using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//原先模式：通过给出一个原型对象来指明所要创建的对象类型，然后用复制这个对象的方法来创建出更多的同类型对象；

//原型模式的优点有：

//原型模式向客户隐藏了创建新实例的复杂性
//原型模式允许动态增加或较少产品类。
//原型模式简化了实例的创建结构，工厂方法模式需要有一个与产品类等级结构相同的等级结构，而原型模式不需要这样。
//产品类不需要事先确定产品的等级结构，因为原型模式适用于任何的等级结构

//原型模式的缺点有：

//每个类必须配备一个克隆方法
//配备克隆方法需要对类的功能进行通盘考虑，这对于全新的类不是很难，但对于已有的类不一定很容易，特别当一个类引用不支持串行化的间接对象，或者引用含有循环结构的时候。
namespace 设计模式之原型模式
{
    ///火影忍者中鸣人的影分身和孙悟空的的变都是原型模式
    class Client
    {
        static void Main(string[] args)
        {
            // 孙悟空 原型
            MonkeyKingPrototype prototypeMonkeyKing = new ConcretePrototype("MonkeyKing");

            // 变一个
            MonkeyKingPrototype cloneMonkeyKing = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);

            // 变两个
            MonkeyKingPrototype cloneMonkeyKing2 = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.Id);
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }
        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }

        // 克隆方法，即孙大圣说“变”
        public abstract MonkeyKingPrototype Clone();


    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        { }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public override MonkeyKingPrototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }

    //浅拷贝只复制指向某个对象的指针，而不复制对象本身，新旧对象还是共享同一块内存。
    //深拷贝会另外创造一个一模一样的对象，新对象跟原对象不共享内存，修改新对象不会改到原对象，是“值”而不是“引用”
}
