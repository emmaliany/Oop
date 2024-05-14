using System;
using System.Collections.Generic;
using System.Text;

namespace part_3_oop
{
    class LinkedList
    {
        private Node _head;
        private Node _tail;
        private Node _max = new Node();
        private Node _min = new Node();

        public void Append(int value)
        {
            Node last = new Node();
            last.Value = value;

            if (_head == null)
            {
                _head = last;
                _tail = _head;
                _max.Value = value;
                _min.Value = value;
                return;
            }
            _max.Value = Math.Max(_max.Value, value);
            _min.Value = Math.Min(_min.Value, value);
            _tail.Next = last;
            _tail = _tail.Next;
        }

        public void Prepend(int value)
        {
            Node temp = new Node();
            temp.Value = value;
            temp.Next = _head;
            _head = temp;
            if (_head.Next == null)
            {
                _tail = _head;
                _max.Value = value;
                _min.Value = value;
                return;
            }
            _max.Value = Math.Max(_max.Value, value);
            _min.Value = Math.Min(_min.Value, value);
        }

        public int Pop()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Cannot pop null linked list");
            }

            int value = _tail.Value;

            if (_head.Next == null)
            {
                _head = null;
                _tail = _head;
                return value;
            }

            Node pointer = _head;
            while (true)
            {
                if (pointer.Next.Next == null)
                {
                    _tail = pointer;
                    pointer.Next = null;
                    break;
                }
                pointer = pointer.Next;
            }
            UpdateMaxMin(value);

            return value;
        }

        public int Unqueue()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Cannot unqueue null linked list");
            }
            int value = _head.Value;
            _head = _head.Next;

            UpdateMaxMin(value);

            return value;
            
        }

        private void UpdateMaxMin(int value)
        {
            if (_head == null)
            {
                return;
            }

            if (value == _max.Value || value == _min.Value)
            {
                Node pointer = _head;
                _max.Value = _head.Value;
                _min.Value = _head.Value;

                while (pointer != null)
                {
                    _max.Value = Math.Max(_max.Value, pointer.Value);
                    _min.Value = Math.Min(_min.Value, pointer.Value);
                    pointer = pointer.Next;
                }
            }
        }

        public IEnumerable<int> ToList()
        {
            Node pointer = _head;
            List<int> values = new List<int>();
            while (pointer != null)
            {
                values.Add(pointer.Value);
                pointer = pointer.Next;
            }        
            return values;
        }

        public bool IsCircular()
        {
            if (_head == null)
            {
                return true;
            }
            Node pointer = _head.Next;

            while (pointer != null)
            {
                if (pointer == _head)
                {
                    return true;
                }
                pointer = pointer.Next;
            }

            return false;
        }

        public void Sort()
        {

            if (_head == null)
            {
                return;
            }

            Node index = _head;
            Node pointer = index.Next;

            while (index != null)
            {
                while (pointer != null)
                {
                    if (pointer.Value < index.Value)
                    {
                        int temp = index.Value;
                        index.Value = pointer.Value;
                        pointer.Value = temp;
                    }
                    pointer = pointer.Next;
                }
                index = index.Next;
                pointer = index;
            }
        }

        public Node GetMaxNode()
        {
            return _max;
        }

        public Node GetMinNode()
        {
            return _min;
        }

        public void PrintList()
        {
            Node pointer = _head;

            while (pointer != null)
            {
                Console.Write(pointer.Value + " -> ");
                pointer = pointer.Next;
            }
            Console.WriteLine("null");
        }
    }
}
