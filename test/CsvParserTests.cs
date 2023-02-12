using Csv_Parser.CustomException;
using Csv_Parser.models;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace Csv_Parser.tests;
[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CsvDataModel_GivenCorrectParameters_ReturnsCorrectProperties()
    {
        var csvData = new FileData()
        {
            Name = "Test Data",
            Description = "Test Description",
            Quantity = "1"
        };

        Assert.IsInstanceOf<FileData>(csvData);
        Assert.That(!string.IsNullOrEmpty(csvData.Name));
        Assert.That(!string.IsNullOrEmpty(csvData.Description));
        Assert.That(!string.IsNullOrEmpty(csvData.Quantity));
        Assert.That(csvData.Name, Is.SameAs("Test Data"));
        Assert.That(csvData.Description, Is.SameAs("Test Description"));
        Assert.That(csvData.Quantity, Is.SameAs("1"));
    }
    [Test]
    public void CsvParser_GivenCorrectPathParameter_ReturnsList()
    {
        var path = @"..\..\..\..\src\TestFile.csv";
        var csvDataParser = new CsvParser(path);

        var objectList = csvDataParser.ExtractDataFromFiles();

        Assert.IsInstanceOf<List<FileData>>(objectList);
        Assert.NotZero(objectList.Count);
    }
    [Test]
    public void CsvParser_GivenInCorrectPathParameter_ReturnsException()
    {
        var path = "Incorrect path";
        var csvDataParser = new CsvParser(path);

        Assert.That(() => csvDataParser.ExtractDataFromFiles(), Throws.TypeOf<InvalidFileTypeException>());
    }
}