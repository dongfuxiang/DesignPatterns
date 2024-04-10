using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//策略模式是对算法的包装，是把使用算法的责任和算法本身分割开，委派给不同的对象负责。策略模式通常把一系列的算法包装到一系列的策略类里面。用一句话慨括策略模式就是——“将每个算法封装到不同的策略类中，使得它们可以互换”。

//环境角色（Context）：持有一个Strategy类的引用
//抽象策略角色（Strategy）：这是一个抽象角色，通常由一个接口或抽象类来实现。此角色给出所有具体策略类所需实现的接口。
//具体策略角色（ConcreteStrategy）：包装了相关算法或行为。

//策略模式的主要优点有：

//策略类之间可以自由切换。由于策略类都实现同一个接口，所以使它们之间可以自由切换。
//易于扩展。增加一个新的策略只需要添加一个具体的策略类即可，基本不需要改变原有的代码。
//避免使用多重条件选择语句，充分体现面向对象设计思想。
//　　策略模式的主要缺点有：

//客户端必须知道所有的策略类，并自行决定使用哪一个策略类。这点可以考虑使用IOC容器和依赖注入的方式来解决，关于IOC容器和依赖注入（Dependency Inject）的文章可以参考：IoC 容器和Dependency Injection 模式。
//策略模式会造成很多的策略类

namespace 设计模式之策略者模式
{
    namespace StrategyPattern
    {
        // 所得税计算策略
        public interface ITaxStragety
        {
            double CalculateTax(double income);
        }

        // 个人所得税
        public class PersonalTaxStrategy : ITaxStragety
        {
            public double CalculateTax(double income)
            {
                return income * 0.12;
            }
        }

        // 企业所得税
        public class EnterpriseTaxStrategy : ITaxStragety
        {
            public double CalculateTax(double income)
            {
                return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
            }
        }

        public class InterestOperation
        {
            private ITaxStragety m_strategy;
            public InterestOperation(ITaxStragety strategy)
            {
                this.m_strategy = strategy;
            }

            public double GetTax(double income)
            {
                return m_strategy.CalculateTax(income);
            }
        }

        class App
        {
            static void Main(string[] args)
            {
                // 个人所得税方式
                InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
                Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));

                // 企业所得税
                operation = new InterestOperation(new EnterpriseTaxStrategy());
                Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));

                Console.Read();
            }
        }
    }
}
