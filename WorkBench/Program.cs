using Autofac;
using System.Reflection;
using WorkBench.Engine.Interfaces.CaesarCipher;
using WorkBench.Engine.Interfaces.FizzBuzz;

var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.FizzBuzz")).AsImplementedInterfaces();
containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.CaesarCipher")).AsImplementedInterfaces();
containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Cipher")).AsImplementedInterfaces();
containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules")).AsImplementedInterfaces();
containerBuilder.RegisterAssemblyTypes(Assembly.Load("WorkBench.Engine.Rules.Bespoke")).AsImplementedInterfaces();
var container = containerBuilder.Build();

var _fizzBuzz = container.Resolve<IFizzBuzz>();
var _encrypt = container.Resolve<IEncipher>();
var _decrypt = container.Resolve<IDecipher>();

Console.Write(string.Join(" ", _fizzBuzz.Calculate(100)));

string userString = string.Empty;

while (string.IsNullOrWhiteSpace(userString))
{
    Console.Write("\n\nType a string to encrypt: ");
    userString = Console.ReadLine();
}

Console.WriteLine("\n");

Console.Write("Enter your Key: ");
int key = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("\n");


Console.WriteLine("Encrypted Data:");
_encrypt.Execute(userString, key);
Console.WriteLine(_encrypt.Value);

Console.Write("\n");

Console.WriteLine("Decrypted Data:");

_decrypt.Execute(_encrypt.Value, key);
Console.WriteLine(_decrypt.Value);

Console.WriteLine("\nHit any key to close");
Console.ReadKey();