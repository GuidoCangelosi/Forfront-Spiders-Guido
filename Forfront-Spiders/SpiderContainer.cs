
namespace Forfront.Spiders
{
    /// <summary>
    /// Container class for the spider path parameters
    /// </summary>
    public class SpiderContainer
    {
        public int WallHeight { get; set; }
        public int WallWidth { get; set; }
        public int InitialLocationX { get; set; }
        public int InitialLocationY { get; set; }
        public string InitialOrientation { get; set; }
        public char[] Waypoints { get; set; }
    }
}
