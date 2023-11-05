using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace ConsoleApp2
{
    class SimpleWindow : GameWindow
    {
        private float objectX = 0.0f;
        private float objectY = 0.0f;

        private Color vertexColor1 = Color.MidnightBlue;
        private Color vertexColor2 = Color.SpringGreen;
        private Color vertexColor3 = Color.Ivory;

        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Up)
                objectY += 0.1f;
            if (e.Key == Key.Down)
                objectY -= 0.1f;
            if (e.Key == Key.Left)
                objectX -= 0.1f;
            else if (e.Key == Key.Right)
                objectX += 0.1f;
            else if (e.Key == Key.R)
            {
                // Modifică culoarea primului vertex la roșu
                vertexColor1 = Color.Red;
            }
            else if (e.Key == Key.G)
            {
                // Modifică culoarea celui de-al doilea vertex la verde
                vertexColor2 = Color.Green;
            }
            else if (e.Key == Key.B)
            {
                // Modifică culoarea celui de-al treilea vertex la albastru
                vertexColor3 = Color.Blue;
            }
            Console.WriteLine($"Vertex 1: R={vertexColor1.R}, G={vertexColor1.G}, B={vertexColor1.B}");
            Console.WriteLine($"Vertex 2: R={vertexColor2.R}, G={vertexColor2.G}, B={vertexColor2.B}");
            Console.WriteLine($"Vertex 3: R={vertexColor3.R}, G={vertexColor3.G}, B={vertexColor3.B}\n");

        }

        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            objectX = (float)e.X / Width * 2.0f - 1.0f;
            objectY = 1.0f - (float)e.Y / Height * 2.0f;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Black);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(objectX, objectY, -2.0);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(vertexColor1);
            GL.Vertex2(-1.0f, 1.0f);

            GL.Color3(vertexColor2);
            GL.Vertex2(0.0f, -1.0f);

            GL.Color3(vertexColor3);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            this.SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
