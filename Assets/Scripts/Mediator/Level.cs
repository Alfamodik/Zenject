using System;
using UnityEngine;

public class Level : IDisposable, IDeffeatNotifies, IRestartNotifies
{
    public event Action Restart;
    public event Action Defeat;

    private INotifiesAtDeath _notifiesAtDeath;
    
    public Level(INotifiesAtDeath notifiesAtDeath)
    {
        _notifiesAtDeath = notifiesAtDeath;
        _notifiesAtDeath.Death += OnDefeat;
    }

    public void Dispose() => _notifiesAtDeath.Death -= OnDefeat;

    public void StartMe() => Debug.Log("StartLevel");

    public void Restarting()
    {
        Restart.Invoke();
        StartMe();
    }

    public void OnDefeat() => Defeat?.Invoke();
}
