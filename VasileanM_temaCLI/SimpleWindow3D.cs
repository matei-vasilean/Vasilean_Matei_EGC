
using OpenTK;
using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace lab2
{
    public class SimpleWindow3D : GameWindow
    {
        const float rotation_speed = 180.0f;
        float angleX, angleY;
        bool showCube = true;
        KeyboardState lastKeyPress;
        MouseState lastMouseState;

        public SimpleWindow3D() : base(800, 600)
        {
            VSync = VSyncMode.On;

            int screenWidth = DisplayDevice.Default.Width;
            int screenHeight = DisplayDevice.Default.Height;

            int windowX = (screenWidth - Width) / 2;
            int windowY = (screenHeight - Height) / 2;

            Location = new Point(windowX, windowY);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Blue);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();

            if (keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
                return;
            }

            else if (keyboard[OpenTK.Input.Key.P] && !keyboard.Equals(lastKeyPress))
            {
                if (showCube == true)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }
            lastKeyPress = keyboard;

            if (mouse[OpenTK.Input.MouseButton.Left] && !mouse.Equals(lastMouseState))
            {
                if (showCube == true)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
            }

            if (keyboard[OpenTK.Input.Key.A])
            {
                angleX -= rotation_speed * (float)e.Time;
            }

            if (keyboard[OpenTK.Input.Key.D])
            {
                angleX += rotation_speed * (float)e.Time;
            }

            if (!mouse.Equals(lastMouseState))
            {
                float deltaX = mouse.X - lastMouseState.X;
                angleY += deltaX * 0.01f;
            }
            lastMouseState = mouse;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Rotate(angleX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(angleY, 0.0f, 1.0f, 0.0f);

            if (showCube == true)
            {
                DrawCube();
                DrawAxes_OLD();
            }

            SwapBuffers();
        }

        private void DrawAxes_OLD()
        {
            GL.LineWidth(2);
            
            GL.Begin(PrimitiveType.Lines);

            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(25, 0, 0);

            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 25, 0);

            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 25);

            GL.End();

            GL.LineWidth(1);
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1.0f, 0.0f, 0.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.Color3(0.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(1.0f, 0.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.End();
        }
    }
}