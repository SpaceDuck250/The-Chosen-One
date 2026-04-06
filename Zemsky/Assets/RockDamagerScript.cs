using UnityEngine;

public class RockDamagerScript : MonoBehaviour
{
    public GameObject shadow;

    public GameObject DamageZone;

    public GameObject crack;

    private void AnimFunctionSpawnDamageZone()
    {
        gameObject.SetActive(false);
        shadow.SetActive(false);
        DamageZone.SetActive(true);

        Instantiate(crack, transform.position, Quaternion.identity);
    }
}
