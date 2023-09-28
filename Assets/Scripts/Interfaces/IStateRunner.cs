public interface IStateRunner
{
    Scratchpad ObjectData { get; }
    StateMachine FSM { get; }
}