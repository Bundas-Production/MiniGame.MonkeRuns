using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    GameObject monsterCharacter;
    [SerializeField]
    Animator animator;
    [Space]
    [SerializeField]
    Transform player;
    [Space]
    [SerializeField]
    GameObject snowball;
    [SerializeField]
    float snowballsPerAttack = 10.0f;
    [SerializeField]
    float snowballSpawnRatio = 10.0f;
    [Space]
    [SerializeField]
    float despawnDistance = 10.0f;
    float respawnTime = 3.0f;

    private void OnEnable()
    {
        StartCoroutine(Behaviour());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Behaviour()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            // Call here the animation instead of this function (Remove this one and call it from animation)
            SpawnSnowballs();

            IncreaseSnowballAtack();

            yield return new WaitForSeconds(5.0f);

            if (Vector3.Distance(transform.position, player.position) > 5.0f)
            {
                Despawn();
                yield return new WaitForSeconds(respawnTime);
                Spawn(new Vector3(player.position.x + Random.Range(-1.0f, 1.0f), transform.position.y, transform.position.z));
            }
        }
    }

    void Spawn(Vector3 position)
    {
        this.transform.position = position;
        monsterCharacter.SetActive(true);
    }

    void Despawn()
    {
        monsterCharacter.SetActive(false);
    }

    public void SpawnSnowballs()
    {
        for (int i = 0; i < snowballsPerAttack; i++)
        {
            GameObject newSnowball = Instantiate(snowball);
            newSnowball.transform.position = new Vector3(player.position.x + Random.Range(-snowballSpawnRatio, snowballSpawnRatio), Random.Range(7.0f, 15.0f), 0);
            float scale = Random.Range(0.5f, 2.0f);
            newSnowball.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    void IncreaseSnowballAtack()
    {
        if (snowballsPerAttack >= 20) return;
        snowballsPerAttack += 2;
        snowballSpawnRatio = snowballsPerAttack * 2.5f;
    }
}
