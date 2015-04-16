using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.ViewportRestrictions;

namespace _03MeteoData
{
    public class CompleteViewportRestriction : ViewportRestrictionBase
    {
        public CompleteViewportRestriction(double? minX, double? maxX, double? minY, double? maxY, double? minWidth, double? maxWidth, double? minHeight, double? maxHeight)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }

        public CompleteViewportRestriction()
        {
        }


        public double? MinX
        {
            get { return minX; }
            set
            {
                if (minX != value)
                {
                    minX = value;
                    RaiseChanged();
                }
            }
        }
        double? minX = null;

        public double? MaxX
        {
            get { return maxX; }
            set
            {
                if (maxX != value)
                {
                    maxX = value;
                    RaiseChanged();
                }
            }
        }
        double? maxX = null;

        public double? MinY
        {
            get { return minY; }
            set
            {
                if (minY != value)
                {
                    minY = value;
                    RaiseChanged();
                }
            }
        }
        double? minY = null;

        public double? MaxY
        {
            get { return maxY; }
            set
            {
                if (maxY != value)
                {
                    maxY = value;
                    RaiseChanged();
                }
            }
        }
        double? maxY = null;

        public double? MinWidth
        {
            get { return minWidth; }
            set
            {
                if (minWidth != value)
                {
                    minWidth = value;
                    RaiseChanged();
                }
            }
        }
        double? minWidth = null;

        public double? MaxWidth
        {
            get { return maxWidth; }
            set
            {
                if (maxWidth != value)
                {
                    maxWidth = value;
                    RaiseChanged();
                }
            }
        }
        double? maxWidth = null;

        public double? MinHeight
        {
            get { return minHeight; }
            set
            {
                if (minHeight != value)
                {
                    minHeight = value;
                    RaiseChanged();
                }
            }
        }
        double? minHeight = null;

        public double? MaxHeight
        {
            get { return maxHeight; }
            set
            {
                if (maxHeight != value)
                {
                    maxHeight = value;
                    RaiseChanged();
                }
            }
        }
        double? maxHeight = null;

        public override Rect Apply(Rect previousDataRect, Rect proposedDataRect, Viewport2D viewport)
        {
            double
                x = proposedDataRect.X,
                y = proposedDataRect.Y,
                w = proposedDataRect.Width,
                h = proposedDataRect.Height;

            // width
            if (minWidth.HasValue && w < minWidth.Value)
                w = minWidth.Value;

            else if (maxWidth.HasValue && w > maxWidth.Value)
                w = maxWidth.Value;

            // height
            if (minHeight.HasValue && h < minHeight.Value)
                h = minHeight.Value;

            else if (maxHeight.HasValue && h > maxHeight.Value)
                h = maxHeight.Value;

            // x; y
            if (minX.HasValue && x < minX.Value)
                x = minX.Value;

            if (minY.HasValue && y < minY.Value)
                y = minY.Value;

            if (maxX.HasValue && x + w > maxX.Value)
            {
                x = maxX.Value - w;
                if (minX.HasValue && x < minX.Value)
                {
                    x = minX.Value;
                    w = maxX.Value - minX.Value;

                    if (minWidth.HasValue && w < minWidth.Value)
                        throw new Exception("MinWidth is larger than possible between MinX and MaxX.");
                }
            }

            if (maxY.HasValue && y + h > maxY.Value)
            {
                y = maxY.Value - h;
                if (minY.HasValue && y < minY.Value)
                {
                    y = minY.Value;
                    h = maxY.Value - minY.Value;

                    if (minHeight.HasValue && h < minHeight.Value)
                        throw new Exception("MinHeight is larger than possible between MinY and MaxY.");
                }
            }

            return new Rect(x, y, w, h);
        }
    }
}
