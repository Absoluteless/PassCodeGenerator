using System;
using System.Drawing;
using MisteryCore;
using MisterySolver.Properties;

namespace MisterySolver.Wrappers
{
    internal class PersonalityWrapper
    {
        public event Action SolvedChanged;

        private bool _solved = false;

        public void SetPersonalities(string code)
        {
            var trimmedCode = code.Trim(' ', '\t', '\r', '\n');
            if (CodeSolver.TrySolve(trimmedCode, out var from, out var to))
            {
                From = from;
                To = to;
                OnSolvedChanging(true);
            }
            else
            {
                From = null;
                To = null;
                OnSolvedChanging(false);
            }
        }

        private void OnSolvedChanging(bool solved)
        {
            if (_solved == solved)
                return;

            _solved = solved;
            SolvedChanged?.Invoke();
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

        public Bitmap Image => _solved ? Resources.After : Resources.Before;
    }
}
