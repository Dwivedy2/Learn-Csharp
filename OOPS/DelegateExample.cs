namespace OOPS
{
    internal class DelegateExample
    {
        public static void Start()
        {
            // Without Delegates, making object of OperationManage and then,
            // passing enums
            OperationManage opManage = new OperationManage(20, 30);
            int? result = opManage.StartOperation(Operation.Sum);
            if (result.HasValue)
            { 
                Console.WriteLine($"Result: {result}");
            }

            // With Delegates
            OperationManageDelegate opMgDel = new OperationManageDelegate(20, 30);
            result = opMgDel.GetOperationResult(Operation.Sum);
            if ( result.HasValue )
            {
                Console.WriteLine($"Result: {result}");
            }

        }
    }

    enum Operation
    {
        Sum,
        Subtract,
        Multiply
    }

    class OperationManage
    {
        int numb1,
            numb2;

        public OperationManage(int numb1, int numb2)
        {
            this.numb1 = numb1;
            this.numb2 = numb2;
        }

        public int Sum()
        {
            return numb1 + numb2;
        }

        public int Subtract()
        {
            return numb1 - numb2;
        }

        public int Multiply()
        {
            return numb1 * numb2;
        }

        public int? StartOperation(Operation op)
        {
            int? result = null;
            switch (op)
            {
                case Operation.Sum:
                    result = Sum();
                    break;
                case Operation.Subtract:
                    result = Subtract();
                    break;
                case Operation.Multiply:
                    result = Multiply();
                    break;
            }
            return result;
        }
    }

    class OperationManageDelegate
    {
        int n1,
            n2;

        Func<int> _sum;
        Func<int> _sub;
        Func<int> _mul;

        Dictionary<Operation, Func<int>> _dictionary = new Dictionary<Operation, Func<int>>();

        public OperationManageDelegate(int n1, int n2)
        {
            this.n1 = n1;
            this.n2 = n2;

            _sum = Sum;
            _sub = Subtract; 
            _mul = Multiply;

            _dictionary.Add(Operation.Sum, _sum);
            _dictionary.Add(Operation.Subtract, _sub);
            _dictionary.Add(Operation.Multiply, _mul);
        }

        public int? GetOperationResult(Operation op) 
        {
            int? result = null;

            if (_dictionary.ContainsKey(op))
            {
                result = _dictionary[op]();
            }

            return result;
        }

        int Sum()
        {
            return n1 + n2;
        }

        int Subtract()
        {
            return n1 - n2;
        }

        int Multiply()
        {
            return n1 * n2;
        }
    }
}
