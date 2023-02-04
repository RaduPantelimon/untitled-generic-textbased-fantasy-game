using GenericRPG;
using GenericRPG.Core;



using (var game = new TutorialGame(Console.OpenStandardInput(), Console.OpenStandardOutput()))
    game.Play();


using (var game = new ComplexGame())
{
    game.Play();

    
}

//game class can be inherited and extended, but the internal workings of the class should not be interfearable
class ComplexGame :TutorialGame
{
    public ComplexGame(): base(Console.OpenStandardInput(), Console.OpenStandardOutput())
    {

    }
}