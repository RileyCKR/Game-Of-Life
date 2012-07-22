using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    class SimulationUI : UserInterface
    {
        public SimulationUI(InputState inputState)
            : base(inputState)
        {
        }

        public override void Initialize()
        {
            PlaybackDock playbackDock = new PlaybackDock(this);
            Controls.Add(playbackDock);

            base.Initialize();
        }
    }
}