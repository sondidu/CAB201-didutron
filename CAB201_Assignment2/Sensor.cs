﻿using CustomExceptions;

namespace Didutron
{
    public class Sensor : Obstacle
    {
        private const char DEFAULT_SENSOR_CHAR = 'S';
        private readonly double radius;
        private const string INVALID_RADIUS_MSG = "Range must be a valid positive number.";
        public Sensor(string[] args) : base(args[0], args[1])
        {
            if (!double.TryParse(args[2], out double radius) || radius <= 0)
            {
                throw new DoubleArgumentException(INVALID_RADIUS_MSG);
            }
            this.radius = radius;
            charRep = DEFAULT_SENSOR_CHAR;
        }
        public override bool HitObstacle(int targetX, int targetY)
        {
            double diffX = targetX - x;
            double diffY = targetY - y;
            return diffX * diffX + diffY * diffY < radius * radius; 
        }
    }
}
