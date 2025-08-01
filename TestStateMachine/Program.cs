using StateMachine;

ExampleStateMachine stateMachine = new ExampleStateMachine(); // 
var s = stateMachine.CurrentState;
bool b = stateMachine.CanTransition(ExampleState.CategoryTwo);
stateMachine.ExecuteTransition(ExampleState.CategoryTwo);
b = stateMachine.CanTransition(ExampleState.CategoryOne);
;




