using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordHW1;
using System;

namespace PasswordHW1.Tests;

[TestClass]
[TestSubject(typeof(PasswordGenerator))]
public class PasswordGeneratorTest
{
    [TestMethod]
    public void IsLengthLessOrEqualThan20SymbolsTest()
    {
        PasswordGenerator pg = new PasswordGenerator();
        string password = pg.GetPassword();
        Assert.IsTrue(password.Length < 21);
    }
    
    [TestMethod]
    public void IsLengthMoreOrEqualThan6SymbolsTest()
    {
        PasswordGenerator pg = new PasswordGenerator();
        string password = pg.GetPassword();
        Assert.IsTrue(password.Length > 5);
    }
    
    [TestMethod]
    public void NumbersDoNotGoInARowTest()
    {
        PasswordGenerator pg = new PasswordGenerator();
        string password = pg.GetPassword();

        for (int i = 0; i < password.Length - 1; i++)
        {
            if (Char.IsNumber(password[i]))
            {
                Assert.IsTrue(!Char.IsNumber(password[i + 1]));
            }
        }
    }
    
    [TestMethod]
    public void HasUnderscoreTest()
    {
        PasswordGenerator pg = new PasswordGenerator();
        string password = pg.GetPassword();
        Assert.IsTrue(password.IndexOf('_') > -1);
    }

    [TestMethod]
    public void HasAtLeastTwoUpperLettersTest()
    {
        PasswordGenerator pg = new PasswordGenerator();
        string password = pg.GetPassword();

        int uppercaseLettersNumber = 0;
        string uppercaseAlphabet = "QWERTYUIOPASDFGHJKLZXCVBNM";
        for (int i = 0; i < password.Length; i++)
        {
            if (uppercaseAlphabet.IndexOf(password[i]) > -1)
            {
                uppercaseLettersNumber++;
            }
        }

        Assert.IsTrue(uppercaseLettersNumber >= 2);
    }

    [TestMethod]
    public void HasLessOrEqualThanFiveNumbersTest()
    {
        PasswordGenerator pg = new PasswordGenerator();
        string password = pg.GetPassword();

        int numbersNum = 0;
        string numbersAlphabet = "0123456789";
        for (int i = 0; i < password.Length; i++)
        {
            if (numbersAlphabet.IndexOf(password[i]) > -1)
            {
                numbersNum++;
            }
        }

        Assert.IsTrue(numbersNum <= 5);
    }
}