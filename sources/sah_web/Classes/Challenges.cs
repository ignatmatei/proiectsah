using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sah_web.Classes
{
    public enum ChallengeState
    {
        Starting,
        Acepted,
        Rejected
    }
    public class Challenges
    {
        public string Challenger;
        public string Challengee;
        public ChallengeState State;
    }
}
