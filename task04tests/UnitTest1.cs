namespace task04tests;

using Xunit;
using task04;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        ISpaceship cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Fighter_ShouldBeWeakerThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.FirePower < cruiser.FirePower);
    }

    [Fact]
    public void Methods_ShouldNotThrowExceptions()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        
        fighter.MoveForward();
        fighter.Rotate(45);
        fighter.Fire();
        
        cruiser.MoveForward();
        cruiser.Rotate(-30);
        cruiser.Fire();
    }
}
