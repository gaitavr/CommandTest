using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Company.Project.Core.Commands;
using Company.Project.Utils;

namespace Company.Project.Core.Play
{
    public sealed class Scenario
    {
        private readonly List<BaseCommand> _commands;

        public Scenario(List<BaseCommand> commands)
        {
            _commands = commands;
        }

        public async Task Play(CancellationToken cancellation, PlayType playType = PlayType.Forward)
        {
            if (_commands == null)
            {
                throw new NullReferenceException("Can't play empty scenario");
            }

            switch (playType)
            {
                case PlayType.Forward:
                    break;
                case PlayType.Backward:
                    _commands.Reverse();
                    break;
                case PlayType.Random:
                    _commands.Shuffle();
                    break;
            }

            foreach (var command in _commands)
            {
                if (cancellation.IsCancellationRequested)
                    break;
                await command.Execute(cancellation);
            }
        }
       

        public enum PlayType
        {
            Forward,
            Backward,
            Random
        }
    }
}
