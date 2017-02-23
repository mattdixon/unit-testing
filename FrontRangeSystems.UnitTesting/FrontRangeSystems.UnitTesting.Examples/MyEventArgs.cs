using System;

namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     Event args used with the <see cref="IFoo.MyEvent" /> event.
    /// </summary>
    public class MyEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MyEventArgs" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public MyEventArgs(string data)
        {
            Data = data;
        }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public string Data { get; set; }
    }
}