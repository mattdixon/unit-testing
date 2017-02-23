using System;

namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     A helper class for mocking.
    /// </summary>
    public class MyClassUnderTest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MyClassUnderTest" /> class.
        /// </summary>
        /// <param name="foo">The foo.</param>
        public MyClassUnderTest(IFoo foo)
        {
            Foo = foo;
            Foo.MyEvent += Foo_MyEvent;
        }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        private IFoo Foo { get; }

        /// <summary>
        ///     Does something.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The result</returns>
        public bool DoSomething(string input)
        {
            return Foo.DoSomething(input);
        }

        /// <summary>
        ///     Tries the parse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="myOutput">My output.</param>
        /// <returns>Returns <c>true</c> for success.</returns>
        public bool TryParse(string input, out string myOutput)
        {
            return Foo.TryParse(input, out myOutput);
        }

        /// <summary>
        ///     Mies to lower.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The result</returns>
        public string MyToLower(string input)
        {
            return Foo.MyToLower(input);
        }

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <returns>The count.</returns>
        public int GetCount()
        {
            return Foo.GetCount();
        }

        /// <summary>
        ///     Adds the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The result.</returns>
        public bool Add(int input)
        {
            return Foo.Add(input);
        }

        private void Foo_MyEvent(object sender, MyEventArgs args)
        {
            Name = args.Data;
            Console.Out.WriteLine("Foo_MyEvent called. args.Data: '{0}'", args.Data);
        }
    }
}