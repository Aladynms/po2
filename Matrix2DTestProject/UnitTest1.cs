using MatrixLib;

namespace Matrix2DTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatrix2D_Add()
        {
            Matrix2D m1 = new(1, 2, 3, 4);
            Matrix2D m2 = new(0, 1, -1, 2);
            Matrix2D m = m1 + m2;

            Matrix2D expected = new(1, 3, 2, 6);

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrix2D_Sub()
        {
            Matrix2D m1 = new(1, 2, 3, 4);
            Matrix2D m2 = new(0, 1, -1, 2);
            Matrix2D m = m1 - m2;

            Matrix2D expected = new(1, 1, 4, 2);

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrix2D_Multip()
        {
            Matrix2D m1 = new(1, 2, 3, 4);
            Matrix2D m2 = new(0, 1, -1, 2);

            int m3 = 3;

            Matrix2D result1 = m1 * m2;
            Matrix2D result2 = m1 * m3;
            Matrix2D result3 = m3 * m1;

            Matrix2D expected1 = new(-2, 5, -4, 11);
            Matrix2D expected2 = new(3, 6, 9, 12);
            Matrix2D expected3 = new(3, 6, 9, 12);

            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);
        }

        [TestMethod]
        public void TestMatrix2D_Plus_Minus()
        {
            Matrix2D m1 = new(1, 2, 3, 4);
            Matrix2D m = -m1;

            Matrix2D expected = new(-1, -2, -3, -4);

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrix2D_Transpose()
        {
            Matrix2D m1 = new(1, 2, 3, 4);
            Matrix2D m = Matrix2D.Transpose(m1);

            Matrix2D expected = new(1, 3, 2, 4);

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMatrix2D_Determinant()
        {
            Matrix2D m1 = new(1, 2, 3, 4);
            int m = Matrix2D.Determinant(m1);

            int expected = -2;

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        [DataRow("[[1,2], [3,4]]", 1, 2, 3, 4)]
        [DataRow("[[1, 2], [3, 4]]", -1, -2, 3, 4)]
        public void TestMatrix2D_Parse_OK(string s, int a, int b, int c, int d)
        {
            Matrix2D m = Matrix2D.Parse(s);

            Matrix2D expected = new(a, b, c, d);

            Assert.Equals(expected, m);
        }

        [DataTestMethod]
        [ExpectedException(typeof(FormatException))]
        [DataRow("[[1,2] [3,4]]")]
        [DataRow("[[1,2], [3 4]]")]
        [DataRow("[[1 2], [3 ,4]]")]
        [DataRow("[[1,2], [3,4]")]
        [DataRow("[1,2], [3, 4]]")]
        [DataRow("[[1,2], [3 4]]")]
        public void TestMatrix2D_Parse_Exception(string s)
        {
            Matrix2D m = Matrix2D.Parse(s);
        }
    }
}