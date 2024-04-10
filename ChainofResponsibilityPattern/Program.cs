using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//责任链模式指的是——某个请求需要多个对象进行处理，从而避免请求的发送者和接收之间的耦合关系。将这些对象连成一条链子，并沿着这条链子传递该请求，直到有对象处理它为止。

//抽象处理者角色（Handler）：定义出一个处理请求的接口。这个接口通常由接口或抽象类来实现。
//具体处理者角色（ConcreteHandler）：具体处理者接受到请求后，可以选择将该请求处理掉，或者将请求传给下一个处理者。因此，每个具体处理者需要保存下一个处理者的引用，以便把请求传递下去。

//责任链模式的优点不言而喻，主要有以下点：

//降低了请求的发送者和接收者之间的耦合。
//把多个条件判定分散到各个处理类中，使得代码更加清晰，责任更加明确。
//　　责任链模式也具有一定的缺点，如：

//在找到正确的处理对象之前，所有的条件判定都要执行一遍，当责任链过长时，可能会引起性能的问题
//可能导致某个请求不被处理。

namespace 设计模式之责任链模式
{
    namespace ChainofResponsibility
    {
        // 采购请求
        public class PurchaseRequest
        {
            // 金额
            public double Amount { get; set; }
            // 产品名字
            public string ProductName { get; set; }
            public PurchaseRequest(double amount, string productName)
            {
                Amount = amount;
                ProductName = productName;
            }
        }

        // 审批人,Handler
        public abstract class Approver
        {
            public Approver NextApprover { get; set; }
            public string Name { get; set; }
            public Approver(string name)
            {
                this.Name = name;
            }
            public abstract void ProcessRequest(PurchaseRequest request);
        }

        // ConcreteHandler
        public class Manager : Approver
        {
            public Manager(string name)
                : base(name)
            { }

            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 10000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else if (NextApprover != null)
                {
                    NextApprover.ProcessRequest(request);
                }
            }
        }

        // ConcreteHandler,副总
        public class VicePresident : Approver
        {
            public VicePresident(string name)
                : base(name)
            {
            }
            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 25000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else if (NextApprover != null)
                {
                    NextApprover.ProcessRequest(request);
                }
            }
        }

        // ConcreteHandler，总经理
        public class President : Approver
        {
            public President(string name)
                : base(name)
            { }
            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 100000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else
                {
                    Console.WriteLine("Request需要组织一个会议讨论");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                PurchaseRequest requestTelphone = new PurchaseRequest(4000.0, "Telphone");
                PurchaseRequest requestSoftware = new PurchaseRequest(10000.0, "Visual Studio");
                PurchaseRequest requestComputers = new PurchaseRequest(40000.0, "Computers");

                Approver manager = new Manager("LearningHard");
                Approver Vp = new VicePresident("Tony");
                Approver Pre = new President("BossTom");

                // 设置责任链
                manager.NextApprover = Vp;
                Vp.NextApprover = Pre;

                // 处理请求
                manager.ProcessRequest(requestTelphone);
                manager.ProcessRequest(requestSoftware);
                manager.ProcessRequest(requestComputers);
                Console.ReadLine();
            }
        }
    }
}
