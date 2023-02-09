using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : Health
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

    public override void Die()
    {
        base.Die();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
