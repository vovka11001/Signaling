using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;
    [SerializeField] private Detector _detector;

    private void OnEnable()
    {
        _detector.PlayerEntered += _signalization.IncreaseVolume;
        _detector.PlayerLeft += _signalization.DecreaseVolume;
    }

    private void OnDisable()
    {
        _detector.PlayerEntered -= _signalization.IncreaseVolume;
        _detector.PlayerLeft -= _signalization.DecreaseVolume;
    }
}
