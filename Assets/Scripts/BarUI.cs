using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : MonoBehaviour
{
    /// <summary>
    /// variables that are need
    /// </summary>
    private float stat, maxStat, width, height;
    private Stats stats;
    [SerializeField]
    private RectTransform bar;

    /// <summary>
    /// This will set the maxstat of the player to the bar max stat.
    /// This will also set the height and width of the bar.
    /// </summary>
    /// <param name="newMaxStat">The max state that the bar will be using</param>
    public void SetMaxStat(float newMaxStat)
    {
        maxStat = newMaxStat;
        height = bar.sizeDelta.y;
        width = bar.sizeDelta.x;
    }

    public void SetStat(float newStat)
    {
        stat = newStat;

        float newWidth = (stat / maxStat) * width;

        bar.sizeDelta = new Vector2(newWidth, height);
    }
}
