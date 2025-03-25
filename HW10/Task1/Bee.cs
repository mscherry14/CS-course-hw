using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Bee
    {
        private readonly HoneyPot _honeyPot;

        public Bee(HoneyPot honeyPot)
        {
            _honeyPot = honeyPot;
        }

        public async Task WorkAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await Task.Delay(new Random().Next(100, 500), token);
                await _honeyPot.AddHoneyAsync(token);
            }
        }
    }
}
