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