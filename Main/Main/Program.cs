using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace Main
{

    internal class Window3D : GameWindow
    {
        private Camera camera;


        private float triangleHeight = 10.0f;
        bool fallTriangle = false;
        bool showTriangle = false;

        const float rotation_speed = 180.0f;
        float angle;
        bool showCube = true;
        KeyboardState lastKeyPress;
        private const int XYZ_SIZE = 75;
        private bool axesControl = true;
        private int transStep = 0;
        private int radStep = 0;
        private int attStep = 0;

        private bool newStatus = false;
        private bool randomizeColors = false;  // Adăugat pentru a controla randomizarea culorilor
        private Random random = new Random();

      

        private int[,] objVertices = {
            {5, 10, 5,
                10, 5, 10,
                5, 10, 5,
                10, 5, 10,
                5, 5, 5,
                5, 5, 5,
                5, 10, 5,
                10, 10, 5,
                10, 10, 10,
                10, 10, 10,
                5, 10, 5,
                10, 10, 5},
            {5, 5, 12,
                5, 12, 12,
                5, 5, 5,
                5, 5, 5,
                5, 12, 5,
                12, 5, 12,
                12, 12, 12,
                12, 12, 12,
                5, 12, 5,
                12, 5, 12,
                5, 5, 12,
                5, 12, 12},
            {6, 6, 6,
                6, 6, 6,
                6, 6, 12,
                6, 12, 12,
                6, 6, 12,
                6, 12, 12,
                6, 6, 12,
                6, 12, 12,
                6, 6, 12,
                6, 12, 12,
                12, 12, 12,
                12, 12, 12}};
        private Color[] colorVertices = { Color.White, Color.LawnGreen, Color.WhiteSmoke, Color.Tomato, Color.Turquoise, Color.OldLace, Color.Olive, Color.MidnightBlue, Color.PowderBlue, Color.PeachPuff, Color.LavenderBlush, Color.MediumAquamarine };

        private Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            Console.WriteLine("1. Apasa A pentru a deplasa cubul la stanga.");
            Console.WriteLine("2. Apasa D pentru a deplasa cubul la dreapta.");
            Console.WriteLine("3. Apasa W pentru a deplasa cubul in sus.");
            Console.WriteLine("4. Apasa S pentru a deplasa cubul in jos.\n");

            Console.WriteLine("5. Apasa F pentru a roti cubul in sus.");
            Console.WriteLine("6. Apasa N pentru a roti cubul in jos.\n");

            Console.WriteLine("7. Apasa P pentru a afisa si ascunde cubul.");
            Console.WriteLine("8. Apasa L pentru a activa/dezactiva randomizarea culorilor.");
            Console.WriteLine("9. Apasa R pentru a imprima valorile RGB ale fetelor cubului.");
            Console.WriteLine("10. Apasa Escape pentru a inchide aplicatia.\n");

            Console.WriteLine("11. Apasa N pentru a seta camera la 'aproape'.");
            Console.WriteLine("12. Apasa F pentru a seta camera la 'departe'.\n");

            // Pentru comenzile de mouse
            Console.WriteLine("13. Click dreapta pentru a face triunghiul sa cada si sa fie vizibil.");
            Console.WriteLine("14. Click stanga pentru a citi culorile pixelilor la pozitia cursorului.\n");

            Console.WriteLine("15. Apasa UP pentru a ajusta camera in fata.");
            Console.WriteLine("16. Apasa DOWN pentru a ajusta camera in spate.");
            Console.WriteLine("17. Apasa LEFT pentru a ajusta camera la stanga.");
            Console.WriteLine("18. Apasa RIGHT pentru a ajusta camera la dreapta.");
            Console.WriteLine("19. Apasa Q pentru a ajusta camera in sus.");
            Console.WriteLine("20. Apasa E pentru a ajusta camera in jos.");
            camera = new Camera();
        }
        private void UpdateColors()
        {
            for (int i = 0; i < colorVertices.Length; i++)
            {
                // Alegeți între randomizarea culorilor sau selectarea dintr-o paletă predefinită
                if (randomizeColors)
                {
                    colorVertices[i] = GenerateRandomColor();
                }
                else
                {
                    // Alegeți culori din paletă
                    // Exemplu: colorVertices[i] = PaletaPredefinita[i];
                }
            }
        }
        
        private Color GenerateRandomColor()
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            // Switch back to modelview matrix mode
            GL.MatrixMode(MatrixMode.Modelview);

            // set the eye
            camera.SetCamera();
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

           /* if (mouse[MouseButton.Left])
            {
                Console.WriteLine("Click non-accelerat (" + mouse.X + "," + mouse.Y + "); accelerat (" + Mouse.X + "," + Mouse.Y + ")");
                IntPtr pix = new IntPtr();
                GL.ReadPixels(Mouse.X, Mouse.Y, 1, 1, PixelFormat.Rgb, PixelType.Int, pix);
                Console.WriteLine("Pixel colour (" + IntPtr.Size + " - 32 or 64 bits process);");
                Console.WriteLine("");
            }
           */



            if (mouse[MouseButton.Right])
            {
              
              fallTriangle = true;
                showTriangle = true;
            }

            if (fallTriangle)
            {
                
                triangleHeight -= 0.50f;

                if (triangleHeight < 0.0f)
                {
                    triangleHeight = 0.0f;
                    fallTriangle = false; 
                }
            }

            // Se utilizeaza mecanismul de control input oferit de OpenTK (include perifcerice multiple, inclusiv
            // pentru gaminig - gamepads, joysticks, etc.).
            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }

           

            if (keyboard[Key.P] && !keyboard.Equals(lastKeyPress))
            {
                // Ascundere comandată, prin apăsarea unei taste - cu verificare de remanență! Timpul de reacție
                // uman << calculator.
                if (showCube)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
            if (keyboard[Key.R] && !keyboard.Equals(lastKeyPress))
            {
                if (newStatus)
                {
                    newStatus = false;
                }
                else
                {
                    newStatus = true;
                }
            }

            if (keyboard[Key.A])
            {
                transStep--;
            }
            if (keyboard[Key.D])
            {
                transStep++;
            }

            if (keyboard[Key.W])
            {
                radStep--;
            }
            if (keyboard[Key.S])
            {
                radStep++;
            }

            if (keyboard[Key.F])
            {
                attStep++;
            }
            if (keyboard[Key.N])
            {
                attStep--;
            }
            if (keyboard[Key.L] && !keyboard.Equals(lastKeyPress))
            {
                randomizeColors = !randomizeColors;
                UpdateColors();
            }
            
            
           
                if (Keyboard[Key.Up])
                {
                    camera.MoveForward();
                }

                if (Keyboard[Key.Down])
                {
                    camera.MoveBackward();
                }

                if (Keyboard[Key.Left])
                {
                    camera.MoveLeft();
                }
                if (Keyboard[Key.Right])
                {
                    camera.MoveRight();
                }
                if (Keyboard[Key.Q])
                {
                    camera.MoveUp();
                }
                if (Keyboard[Key.E])
                {
                    camera.MoveDown();
                }

        //    HandleCameraMovement(keyboard);
            lastKeyPress = keyboard;
        }

protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            camera.SetCamera();
            if (newStatus)
            {
                PrintRGBValues();
                newStatus = false;
                DrawCube();
            }

            if (axesControl)
            {
                DrawAxes();
            }

            if (showCube == true)
            {
                GL.PushMatrix();
                GL.Translate(transStep, attStep, radStep);
                DrawCube();
                GL.PopMatrix();
            }
            if (showTriangle == true)
            {
                GL.PushMatrix();
                GL.Vertex3(objVertices[0, 0], objVertices[1, 0] + triangleHeight, objVertices[2, 0]);
                GL.Vertex3(objVertices[0, 1], objVertices[1, 1] + triangleHeight, objVertices[2, 1]);
                GL.Vertex3(objVertices[0, 2], objVertices[1, 2] + triangleHeight, objVertices[2, 2]);
                DrawTriangle();
                GL.PopMatrix();
            }

    
        //GL.Flush();

        //  DrawTriangle(); 

        SwapBuffers();
        }

        private void DrawAxes()
        {
            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 35; i += 3)
            {
                int colorIndex = i / 3;

                GL.Color3(colorVertices[colorIndex]);
                GL.Vertex3(objVertices[0, i], objVertices[1, i], objVertices[2, i]);
                GL.Vertex3(objVertices[0, i + 1], objVertices[1, i + 1], objVertices[2, i + 1]);
                GL.Vertex3(objVertices[0, i + 2], objVertices[1, i + 2], objVertices[2, i + 2]);
            }
            GL.End();
        }

        private void DrawTriangle()
        {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.White);

            // Top vertex
            GL.Vertex3(objVertices[0, 0], objVertices[1, 0] + triangleHeight, objVertices[2, 0]);

            // Bottom-left vertex
            GL.Vertex3(objVertices[0, 1], objVertices[1, 1] + triangleHeight, objVertices[2, 1]);

            // Bottom-right vertex
            GL.Vertex3(objVertices[0, 2], objVertices[1, 2] + triangleHeight, objVertices[2, 2]);

            GL.End();
        }


        private void PrintRGBValues()
        {
            Console.WriteLine("RGB values:");
            for (int i = 0; i < 12; i++)
            {
                // Get RGB values from the color
                int red = colorVertices[i].R;
                int green = colorVertices[i].G;
                int blue = colorVertices[i].B;

                // Print RGB values to the console
                Console.WriteLine($"Face {i + 1}: R={red}, G={green}, B={blue}");
            }
            Console.WriteLine();
        }



        [STAThread]
        static void Main(string[] args)
        {

            using (Window3D example = new Window3D())
            {
                example.Run(30.0, 0.0);
                
            }

        }
    }

}