using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//组合模式允许你将对象组合成树形结构来表现”部分-整体“的层次结构，使得客户以一致的方式处理单个对象以及对象的组合。

//组合模式中涉及到三个角色：

//抽象构件（Component）角色：这是一个抽象角色，上面实现中Graphics充当这个角色，它给参加组合的对象定义出了公共的接口及默认行为，可以用来管理所有的子对象（在透明式的组合模式是这样的）。在安全式的组合模式里，构件角色并不定义出管理子对象的方法，这一定义由树枝结构对象给出。
//树叶构件（Leaf）角色：树叶对象时没有下级子对象的对象，上面实现中Line和Circle充当这个角色，定义出参加组合的原始对象的行为
//树枝构件（Composite）角色：代表参加组合的有下级子对象的对象，上面实现中ComplexGraphics充当这个角色，树枝对象给出所有管理子对象的方法实现，如Add、Remove等。

//优点：

//组合模式使得客户端代码可以一致地处理对象和对象容器，无需关系处理的单个对象，还是组合的对象容器。
//将”客户代码与复杂的对象容器结构“解耦。
//可以更容易地往组合对象中加入新的构件。
//缺点：使得设计更加复杂。客户端需要花更多时间理清类之间的层次关系。（这个是几乎所有设计模式所面临的问题）。
namespace 设计模式之组合模式
{
    // 通过一些简单图形以及一些复杂图形构建图形树来演示组合模式
    // 客户端调用
    class Client
    {
        static void Main(string[] args)
        {
            ComplexGraphics complexGraphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            complexGraphics.Add(new Line("线段A"));
            ComplexGraphics CompositeCG = new ComplexGraphics("一个圆和一条线组成的复杂图形");
            CompositeCG.Add(new Circle("圆"));
            CompositeCG.Add(new Circle("线段B"));
            complexGraphics.Add(CompositeCG);
            Line l = new Line("线段C");
            complexGraphics.Add(l);

            // 显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            // 移除一个组件再显示复杂图形的画法
            complexGraphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            complexGraphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.Read();
        }
    }

    /// <summary>
    /// 图形抽象类，
    /// </summary>
    public abstract class Graphics
    {
        public string Name { get; set; }
        public Graphics(string name)
        {
            this.Name = name;
        }

        public abstract void Draw();
        public abstract void Add(Graphics g);
        public abstract void Remove(Graphics g);
    }

    /// <summary>
    /// 简单图形类——线
    /// </summary>
    public class Line : Graphics
    {
        public Line(string name)
            : base(name)
        { }

        // 重写父类抽象方法
        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }
        // 因为简单图形在添加或移除其他图形，所以简单图形Add或Remove方法没有任何意义
        // 如果客户端调用了简单图形的Add或Remove方法将会在运行时抛出异常
        // 我们可以在客户端捕获该类移除并处理
        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形Line添加其他图形");
        }
        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形Line移除其他图形");
        }
    }

    /// <summary>
    /// 简单图形类——圆
    /// </summary>
    public class Circle : Graphics
    {
        public Circle(string name)
            : base(name)
        { }

        // 重写父类抽象方法
        public override void Draw()
        {
            Console.WriteLine("画  " + Name);
        }

        public override void Add(Graphics g)
        {
            throw new Exception("不能向简单图形Circle添加其他图形");
        }
        public override void Remove(Graphics g)
        {
            throw new Exception("不能向简单图形Circle移除其他图形");
        }
    }

    /// <summary>
    /// 复杂图形，由一些简单图形组成,这里假设该复杂图形由一个圆两条线组成的复杂图形
    /// </summary>
    public class ComplexGraphics : Graphics
    {
        private List<Graphics> complexGraphicsList = new List<Graphics>();

        public ComplexGraphics(string name)
            : base(name)
        { }

        /// <summary>
        /// 复杂图形的画法
        /// </summary>
        public override void Draw()
        {
            foreach (Graphics g in complexGraphicsList)
            {
                g.Draw();
            }
        }

        public override void Add(Graphics g)
        {
            complexGraphicsList.Add(g);
        }
        public override void Remove(Graphics g)
        {
            complexGraphicsList.Remove(g);
        }
    }
}
