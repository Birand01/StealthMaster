using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public enum StateID
    {
        NULL = 0,
        PATROL,
        CHASE,
        ATTACK,
        DEAD,
        WIN
    }

    public abstract class State
    {
        protected StateID stateID = StateID.NULL;
        public StateID ID { get { return stateID; } }

        public virtual void OnEnterState() { }

        public virtual void OnLeaveState() { }

        public abstract StateID Decide();

        public abstract void Act();

    }
}
   

