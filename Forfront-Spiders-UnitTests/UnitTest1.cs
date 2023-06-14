
using f = Forfront.Spiders;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region ValidateWallSize

        [Test]
        public void ValidateWallSizeWhenCorrectValuesGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 9";

            // Act
            bool result = utility.ValidateWallSize(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateWallSizeWhenIncorrectValuesGivenTest1()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5";

            // Act
            bool result = utility.ValidateWallSize(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateWallSizeWhenIncorrectValuesGivenTest2()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = " ";

            // Act
            bool result = utility.ValidateWallSize(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateWallSizeWhenIncorrectValuesGivenTest3()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "4 11";

            // Act
            bool result = utility.ValidateWallSize(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateWallSizeWhenIncorrectValuesGivenTest4()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 31";

            // Act
            bool result = utility.ValidateWallSize(input);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region ValidateSpiderInitialLocation

        [Test]
        public void ValidateSpiderInitialLocationWhenCorrectValuesLeftGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 9 Left";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateSpiderInitialLocationWhenCorrectValuesRightGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 9 Right";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateSpiderInitialLocationWhenCorrectValuesUpGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 9 Up";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateSpiderInitialLocationWhenCorrectValuesDownGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 9 Down";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateSpiderInitialLocationWhenIncorrectValuesLEFTGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 9 LEFT";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateSpiderInitialLocationWhenIncorrectValuesTooHighGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "5 29 Left";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateSpiderInitialLocationWhenIncorrectValuesTooLowGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "-1 19 Left";

            // Act
            bool result = utility.ValidateSpiderInitialLocation(input);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region ValidateSpiderWaypoints

        [Test]
        public void ValidateSpiderWaypointsWhenCorrectValuesGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "FLR";

            // Act
            bool result = utility.ValidateSpiderWaypoints(input);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateSpiderWaypointsWhenIncorrectValuesGivenTest1()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "FLA";

            // Act
            bool result = utility.ValidateSpiderWaypoints(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateSpiderWaypointsWhenIncorrectValuesGivenTest2()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "FLaFL";

            // Act
            bool result = utility.ValidateSpiderWaypoints(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateSpiderWaypointsWhenIncorrectValuesGivenTest3()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            string input = "FL FL";

            // Act
            bool result = utility.ValidateSpiderWaypoints(input);

            // Assert
            Assert.IsFalse(result);
        }

        #endregion

        #region Getting the input data

        [Test]
        public void GetWallSizeWhenCorrectValuesGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            f.SpiderContainer container = new f.SpiderContainer();
            string input = "6 9";

            // Act
            utility.GetWallSize(input, container);

            // Assert
            Assert.That(container.WallHeight, Is.EqualTo(6));
            Assert.That(container.WallWidth, Is.EqualTo(9));
        }

        [Test]
        public void GetInitialLocationWhenCorrectValuesGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            f.SpiderContainer container = new f.SpiderContainer();
            string input = "9 14 Right";

            // Act
            utility.GetInitialLocation(input, container);

            // Assert
            Assert.That(container.InitialLocationX, Is.EqualTo(9));
            Assert.That(container.InitialLocationY, Is.EqualTo(14));
            Assert.That(container.InitialOrientation, Is.EqualTo("Right"));
        }

        [Test]
        public void GetWaypointsWhenCorrectValuesGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            f.SpiderContainer container = new f.SpiderContainer();
            string input = "FLRFLR";

            // Act
            utility.GetWaypoints(input, container);

            // Assert
            Assert.That(container.Waypoints[0], Is.EqualTo('F'));
            Assert.That(container.Waypoints[1], Is.EqualTo('L'));
            Assert.That(container.Waypoints[2], Is.EqualTo('R'));
            Assert.That(container.Waypoints[3], Is.EqualTo('F'));
            Assert.That(container.Waypoints[4], Is.EqualTo('L'));
            Assert.That(container.Waypoints[5], Is.EqualTo('R'));
        }

        [Test]
        public void ComputeResultWhenCorrectValuesGivenTest()
        {
            // Arrange
            f.ISpidersUtility utility = new f.SpidersUtility();
            f.SpiderContainer container = new f.SpiderContainer();
            container.WallHeight = 10;
            container.WallWidth = 20;
            container.InitialOrientation = "Right";
            container.InitialLocationX = 0;
            container.InitialLocationY = 0;
            container.Waypoints = new char[5] { 'F', 'L', 'F', 'R', 'F' };

            // Act
            string result = utility.ComputeResult(container);

            // Assert
            Assert.That(result, Is.EqualTo("2 1 Right"));
        }

        #endregion
    }
}