using System;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                //Prompts user to enter a number, calls on the 'getNumber' method
                //and stores the returned value in 'leftOperand' variable
                Console.Clear();
                Console.WriteLine("Please enter your first operand, then press enter. ( number )");
                decimal leftOperand = getNumber();

                //Prompts user to select an operator, calls on the 'getOperator' method
                //and stores the desired operator in 'operation' variable
                Console.Clear();
                Console.WriteLine($"{leftOperand}\n Please enter an operator, then press enter. ( +, -, *, or / )"); 
                string operation = getOperator();

                //Prompts user to enter another number, calls on the 'getNumber' method
                //and stores the returned value in 'rightOperand' variable
                Console.Clear();
                Console.WriteLine($"{leftOperand} {operation}\n Please enter your second operand, then press enter. ( number )");
                decimal rightOperand = getNumber();

                //Passes the left operand, the right operand, and the operator 
                //to the 'calculate' method. The returned message is displayed.
                Console.Clear();
                Console.WriteLine(calculate(leftOperand, rightOperand, operation) + "\n Would you like to perform another calculation? (Y/n)");

                //If user wishes to continue, 'Y' or 'y' is the
                //expected reply. Based on this value, loop
                //continues or stops.
                string reply = Console.ReadLine().ToLower();
                run = reply == "y" ? true : false;
            }
        }
        private static decimal getNumber()
        {
            // Takes in user input, attempts to parse it, 
            // and returns the parsed value. If user input overflows
            // decimal type explanatory message is displayed for user, 
            // and method runs again.
            bool noNumber = true;
            decimal number = default;
            while(noNumber)
            {
                if (!decimal.TryParse(Console.ReadLine(), out number))
                {
                    Console.WriteLine($"Please enter a valid number, between {decimal.MinValue} & {decimal.MaxValue}.");
                }
                else
                {
                    noNumber = false;
                }
            }
            return number;
        }

        private static string getOperator()
        {
            // Takes in user input, checks it's validity as an operator. 
            // If operator is not valid, explanatory message is displayed 
            // for user, and method runs again.
            bool noOperator = true;
            string operation = default;
            while(noOperator)
            {
                operation = Console.ReadLine();
                string[] symbols = {"+", "-", "*", "/"};
                if(!symbols.Contains(operation))
                {
                    Console.WriteLine("Please enter a valid operator.");
                }
                else
                {
                    noOperator = false;
                }
            }
            return operation;
        }

        private static string calculate(decimal leftOperand, decimal rightOperand, string operation)
        {
            // Takes in both operands and an operator, performs
            // calculation, and returns calculation and result 
            // as a string. If exceptions occur, explanatory 
            // message is displayed for user.
            string message = default;
            try
            {
                decimal answer = default;
                switch(operation)
                {
                    case "+":
                        answer = leftOperand + rightOperand;
                        break;
                    case "-":
                        answer = leftOperand - rightOperand;
                        break;
                    case "*":
                        answer = leftOperand * rightOperand;
                        break;
                    case "/":
                        answer = leftOperand / rightOperand;
                        break;
                }
                message = $"{leftOperand} {operation} {rightOperand} = {answer}";
            }
            catch (System.OverflowException)
            {
                message ="Value was either too large or too small. Please try again.";
            }
            catch (System.DivideByZeroException)
            {
                message ="You cannot divide by zero. Please try again.";
            }
            return message;
        }
    }
}
