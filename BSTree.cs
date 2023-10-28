using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace TreeAssignment
{
    public class BSTree 
    {
        public Node Root { get; set; }

        public BSTree()
        {
            Root = null;
        }



        //add method

        private void InsertNode(Node tree, Node node)
        {
            // Compare the nodes based on the string 
            int comparison = string.Compare(node.Data, tree.Data);

            if (comparison < 0)
            {
                // Insert on the left
                if (tree.left == null)
                {
                    tree.left = node;
                }
                else
                {
                    InsertNode(tree.left, node);
                }
            }
            else if (comparison > 0)
            {
                // Insert on the right
                if (tree.right == null)
                {
                    tree.right = node;
                }
                else
                {
                    InsertNode(tree.right, node);
                }
            }
            
        }


        //ADD UI METHOD  
        
        public void Add(string data)
        {

            Console.WriteLine("Adding Words in the dictionary");

            Node node = new Node(data, data.Length);

            if (Root == null)
            {
                Root = node;
                Console.WriteLine("word inserted successfully");
            }
            else
            {
                InsertNode(Root, node);
                Console.WriteLine("word inserted successfully");

            }
        }
        
        #region tree traversals

        //Tree Pre Order

        public string TraversePreOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(node.ToString() + " "); // Add a space here
                sb.Append(TraversePreOrder(node.left));
                sb.Append(TraversePreOrder(node.right));
            }
            return sb.ToString();
        }
        //UI

        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("tree is empty");
            }
            else
            {
                sb.Append(TraversePreOrder(Root));
            }

            return sb.ToString();
        }


        // In-Order Traversal
        public string TraverseInOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraverseInOrder(node.left));
                sb.Append(node.ToString() + " "); // Add a space here
                sb.Append(TraverseInOrder(node.right));
            }

            return sb.ToString();
        }

        // UI
        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("Tree is empty");
            }
            else
            {
                sb.Append(TraverseInOrder(Root));
            }

            return sb.ToString();
        }



        // Post-Order Traversal
        public string TraversePostOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraversePostOrder(node.left));
                sb.Append(TraversePostOrder(node.right));
                sb.Append(node.ToString() + " "); // Add a space here
            }

            return sb.ToString();
        }

        // UI
        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("Tree is empty");
            }
            else
            {
                sb.Append(TraversePostOrder(Root));
            }

            return sb.ToString();
        }





        #endregion


        //delete method
        public Node Delete(Node tree, Node node)
        {

            int comparison = string.Compare(node.Data, tree.Data);

            if (tree == null)
            {
                //reached null side of the tree, return to unload stack 
                return tree;
            }

            if (comparison < 0)
            {
                //traverse left side to find node
                tree.left = Delete(tree.left, node);


            }
            else if (comparison > 0) 
            {
                //traverse right side to find node
                tree.right = Delete(tree.right, node);


            }
            else
            {
                //found node to delete
                //check if node has one child or no child
                if (tree.left == null)
                {
                    //pull right side of the tree up
                    return tree.right;
                }

                else if (tree.right == null)
                {
                    return tree.left;
                }

                else
                {
                    //node has two leaf nodes
                    tree.Data = MinValue(tree.right);

                    //traverse the left side of the tree to delete the inorder succesor

                    tree.right = Delete(tree.right, tree);
                }
                
            }
            return tree;
        }



        public string MinValue(Node node)
        {
            //finds the minimum node in the right side of the tree
            string minval = node.Data;
            while (node.left != null)
            {
                minval = node.left.Data;
                node = node.left;
            }

            return minval;
        }


        //UI method call

        public string Remove()
        {

            Console.WriteLine("Please enter the word you want to delete");
            string word = Console.ReadLine();
            Node node = new Node(word, word.Length);
            node = Search(Root, node);
            if (node != null)
            {
                Root = Delete(Root, node);
                return "Target: " + word.ToString() + ", Node removed";
            }
            else
            {
                return "Target: " + word.ToString() + ", Node not found";
            }
        }




        //query method

        public Node Search(Node tree, Node node)

        {

            if (tree != null)
            {
                int comparison = string.Compare(node.Data, tree.Data);
                //have not reached the end of the branch 
                if(comparison == 0)
                {
                    return tree;
                }

                else if(comparison < 0)
                {
                    return Search(tree.left, node);  //traverse the left subtree

                }
                else
                {
                    //traverse right side
                    return Search(tree.right, node);
                }
            }

            //not found
            return null;
        }



        public string Find(string data)
        {
            //turn the data into node first
            Node node = new Node(data, data.Length);

            node = Search(Root, node);

            if(node != null)
            {
                return "Target: " + data.ToString() + ", Node found: " + node.ToString();
            }
            else
            {
                return "Target: " + data.ToString() + ", Node not found ";
            }


        }


        #region extra methods


        //submenu for traversals

        Stopwatch sw = new Stopwatch();

        public void TraversalList()
        {
            Console.WriteLine("Select a method: ");
            Console.WriteLine();
            Console.WriteLine("1. In Order");
            Console.WriteLine("2. Pre Order");
            Console.WriteLine("3. Post Order");

            Console.WriteLine("Enter Your choice: ");
            string choice = Console.ReadLine();


            switch (choice)
            {
                case "1":

                    Console.WriteLine("*** In Order ***");
                    sw.Start();
                    Console.WriteLine(InOrder());
                    sw.Stop();
                    Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
                    Console.ReadKey();
                    break;

                case "2":

                    Console.WriteLine("*** Pre Order ***");
                    sw.Start();
                    Console.WriteLine(PreOrder());
                    sw.Stop();
                    Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
                    Console.ReadKey();
                    break;

                case "3":

                    Console.WriteLine("*** Post Order ***");
                    sw.Start();
                    Console.WriteLine(PostOrder());
                    sw.Stop();
                    Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
                    Console.ReadKey();
                    break;


            }
            Console.WriteLine();


        }


        #endregion






    }
}



