using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoordinateTransformation
{
    public static Vector3 TowerToWorld(int row, int column)
    {
        Vector3 worldPosition = Tower.bottomArray[row] + column * Tower.yOffset;
        return worldPosition;
    }

    public static Vector2 WorldToTower(Vector3 worldPosition)
    {
        //使用XZ座標找方向以及半徑
        //利用Y座標找高度

        Vector2 towerIndex = Vector2.zero;

        return towerIndex;
    }
}
