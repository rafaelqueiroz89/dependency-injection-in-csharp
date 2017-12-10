using System;

namespace CarEngineWithoutDI
{
    /// <summary>
    /// This example shows a particular problem, we have an interface ILog
    /// A class called ConsoleLog which inherits from ILog to log to the console
    /// An Engine class
    /// And a Car class which depends on the Engine to initialize, all goes well but what if we had more
    /// dependencies in the constructor? The code would be a lot bigger and harder to read. So DI here is handy. 
    /// </summary>
    class CarEngineWithoutDI
    {
        public interface ILog
        {
            void Write(string message);
        }

        public class ConsoleLog : ILog
        {
            public void Write(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class Engine
        {
            private ILog log;
            private int id;

            public Engine(ILog log)
            {
                this.log = log;
                id = new Random().Next();
            }

            public void Ahead(int power)
            {
                log.Write($"Engine [{id}] ahead {power}");
            }
        }

        public class Car
        {
            private Engine engine;
            private ILog log;

            public Car(Engine engine, ILog log)
            {
                this.engine = engine;
                this.log = log;
            }

            public void Go()
            {
                engine.Ahead(100);
                log.Write("Car going forward...");
            }
        }

        internal class Program
        {
            //public static void Main(string[] args)
            //{
            //    var log = new ConsoleLog();
            //    var engine = new Engine(log);
            //    var car = new Car(engine, log);
            //    car.Go();
            //}
        }
    }
}
