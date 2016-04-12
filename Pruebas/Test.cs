using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCCAMNET.NPI;
namespace Pruebas
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public static void TestMethod1()
        {
            RPN rpn = new RPN();
            Console.Write("Type infix expression [ctrl+c to brake]: ");
            string infix = Console.ReadLine();
            Console.WriteLine("Result: {0}", rpn.Eval(infix).Content);
        }
    }
}
