using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式之单例模式
{
    //说到单例模式,大家第一反应应该就是——什么是单例模式？，
    //从“单例”字面意思上理解为——一个类只有一个实例，所以
    //单例模式也就是保证一个类只有一个实例的一种实现方法罢了
    //(设计模式其实就是帮助我们解决实际开发过程中的方法, 该
    //方法是为了降低对象之间的耦合度, 然而解决方法有很多种,
    //所以前人就总结了一些常用的解决方法为书籍, 从而把这本书
    //就称为设计模式)，下面给出单例模式的一个官方定义：确保一
    //个类只有一个实例,并提供一个全局访问点。
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 单例模式的实现
        /// </summary>
        public class Singleton
        {
            // 定义一个静态变量来保存类的实例
            private static Singleton uniqueInstance;

            // 定义一个标识确保线程同步
            private static readonly object locker = new object();

            // 定义私有构造函数，使外界不能创建该类实例
            private Singleton()
            {
            }

            /// <summary>
            /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
            /// </summary>
            /// <returns></returns>
            public static Singleton GetInstance()
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                // 双重锁定只需要一句判断就可以了
                if (uniqueInstance == null)
                {
                    lock (locker)
                    {
                        // 如果类的实例不存在则创建，否则直接返回
                        if (uniqueInstance == null)
                        {
                            uniqueInstance = new Singleton();
                        }
                    }
                }
                return uniqueInstance;
            }
        }
    }
}
