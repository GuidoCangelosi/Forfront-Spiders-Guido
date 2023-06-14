
using System;

namespace Forfront.Spiders
{
    public class SpidersUtility : ISpidersUtility, IDisposable
    {
        bool _disposed = false;

        public bool ValidateWallSize(string input)
        {
            try
            {
                if(!string.IsNullOrEmpty(input))
                {
                    string[] values = input.Split(new char[1] { ' ' });
                    if (values.Length == 2)
                    {
                        if (int.TryParse(values[0], out int value1))
                        {
                            if (int.TryParse(values[1], out int value2))
                            {
                                if (value1 > 4 && value1 < 21)
                                {
                                    if (value2 > 4 && value2 < 21)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public bool ValidateSpiderInitialLocation(string input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    string[] values = input.Split(new char[1] { ' ' });
                    if (values.Length == 3)
                    {
                        if (int.TryParse(values[0], out int value1))
                        {
                            if (int.TryParse(values[1], out int value2))
                            {
                                if ((values[2] == "Left") || (values[2] == "Right") || (values[2] == "Up") || (values[2] == "Down"))
                                {
                                    if (value1 > -1 && value1 < 21)
                                    {
                                        if (value2 > -1 && value2 < 21)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public bool ValidateSpiderWaypoints(string input)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    input = input.Trim();

                    if (input.Length > 0)
                    {
                        string[] values = input.Split(new char[1] { ' ' });

                        if (values.Length == 1)  // means we have no blank spaces within string - it's all in one block
                        {
                            char[] waypoints = input.ToCharArray();

                            result = true;

                            foreach (char waypoint in waypoints)
                            {
                                if ((waypoint != 'F') && (waypoint != 'L') && (waypoint != 'R'))
                                {
                                    result &= false;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return result;
        }

        public void GetWallSize(string input, SpiderContainer spiderContainer)
        {
            string[] values = input.Split(new char[1] { ' ' });
            spiderContainer.WallHeight = int.Parse(values[0]);
            spiderContainer.WallWidth = int.Parse(values[1]);
        }

        public void GetInitialLocation(string input, SpiderContainer spiderContainer)
        {
            string[] values = input.Split(new char[1] { ' ' });
            spiderContainer.InitialLocationX = int.Parse(values[0]);
            spiderContainer.InitialLocationY = int.Parse(values[1]);
            spiderContainer.InitialOrientation = values[2];
        }

        /// <summary>
        /// it represents which path/waypoints the spiders will follow in terms of going fwd, turning left or right.
        /// this could be also named GetPath.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="spiderContainer"></param>
        public void GetWaypoints(string input, SpiderContainer spiderContainer)
        {
            spiderContainer.Waypoints = input.Trim().ToCharArray();
        }

        public string ComputeResult(SpiderContainer spiderContainer)
        {
            int currentX = spiderContainer.InitialLocationX;
            int currentY = spiderContainer.InitialLocationY;
            string currentOrientation = spiderContainer.InitialOrientation;

            foreach (char waypoint in spiderContainer.Waypoints) 
            {
                switch (waypoint)
                {
                    case 'F':
                        if (currentOrientation == "Right") currentX++;
                        if (currentOrientation == "Left") currentX--;
                        if (currentOrientation == "Up") currentY++;
                        if (currentOrientation == "Down") currentY--;
                        break;
                    case 'R':
                        if (currentOrientation == "Right") currentOrientation = "Down"; 
                        else if (currentOrientation == "Left") currentOrientation = "Up"; 
                        else if (currentOrientation == "Up") currentOrientation = "Right";
                        else if (currentOrientation == "Down") currentOrientation = "Left";
                        break;
                    case 'L':
                        if (currentOrientation == "Right") currentOrientation = "Up";
                        else if (currentOrientation == "Left") currentOrientation = "Down";
                        else if (currentOrientation == "Up") currentOrientation = "Left";
                        else if (currentOrientation == "Down") currentOrientation = "Right";
                        break;
                    default:
                        break;
                }
            }

            return $"{currentX} {currentY} {currentOrientation}";
        }

        /// <summary>
        /// at the moment we do not have any large .net objects to release nor do we have unmanaged objects such as database code, etc. 
        /// but I find it useful to prepare for future disposal and this enables me to execute the process with a USING keyword. (in Main())
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources here

            // TODO: set large fields to null if any

            _disposed = true;
        }
    }
}
