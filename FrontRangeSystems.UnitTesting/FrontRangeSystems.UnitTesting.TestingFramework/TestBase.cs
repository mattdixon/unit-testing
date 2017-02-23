//--------------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using System;

namespace FrontRangeSystems.UnitTesting.TestingFramework
{
    public abstract class TestBase<T> : TestBase where T : class
    {
        protected T ItemUnderTest { get; set; }
    }

    public abstract class TestBase
    {
        public Random Random => new Random();
    }
}