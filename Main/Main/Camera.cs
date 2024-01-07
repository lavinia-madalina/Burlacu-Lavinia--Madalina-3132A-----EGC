using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Main
{
    class Camera
    {
        private Vector3 eye;
        private Vector3 target;
        private Vector3 up_vector;

        private const int MOVEMENT_UNIT = 1;


        public Camera()
        {
            // Set the initial position of the camera
            eye = new Vector3(25, 25, 25);  // Adjust the values based on your scene and preferences
            target = new Vector3(0, 0, 0);   // Assuming the cube is centered at the origin
            up_vector = new Vector3(0, 1, 0); // Up vector (adjust as needed)
        }



        public Camera(Vector3 _eye, Vector3 _target, Vector3 _up)
        {
            eye = _eye;
            target = _target;
            up_vector = _up;
        }

        public void SetCamera()
        {
            Matrix4 cameraMatrix = Matrix4.LookAt(eye, target, up_vector);
            GL.LoadMatrix(ref cameraMatrix);
        }


        public void MoveRight()
        {
            Vector3 right = Vector3.Cross(up_vector, target - eye).Normalized();
            eye += right * MOVEMENT_UNIT;
            target += right * MOVEMENT_UNIT;
            SetCamera();
        }

        // Implement similar modifications for other movement methods

        public void MoveLeft()
        {
            eye = new Vector3(eye.X, eye.Y, eye.Z + MOVEMENT_UNIT);
            target = new Vector3(target.X, target.Y, target.Z + MOVEMENT_UNIT);
            SetCamera();
        }

        public void MoveForward()
        {
            eye = new Vector3(eye.X - MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X - MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        public void MoveBackward()
        {
            eye = new Vector3(eye.X + MOVEMENT_UNIT, eye.Y, eye.Z);
            target = new Vector3(target.X + MOVEMENT_UNIT, target.Y, target.Z);
            SetCamera();
        }

        public void MoveUp()
        {
            eye = new Vector3(eye.X, eye.Y + MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y + MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

        public void MoveDown()
        {
            eye = new Vector3(eye.X, eye.Y - MOVEMENT_UNIT, eye.Z);
            target = new Vector3(target.X, target.Y - MOVEMENT_UNIT, target.Z);
            SetCamera();
        }

    }
}
