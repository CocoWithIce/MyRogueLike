
using Unity.VisualScripting;
using UnityEngine;

public class EnemyData : ScriptableObject
{
    
}

public class EnemyDirector
{
    public Enemy Construct(EnemyBuilder builder, EnemyData data)
    {
        builder.AddWeaponComponent();
        builder.AddAnotherComponent();
        builder.AddLastComponent();

        return builder.Build();
    }
}

public class EnemyBuilder
{
    private Enemy enemy = new GameObject("Enemy").AddComponent<Enemy>();

    public void AddWeaponComponent()
    {
        enemy.gameObject.AddComponent<Rigidbody>();
    }
    public void AddAnotherComponent()
    {
        enemy.gameObject.AddComponent<Rigidbody>();
    }
    public void AddLastComponent()
    {
        enemy.gameObject.AddComponent<Rigidbody>();
    }

    public Enemy Build()
    {
        Enemy builtEnemy = enemy;
        enemy = new GameObject("Enemy").AddComponent<Enemy>();
        return builtEnemy;
    }
}

public class EnemyTest
{
    public float Health;

    private EnemyTest(Builder builder)
    {
    }

    public class Builder
    {
        protected float _health;
        private float _mana;
        private string _name;
        
        public Builder AddHealth(float health)
        {
            _health = health;
            return this;
        }

        public Builder AddMana(float mana)
        {
            _mana = mana;
            return this;
        }
        
        public Builder AddName(string name)
        {
            _name = name;
            return this;
        }

        public EnemyTest Build()
        {
            return new EnemyTest(this);
        }
    }
}

public class A
{
    public void Test()
    {
        var enemy = new EnemyTest.Builder()
            .AddHealth(100)
            .AddMana(50)
            .AddName("What") 
            .Build();
    }
}
