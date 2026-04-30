using UnityEngine;

public class GamemodeSubsystem
{
    public GamemodeBase gamemodeParent { get; set; }
    
    public virtual void OnAwake() { }
    public virtual void OnEnable() { }
    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void OnDisable() { }
    
}
