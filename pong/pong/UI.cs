using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace UI
{
	public class Button
	{
		//Button textute
		Texture2D Texture;
		// Button position
		Vector2 Position;
		//Button area
		Rectangle Area;
		//Button color
		Color color = Color.White;
		//Button Size
		Vector2 Size;
		string player1, player2;
		// Construtor da classe Botao
		public Button(Texture2D NewTexture, Vector2 NewSize)
		{
			//Define new texture of button
			Texture = NewTexture;

			//Define new size of button
			Size = NewSize;
		}
		bool down;
		public bool isClicked;
		public void Update(MouseState mouse)
        {
			//Define button position and size
			Area = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
			// Cria um retângulo para a posição atual do mouse
			Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

			// Verifica se o mouse está sobre o botão
			if (mouseRectangle.Intersects(Area))
			{
				down = true;
				color = Color.Gray;
				if (mouse.LeftButton == ButtonState.Pressed)
				{
					isClicked = true;
				}
				else if (mouse.LeftButton == ButtonState.Released)
				{
					isClicked = false;
				}
			}
            else
            {
				down = false;
				color = Color.White;
            }
        }
		public void setPosition(Vector2 newposition)
		{
			Position = newposition;
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
