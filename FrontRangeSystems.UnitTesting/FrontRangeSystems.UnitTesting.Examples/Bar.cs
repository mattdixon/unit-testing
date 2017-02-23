using System;

namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     An implementation of <see cref="IFoo" />. This is used in the <see cref="MoqTest.SubmitInstance" /> test.
    /// </summary>
    public class Bar : IFoo
    {
        /// <summary>
        ///     Occurs when [my event].
        /// </summary>
        public event MyEventDelegate MyEvent;

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Does something.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///     Returns <c>true</c> for success.
        /// </returns>
        public bool DoSomething(string input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Tries the parse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns>
        ///     Returns <c>true</c> for success.
        /// </returns>
        public bool TryParse(string input, out string output)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Submits the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>
        ///     Returns <c>true</c> for success.
        /// </returns>
        public bool Submit(ref IFoo instance)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Mies to lower.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///     Returns <c>true</c> for success.
        /// </returns>
        public string MyToLower(string input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <returns>
        ///     Returns the count.
        /// </returns>
        public int GetCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Adds the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///     Returns the result.
        /// </returns>
        public bool Add(int input)
        {
            if (MyEvent != null)
            {
                MyEvent(this, new MyEventArgs("My data"));
            }

            throw new NotImplementedException();
        }
    }
}