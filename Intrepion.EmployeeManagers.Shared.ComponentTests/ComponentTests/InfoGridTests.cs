using Intrepion.EmployeeManagers.Shared.Grid;
using Bunit;
using NUnit.Framework;

namespace Intrepion.EmployeeManagers.Shared.UnitTests.InfoGridTests;

public class InfoGridTests : BunitContext
{
    [Test]
    public void InfoGridComponentRendersCorrectly()
    {
        var cut = Render<InfoGrid>();

        cut.MarkupMatches("<div><p>No information found.</p></div>");
    }
}
