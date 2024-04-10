using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//使用了外观模式之后，客户端只依赖与外观类，从而将客户端与子系统的依赖解耦了，
//如果子系统发生改变，此时客户端的代码并不需要去改变。
//外观模式的实现核心主要是——由外观类去保存各个子系统的引用，
//实现由一个统一的外观类去包装多个子系统类，然而客户端只需要引用这个外观类，
//然后由外观类来调用各个子系统中的方法。然而这样的实现方式非常类似适配器模式，
//然而外观模式与适配器模式不同的是：适配器模式是将一个对象包装起来以改变其接口，
//而外观是将一群对象 ”包装“起来以简化其接口。它们的意图是不一样的，适配器是将接口转换为不同接口，

//优点：

//外观模式对客户屏蔽了子系统组件，从而简化了接口，减少了客户处理的对象数目并使子系统的使用更加简单。
//外观模式实现了子系统与客户之间的松耦合关系，而子系统内部的功能组件是紧耦合的。松耦合使得子系统的组件变化不会影响到它的客户。
//缺点：

//如果增加新的子系统可能需要修改外观类或客户端的源代码，这样就违背了”开——闭原则“（不过这点也是不可避免）。
//而外观模式是提供一个统一的接口来简化接口。
namespace 设计模式之外观模式
{
    /// <summary>
    /// 以学生选课系统为例子演示外观模式的使用
    /// 学生选课模块包括功能有：
    /// 验证选课的人数是否已满
    /// 通知用户课程选择成功与否
    /// 客户端代码
    /// </summary>
    class Student
    {
        private static RegistrationFacade facade = new RegistrationFacade();

        static void Main(string[] args)
        {
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();
        }
    }

    // 外观类
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStu;
        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }

            return notifyStu.Notify(studentName);
        }
    }

    #region 子系统
    // 相当于子系统A
    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    // 相当于子系统B
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }
    #endregion
}
