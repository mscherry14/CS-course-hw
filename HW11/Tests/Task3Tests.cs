using System.Text;
using Task3;

namespace Tests;

[TestClass]
public class Task3Tests
{
    [TestMethod]
    public void Test_H2O_WithInput_HOH()
    {
        // Arrange
        var h2o = new H2O();
        var output = new StringBuilder();

        // Act
        var threadH1 = new Thread(() => h2o.Hydrogen(() => output.Append("H")));
        var threadO = new Thread(() => h2o.Oxygen(() => output.Append("O")));
        var threadH2 = new Thread(() => h2o.Hydrogen(() => output.Append("H")));

        threadH1.Start();
        threadO.Start();
        threadH2.Start();

        threadH1.Join();
        threadO.Join();
        threadH2.Join();

        // Assert
        var validResults = new List<string> { "HOH", "OHH", "HHO" };
        CollectionAssert.Contains(validResults, output.ToString());
    }

    [TestMethod]
    public void Test_H2O_WithInput_OOHHHH()
    {
        // Arrange
        var h2o = new H2O();
        var output = new StringBuilder();

        // Act
        var threadO1 = new Thread(() => h2o.Oxygen(() => output.Append("O")));
        var threadO2 = new Thread(() => h2o.Oxygen(() => output.Append("O")));
        var threadH1 = new Thread(() => h2o.Hydrogen(() => output.Append("H")));
        var threadH2 = new Thread(() => h2o.Hydrogen(() => output.Append("H")));
        var threadH3 = new Thread(() => h2o.Hydrogen(() => output.Append("H")));
        var threadH4 = new Thread(() => h2o.Hydrogen(() => output.Append("H")));

        threadO1.Start();
        threadO2.Start();
        threadH1.Start();
        threadH2.Start();
        threadH3.Start();
        threadH4.Start();

        threadO1.Join();
        threadO2.Join();
        threadH1.Join();
        threadH2.Join();
        threadH3.Join();
        threadH4.Join();

        // Assert
        Assert.AreEqual(6, output.Length);
        Assert.AreEqual(2, output.ToString().Split('O').Length - 1); 
        Assert.AreEqual(4, output.ToString().Split('H').Length - 1); 
    }
}
