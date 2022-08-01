using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeProblem
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        public T NodeData
        {
            get; set;
        }
        public BinarySearchTree<T> leftTree { get; set; }
        public BinarySearchTree<T> rightTree { get; set; }

        public BinarySearchTree(T nodeData)
        {
            this.NodeData = nodeData;
            this.rightTree = null;
            this.leftTree = null;

        }
        int leftCount = 0, rightCount = 0;
        bool result = false;
        public void Insert(T item) // this method is used to insert the value in tree
        {
            T currentNodeValue = this.NodeData;
            if ((currentNodeValue.CompareTo(item)) > 0) 
            {//if this condition becomes true it means the value we want to add is less than currentNodeValue and it will check if left node is null or not
                if (this.leftTree == null) // if the leftTree is null then the value is added in this or else this insert method will be called again
                {
                    this.leftTree = new BinarySearchTree<T>(item);
                }
                else
                    this.leftTree.Insert(item);

            }
            else//if the first if condition becomes false it means the value we want to add is greater than currentNodeValue and it will check if right node is null or not
            {
                if (this.rightTree == null)// if the rightTree is null then the value is added in this or else this insert method will be called again
                {
                    this.rightTree = new BinarySearchTree<T>(item);
                }
                else
                    this.rightTree.Insert(item);
            }
        }
        public void Display() // this method is used to display the value
        {
            if (this.leftTree != null)
            {
                this.leftCount++;
                this.leftTree.Display();
            }
            Console.WriteLine(this.NodeData.ToString());
            if (this.rightTree != null)
            {
                this.rightCount++;
                this.rightTree.Display();
            }
        }

        public void GetSize() // this method is used to get total number of values or nodes added
        {
            Console.WriteLine("Size" + " " + (1 + this.leftCount + this.rightCount));
        }

        public bool IfExists(T element, BinarySearchTree<T> node)
        {
            if (node == null)
                return false;
            if (node.NodeData.Equals(element))
            {
                Console.WriteLine("Found the element in BST" + " " + node.NodeData);
                result = true;
            }
            else
                Console.WriteLine("Current element is {0} in BST", node.NodeData);
            if (element.CompareTo(node.NodeData) < 0)
                IfExists(element, node.leftTree);
            if (element.CompareTo(node.NodeData) > 0)
                IfExists(element, node.rightTree);
            return result;
        }
    }
}
