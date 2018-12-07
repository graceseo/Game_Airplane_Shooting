﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GSeoFinalProject
{
    class FighterShot
    {
        Game1 game;
        Score score;
        Rectangle rectangle;
        int test = 0;

        Texture2D shotTexture;

        public FighterShot(Game1 game, Score score, Vector2 startLocation)
        {
            this.game = game;
            this.score = score;
            shotTexture = game.Content.Load<Texture2D>("Images/fighterShot");
            rectangle = new Rectangle((int)startLocation.X, (int)startLocation.Y, shotTexture.Width, shotTexture.Height);
        }

        public void Update()
        {
            rectangle.Y -= 10;

            ////loop the static enemyList of EnemyControl Class
            //foreach (Enemy enemy in EnemyControl.enemyList)
            //{
            //    if (rectangle.Intersects(enemy.Rectangle))
            //    {
            //        enemy.EnemyDied();
            //        enemy.IsHit=true;
            //        test++;
            //    }
            //}
            for (int i=0; i<EnemyControl.enemyList.Count; i++)
            {
                if (rectangle.Intersects(EnemyControl.enemyList[i].Rectangle))
                {
                    EnemyControl.enemyList[i].IsHit = true;
                    EnemyControl.enemyList.RemoveAt(i);
                    score.CurrentScore += 100;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (rectangle.Y > shotTexture.Height * -1)
            {
                spriteBatch.Draw(shotTexture, rectangle, Color.White);

            }
        }
    }
}