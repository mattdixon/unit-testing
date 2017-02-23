//--------------------------------------------------------------------------
// <copyright file="MsTestBase.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrontRangeSystems.UnitTesting.TestingFramework
{
    [TestClass]
    public abstract class MsTestBase<T> : TestBase<T> where T : class
    {
        /// <summary>
        ///     Initializes the unit test class. This occurs once for the class, before any tests are executed.
        /// </summary>
        [ClassInitialize]
        public void ClassInitialize()
        {
            ClassInitializeInternal();
        }

        /// <summary>
        ///     Initializes the test. This occurs once before each test in the class is executed.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            TestInitializeInternal();
        }

        /// <summary>
        ///     Unit test cleanup. This occurs once after each test in the class is executed.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            TestCleanupInternal();
        }

        /// <summary>
        ///     Unit test class cleanup. This occurs once after all tests in the class are executed.
        /// </summary>
        [ClassCleanup]
        public void ClassCleanup()
        {
            ClassCleanupInternal();
        }

        protected virtual void ClassInitializeInternal()
        {}

        protected virtual void TestInitializeInternal()
        {}

        protected virtual void TestCleanupInternal()
        {}

        protected virtual void ClassCleanupInternal()
        {}
    }
}