using System;

public interface INotifiesAtDeath
{
    event Action Death;
}