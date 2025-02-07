using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public static int civilianarrest;
    public static int civiliankilled;
    public static int enemyarrest;
    public static int enemykilled;
    public static void CivilianArrestAddPoint(int point)
    {
        civilianarrest += point;
    }
    public static void CivilianKilledAddPoint(int point)
    {
        civiliankilled += point;
    }
    public static void EnemyArrestAddPoint(int point)
    {
        enemyarrest += point;
    }
    public static void EnemyKilledAddPoint(int point)
    {
        enemykilled += point;
    }
}
