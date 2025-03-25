using Task1Integral;

namespace Tests;

[TestClass]
public class Task1IntegralTests
{
    [TestMethod]
    public void TestMethod1()
    {
    }

    [TestMethod]
    public void TestLinearFunction()
    {
        Task1Solution.Function linearFunction = x => x;
        double result = Task1Solution.Integrate(linearFunction, 0, 1);
        Assert.AreEqual(0.5, result, 1e-5);
    }

    [TestMethod]
    public void TestQuadraticFunction()
    {
        Task1Solution.Function quadraticFunction = x => x * x;
        double result = Task1Solution.Integrate(quadraticFunction, 0, 1);
        Assert.AreEqual(1.0 / 3.0, result, 1e-5);
    }

    [TestMethod]
    public void TestSinFunction()
    {
        Task1Solution.Function sinFunction = Math.Sin;
        double result = Task1Solution.Integrate(sinFunction, 0, Math.PI);
        Assert.AreEqual(2.0, result, 1e-5); 
    }

    [TestMethod]
    public void TestExpFunction()
    {
        Task1Solution.Function expFunction = Math.Exp;
        double result = Task1Solution.Integrate(expFunction, 0, 1);
        Assert.AreEqual(Math.E - 1, result, 1e-5);
    }
}