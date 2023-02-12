using SFML.System;

namespace LiliumEngine.Basics
{
    public class Timer
    {
        private float tickInterval;
        private Clock clock;
        public float TickInterval
        {
            get => tickInterval;

            set
            {
                if (value > 0) tickInterval = value;
                else throw new ArgumentOutOfRangeException("Value is less than zero.");
            }
        }
        public bool Ticked
        {
            get
            {
                if (clock.ElapsedTime.AsMilliseconds() >= tickInterval)
                {
                    this.Restart();
                    return true;
                }
                else
                    return false;
            }
        }

        public Timer(float tickInterval)
        {
            this.tickInterval = tickInterval;
            this.clock = new Clock();
        }

        public void Start()
        {
            this.clock = new Clock();
        }

        public void Restart()
        {
            clock.Restart();
        }
    }
}
