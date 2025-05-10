using System;
using UnityEngine;

public interface IAdsService
{
    public void ShowAd();
    public event Action OnAdShown;
}
    

public class AdsService : IAdsService
{
    public event Action OnAdShown;
    
    public void ShowAd()
    {
        Debug.Log("Showing Ad");
        OnAdShown?.Invoke();
    }
}
