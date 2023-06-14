
namespace Forfront.Spiders
{
    public interface ISpidersUtility
    {
        bool ValidateWallSize(string input);
        bool ValidateSpiderInitialLocation(string input);
        bool ValidateSpiderWaypoints(string input);

        void GetWallSize(string input, SpiderContainer spiderContainer);
        void GetInitialLocation(string input, SpiderContainer spiderContainer);
        void GetWaypoints(string input, SpiderContainer spiderContainer);

        string ComputeResult(SpiderContainer spiderContainer);
    }
}