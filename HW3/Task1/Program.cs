// See https://aka.ms/new-console-template for more information


var x=new
{
    Items = new List<int> { 1, 2, 3 }.GetEnumerator()
};
var enumerator = x.Items;
while (enumerator.MoveNext())
    Console.WriteLine(enumerator.Current);