using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//迭代器模式提供了一种方法顺序访问一个聚合对象（理解为集合对象）中各个元素，而又无需暴露该对象的内部表示，这样既可以做到不暴露集合的内部结构，又可让外部代码透明地访问集合内部的数据。

//迭代器角色（Iterator）：迭代器角色负责定义访问和遍历元素的接口
//具体迭代器角色（Concrete Iteraror）：具体迭代器角色实现了迭代器接口，并需要记录遍历中的当前位置。
//聚合角色（Aggregate）：聚合角色负责定义获得迭代器角色的接口
//具体聚合角色（Concrete Aggregate）：具体聚合角色实现聚合角色接口。

//优点：

//迭代器模式使得访问一个聚合对象的内容而无需暴露它的内部表示，即迭代抽象。
//迭代器模式为遍历不同的集合结构提供了一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作
//　　迭代器模式存在的缺陷：

//迭代器模式在遍历的同时更改迭代器所在的集合结构会导致出现异常。所以使用foreach语句只能在对集合进行遍历，不能在遍历的同时更改集合中的元素。

namespace 设计模式之迭代器模式
{
    // 抽象聚合类
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    // 迭代器抽象类
    public interface Iterator
    {
        bool MoveNext();
        Object GetCurrent();
        void Next();
        void Reset();
    }

    // 具体聚合类
    public class ConcreteList : IListCollection
    {
        int[] collection;
        public ConcreteList()
        {
            collection = new int[] { 2, 4, 6, 8 };
        }

        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }
    }

    // 具体迭代器类
    public class ConcreteIterator : Iterator
    {
        // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteList _list;
        private int _index;

        public ConcreteIterator(ConcreteList list)
        {
            _list = list;
            _index = 0;
        }


        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }

        public Object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }

        }
    }

    // 客户端
    class Program
    {
        static void Main(string[] args)
        {
            Iterator iterator;
            IListCollection list = new ConcreteList();
            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }

            Console.Read();
        }
    }
}
