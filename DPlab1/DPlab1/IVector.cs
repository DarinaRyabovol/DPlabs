using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPlab1
{
    public interface IVector
    {
        void Write(int number, int position);
        int Read(int position);
        int GetSize();
    }
    public class OriginVector : IVector
    {
        private int[] value;
        private int size;
        public void Write(int number, int position)
        {
            if (position < 0) return;
            if (position >= size) return;
            value[position] = number;
        }
        public int Read(int position)
        {
            return value[position];
        }
        public int GetSize()
        {
            return size;
        }
        public OriginVector()
        {
            value = new int[0];
            size = 0;
        }
        public OriginVector(int size)
        {
            this.size = size;
            value = new int[size];
            //Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                value[i] = 0;
            }
        }
        public OriginVector(int[] arr)
        {
            value = arr;
            size = arr.GetLength(0);
        }
    }
    public class SparceVector : IVector
    {
        private int maxSize;
        private struct Element
        {
            public int number;
            public int value;
            public Element(int a, int b)
            {
                number = a;
                value = b;
            }
        }
        private List<Element> elements;
        public void Write(int number, int position)
        {
            if (position >= maxSize)
                return;
            int size = elements.Count;
            if (size == 0)
            {
                elements.Add(new Element(position, number));
                return;
            }
            if (elements[size - 1].number < position)
            {
                //дописать проверку на 0-е значение
                elements.Add(new Element(position, number));
                return;
            }
            int i = 0;
            foreach (Element j in elements)
            {
                if (j.number == position)
                    break;
                if (j.number > position)
                {
                    elements.Insert(i, new Element(position, number));
                    return;
                }
                i++;
            }
            elements[i] = new Element(position, number);
        }
        public int Read(int position)
        {
            foreach (Element i in elements)
            {
                if (i.number == position)
                    return i.value;
            }
            return 0;
        }
        public int GetSize()
        {
            return elements[elements.Count - 1].number;
        }
        public SparceVector()
        {
            elements = new List<Element>(0);
            maxSize = 0;
        }
        public SparceVector(int size)
        {
            maxSize = size;
            elements = new List<Element>(0);
        }
        public SparceVector(Int16 count)
        {
            Random r = new Random();
            maxSize = r.Next(20);
            elements = new List<Element>(0);
            for (int i = 0; i < count; i++)
            {
                Write(r.Next(100), r.Next(maxSize));
            }
        }
    }
}
