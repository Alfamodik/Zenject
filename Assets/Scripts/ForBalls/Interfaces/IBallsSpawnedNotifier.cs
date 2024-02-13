using System;
using System.Collections.Generic;

public interface IBallsSpawnedNotifier
{
    event Action<List<Ball>> BallsSpawned;
}
