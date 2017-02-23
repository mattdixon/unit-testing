//--------------------------------------------------------------------------
// <copyright file="MyEventArgs.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------
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