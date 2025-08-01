using StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStateMachine
{

    public enum ExampleState
    {
        CategoryOne,
        CategoryTwo,
        CategoryThree,
        Quit
    }

    public class ExampleStateMachine : StateMachine<ExampleState>
    {
        public ExampleStateMachine() : base(ExampleState.CategoryOne, [
            (ExampleState.CategoryOne, [ExampleState.CategoryOne, ExampleState.CategoryTwo, ExampleState.Quit]),
        (ExampleState.CategoryTwo, [ExampleState.CategoryTwo, ExampleState.CategoryThree, ExampleState.Quit]),
        (ExampleState.CategoryThree, [ExampleState.CategoryThree, ExampleState.Quit]),
        (ExampleState.Quit, [ExampleState.Quit])

            ])
        { }

        public override bool OnIdleState()
        {
            return false;
        }
    }
}
