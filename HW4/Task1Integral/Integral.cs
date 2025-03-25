namespace Task1Integral
{
    public static class Task1Solution
    {
        public delegate double Function(double x);

        public static double Integrate(Function f, double a, double b, int n = 1000)
        {
            double h = (b - a) / n; 
            double sum = 0.5 * (f(a) + f(b));

            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                sum += f(x);
            }

            return sum * h;
        }
    }
}