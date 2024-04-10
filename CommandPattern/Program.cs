using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//命令模式属于对象的行为型模式。命令模式是把一个操作或者行为抽象为一个对象中，通过对命令的抽象化来使得发出命令的责任和执行命令的责任分隔开。命令模式的实现可以提供命令的撤销和恢复功能。

//优点：

//命令模式使得新的命令很容易被加入到系统里。
//可以设计一个命令队列来实现对请求的Undo和Redo操作。
//可以较容易地将命令写入日志。
//可以把命令对象聚合在一起，合成为合成命令。合成命令式合成模式的应用。
//　　命令模式的缺点：

//使用命令模式可能会导致系统有过多的具体命令类。这会使得命令模式在这样的系统里变得不实际。
namespace 设计模式之命令模式
{

  //  军训场景中，具体的命令即是学生跑1000米，这里学生是命令的接收者，教官是命令的请求者，院领导是命令的发出者，即客户端角色。要实现命令模式，则必须需要一个抽象命令角色来声明约定，这里以抽象类来来表示。命令的传达流程是：

　　//命令的发出者必须知道具体的命令、接受者和传达命令的请求者，对应于程序也就是在客户端角色中需要实例化三个角色的实例对象了。

　　//命令的请求者负责调用命令对象的方法来保证命令的执行，对应于程序也就是请求者对象需要有命令对象的成员，并在请求者对象的方法内执行命令。

　　//具体命令就是跑1000米，这自然属于学生的责任，所以是具体命令角色的成员方法，而抽象命令类定义这个命令的抽象接口。

　　//有了上面的分析之后，具体命令模式的实现代码如下所示：
    // 教官，负责调用命令对象执行请求
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    // 命令抽象类
    public abstract class Command
    {
        // 命令应该知道接收者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        // 命令执行方法
        public abstract void Action();
    }

    //
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Action()
        {
            // 调用接收的方法，因为执行命令的是学生
            _receiver.Run1000Meters();
        }
    }

    // 命令接收者——学生
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }

    // 院领导
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化Receiver、Invoke和Command
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);

            // 院领导发出命令
            i.ExecuteCommand();
        }
    }
}
