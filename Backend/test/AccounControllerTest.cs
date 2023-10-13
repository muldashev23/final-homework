using System.Net;
using System.Net.Http.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace test;

public class Tests
{
    private FactoryOverride _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new FactoryOverride();
    }

    [Test]
    [Order(1)]
    public async Task PostLoginHappyPath()
    {
        var client = _factory.CreateClient();
        var newUser = new { Password = "Admin123", Email = "admin@gmail.com" };
        var response = await client.PostAsJsonAsync("/api/account/login", newUser);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    [Order(2)]
    public async Task PostRegistration()
    {
        var client = _factory.CreateClient();
        var newUser = new
        {
            UserName = "Bro",
            Password = "User1234",
            Email = "bro@gmail.com"
        };
        var response = await client.PostAsJsonAsync("/api/account/registration", newUser);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
