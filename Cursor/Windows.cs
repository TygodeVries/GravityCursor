using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;
namespace Cursor
{
    public class Windows
    {
        [DllImport("User32.Dll")]
        private static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static bool KeyPressed(Keys key)
        {
            return GetAsyncKeyState((int)((byte)key)) < 0;
        }

        public static Vector2i GetCursorPosition()
        {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            
            return lpPoint;
        }

        public static void SetCursorPosition(Vector2i vector)
        {
            SetCursorPos(vector.x, vector.y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Vector2i(POINT point)
        {
            return new Vector2i(point.X, point.Y);
        }
    }


    public class Vector2i
    {
        public int x, y;

        public Vector2i(int x, int y)
        {
            this.x = x; this.y = y;
        }

        public static Vector2i operator +(Vector2i a, Vector2i b)
        {
            return new Vector2i(a.x + b.x, a.y + b.y);
        }

        public static Vector2i operator -(Vector2i a, Vector2i b)
        {
            return new Vector2i(a.x - b.x, a.y - b.y);
        }

        public static explicit operator Vector2f(Vector2i x)
        {
            return new Vector2f(x.x, x.y);
        }
    }

    public class Vector2f
    {
        public float x, y;

        public Vector2f(float x, float y)
        {
            this.x = x; this.y = y;
        }

        public static Vector2f operator +(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.x + b.x, a.y + b.y);
        }

        public static Vector2f operator -(Vector2f a, Vector2f b)
        {
            return new Vector2f(a.x - b.x, a.y - b.y);
        }

        public static Vector2f operator /(Vector2f a, float b)
        {
            return new Vector2f(a.x / b, a.y / b);
        }

        public Vector2i Round()
        {
            return new Vector2i((int) Math.Round(x), (int) Math.Round(y));
        }
    }
}
