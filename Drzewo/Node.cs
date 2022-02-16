using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node
    {
        public double value;
        public Node rightChild;
        public Node leftChild;
        
        public Node(double _value)
        {
            value = _value;
        }
        
        public Node Search(double number)
        {
            if (number == value)
            {
                return this;
            }
            else if (number < value && leftChild != null)
            {
                return leftChild.Search(number);
            }
            else if(rightChild != null)
            {
                return rightChild.Search(number);
            }
            else
            {
                return null;
            }
        }
        
        public void Insert(double number)
        {
            if(number > this.value)
            {
                if (rightChild == null)
                {
                    rightChild = new Node(number);
                }
                else
                {
                    rightChild.Insert(number);
                }
            }else if(number < this.value)
            {
                if (leftChild == null)
                {
                    leftChild = new Node(number);
                }
                else
                {
                    leftChild.Insert(number);
                }
            }
        }
        
        
    }
}
