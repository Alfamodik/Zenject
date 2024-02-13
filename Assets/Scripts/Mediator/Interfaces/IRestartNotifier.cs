using System;

public interface IRestartNotifier
{
    event Action Restart;
}
