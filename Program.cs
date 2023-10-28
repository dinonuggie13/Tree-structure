    using System.Diagnostics;
    using System;
    using TreeAssignment;
    using System.IO;


   


internal class Program
{
    static void Main(string[] args)
    {
        BSTree bstTree = new BSTree();
        AvlTree avlTree = new AvlTree();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("           Choose A Tree           ");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("1. Binary Search Tree (BST)");
            Console.WriteLine("2. AVL Tree");
            Console.WriteLine("3. Exit");

            Console.WriteLine("-----------------------------------");
            Console.Write("Enter your choice: ");
            string treeChoice = Console.ReadLine();

            Console.Clear();

            switch (treeChoice)
            {
                case "1":
                    // Binary Search Tree (BST) operations
                    RunBSTMenu(bstTree);
                    break;

                case "2":
                    // AVL Tree operations
                    RunAVLMenu(avlTree);
                    break;

                case "3":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RunBSTMenu(BSTree bstTree)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("      Binary Search Tree (BST) Menu");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("1. Load Files");
            Console.WriteLine("2. Tree Traversal");
            Console.WriteLine("3. Add Operation");
            Console.WriteLine("4. Delete Operation");
            Console.WriteLine("5. Search Operation");
            Console.WriteLine("6. Back to Tree Type Selection");

            Console.WriteLine("--------------------------------------");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    LoadFiles(bstTree);
                    break;

                case "2":
                    // Tree Traversal operations for BST
                    Console.WriteLine("Pre-Order Traversal:");
                    Console.WriteLine(bstTree.PreOrder());
                    Console.WriteLine("In-Order Traversal:");
                    Console.WriteLine(bstTree.InOrder());
                    Console.WriteLine("Post-Order Traversal:");
                    Console.WriteLine(bstTree.PostOrder());
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("           ***Add Method***           ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter a word to add: ");
                    string word = Console.ReadLine();
                    bstTree.Add(word);
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("          ***Delete Method***         ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--------------------------------------");
                    string removeResult = bstTree.Remove();
                    Console.WriteLine(removeResult);
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("          ***Search method***         ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter a word to find: ");
                    string find = Console.ReadLine();
                    string findResult = bstTree.Find(find);
                    Console.WriteLine(findResult);
                    Console.ReadKey();
                    break;

                case "6":
                    exit = true;
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RunAVLMenu(AvlTree avlTree)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("      AVL Tree Menu");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. Load Files");
            Console.WriteLine("2. Tree Traversal");
            Console.WriteLine("3. Add Operation");
            Console.WriteLine("4. Delete Operation");
            Console.WriteLine("5. Search Operation");
            Console.WriteLine("6. Back to Tree Type Selection");

            Console.WriteLine("--------------------------------------------------");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    LoadFiles2(avlTree);
                    break;

                case "2":
                    // Tree Traversal operations for AVL Tree
                    Console.WriteLine("Pre-Order Traversal:");
                    Console.WriteLine(avlTree.PreOrder1());
                    Console.WriteLine("In-Order Traversal:");
                    Console.WriteLine(avlTree.InOrder1());
                    Console.WriteLine("Post-Order Traversal:");
                    Console.WriteLine(avlTree.PostOrder1());
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("           ***Add Method***           ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter a word to add: ");
                    string word = Console.ReadLine();
                    avlTree.Add1(word);
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("          ***Delete Method***         ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--------------------------------------");
                    string removeResult = avlTree.Remove1();
                    Console.WriteLine(removeResult);
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("          ***Search method***         ");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("Enter a word to find: ");
                    string find = Console.ReadLine();
                    string findResult = avlTree.Find1(find);
                    Console.WriteLine(findResult);
                    Console.ReadKey();
                    break;

                case "6":
                    exit = true;
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void LoadFiles(BSTree tree)
    {
        string directoryPath = @"C:\Users\helle\OneDrive\Documents\files"; // Replace with the actual directory path
        string[] files = Directory.GetFiles(directoryPath, "*.txt"); // Filter to select only text files

        Console.WriteLine("Select a file to load:");
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        Console.Write("Enter the file number to load: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int fileNumber) && fileNumber >= 1 && fileNumber <= files.Length)
        {
            string selectedFilePath = files[fileNumber - 1];

            using (StreamReader reader = new StreamReader(selectedFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.StartsWith("#")) // Ignore lines starting with #
                    {
                        string[] words = line.Split(' '); // Split the line into words
                        foreach (string word in words)
                        {
                            tree.Add(word.Trim()); // Add each word to the tree
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid file number. Please try again.");
        }

        Console.WriteLine("File was loaded successfully.");
    }


    public static void LoadFiles2(AvlTree tree)
    {
        string directoryPath = @"C:\Users\helle\OneDrive\Documents\files"; // Replace with the actual directory path
        string[] files = Directory.GetFiles(directoryPath, "*.txt"); // Filter to select only text files

        if (files.Length == 0)
        {
            Console.WriteLine("No text files found in the specified directory.");
            return;
        }

        Console.WriteLine("Select a file to load:");
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
        }

        Console.Write("Enter the file number to load (1 - " + files.Length + "): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int fileNumber) && fileNumber >= 1 && fileNumber <= files.Length)
        {
            string selectedFilePath = files[fileNumber - 1];

            using (StreamReader reader = new StreamReader(selectedFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.StartsWith("#")) // Ignore lines starting with #
                    {
                        string[] words = line.Split(' '); // Split the line into words
                        foreach (string word in words)
                        {
                            tree.Add1(word.Trim()); // Add each word to the AVL tree and rebalance
                            Console.WriteLine("->" + word);
                        }
                    }
                }
            }

            Console.WriteLine("File was loaded successfully into the AVL tree.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid file number.");
        }
    }



}
