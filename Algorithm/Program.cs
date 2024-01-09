
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Lütfen bir string giriniz: ");
        string input = Console.ReadLine();

        PrintTreeStructure(input);
    }

    static void PrintTreeStructure(string input)
    {
        var stack = new Stack<Node>();
        var root = new Node(' ', -1);
        stack.Push(root);

        foreach (var ch in input)
        {
            if (stack.Any(node => node.Value == ch))
            {
                while (stack.Peek().Value != ch)
                {
                    stack.Pop();
                }
                stack.Pop(); // Tekrar eden elemanı çıkart
            }
            else
            {
                var newNode = new Node(ch, stack.Count - 1);
                stack.Peek().Children.Add(newNode);
                stack.Push(newNode);
            }
        }

        PrintNodes(root.Children, 0);
    }

    static void PrintNodes(List<Node> nodes, int depth)
    {
        foreach (var node in nodes)
        {
            Console.WriteLine(new String('-', depth) + node.Value);
            PrintNodes(node.Children, depth + 1);
        }
    }

    class Node
    {
        public char Value { get; }
        public List<Node> Children { get; }

        public Node(char value, int depth)
        {
            Value = value;
            Children = new List<Node>();
        }
    }
}
