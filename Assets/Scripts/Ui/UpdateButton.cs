using Ui;
using UnityEngine;
using Zenject;

public class UpdateButton : MonoBehaviour
{
    [Inject] private TowerInfo towerInfo;
    
    private void OnMouseDown()
    {
        towerInfo.ReturnCurrentTower.UpdateStart();
        towerInfo.ResetInfo(towerInfo.ReturnCurrentTower);
    }
}
