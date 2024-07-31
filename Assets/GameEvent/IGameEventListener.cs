using System;

// Note: This code has been obtained from another project I'm currently developing
public interface IGameEventListener<Item>
{
  public void OnEventTriggered(Item item);
}

public class GameEventListener<Item> : IGameEventListener<Item>
{
  Action<Item> _Callback;

  public GameEventListener(Action<Item> Callback)
  {
    _Callback = Callback;
  }

  public void OnEventTriggered(Item item) => _Callback?.Invoke(item);
}


public interface IEmptyGameEventListener
{
  public void OnEventTriggered();
}

public class EmptyGameEventListener : IEmptyGameEventListener
{
  Action _Callback;

  public EmptyGameEventListener(Action Callback)
  {
    _Callback = Callback;
  }

  public void OnEventTriggered() => _Callback?.Invoke();
}