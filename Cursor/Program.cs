using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Cursor
{
    internal class Program
    {
        static Vector2f cursorVelocity = new Vector2f(0, 0);
        static Vector2i lastCursorLocation = new Vector2i(0, 0);
        static void Main(string[] args)
        {
            Console.WriteLine("Grafity Mouse Started!");
            Console.WriteLine("Press ``escape`` to exit at any time!");
            while (!Windows.KeyPressed(System.Windows.Forms.Keys.Escape))
            {
                Vector2i delta =  Windows.GetCursorPosition() - lastCursorLocation;
                cursorVelocity += (Vector2f) delta;

                Vector2i location = Windows.GetCursorPosition();
                location += new Vector2i((int)cursorVelocity.x, (int)cursorVelocity.y);
                Windows.SetCursorPosition(location);
                
                lastCursorLocation = location;

                Thread.Sleep(3);

                cursorVelocity += new Vector2f(0, 1); // Grafity
                cursorVelocity /= 1.04f; // Apply some very non-sienctific drag
            }

            Console.WriteLine("Bye!");
        }
    }
}
