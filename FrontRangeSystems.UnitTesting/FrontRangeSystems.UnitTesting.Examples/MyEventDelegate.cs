namespace FrontRangeSystems.UnitTesting.Examples
{
    /// <summary>
    ///     A delegate for handling the <see cref="IFoo.MyEvent" /> event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="MyEventArgs" /> instance containing the event data.</param>
    public delegate void MyEventDelegate(object sender, MyEventArgs args);
}