using System.Drawing;
using MisteryCore;
using MisterySolver.Properties;

namespace MisterySolver.Wrappers
{
    internal class PersonalityWrapper
    {
        public void SetPersonalities(string code)
        {
            if (CodeSolver.TrySolve(code, out var from, out var to))
            {
                From = from;
                To = to;
            }
            else
            {
                From = null;
                To = null;
            }
        }

        public Personality? From { get; private set; }
        public Personality? To { get; private set; }

        public string GetGreeting()
        {
            return From == null ? "Привет!" : string.Format(Resources.Greeting, From.ToString());
        }

        public string GetTo()
        {
            return To == null ? null : "Ты даришь подарок " + To;
        }

        public Bitmap Image => Resources.ChristmasImage;
    }
}
