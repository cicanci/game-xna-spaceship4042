using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShip4042.Class
{
    public class Collision
    {
        public static bool IntersectPixels(Rectangle rectangleA, Color[] dataA,
                    Rectangle rectangleB, Color[] dataB)
        {
            if ((rectangleA != null) && (dataA != null) && (rectangleB != null) && (dataB != null))
            {
                // Find the bounds of the rectangle intersection
                int top = Math.Max(rectangleA.Top, rectangleB.Top);
                int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
                int left = Math.Max(rectangleA.Left, rectangleB.Left);
                int right = Math.Min(rectangleA.Right, rectangleB.Right);

                // Check every point within the intersection bounds
                for (int y = top; y < bottom; y++)
                {
                    for (int x = left; x < right; x++)
                    {
                        // Get the color of both pixels at this point
                        Color colorA = dataA[(x - rectangleA.Left) +
                                             (y - rectangleA.Top) * rectangleA.Width];
                        Color colorB = dataB[(x - rectangleB.Left) +
                                             (y - rectangleB.Top) * rectangleB.Width];

                        // If both pixels are not completely transparent,
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            // then an intersection has been found
                            return true;
                        }
                    }
                }
            }

            // No intersection found
            return false;
        }
    }
}
