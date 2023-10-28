using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TreeAssignment
{
    internal class AvlTree 
    {

        public Node1 Root { get; set; }

        public AvlTree()
        {
            Root = null;
        }



        // Insert method
        private Node1 InsertNode(Node1 tree, Node1 node)
        {
            // Check if the current subtree is null, insert the node here
            if (tree == null)
            {
                tree = node;
                return tree;
            }

            int comparison = string.Compare(tree.Data, node.Data);

            if (comparison < 0)
            {
                // Traverse the left side and insert when null, then balance the tree
                tree.Left = InsertNode(tree.Left, node);
            }
            else if (comparison > 0)
            {
                // Traverse the right side and insert when null, then balance the tree
                tree.Right = InsertNode(tree.Right, node);
            }

            // Balance the tree after insertion
            tree = BalanceTree(tree);

            return tree;
        }



        //UI method call

        public void Add1(string data)
        {
            Node1 node = new Node1(data, data.Length);

            if (Root == null)
            {
                //Tree is empty
                Root = node;
            }
            else
            {
                Root = InsertNode(Root, node);
            }
        }



        private Node1 BalanceTree(Node1 current)
        {

            //obtain a balance reference from height of both left and right subtrees from current node
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                //left side of tree is unbalanced
                //decide left or right rotation
                if (BalanceFactor(current.Left) > 0)
                {
                    //left side requires rotation, perform a left subtree rotation 
                    current = RotateLL(current);
                }
                else
                {
                    //right side requires rotation, perform a right subtree rotation
                    current = RotateLR(current);

                }
            }

            else if(b_factor < -1)
            {
                //right side of the tree is unbalanced
                //decide a left or right rotation 

                if (BalanceFactor(current.Right) > 0)
                {
                    //left side rotation
                    current = RotateRL(current);

                }
                else
                {
                    //right side requires rotation 
                    current = RotateRR(current);
                }
            }
            return current;

        }


        public Node1 RotateRR(Node1 parent)
        {
            Node1 pivot = parent.Right;
            parent.Right = parent.Left;
            pivot.Left = parent;
            return pivot;
        }


        public Node1 RotateRL(Node1 parent)
        {
            Node1 pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);


        }


        public Node1 RotateLL (Node1 parent)
        {
            Node1 pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;

        }


        public Node1 RotateLR(Node1 parent)
        {
            Node1 pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent)
;        }


        public int GetHeight(Node1 root)
        {
            if (root == null)
            {
                return 0;  // Height of an empty tree is 0.
            }

            int height = 0;
            Stack<Tuple<Node1, int>> stack = new Stack<Tuple<Node1, int>>();
            stack.Push(new Tuple<Node1, int>(root, 1));

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Node1 node = current.Item1;
                int currentHeight = current.Item2;

                height = Math.Max(height, currentHeight);

                if (node.Left != null)
                {
                    stack.Push(new Tuple<Node1, int>(node.Left, currentHeight + 1));
                }

                if (node.Right != null)
                {
                    stack.Push(new Tuple<Node1, int>(node.Right, currentHeight + 1));
                }
            }

            return height;
        }




        public int BalanceFactor(Node1 current)
        {
            int left = GetHeight(current.Left);
            int right = GetHeight(current.Right);
            int b_factor = left - right;
            return b_factor;
        }



        //traveral methods

        public string TraversePreOrder(Node1 node)
        {
            StringBuilder sb = new StringBuilder();
            
            if(node != null)
            {
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));

            }
            return sb.ToString();
        }

        public string PreOrder1()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE IS EMPTy");
            }
            else
            {
                sb.Append(TraversePreOrder(Root));

            }

            return sb.ToString();
        }


        // InOrder traversal
        public string InOrder1()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE IS EMPTY");
            }
            else
            {
                InOrderTraversal(Root, sb);
            }

            return sb.ToString();
        }

        private void InOrderTraversal(Node1 node, StringBuilder sb)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, sb);
                sb.Append(node.Data + " ");
                InOrderTraversal(node.Right, sb);
            }
        }

        // PostOrder traversal
        public string PostOrder1()
        {
            StringBuilder sb = new StringBuilder();
            if (Root == null)
            {
                sb.Append("TREE IS EMPTY");
            }
            else
            {
                PostOrderTraversal(Root, sb);
            }

            return sb.ToString();
        }

        private void PostOrderTraversal(Node1 node, StringBuilder sb)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left, sb);
                PostOrderTraversal(node.Right, sb);
                sb.Append(node.Data + " ");
            }
        }


        public Node1 Delete(Node1 current, Node1 target)
        {
            if (current == null)
            {
                return current;
            }

            int comparison = string.Compare(current.Data, target.Data);

            if (comparison < 0)
            {
                current.Left = Delete(current.Left, target);
                if (BalanceFactor(current) == -2)
                {
                    if (BalanceFactor(current.Right) <= 0)
                    {
                        current = RotateRR(current);
                    }
                    else
                    {
                        current = RotateRL(current);
                    }
                }
            }
            else if (comparison > 0)
            {
                current.Right = Delete(current.Right, target);
                if (BalanceFactor(current) == 2)
                {
                    if (BalanceFactor(current.Left) >= 0)
                    {
                        current = RotateLL(current);
                    }
                    else
                    {
                        current = RotateLR(current);
                    }
                }
            }
            else
            {
                // target found
                if (current.Right != null)
                {
                    Node1 parent = current.Right;
                    while (parent.Left != null)
                    {
                        parent = parent.Left;
                    }
                    current.Data = parent.Data;
                    current.Right = Delete(current.Right, parent);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                else
                {
                    // target is in this node
                    // with no right subtree, this is easy, just replace with left subtree
                    current = current.Left;
                }
            }

            return current;
        }


        //UI method call
        public string Remove1()
        {
            Console.WriteLine("Please enter the word You want to remove: ");
            string data = Console.ReadLine();
            Node1 node = new Node1(data, data.Length);
            node = Search(Root, node); //optional
            if (node != null)
            {
                Root = Delete(Root, node);
                return "Target: " + data.ToString() + ", Node removed";
            }
            else
            {
                return "Target: " + data.ToString() + ", Node not found or tree empty";
            }
            
        }





        //Search method

        public Node1 Search(Node1 tree, Node1 node)
        {

            int comparison = string.Compare(tree.Data, node.Data);
            if (tree != null)
            {
                //have not reached the end of a branch
                if (node.Data == tree.Data)
                {
                    return tree;

                }
                else
                {
                    //traverse right side
                    return Search(tree.Right, node);
                }
            }
            return null;
        }


        public string Find1(string data)
        {
            Node1 node = new Node1(data, data.Length);
            node = Search(Root, node);
            if (node != null)
            {
                return "Target: " + data + ", Node found: " + node.Data;
            }
            else
            {
                return "Target: " + data + ", Node not found";
            }
        }





        




    }
}
