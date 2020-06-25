using System.Collections.Generic;

namespace DependencyInjection
{
    public class Editor
    {
        public IEnumerable<Button> Buttons { get; }

        public Editor(IEnumerable<Button> buttons)
        {
            this.Buttons = buttons;
        }

        public void ClickAll()
        {
            foreach (var button in Buttons)
            {
                button.Click();
            }
        }
    }
}