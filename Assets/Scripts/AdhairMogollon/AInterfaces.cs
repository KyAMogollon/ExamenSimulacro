using UnityEngine;

public interface AIAimable
{
    Vector2 Position { get; set; }
}

public interface AIMoveable
{
    void Move(Vector2 direction);
}

public interface AIAttackable
{
    void Attack(Vector2 position);
}