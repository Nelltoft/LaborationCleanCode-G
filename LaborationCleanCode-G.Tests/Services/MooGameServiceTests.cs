using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaborationCleanCode_G.Core.Services;
using LaborationCleanCode_G.Core.Interfaces;
using LaborationCleanCode_G.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace LaborationCleanCode_G.Core.Services.Tests;

[TestClass()]
public class MooGameServiceTests
{
    IInputOutput _inputOutput;
    IPlayerDataRepository _playerDataRepository;
    IGameService _sut;

    [TestInitialize]
    public void Initialize()
    {
        _inputOutput = new ConsoleIO();
        _playerDataRepository = new PlayerDataRepository(_inputOutput);
        _sut = new MooGameService(_inputOutput, _playerDataRepository);
    }

    [TestMethod()]
    public void GenerateGoal_TestThatStringLengthIsFour()
    {
        //assign
        int shouldEquals = 4;

        //act
        var result = _sut.GenerateGoal();

        //assert
        Assert.AreEqual(shouldEquals, result.Length);
    }

    [TestMethod()]
    public void GenerateGoal_TestThatItReturnsAString()
    {
        //assign

        //act
        var result = _sut.GenerateGoal();

        //assert
        Assert.IsInstanceOfType<string>(result);
    }

    [TestMethod()]
    public void GenerateGoal_TestThatItReturnsAStringOfFourUniqueIntegers()
    {
        //assign
        int shouldEquals = 4;

        //act
        var result = _sut.GenerateGoal();

        //assert
        Assert.AreEqual(result.Distinct().Count(), shouldEquals);
    }

    [TestMethod()]
    public void CheckWinCondition_TestThatItReturnsAString()
    {
        //assign
        var playerGuess = "1234";
        var gameGoal = "1234";

        //act
        var result = _sut.CheckWinCondition(gameGoal, playerGuess);

        //assert
        Assert.IsInstanceOfType<string>(result);
    }

    [TestMethod()]
    public void CheckWinCondition_TestThatItReturnsTheStringBBBBIfThePlayerWins()
    {
        //assign
        var playerGuess = "1234";
        var gameGoal = "1234";
        var shouldEqual = "BBBB,";

        //act
        var result = _sut.CheckWinCondition(gameGoal, playerGuess);

        //assert
        Assert.AreEqual(shouldEqual, result);
    }
}