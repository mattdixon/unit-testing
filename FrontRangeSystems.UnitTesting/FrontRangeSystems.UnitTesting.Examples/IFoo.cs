//--------------------------------------------------------------------------
// <copyright file="IFoo.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;

namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     An interface used for mocking.
    /// </summary>
    public interface IFoo
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        ///     Occurs when [my event].
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
        event MyEventDelegate MyEvent;

        /// <summary>
        ///     Does something.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Returns <c>true</c> for success.</returns>
        bool DoSomething(string input);

        /// <summary>
        ///     Tries the parse.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <returns>Returns <c>true</c> for success.</returns>
        bool TryParse(string input, out string output);

        /// <summary>
        ///     Submits the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>Returns <c>true</c> for success.</returns>
        bool Submit(ref IFoo instance);

        /// <summary>
        ///     A ToLower implementation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Returns <c>true</c> for success.</returns>
        string MyToLower(string input);

        /// <summary>
        ///     Gets the count.
        /// </summary>
        /// <returns>Returns the count.</returns>
        int GetCount();

        /// <summary>
        ///     Adds the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Returns the result.</returns>
        bool Add(int input);
    }
}