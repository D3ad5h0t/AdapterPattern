using System;
using Autofac;
using Autofac.Features.Metadata;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OpenCommand>()
                .As<ICommand>()
                .WithMetadata("Name", "Open");
            builder.RegisterType<SaveCommand>()
                .As<ICommand>()
                .WithMetadata("Name", "Save");
            
            //builder.RegisterType<Button>();
            builder.RegisterAdapter<Meta<ICommand>, Button>(
                cmd => new Button(cmd.Value, (string) cmd.Metadata["Name"]));
            
            builder.RegisterType<Editor>();

            using var c = builder.Build();
            var editor = c.Resolve<Editor>();
            editor.ClickAll();

            foreach (var button in editor.Buttons)
            {
                button.PrintMe();
            }
        }
    }
}