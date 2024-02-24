using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : GenericSingleton<EventManager>
{
    public UnityAction<DamageEventData> damageEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EntityDamaged(DamageEventData data)
    {
        damageEvent.Invoke(data);
    }

    public async void RestartGame()
    {
        await System.Threading.Tasks.Task.Delay(5000);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().path);
    }
}
