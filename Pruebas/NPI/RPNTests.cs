using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCCAMNET.NPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCCAMNET.NPI.Tests
{
    [TestClass()]
    public class RPNTests
    {
        [TestMethod()]
        public void ToRPNTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public async Task EvalTest()
        {
            RPN rpn = new RPN();
            Console.Write("Type infix expression [ctrl+c to brake]: ");
            string infix = "AX = 5 + 90";
            string lol = rpn.Eval(infix).Content;
        }
    }
}