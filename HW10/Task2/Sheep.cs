namespace Task2
{
    public class Sheep
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Sheep(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(Random random, int N)
        {
            int direction = random.Next(0, 8); 
            MoveInDirection(direction, N);
        }

        private void MoveInDirection(int direction, int N)
        {
            switch (direction)
            {
                case 0: X = (X - 1 + N) % N; Y = (Y - 1 + N) % N; break;
                case 1: X = (X - 1 + N) % N; break; 
                case 2: X = (X - 1 + N) % N; Y = (Y + 1) % N; break; 
                case 3: Y = (Y - 1 + N) % N; break; 
                case 4: Y = (Y + 1) % N; break; 
                case 5: X = (X + 1) % N; Y = (Y - 1 + N) % N; break;
                case 6: X = (X + 1) % N; break;
                case 7: X = (X + 1) % N; Y = (Y + 1) % N; break; 
            }
        }
    }
}
