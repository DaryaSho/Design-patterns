using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            Lamp lamp = new Lamp();
            people.SetComand(new LampOnComand(lamp));
            people.PressButton();
            people.PressUndo();
        }
    }
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    class Lamp
    {
        public void On()
        {
            Console.WriteLine("Lamp On!");
        }
        public void Off()
        {
            Console.WriteLine("Lamp Off!");
        }
    }
    class LampOnComand : ICommand
    {
        Lamp lamp;
        public LampOnComand(Lamp lamp)
        {
           this.lamp = lamp;
        }
        public void Execute()
        {
            lamp.On();
        }
        public void Undo()
        {
            lamp.Off();
        }
    }
    class People
    {
        ICommand command;
        public People(){ }

        public void SetComand(ICommand command)
        {
            this.command = command;
        }
        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}
