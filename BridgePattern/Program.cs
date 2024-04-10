using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//桥接模式即将抽象部分与实现部分脱耦，使它们可以独立变化。

//优点：

//把抽象接口与其实现解耦。

//抽象和实现可以独立扩展，不会影响到对方。

//实现细节对客户透明，对用于隐藏了具体实现细节。

//缺点： 增加了系统的复杂度
namespace 设计模式之桥接模式
{

    #region 抽象化部分的代码：
    /// <summary>
    /// 抽象概念中的遥控器，扮演抽象化角色
    /// </summary>
    public class RemoteControl
    {
        // 字段
        private TV implementor;

        // 属性
        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        /// <summary>
        /// 开电视机，这里抽象类中不再提供实现了，而是调用实现类中的实现
        /// </summary>
        public virtual void On()
        {
            implementor.On();
        }

        /// <summary>
        /// 关电视机
        /// </summary>
        public virtual void Off()
        {
            implementor.Off();
        }

        /// <summary>
        /// 换频道
        /// </summary>
        public virtual void SetChannel()
        {
            implementor.tuneChannel();
        }
    }

    /// <summary>
    /// 具体遥控器
    /// </summary>
    public class ConcreteRemote : RemoteControl
    {
        public override void SetChannel()
        {
            Console.WriteLine("---------------------");
            base.SetChannel();
            Console.WriteLine("---------------------");
        }
    }
    #endregion

    #region 遥控器的实现方法部分代码，即实现化部分代码，此时我们用另外一个抽象类TV封装了遥控器功能的变化，具体实现交给具体型号电视机去完成：
    /// <summary>
    /// 电视机，提供抽象方法
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void tuneChannel();
    }

    /// <summary>
    /// 长虹牌电视机，重写基类的抽象方法
    /// 提供具体的实现
    /// </summary>
    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("长虹牌电视机已经关掉了");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("长虹牌电视机换频道");
        }
    }

    /// <summary>
    /// 三星牌电视机，重写基类的抽象方法
    /// </summary>
    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("三星牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("三星牌电视机已经关掉了");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("三星牌电视机换频道");
        }
    }
    #endregion


    #region 采用桥接模式的客户端调用代码：
    /// <summary>
    /// 以电视机遥控器的例子来演示桥接模式
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // 创建一个遥控器
            RemoteControl remoteControl = new ConcreteRemote();
            // 长虹电视机
            remoteControl.Implementor = new ChangHong();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.WriteLine();

            // 三星牌电视机
            remoteControl.Implementor = new Samsung();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.Read();
        }
    }
    #endregion

}


