using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LETTER_FIGHT.Service
{
    /// <summary>
    /// This class is used to control the turn of the players.
    /// </summary>
    public static class TurnControlService
    {
        public static int ActivePlayerIndex { get; set; } = 0;
        public static int nextPlayer(int limit)
        {
            if(ActivePlayerIndex == limit)
            {
                ActivePlayerIndex = 0;
            }
            else
            {
                ActivePlayerIndex++;
            }
            return ActivePlayerIndex;
        }
    }
}
