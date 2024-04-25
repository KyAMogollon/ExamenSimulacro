using UnityEngine;

public interface IvIAimable
{
    Vector2 Position { get; set; }
}

public interface IvIMoveable
{
    void Move(Vector2 direction);
}

public interface IvIAttackable
{
    void Attack(Vector2 position);
}