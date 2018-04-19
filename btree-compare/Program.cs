using System;

namespace fragile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running task 1 - compare bTrees.");
            var comparer = new BTNComparer();
            comparer.run();

            Console.ReadLine();
        }

    }

    class BTN
    {
        public BTN(int val)
        {
            this.val = val;
        }
        public int val;
        public BTN left;
        public BTN right;
    }

    class BTNComparer
    {
        public void run()
        {
            BTN a = new BTN(1)
            {
                left = new BTN(2),
                right = new BTN(3)
                {
                    left = new BTN(4),
                    right = new BTN(5)
                }
            };

            BTN b = new BTN(1)
            {
                left = new BTN(2)
                {
                    left = new BTN(4),
                    right = new BTN(5)
                },
                right = new BTN(3)
            };

            BTN c = new BTN(1)
            {
                left = new BTN(2),
                right = new BTN(3)
                {
                    left = new BTN(4),
                    right = new BTN(5)
                }
            };

            BTN d = new BTN(1)
            {
                left = new BTN(2)
                {
                    left = new BTN(4),
                    right = new BTN(5)
                },
                right = new BTN(3)
            };

            Console.WriteLine("Is a equal to b? {0}", BTreesAreEquals(a, b));
            Console.WriteLine("Is a equal to c? {0}", BTreesAreEquals(a, c));
            Console.WriteLine("Is a equal to d? {0}", BTreesAreEquals(a, d));
            Console.WriteLine("Is b equal to c? {0}", BTreesAreEquals(b, c));
            Console.WriteLine("Is b equal to d? {0}", BTreesAreEquals(b, d));
        }

        bool BTreesAreEquals(BTN a, BTN b)
        {
            // se AMBOS forem nulos, então são iguais
            if( a == null && b == null )
                return true;

            // se SOMENTE UM for nulo, então são diferentes
            if( a == null || b == null )
                return false;

            // AMBOS são NÃO-NULOS, então todas propriedades devem ser iguais
            return (a.val == b.val) &&
                   BTreesAreEquals(a.left, b.left) &&
                   BTreesAreEquals(a.right, b.right);
        }
    }   

}
