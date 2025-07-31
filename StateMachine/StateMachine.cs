using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    

    /// <summary>
    /// Base class for a state machine that manages transitions between states of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StateMachine<T> where T : Enum
    {
        /// <summary>
        /// Constructor for the state machine. Its arguments are the initial state and a list of transitions.
        /// </summary>
        /// <param name="initState"></param>
        /// <param name="newtransitions"></param>
        /// <exception cref="ArgumentException"></exception>
        protected StateMachine(T initState, List<(T, T[])> newtransitions)
        {
            transitions = new Dictionary<T, T[]>();
            foreach ((T, T[]) t in newtransitions)
            {
                if (t.Item1 == null || t.Item2 == null)
                {
                    throw new ArgumentException($"Invalid transition from {t.Item1} to {t.Item2}");
                }

                if (!transitions.Keys.Contains(t.Item1))
                {
                    transitions.Add(t.Item1, t.Item2);
                }
                else
                {
                   throw new ArgumentException($"Transitions from state {t.Item1} already exists");  
                }
            }
            CurrentState = initState;

        }
        /// <summary>
        /// list of valid transitions for the state machine.
        /// Each transition is defined by a starting state and an array of possible next states.
        internal Dictionary<T, T[]> transitions;

        /// <summary>
        /// Current state of the state machine.
        /// </summary>  
        public T? CurrentState { get; private set; }
        /// <summary>
        /// Timestamp of the last state transition.
        /// </summary>
        public DateTime tsLastTransition { get; private set; }

        /// <summary>
        /// Returns true if machine state can transition to next state
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public bool CanTransition(T next)
        {
            if (CurrentState == null || transitions == null)
            {
                throw new InvalidOperationException($"No initial state defined or transitions defined");
            }
            return transitions != null
                && transitions.Any(t => t.Key.Equals(CurrentState) && t.Value.Contains(next));
        }

        /// <summary>
        /// Executes a transition to the next state if it is valid.
        /// </summary>
        /// <param name="next"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ExecuteTransition(T next)
        {
            if (CanTransition(next))
            {
                CurrentState = next;
                tsLastTransition = DateTime.Now;
            }
            else
            {
                throw new InvalidOperationException($"Cannot transition from {CurrentState} to {next}. No valid transition defined.");
            }
        }

        /// <summary>
        /// Method to be called when the state machine is in a set of specific states
        /// </summary>
        /// <returns></returns>
        public abstract bool OnIdleState();
    }
}
