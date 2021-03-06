﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clothes_Pick
{
    public class ScrollablePanel : Panel
    {
        private Point _mouseLastPosition;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseLastPosition = e.Location;
            }
            base.OnMouseDown(e);
        }

        private int ValidateChange(int change)
        {
            var padding = -1;
            if (change < 0)
            {
                var max = (from Control control in Controls select control.Left + control.Width + padding).Concat(new[] { int.MinValue }).Max();

                if (max < Width + Math.Abs(change))
                {
                    return Width - max;
                }
            }
            else
            {
                var min = (from Control control in Controls select control.Left).Concat(new[] { int.MaxValue }).Min();

                if (min > padding - Math.Abs(change))
                {
                    return padding - min;
                }
            }
            return change;
        }

        private void HandleDelta(int delta)
        {
            var change = ValidateChange(delta);

            foreach (Control control in Controls)
            {
                control.Left += change;
            }

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) != 0)
            {
                var delta = _mouseLastPosition.X - e.X;
                HandleDelta(delta);
                _mouseLastPosition = e.Location;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            HandleDelta(e.Delta);
            base.OnMouseWheel(e);
        }
    }
}
