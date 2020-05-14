﻿using UnityEngine;

public class TimeController : MonoBehaviour
{
    public void PauseOn() => Time.timeScale = 0;

    public void PauseOff() => Time.timeScale = 1;
}
