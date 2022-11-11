using UnityEngine;
public abstract class AbstractBullet : MonoBehaviour
{
    [SerializeField] protected float damage;
    public float Damage { get; set; }
    public BulletMoveBehaviour moveBehaviour;
    public DamageDealerBehaviour damageDealerBehaviour;

    public void Move() { moveBehaviour.Move(Time.deltaTime); }
}