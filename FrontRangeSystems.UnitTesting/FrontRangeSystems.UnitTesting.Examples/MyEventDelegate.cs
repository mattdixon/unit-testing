//--------------------------------------------------------------------------
// <copyright file="MyEventDelegate.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------
namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     A delegate for handling the <see cref="IFoo.MyEvent" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="MyEventArgs" /> instance containing the event data.</param>
    public delegate void MyEventDelegate(object sender, MyEventArgs args);
}