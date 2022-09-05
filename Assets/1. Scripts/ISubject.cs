using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject {
    void AddObserver(Observer o);
    void RemoveObserver(Observer o);

    void Notify();
}
    

