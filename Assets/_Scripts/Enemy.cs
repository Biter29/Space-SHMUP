﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    public class Enemy : MonoBehaviour
    {
        [Header("Set in Inspector: Enemy")]
        public float speed = 10f;
        public float fireRate = 0.3f;
        public float health = 10;
        public int score = 100;

        protected BoundsCheck bndCheck;
        private void Awake()
        {
            bndCheck = GetComponent<BoundsCheck>();
        }
        public Vector3 pos
        {
            get
            {
                return (this.transform.position);
            }
            set
            {
                this.transform.position = value;
            }
        }


        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move();

            if (bndCheck != null && bndCheck.offDown)
            {

                Destroy(gameObject);

            }
        }
        public virtual void Move()
        {
            Vector3 tempPos = pos;
            tempPos.y -= speed * Time.deltaTime;
            pos = tempPos;
        }
        void OnCollisionEnter(Collision coll)
        {
            GameObject otherGO = coll.gameObject;
        switch (otherGO.tag)
        {
           
            case "ProjectileHero":
                Projectile p = otherGO.GetComponent<Projectile>();
                if (!bndCheck.isOnScreen)
                {
                    Destroy(otherGO);
                    break;
                }
                health -= Main.GetWeaponDefinition(p.type).damageonHit;
                if (health <= 0)
                {
                    Destroy(this.gameObject);
                }
                Destroy(otherGO);
                break;
            default:
                print("Enemy hit by non-projectile: " + otherGO.name);
                break;
        }
        
        }
    }
