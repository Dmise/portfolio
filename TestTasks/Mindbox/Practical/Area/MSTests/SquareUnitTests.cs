using squareDll;

namespace MSTests
{
    [TestClass]
    public class AreaTests
    {
        [TestMethod]
        public void Triangle_3_5_4()  //3 5 4 = 6
        {
            //Arrange
            var triangle = new Triangle(3,5,4);

            //Act
            var areaResult = triangle.Area;

            //Assert

            var rightResult = 6;
            Assert.AreEqual(rightResult, areaResult);
        }

        [TestMethod]
        public void Triangle_7_5_3()  
        {
            //Arrange
            var triangle = new Triangle(7, 5, 3);

            //Act
            var areaResult = triangle.Area;

            //Assert

            double rightResult = 6.49519052838329;

            Assert.AreEqual(rightResult, areaResult);

        }

        [TestMethod]
        public void Triangle_3_4_5_right() // Пифагоровый треугольник
        {

            //Arrange
            var triangle = new Triangle(3, 4, 5);

            //Act
            

            //Assert                    

            Assert.IsTrue(triangle.IsRightTriangle);
        }

        [TestMethod]
        public void Triangle_5_12_13_right() // Пифагоровый треугольник
        {

            //Arrange
            var triangle = new Triangle(5, 12, 13);

            //Act


            //Assert                    

            Assert.IsTrue(triangle.IsRightTriangle);
        }

        [TestMethod]
        public void Round_2()
        {
            var circle = new Circle(2);

            var areaResult = circle.Area;

            double rightResult = 12.566370614359172;
            Assert.AreEqual(rightResult, areaResult);
        }

        [TestMethod]
        public void Round_1()
        {
            var circle = new Circle(1);

            var areaResult = circle.Area;

            double rightResult = Math.PI;
            Assert.AreEqual(rightResult, areaResult);
        }
    }

    
    
}