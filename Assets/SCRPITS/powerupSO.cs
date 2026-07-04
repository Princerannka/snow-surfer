using UnityEngine;

[CreateAssetMenu(fileName = "powerupSO", menuName = "powerupSO")]
public class powerupSO : ScriptableObject
{
    [SerializeField] string poweruptype;
    [SerializeField] float valuechange;
    [SerializeField] float time;

    public string GetPowerupType()
    {
        return poweruptype;
    }

    public float GetValueChange()
    {
        return valuechange;
    }

    public float GetTime()
    {
        return time;
    }

}
