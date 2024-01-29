using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK.Platform;
using OpenTK.Graphics.OpenGL;
using OpenTK;

/**
    Aplicația utilizează biblioteca OpenTK v2.0.0 (stable) oficială și OpenTK. GLControl v2.0.0
    (unstable) neoficială. Aplicația fiind scrisă în modul GUI (WinForms) vom utiliza controlul WinForms
    oferit de OpenTK, pe acre îl vom importa in Toolbox! Acest lucru se poate face doar dacă copiem
    local packetul OpenTK.GLControl.dll oferit de NuGet, apoi îl aducem ca referință în Toolbox.
    Tipul de ferestră utilizat: FORM. Se demmonstrează modul imediat de randare (vezi comentariu!)...
**/
namespace OpenTK_winforms_z01 {
    public partial class OpenGLWnd : Form {

        /// <summary>
        /// Constante utilizate în aplicație.
        /// </summary>
        private const int XYZ_SIZE = 75;

        /// <summary>
        /// Variabile de stare pentru partea de interacțiune/randare 3D.
        /// </summary>
        private float eyePosX = 100;
        private float eyePosY = 100;
        private float eyePosZ = 50;
        private Point mousePos;

        private int pointX_1 = 35;
        private int pointY_1 = 55;
        private int pointZ_1 = 55;
        private int pointX_2 = 45;
        private int pointY_2 = 60;
        private int pointZ_2 = 55;

        private int lineX_1 = 35;
        private int lineY_1 = 25;
        private int lineZ_1 = 20;
        private int lineX_2 = 70;
        private int lineY_2 = 25;
        private int lineZ_2 = 40;

        private float[] triangle_1 = { 35, 25, 20 };
        private float[] triangle_2 = { 70, 25, 40 };
        private float[] triangle_3 = { 30, 60, 50 };

        private int[,] objVertices = {{25, 50, 25,
                                      50, 25, 50,
                                      25, 50, 25,
                                      50, 25, 50,
                                      25, 25, 25,
                                      25, 25, 25,
                                      25, 50, 25,
                                      50, 50, 25,
                                      50, 50, 50,
                                      50, 50, 50,
                                      25, 50, 25,
                                      50, 50, 25},
                                     {25, 25, 60,
                                      25, 60, 60,
                                      25, 25, 25,
                                      25, 25, 25,
                                      25, 60, 25,
                                      60, 25, 60,
                                      60, 60, 60,
                                      60, 60, 60,
                                      25, 60, 25,
                                      60, 25, 60,
                                      25, 25, 60,
                                      25, 60, 60},
                                     {30, 30, 30,
                                      30, 30, 30,
                                      30, 30, 60,
                                      30, 60, 60,
                                      30, 30, 60,
                                      30, 60, 60,
                                      30, 30, 60,
                                      30, 60, 60,
                                      30, 30, 60,
                                      30, 60, 60,
                                      60, 60, 60,
                                      60, 60, 60}};
        private Color[] colorVertices = { Color.White, Color.LawnGreen, Color.WhiteSmoke, Color.Tomato, Color.Turquoise, Color.OldLace, Color.Olive, Color.MidnightBlue, Color.PowderBlue, Color.PeachPuff, Color.LavenderBlush, Color.MediumAquamarine };

        /// <summary>
        /// Variabile de control pentru partea de interacțiune/randare 3D.
        /// </summary>
        private bool axesControl = true;
        private bool mouse2DControl = false;
        private bool mouse3DControl = false;

        private bool pointsControl = false;
        private bool linesControl = false;
        private bool triangleControl = false;
        private bool objectControl = false;

        private bool translateTriangleControl = false;
        private int translateTriangleVal = 0;

        private float cameraRotationX = 0.0f;
        private float cameraRotationY = 0.0f;
        private bool isMousePressed = false;
        private Point lastMousePos;
        /// <summary>
        /// Constructor default.
        /// </summary>
        public OpenGLWnd() {
            InitializeComponent();
            glControlDemo.PreviewKeyDown += glControlDemo_PreviewKeyDown;
            chkCameraControl.CheckedChanged += chkCameraControl_CheckedChanged;

        }

        /// <summary>
        /// Setare mediu OpenGL și încarcarea resurselor (dacă e necesar) - de exemplu culoarea de
        /// fundal a controlului 3D.
        /// Atenție! Acest cod se execută înainte de desenarea efectivă a scenei 3D.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            base.DoubleBuffered = true;
            btnTranslateCurrentObject.Text = "T" + Environment.NewLine + "R" + Environment.NewLine + "A" + Environment.NewLine + "N" + Environment.NewLine + "S" + Environment.NewLine + "L" + Environment.NewLine + "A" + Environment.NewLine + "T" + Environment.NewLine + "E";

            // Ne asigurăm că viewport-ul este setat corect - nu uitați că prima desenare a ferestrei
            // va permite trecerea de la fereastra de mărime (0,0) la cea de mărime specificată - fără
            // un resize vom avea un control de mărime (0,0).
            glControlDemo_Resize(this, EventArgs.Empty);    // Setare viewport.
            SetGLControlDefaultBackground();                // Setare culoare fundal control GL.
        }

        /// <summary>
        /// Inițierea afișării și setarea viewport-ului grafic.
        /// Viewport-ul va fi dimensionat conform mărimii ferestrei active (cele 2 obiecte pot avea și mărimi 
        /// diferite).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControlDemo_Resize(object sender, EventArgs e) {
            if (glControlDemo.ClientSize.Height == 0) {
                glControlDemo.ClientSize = new System.Drawing.Size(glControlDemo.ClientSize.Width, 1);
            }

            SetGLDefaultViewport(glControlDemo);
        }

        /// <summary>
        /// Secțiunea de randare a scenei 3D pe controlul GL. Este declanșată de invalidarea acestuia la
        /// utilizarea metodei "Invalidate()" (printre altele). Randarea aceasta se poate face programatic
        /// (de către sistem) când acesta are nevoie, sau comandat dacă am făcut vreo actualizate în mod
        /// explicit în modelul 3D.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControlDemo_Paint(object sender, PaintEventArgs e) {
            glControlDemo.MakeCurrent();

            float aspect_ratio = Width / (float)Height;
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
            Matrix4 lookat = Matrix4.LookAt(eyePosX, eyePosY, eyePosZ, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            //Corecții de adâncime de culoare.
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            //Resetează buffer-ele la valori default.
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.Rotate(cameraRotationX, 1, 0, 0);
            GL.Rotate(cameraRotationY, 0, 1, 0);
            // Camera control - rotatie 2D/3D cu ajutorul mouse-ului.
            if (mouse2DControl == true) {
                // Doar după Ox.
                GL.Rotate(mousePos.X, 1, 0, 0);
            }
            if (mouse3DControl == true) {
                // Doar după Ox.
                GL.Rotate(mousePos.X, 1, 1, 1);
            }

            // Scena 3D!
            if (axesControl) {
                DrawAxes();
            }

            if (pointsControl) {
                DrawPoints();
            }

            if (linesControl) {
                DrawLine();
            }

            if (triangleControl) {
                if (translateTriangleControl) {
                    GL.Translate(1.0f + translateTriangleVal, 1.0f + translateTriangleVal, 1.0f + translateTriangleVal);
                    DrawTriangle();
                    translateTriangleControl = false;
                } else {
                    GL.Begin(PrimitiveType.Triangles);
                    GL.Color3(Color.Magenta);
                    GL.Vertex3(triangle_1[0], triangle_1[1], triangle_1[2]);
                    GL.Vertex3(triangle_2[0], triangle_2[1], triangle_2[2]);
                    GL.Vertex3(triangle_3[0], triangle_3[1], triangle_3[2]);
                    GL.End();
                }
            }

            if (objectControl) {
                DrawObject();
            }

            glControlDemo.SwapBuffers();
        }

        /**********************************************************************************************
         * 3D scene area!
         **********************************************************************************************/
        /// <summary>
        /// Desenează axele de coordonate. Dimensiunea absolută implicită a acestora este 150 (modificabil 
        /// din constanta XYZ_SIZE declarată).
        /// </summary>
        private void DrawAxes() {
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

        private void DrawPoints() {
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.White);
            GL.Vertex3(pointX_1, pointY_1, pointZ_1);
            GL.End();
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Red);
            GL.Vertex3(pointX_2, pointY_2, pointZ_2);
            GL.End();
        }

        private void DrawLine() {
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.White);
            GL.Vertex3(lineX_1, lineY_1, lineZ_1);
            GL.Vertex3(lineX_2, lineY_2, lineZ_2);
            GL.End();
        }

        private void DrawTriangle() {
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(Color.Magenta);
            GL.Vertex3(triangle_1[0], triangle_1[1], triangle_1[2]);
            GL.Vertex3(triangle_2[0], triangle_2[1], triangle_2[2]);
            GL.Vertex3(triangle_3[0], triangle_3[1], triangle_3[2]);
            GL.End();
        }

        private void DrawObject() {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 35; i = i + 3) {
                //For i As Integer = 0 To 35 Step 3
                GL.Color3(colorVertices[i / 3]);
                GL.Vertex3(objVertices[0, i], objVertices[1, i], objVertices[2, i]);
                GL.Vertex3(objVertices[0, i + 1], objVertices[1, i + 1], objVertices[2, i + 1]);
                GL.Vertex3(objVertices[0, i + 2], objVertices[1, i + 2], objVertices[2, i + 2]);
            }
            GL.End();
        }

        /**********************************************************************************************
         * OpenGL/OpenTK helper functions area!
         **********************************************************************************************/
        /// <summary>
        /// Setează culoarea de fundal specificată pentru controlul OpenTK. Culoarea default preferată este
        /// negrul...
        /// </summary>
        /// <param name="col"></param>
        private void SetGLControlBackground(Color col) {
            GL.ClearColor(col);
        }

        /// <summary>
        /// Setează culoarea de fundal deafult pentru controlul OpenTK. Culoarea default preferată este
        /// negrul...
        /// </summary>
        private void SetGLControlDefaultBackground() {
            GL.ClearColor(Color.Black);
        }

        /// <summary>
        /// Setează dimensiunea default a viewport-ului, bazată pe cea a zonei-client a controlului OpenTK.
        /// </summary>
        /// <param name="ctrl"></param>
        private void SetGLDefaultViewport(GLControl ctrl) {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControlDemo.ClientSize.Width, 0, glControlDemo.ClientSize.Height, -1, 1);
            GL.Viewport(0, 0, glControlDemo.ClientSize.Width, glControlDemo.ClientSize.Height);
        }


        /**********************************************************************************************
         * CONTROLS area!
         **********************************************************************************************/
        private void btnBgWhite_Click(object sender, EventArgs e) {
            SetGLControlBackground(Color.White);

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnBgBlue_Click(object sender, EventArgs e) {
            SetGLControlBackground(Color.MidnightBlue);

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnBgRed_Click(object sender, EventArgs e) {
            SetGLControlBackground(Color.IndianRed);

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnBgReset_Click(object sender, EventArgs e) {
            SetGLControlDefaultBackground();

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        /// <summary>
        /// Controlează afișarea axelor de coordonate!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAxes_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked == true) {
                axesControl = true;
            } else {
                axesControl = false;
            }

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        /// <summary>
        /// Controlează mișcarea universului 3D cu ajutorul mouse-ului după 2 axe (a 3-a e fixă).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMouse2D_Click(object sender, EventArgs e) {
            if (mouse2DControl == false) {
                unset3Dmouse();
                set2Dmouse();
            } else {
                unset2Dmouse();
            }

            // Forțează redesenarea canvasului!
            //glControlDemo.Invalidate();
        }

        /// <summary>
        /// Controlează mișcarea universului 3D cu ajutorul mouse-ului după 3 axe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMouse3D_Click(object sender, EventArgs e) {
            if (mouse3DControl == false) {
                unset2Dmouse();
                set3Dmouse();
            } else {
                unset3Dmouse();
            }

            // Forțează redesenarea canvasului!
            //glControlDemo.Invalidate();
        }

        private void set2Dmouse() {
            mouse2DControl = true;
            btnMouse2D.Font = new Font(btnMouse2D.Font, FontStyle.Regular);
        }

        private void unset2Dmouse() {
            mouse2DControl = false;
            btnMouse2D.Font = new Font(btnMouse2D.Font, FontStyle.Strikeout);
        }

        private void set3Dmouse() {
            mouse3DControl = true;
            btnMouse3D.Font = new Font(btnMouse3D.Font, FontStyle.Regular);
        }

        private void unset3Dmouse() {
            mouse3DControl = false;
            btnMouse3D.Font = new Font(btnMouse3D.Font, FontStyle.Strikeout);
        }
        private void glControlDemo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                isMousePressed = true;
                lastMousePos = e.Location;
            }
        }
        private void glControlDemo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                isMousePressed = false;
            }
        }
        private void glControlDemo_MouseMove(object sender, MouseEventArgs e)
        {
            mousePos = e.Location;
            lblPointerDisplay.Text = e.X.ToString() + " , " + e.Y.ToString();

            // Forțează redesenarea canvasului!
            if (isMousePressed)
            {
                float deltaX = e.X - lastMousePos.X;
                float deltaY = e.Y - lastMousePos.Y;

                const float rotationSpeed = 0.5f;
                const float movementSpeed = 0.1f;

                // Rotate camera
                cameraRotationY += deltaX * rotationSpeed;
                cameraRotationX += deltaY * rotationSpeed;

                // Move camera
                if (e.Button == MouseButtons.Right)
                {
                    eyePosX += deltaX * movementSpeed;
                    eyePosY -= deltaY * movementSpeed; // Invert Y-axis for natural movement
                }

                lastMousePos = e.Location;

                // Forțează redesenarea canvasului!
                glControlDemo.Invalidate();
            }
        }

        private void glControlDemo_MouseLeave(object sender, EventArgs e) {
            lblPointerDisplay.Text = "";
        }

        /// <summary>
        /// Manipulează adâncimea perspectivei pentru axa Ox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spinnerXposView_ValueChanged(object sender, EventArgs e) {
            eyePosX = (int)((NumericUpDown)sender).Value;

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        /// <summary>
        /// Manipulează adâncimea perspectivei pentru axa Oy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spinnerYposView_ValueChanged(object sender, EventArgs e) {
            eyePosY = (int)((NumericUpDown)sender).Value;

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        /// <summary>
        /// Manipulează adâncimea perspectivei pentru axa Oz.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spinnerZposView_ValueChanged(object sender, EventArgs e) {
            eyePosZ = (int)((NumericUpDown)sender).Value;

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnDrawPoints_Click(object sender, EventArgs e) {
            UnsetAllObjects();
            SetPoints();

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnDrawLine_Click(object sender, EventArgs e) {
            UnsetAllObjects();
            SetLine();

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnDrawTriangle_Click(object sender, EventArgs e) {
            UnsetAllObjects();
            SetTriangle();

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnDrawObject_Click(object sender, EventArgs e) {
            UnsetAllObjects();
            SetObject();

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnTranslateCurrentObject_Click(object sender, EventArgs e) {
            // Momentan doar triunghiul!!!
            translateTriangleControl = true;
            translateTriangleVal++;

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void btnResetObjects_Click(object sender, EventArgs e) {
            UnsetAllObjects();

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }

        private void SetPoints() {
            pointsControl = true;
        }

        private void UnsetPoints() {
            pointsControl = false;
        }

        private void SetLine() {
            linesControl = true;
        }

        private void UnsetLine() {
            linesControl = false;
        }

        private void SetTriangle() {
            triangleControl = true;
        }

        private void UnsetTriangle() {
            triangleControl = false;
        }

        private void SetObject() {
            objectControl = true;
        }

        private void UnsetObject() {
            objectControl = false;
        }

        private void UnsetAllObjects() {
            translateTriangleVal = 0;

            UnsetPoints();
            UnsetLine();
            UnsetTriangle();
            UnsetObject();
        }

        private void glControlDemo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            HandlePointTranslation(e.KeyCode);

            // Handle camera rotation
            HandleCameraRotation(e.KeyCode);
        }
        private void HandleCameraRotation(Keys key)
        {
            const float rotationSpeed = 2.0f;

            switch (key)
            {
                case Keys.U:
                    cameraRotationY += rotationSpeed;
                    break;
                case Keys.I:
                    cameraRotationY -= rotationSpeed;
                    break;
                case Keys.O:
                    cameraRotationX += rotationSpeed;
                    break;
                case Keys.P:
                    cameraRotationX -= rotationSpeed;
                    break;
            }

            // Forțează redesenarea canvasului!
            glControlDemo.Invalidate();
        }
        private void chkCameraControl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCameraControl.Checked)
            {
                // Enable camera control
                glControlDemo.MouseMove += glControlDemo_CameraMouseMove;
            }
            else
            {
                // Disable camera control
                glControlDemo.MouseMove -= glControlDemo_CameraMouseMove;
            }
        }
        private void glControlDemo_CameraMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
              
                // rotate around the Y-axis here
                eyePosX += e.X - mousePos.X;
                eyePosY += e.Y - mousePos.Y;

                // Update the mouse position
                mousePos = e.Location;

                // Force redrawing of the scene
                glControlDemo.Invalidate();
            }
        }
        private void HandlePointTranslation(Keys key)
        {


            switch (key)
            {
                case Keys.Up:
                    pointY_1 += 1;
                    pointY_2 += 1;
                    lineY_1 += 1;
                    lineY_2 += 1;
                    triangle_1[1] += 1;
                    triangle_2[1] += 1;
                    triangle_3[1] += 1;

                    for (int i = 1; i < objVertices.GetLength(1); i += 3)
                        objVertices[1, i] += 1;
                  

                    break;
                case Keys.Down:
                    pointY_1 -= 1;
                    pointY_2 -= 1;
                    lineY_1 -= 1;
                    lineY_2 -= 1;
                    triangle_1[1] -= 1;
                    triangle_2[1] -= 1;
                    triangle_3[1] -= 1;

                    for (int i = 1; i < objVertices.GetLength(1); i += 3)
                        objVertices[1, i] -= 1;
                    break;
                case Keys.Left:
                    pointX_1 -= 1;
                    pointX_2 -= 1;
                    lineX_1 -= 1;
                    lineX_2 -= 1;
                    triangle_1[0] -= 1;
                    triangle_2[0] -= 1;
                    triangle_3[0] -= 1;

                    for (int i = 0; i < objVertices.GetLength(1); i += 3)
                        objVertices[0, i] -= 1;
                    break;
                case Keys.Right:
                    pointX_1 += 1;
                    pointX_2 += 1;
                    lineX_1 += 1;
                    lineX_2 += 1;
                    triangle_1[0] += 1;
                    triangle_2[0] += 1;
                    triangle_3[0] += 1;

                    for (int i = 0; i < objVertices.GetLength(1); i += 3)
                        objVertices[0, i] += 1;
                    break;
                case Keys.W:
                    pointZ_1 += 1;
                    pointZ_2 += 1;
                    lineZ_1 += 1;
                    lineZ_2 += 1;
                    triangle_1[2] += 1;
                    triangle_2[2] += 1;
                    triangle_3[2] += 1;
                    for (int i = 2; i < objVertices.GetLength(1); i += 3)
                        objVertices[2, i] += 1;

                    break;
                case Keys.S:
                    pointZ_1 -= 1;
                    pointZ_2 -= 1;
                    lineZ_1 -= 1;
                    lineZ_2 -= 1;
                    triangle_1[2] -= 1;
                    triangle_2[2] -= 1;
                    triangle_3[2] -= 1;

                    for (int i = 2; i < objVertices.GetLength(1); i += 3)
                        objVertices[2, i] -= 1;
                    break;
                case Keys.Q:
                    RotateTriangle(5.0f, 1.0f, 0.0f, 0.0f); // Rotirea cu 5 grade în jurul axei X
                    break;
                case Keys.E:
                    RotateTriangle(-5.0f, 1.0f, 0.0f, 0.0f); // Rotirea cu -5 grade în jurul axei X
                    break;
                case Keys.R:
                    TranslateTriangle(1.0f, 0.0f, 0.0f); // Translatarea la dreapta
                    break;
                case Keys.F:
                    TranslateTriangle(-1.0f, 0.0f, 0.0f); // Translatarea la stânga
                    break;
                case Keys.T:
                    ScaleTriangle(1.1f, 1.1f, 1.1f); // Scalarea triunghiului
                    break;
                case Keys.G:
                    ScaleTriangle(0.9f, 0.9f, 0.9f); // Micșorarea triunghiului
                    break;
            }

           
            glControlDemo.Invalidate();
        }

        private void TranslateTriangle(float translateX, float translateY, float translateZ)
        {
            triangle_1[0] += translateX;
            triangle_1[1] += translateY;
            triangle_1[2] += translateZ;

            triangle_2[0] += translateX;
            triangle_2[1] += translateY;
            triangle_2[2] += translateZ;

            triangle_3[0] += translateX;
            triangle_3[1] += translateY;
            triangle_3[2] += translateZ;
        }
        private void RotateTriangle(float angle, float axisX, float axisY, float axisZ)
        {
         //   triangleRotateAngle += angle;
          
            triangle_1[0] += axisX;
            triangle_1[1] += axisY;
            triangle_1[2] += axisZ;

            triangle_2[0] += axisX;
            triangle_2[1] += axisY;
            triangle_2[2] += axisZ;

            triangle_3[0] += axisX;
            triangle_3[1] += axisY;
            triangle_3[2] += axisZ;
        }

    

        private void ScaleTriangle(float scaleX, float scaleY, float scaleZ)
        {
        triangle_1[0] += scaleX;
        triangle_1[1] += scaleY;
        triangle_1[2] += scaleZ;

        triangle_2[0] += scaleX;
        triangle_2[1] += scaleY;
        triangle_2[2] += scaleZ;

        triangle_3[0] += scaleX;
        triangle_3[1] += scaleY;
        triangle_3[2] += scaleZ;
    }


    }
}

