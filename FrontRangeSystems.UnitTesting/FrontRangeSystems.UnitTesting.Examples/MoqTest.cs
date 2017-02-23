using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     Moq tests for getting developers up to speed with the mocking framework.
    /// </summary>
    [TestClass]
    public class MoqTest
    {
        /// <summary>
        ///     Gets or sets the mock foo.
        /// </summary>
        /// <value>
        ///     The mock foo.
        /// </value>
        public Mock<IFoo> MockFoo { get; set; }

        /// <summary>
        ///     Gets or sets the class under test.
        /// </summary>
        /// <value>
        ///     The class under test.
        /// </value>
        public MyClassUnderTest ClassUnderTest { get; set; }

        /// <summary>
        ///     Initializes the test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            MockFoo = new Mock<IFoo>();
            ClassUnderTest = new MyClassUnderTest(MockFoo.Object);
        }

        /// <summary>
        ///     Does something success.
        /// </summary>
        [TestMethod]
        public void DoSomethingSuccess()
        {
            MockFoo.Setup(foo => foo.DoSomething("ping")).Returns(true).Verifiable();

            var result = ClassUnderTest.DoSomething("ping");
            Assert.That(result, Is.True);
        }

        /// <summary>
        ///     Outs the parameters.
        /// </summary>
        [TestMethod]
        public void OutParameters()
        {
            var expectedOutput = "ack";
            var input = "ping";
            MockFoo.Setup(f => f.TryParse(input, out expectedOutput)).Returns(true);

            string actualOutput;
            var result = ClassUnderTest.TryParse(input, out actualOutput);
            Assert.That(result, Is.True);
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        /// <summary>
        ///     Submits the instance.
        /// </summary>
        [TestMethod]
        public void SubmitInstance()
        {
            IFoo instance = new Bar();
            MockFoo.Setup(foo => foo.Submit(ref instance)).Returns(true);
        }

        /// <summary>
        ///     Accesses the invocation.
        /// </summary>
        [TestMethod]
        public void AccessInvocation()
        {
            MockFoo.Setup(foo => foo.MyToLower(It.IsAny<string>())).Returns((string s) => s.ToLower());

            var input = "JDosKdlsKJLGnskljGLkjSfgkjs";
            var expected = input.ToLower();
            var actual = ClassUnderTest.MyToLower(input);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Throws the invalid operation exception.
        /// </summary>
        [TestMethod]
        public void ThrowInvalidOperationException()
        {
            MockFoo.Setup(foo => foo.MyToLower("reset")).Throws<InvalidOperationException>();
            Assert.That(() => ClassUnderTest.MyToLower("reset"), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        /// <summary>
        ///     Throws the argument exception.
        /// </summary>
        [TestMethod]
        public void ThrowArgumentException()
        {
            var expectedException = new ArgumentException("command");
            MockFoo.Setup(foo => foo.MyToLower(null)).Throws(expectedException);
            Assert.That(() => ClassUnderTest.MyToLower(null), Throws.Exception.EqualTo(expectedException));
        }

        /// <summary>
        ///     Lazies the evaluating return value.
        /// </summary>
        [TestMethod]
        public void LazyEvaluatingReturnValue()
        {
            var expected = 3;
            MockFoo.Setup(foo => foo.GetCount()).Returns(() => expected);

            var actual = ClassUnderTest.GetCount();
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///     Returning the different values.
        /// </summary>
        [TestMethod]
        public void ReturningDifferentValues()
        {
            var calls = 0;
            MockFoo.Setup(foo => foo.GetCount()).Returns(() => calls).Callback(() => calls++);

            var expected = 3;
            for (var i = 0; i < expected; i++)
            {
                Console.Out.WriteLine("mock.Object.GetCount() = {0}", MockFoo.Object.GetCount());
            }

            Assert.That(calls, Is.EqualTo(expected));
        }

        /// <summary>
        ///     Adds the even number.
        /// </summary>
        [TestMethod]
        public void AddEvenNumber()
        {
            MockFoo.Setup(foo => foo.Add(It.Is<int>(i => i % 2 == 0))).Returns(true);

            var actual = ClassUnderTest.Add(4);
            Assert.That(actual, Is.True);
        }

        /// <summary>
        ///     Adds the range.
        /// </summary>
        [TestMethod]
        public void AddRange()
        {
            MockFoo.Setup(foo => foo.Add(It.IsInRange(0, 10, Range.Inclusive))).Returns(true);

            for (var i = -5; i < 20; i++)
            {
                var actual = ClassUnderTest.Add(i);
                var expected = i >= 0 && i <= 10;
                Console.Out.WriteLine(i + " : " + actual);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        /// <summary>
        ///     Does something regex.
        /// </summary>
        [TestMethod]
        public void DoSomethingRegex()
        {
            MockFoo.Setup(x => x.MyToLower(It.IsRegex("[a-d]+", RegexOptions.IgnoreCase))).Returns("foo");

            foreach (var i in Enumerable.Range(90, 125))
            {
                var actual = ClassUnderTest.MyToLower(((char) i).ToString());
                var expected = i >= 97 && i <= 100 ? "foo" : null;
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        /// <summary>
        ///     Names the property return.
        /// </summary>
        [TestMethod]
        public void NamePropertyReturn()
        {
            const string Expected = "bar";
            MockFoo.Setup(foo => foo.Name).Returns(Expected);

            Assert.That(MockFoo.Object.Name, Is.EqualTo(Expected));
        }

        /// <summary>
        ///     Sets the property.
        /// </summary>
        [TestMethod]
        public void SetProperty()
        {
            var expected = "foo";
            MockFoo.SetupProperty(foo => foo.Name, expected);

            var actual = MockFoo.Object.Name;
            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        ///     Raises the event.
        /// </summary>
        [TestMethod]
        public void RaiseEvent()
        {
            var expected = "test value";
            MockFoo.Raise(foo => foo.MyEvent += null, new MyEventArgs(expected));
            Assert.That(ClassUnderTest.Name, Is.EqualTo(expected));
        }
    }
}