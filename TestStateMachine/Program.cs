using StateMachine;

ExampleStateMachine stateMachine = new ExampleStateMachine();
var s = stateMachine.CurrentState;
bool b = stateMachine.CanTransition(ExampleState.CategoryTwo);
stateMachine.ExecuteTransition(ExampleState.CategoryTwo);
b = stateMachine.CanTransition(ExampleState.CategoryOne);
;

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

public enum ExampleState
{ 
    CategoryOne,
    CategoryTwo,
    CategoryThree,
    Quit
}



