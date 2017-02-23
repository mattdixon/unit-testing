//--------------------------------------------------------------------------
// <copyright file="NUnitTestBase.cs" company="Front Range Systems, LLC">
//     Copyright (c) 2017 Front Range Systems, LLC. All rights reserved.
//     You are free to use this source code as you wish. Front Range Systems, LLC is not
//     responsible for any bugs, errors, or resulting damage from problems
//     with this source code. We are, after all, human. This code is meant
//     to be used as a learning tool. 
// </copyright>
// <author>Matt Dixon</author>
//--------------------------------------------------------------------------

using NUnit.Framework;

namespace FrontRangeSystems.UnitTesting.TestingFramework
{
    [TestFixture]
    public abstract class NUnitTestBase<T> : TestBase<T> where T : class
    {
        /// <summary>
        ///     Initializes the unit test class. This occurs once for the class, before any tests are executed.
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            OneTimeSetUpInternal();
        }

        /// <summary>
        ///     Initializes the test. This occurs once before each test in the class is executed.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            SetupInternal();
        }

        /// <summary>
        ///     Unit test cleanup. This occurs once after each test in the class is executed.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            TearDownInternal();
        }

        /// <summary>
        ///     Unit test class cleanup. This occurs once after all tests in the class are executed.
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            OneTimeTearDownInternal();
        }

        protected virtual void OneTimeSetUpInternal()
        {}

        protected virtual void SetupInternal()
        {}

        protected virtual void TearDownInternal()
        {}

        protected virtual void OneTimeTearDownInternal()
        {}
    }
}