using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] enemies;
    public Transform Target;

    private static float timer = 5.0f;
    private static int cofactor = 1;

    private static List<Transform> enemyBuffer;

    private void Start()
    {
        enemyBuffer = new List<Transform>();
    }
    private static bool flag = false;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad * cofactor > timer && flag)
        {
            flag = !flag;
            cofactor++;
            StartCoroutine(CreateEnemy());
        }
        else if(Time.timeSinceLevelLoad * cofactor > timer / 2 && enemyBuffer.Count < 10)
        {
            StartCoroutine(RaiseEnemySlot());
        }
    }

    private Vector3 GetPosition()
    {
        int index = Random.Range(0, spawnPoints.Length);
        float posX = Random.value * 8 - 4,
              posY = 0.5f,
              posZ = Random.value * 8 - 4;

        return new Vector3(spawnPoints[index].position.x + posX,
                           posY,
                           spawnPoints[index].position.z + posZ);
    }

    private IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(timer);
        timer += 0.5f;
        int index = Random.Range(0, enemies.Length);
        var enemy = Instantiate(enemies[index]);
        enemy.position = GetPosition();
        enemy.gameObject.GetComponent<TrainedEnemyAgent>().Target = Target;
        enemyBuffer.Add(enemy);
    }

    private IEnumerator RaiseEnemySlot()
    {
        yield return new WaitForSeconds(4f);
        flag = !flag;
    }
}
