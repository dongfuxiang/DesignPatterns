using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//建造者模式（Builder Pattern）:将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。

//1.在建造者模式中，指挥者是直接与客户端打交道的，指挥者将客户端创建产品的请求划分为对各个部件的建造请求，再将这些请求委派到具体建造者角色，具体建造者角色是完成具体产品的构建工作的，却不为客户所知道。
//2.建造者模式主要用于“分步骤来构建一个复杂的对象”，其中“分步骤”是一个固定的组合过程，而复杂对象的各个部分是经常变化的（也就是说电脑的内部组件是经常变化的，这里指的的变化如硬盘的大小变了，CPU由单核变双核等）。
//3.产品不需要抽象类，由于建造模式的创建出来的最终产品可能差异很大，所以不大可能提炼出一个抽象产品类。
//4.在前面文章中介绍的抽象工厂模式解决了“系列产品”的需求变化，而建造者模式解决的是 “产品部分” 的需要变化。
//5.由于建造者隐藏了具体产品的组装过程，所以要改变一个产品的内部表示，只需要再实现一个具体的建造者就可以了，从而能很好地应对产品组成组件的需求变化。



/// <summary>
/// 以组装电脑为例子
/// 每台电脑的组成过程都是一致的，但是使用同样的构建过程可以创建不同的表示(即可以组装成不一样的电脑，配置不一样)
/// 组装电脑的这个场景就可以应用建造者模式来设计
/// </summary>
namespace 设计模式之建造者模式
{
    /// <summary>
    /// 客户类
    /// </summary>
    class Customer
    {
        static void Main(string[] args)
        {
            // 客户找到电脑城老板说要买电脑，这里要装两台电脑
            // 创建指挥者和构造者
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // 老板叫员工去组装第一台电脑
            director.Construct(b1);

            // 组装完，组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();

            // 老板叫员工去组装第二台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();

            Console.Read();
        }
    }

    /// <summary>
    /// 小王和小李难道会自愿地去组装嘛，谁不想休息的，这必须有一个人叫他们去组装才会去的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    /// 指挥创建过程类
    /// </summary>
    public class Director
    {
        // 组装电脑
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }

    /// <summary>
    /// 电脑类
    /// </summary>
    public class Computer
    {
        // 电脑组件集合
        private IList<string> parts = new List<string>();

        // 把单个组件添加到电脑组件集合中
        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("电脑开始在组装.......");
            foreach (string part in parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("电脑组装好了");
        }
    }

    /// <summary>
    /// 抽象建造者，这个场景下为 "组装人" ，这里也可以定义为接口
    /// </summary>
    public abstract class Builder
    {
        // 装CPU
        public abstract void BuildPartCPU();
        // 装主板
        public abstract void BuildPartMainBoard();

        // 当然还有装硬盘，电源等组件，这里省略

        // 获得组装好的电脑
        public abstract Computer GetComputer();
    }

    /// <summary>
    /// 具体创建者，具体的某个人为具体创建者，例如：装机小王啊
    /// </summary>
    public class ConcreteBuilder1 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board1");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }

    /// <summary>
    /// 具体创建者，具体的某个人为具体创建者，例如：装机小李啊
    /// 又装另一台电脑了
    /// </summary>
    public class ConcreteBuilder2 : Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }
}