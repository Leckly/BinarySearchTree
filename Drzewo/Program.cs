using System;
using System.IO;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();
            string[] lines = File.ReadAllLines("in1.txt");
            string[] dimensions = lines[0].Split(" ");
            int width = int.Parse(dimensions[0]);
            string[][] arr = new string[width][];
            for (int i = 0; i < width; i++)
            {
                arr[i] = new string[2];
            }
            int j = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                string c = lines[i];
                string[] d = c.Split(" ");
                    arr[j][0] = d[0];
                    arr[j][1] = d[1];

                if (j < width)
                {
                    j++;
                }
            }
            
            string x;
            double y;
            for (int i = 0; i < width; i++)
            {
                
                x = arr[i][0];
                y = double.Parse(arr[i][1]);
                switch (x)
                {
                    case "W":
                        tree.Insert(y);
                        break;
                    case "S":
                        Node check = tree.Search(y);
                        if(check == null)
                        {
                            Console.WriteLine("NO");
                        }
                        else
                        {
                            Console.WriteLine("YES");
                        }
                        break;
                    case "U":
                        tree.Delete(y);
                        break;
                    case "L":
                        //int a = Convert.ToInt32(y);
                        Console.WriteLine(tree.Quantity(tree.root, y));
                        break;
                    
                    
                }
            }


            //Console.WriteLine(drzewo.korzen.wartosc);
            show(tree.root,0);
        }
        public static void show(Node a, int level)
        {
            for(int i = 0; i < level; i++)
            {
                Console.Write("     ");
            }
            Console.WriteLine(a.value);
            if (a.rightChild != null)
            {
                show(a.rightChild, level + 1);
            }
            if (a.leftChild != null)
            {
                show(a.leftChild, level + 1);
            }
        }
    }
}
