using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public static int healthPoint;

    public static int startHealtPoint;
    public static int moneyForKill;

   [SerializeField]
    private Image indicator;

    [SerializeField]
    private int damageForBase;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int healtForEnemy;

    [SerializeField]
    private int moneyForEnemy;
    private Transform targetPoint;

    private int pointIndex=0;

    private void Start()
    {
        startHealtPoint = healtForEnemy;
        healthPoint = startHealtPoint;
        targetPoint = Points.points[0];
        moneyForKill = moneyForEnemy;
    }

    private void Update()
    {
       transform.position=Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        var indicatorWidth= healthPoint/startHealtPoint;
                var indicatorScale= indicator.transform.localScale;
                indicator.transform.localScale =new Vector3(indicatorWidth,indicatorScale.y,indicatorScale.z);

         var distance=Vector3.Distance(transform.position, targetPoint.position);

        if(distance <= 0.4f){
            GetNextPoint();
        }
    }

    private void GetNextPoint(){
        if(pointIndex >= Points.points.Length-1){
            Destroy(gameObject);
            PlayerStats.Lifes -= damageForBase;
            return;

        }
        pointIndex++;
        targetPoint=Points.points[pointIndex];
    }
}
