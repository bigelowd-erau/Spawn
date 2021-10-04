using UnityEngine;

interface ISubscriber
{
    void Subscribe();
    void Unsubscribe();
    void OnEnable();
    void OnDisable();
}
