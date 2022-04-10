
   
using UnityEngine;
using UnityEngine.UI;

public class Wave_UI : MonoBehaviour
{
    public Text waveText;

    public Text enemyText;



    public void UpdateUI(int _wave, int _enemies)
    {
        waveText.text = _wave.ToString();
        enemyText.text = _enemies.ToString();
    }

    public void HideUI()
    {
        waveText.text = "";
        enemyText.text = "";
    }
}
