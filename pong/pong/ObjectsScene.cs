using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace ObjectsScene
{
	public class ball
    {
		//ball textute
		Texture2D Texture;
		//ball position
		Vector2 Position;
		//ball velocity
		Vector2 velocity;
		//ball area
		Rectangle Area;
		//ball color
		Color color = Color.White;
		//ball Size
		Vector2 Size;
		public ball(Texture2D NewTexture, Vector2 NewSize)
		{
			//Define new texture of button
			Texture = NewTexture;

			//Define new size of button
			Size = NewSize;
		}
		public void setPosition(Vector2 newposition)
		{
			Position = newposition;
		}
		public void Update()
		{
			Area = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
			Position = new Vector2(Position.X + velocity.X, Position.Y - velocity.Y);
		}
		public Vector2 getposition()
		{
			return Position;
		}
		public void setXvelocity(int x)
        {
			velocity = new Vector2(x, velocity.Y);
        }
		public void setYvelocity(int y)
		{
			velocity = new Vector2(velocity.X, y);
		}
		public Vector2 getvelocity()
        {
			return velocity;
        }
		public void Draw(SpriteBatch spriteBatch)
		{
			if (Texture == null)
			{
				throw new Exception("Texture is null");
			}
			else if (Area == null)
			{
				throw new Exception("Area is null");
			}
			else if (color == null)
			{
				throw new Exception("color is null");
			}
			else
			{
				spriteBatch.Draw(Texture, Area, color);
			}
		}
}
	public class PongPlayer
	{
		//player textute
		Texture2D Texture;
		//player position
		Vector2 Position;
		//player area
		Rectangle Area;
		//player color
		Color color = Color.White;
		//player Size
		Vector2 Size;
		public PongPlayer(Texture2D NewTexture, Vector2 NewSize)
		{
			//Define new texture of button
			Texture = NewTexture;

			//Define new size of button
			Size = NewSize;
		}
		public void setPosition(Vector2 newposition)
		{
			Position = newposition;
		}
		public void Update()
        {
			Area = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
		}
		public Vector2 getposition()
        {
			return Position;
        }
		public void Draw(SpriteBatch spriteBatch)
		{
			if (Texture == null)
			{
				throw new Exception("Texture is null");
			}
			else if (Area == null)
			{
				throw new Exception("Area is null");
			}
			else if (color == null)
			{
				throw new Exception("color is null");
			}
			else
			{
				spriteBatch.Draw(Texture, Area, color);
			}
		}
	}
}


