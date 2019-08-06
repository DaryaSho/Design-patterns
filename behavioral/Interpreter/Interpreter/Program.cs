using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            int a = 2; int b = 8; int c = 3;
            context.SetVariable("a", a);
            context.SetVariable("b", b);
            context.SetVariable("c", c);
            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new NumberExpression("a"), new NumberExpression("b")),
                new NumberExpression("c"));
            int result = expression.Interpret(context);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    class Context
    {
        Dictionary<string, int> variables;
        public Context()
        {
            variables = new Dictionary<string, int>();
        }
        public int GetVariable(string name)
        {
            return variables[name];
        }
        public void SetVariable(string name, int value)
        {
            if (variables.ContainsKey(name))
            {
                variables[name] = value;
            }
            else
            {
                variables.Add(name, value);
            }
        }
    }
    interface IExpression
    {
        int Interpret(Context context);
    }

    class NumberExpression : IExpression
    {
        string name;
        public NumberExpression(string varialeName)
        {
            name = varialeName;
        }
        public int Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
    class AddExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;
        public AddExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) + rightExpression.Interpret(context);
        }
    }
    class SubtractExpression : IExpression
    {
        IExpression leftExpression;
        IExpression rightExpression;
        public SubtractExpression(IExpression left, IExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return leftExpression.Interpret(context) - rightExpression.Interpret(context);
        }
    }
}
