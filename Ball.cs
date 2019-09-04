using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ARKANOID
    {
    public class Ball
        {
        public Vector2 position;
        public Point size;
        Texture2D texture;
        public Vector2 speed;

        public Ball(Texture2D texture)
            {

                this.texture = texture;
                size = new Point(texture.Width,texture.Height);
                position = new Vector2(Screen.WIDTH /2 - size.X /2,Screen.HEIGHT /2 - size.Y /2);
                speed = new Vector2(100,-100) * 4;

            }

        public void Update(GameTime gameTime)
            {
                position += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

                if (position.X < 0 ||
                        position.X + size.X > Screen.WIDTH * 3 / 4)//vai bater na parte no score no background
                    {
                        speed.X *= -1;
                        Score.getInstance().SCORE +=1;
                    }

                if (position.Y < 0 || position.Y + size.Y >Screen.HEIGHT)
                    {
                        speed.Y *= -1;
                    }

            }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            {
                spriteBatch.Draw(texture, new Rectangle((int)position.X,(int)position.Y, size.X, size.Y),
                            Color.White);
            }


        }
    }
