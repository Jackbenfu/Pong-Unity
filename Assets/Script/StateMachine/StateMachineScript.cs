using System.Collections.Generic;
using Pong.StateMachine.Exception;
using UnityEngine;

namespace Pong.StateMachine
{
    public abstract class StateMachineScript<TStateMachine> : MonoBehaviour
        where TStateMachine : StateMachineScript<TStateMachine>
    {
        #region Private

        private State<TStateMachine> currentState;
        private IDictionary<int, State<TStateMachine>> states;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            states = new Dictionary<int, State<TStateMachine>>();
            LoadStates();

            if (0 == states.Count)
            {
                throw new NoStateDefinedException();
            }

            currentState.Enter(null);
        }

        private void Update()
        {
            currentState.Update(Time.deltaTime);
        }

        #endregion

        #region State management

        public void GoToState<TState>()
            where TState : State<TStateMachine>, new()
        {
            GoToState<TState>(null);
        }

        public void GoToState<TState>(object param)
            where TState : State<TStateMachine>, new()
        {
            if (null != currentState)
            {
                currentState.Exit();
            }

            currentState = GetState<TState>();
            currentState.Enter(param);
        }

        protected abstract void LoadStates();

        protected void AddState<TState>()
            where TState : State<TStateMachine>, new()
        {
            AssertStateDoesNotExist<TState>();

            var state = new TState();
            state.StateMachine = (TStateMachine)this;
            state.Init();
            states.Add(GetTypeHashCode<TState>(), state);

            TrySetFirstState(state);
        }

        protected void AddState<TState, TStateContext>(TStateContext context)
            where TState : StateWithContext<TStateMachine, TStateContext>, new()
        {
            AssertStateDoesNotExist<TState>();

            var state = new TState();
            state.Context = context;
            state.StateMachine = (TStateMachine)this;
            state.Init();
            states.Add(GetTypeHashCode<TState>(), state);

            TrySetFirstState(state);
        }

        private State<TStateMachine> GetState<TState>()
            where TState : State<TStateMachine>, new()
        {
            var hashCode = GetTypeHashCode<TState>();

            if (states.ContainsKey(hashCode))
            {
                return states[hashCode];
            }

            throw new StateNotDefinedException(GetTypeName<TState>());
        }

        private void TrySetFirstState(State<TStateMachine> state)
        {
            if (1 == states.Count)
            {
                currentState = state;
            }
        }

        #endregion

        #region Assertions

        private void AssertStateDoesNotExist<TState>()
        {
            var hashCode = GetTypeHashCode<TState>();

            if (states.ContainsKey(hashCode))
            {
                throw new StateAlreadyDefinedException(GetTypeName<TState>());
            }
        }

        #endregion

        #region Utils

        private static int GetTypeHashCode<T>()
        {
            return typeof(T).GetHashCode();
        }

        private static string GetTypeName<T>()
        {
            return typeof(T).FullName;
        }

        #endregion
    }
}
