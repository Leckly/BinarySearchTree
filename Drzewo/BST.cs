using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BST
    {
        public Node root;
                
        public Node Search(double number)
        {
            if(root != null)
            {
                return root.Search(number);
            }
            else
            {
                return null;
            }
        }


        public void Insert(double liczba)
        {
            if (root != null)
            {
                if (root.Search(liczba) == null)
                {
                    root.Insert(liczba);   
                }
            }
            else
            {
                root = new Node(liczba);
            }
        }
        public void Delete(double number)
        {
            Node parentOfWanted = root;
            Node wanted = root;
            bool side = false;//false == lewa strona , true == prawa strona
            if(wanted == null)
            {
                return;
            }           
            while (wanted != null && wanted.value != number)
            {
                parentOfWanted = wanted;
                if (number < wanted.value)
                {
                    wanted = parentOfWanted.leftChild;
                }
                else
                {
                    wanted = parentOfWanted.rightChild;

                }
            }
            if (parentOfWanted.rightChild == wanted)
            {
                side = true;
            }
            else if (parentOfWanted.leftChild == wanted)
            {
                side = false;
            }
            if(wanted == null)
            {
                return;
            }
            if (wanted.leftChild == null && wanted.rightChild == null)
            {
                if (wanted == root)
                {
                    root = null;
                }
                if (side == true)
                {
                    parentOfWanted.rightChild = null;
                }
                else if (side == false)
                {
                    parentOfWanted.leftChild = null;
                }
            }
            else if (wanted.leftChild == null && wanted.rightChild != null)
            {
                if (wanted == root)
                {
                    root = root.rightChild;
                }
                if (side == true)
                {
                    parentOfWanted.rightChild = wanted.rightChild;
                }
                else if (side == false)
                {
                    parentOfWanted.leftChild = wanted.rightChild;
                }
            }
            else if (wanted.leftChild != null && wanted.rightChild == null)
            {
                if (wanted == root)
                {
                    root = root.leftChild;
                }
                if (side == true)
                {
                    parentOfWanted.rightChild = wanted.leftChild;
                }
                else if (side == false)
                {
                    parentOfWanted.leftChild = wanted.leftChild;
                }
            }
            if (wanted.leftChild != null && wanted.rightChild != null)
            {
                Node succesor = Succesor(wanted);
                if (wanted == root)
                {
                    root = succesor;
                }
                else if (side == false)
                {
                    parentOfWanted.leftChild = succesor;
                }
                else if (side == true)
                {
                    parentOfWanted.rightChild = succesor;
                }
            }
        }

        public Node Succesor(Node wanted)
        {
            Node fatherOfSuccesor = wanted;
            Node Succesor = wanted;
            Node temp = wanted.rightChild;
            while (temp != null)
            {
                fatherOfSuccesor = Succesor;
                Succesor = temp;
                temp = temp.leftChild;
            }
            if(Succesor!= wanted.rightChild)
            {
                fatherOfSuccesor.leftChild = Succesor.rightChild;
                Succesor.rightChild = wanted.rightChild;
            }           
            Succesor.leftChild = wanted.leftChild;

            return Succesor;
        }
        public int Quantity(Node root, double number)
        {
            if (root == null)
            {
                return 0;
            }

            
            if (root.value >= number && root.value < number+1)
            {
                return 1 + Quantity(root.leftChild, number) +
                        Quantity(root.rightChild, number);
            }

            if (root.value > number+1)
            {
                return Quantity(root.leftChild, number);
            }

            if (root.value < number)
            {
                return Quantity(root.rightChild, number);
            }
            return 0;
        }
    }
}
