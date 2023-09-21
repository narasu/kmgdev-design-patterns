using System;

public interface ICallback : IEvent
{
    object Callback { get; set; }
}
