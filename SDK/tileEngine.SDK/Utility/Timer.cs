using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tileEngine.SDK.Utility
{
    /// <summary>
    /// A flexible timer class that can be used to trigger events on a clock tick.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// The time remaining to tick before the timer event is fired.
        /// </summary>
        public double TickLength { get; set; }

        /// <summary>
        /// Whether this timer loops or not.
        /// </summary>
        public bool Loop { get; set; } = false;

        /// <summary>
        /// Whether this timer is currently running or not.
        /// </summary>
        public bool Running { get; private set; } = false;

        /// <summary>
        /// Event triggered when this timer ticks over.
        /// </summary>
        public event OnTimerTickHandler OnTick;
        public delegate void OnTimerTickHandler();

        //The time remaining on the timer.
        private double timeRemaining = 0;

        /// <summary>
        /// Creates a timer, optionally setting the number of seconds remaining on the clock.
        /// </summary>
        public Timer(float seconds = 0)
        {
            TickLength = seconds;
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start() { Running = true; }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop() { Running = false; }

        /// <summary>
        /// Resets the timer to the start of the time tick.
        /// </summary>
        public void Reset() { timeRemaining = TickLength; }

        /// <summary>
        /// Updates this timer.
        /// Should be called every update tick.
        /// </summary>
        public void Update(GameTime delta)
        {
            //Nothing to tick.
            if (!Running)
                return;

            //Decrease time left, check if finished.
            timeRemaining -= delta.ElapsedGameTime.TotalSeconds;
            if (timeRemaining < 0)
            {
                timeRemaining = 0;
                OnTick?.Invoke();

                //Reset depending on looping.
                if (Loop)
                {
                    timeRemaining = TickLength;
                }
                else
                {
                    Running = false;
                }
            }
        }
    }
}
