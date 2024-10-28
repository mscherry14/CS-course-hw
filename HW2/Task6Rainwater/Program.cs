// See https://aka.ms/new-console-template for more information

using Task6Rainwater;

int num = Convert.ToInt32(Console.ReadLine());
int[] heights = new int[num];
for (int i = 0; i < num; i++)
{
    heights[i] = Convert.ToInt32(Console.ReadLine()); 
}
Console.WriteLine(RainwaterCounter.Count(ref heights));