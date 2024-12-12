using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperPOS.Core.Helpers
{
    internal class DataGridViewHelper
    {
        public static void UpdateDataGridBackground(DataGridView dg)
        {
            try
            {
                for (int i = 0; i < dg.Rows.Count; i++)
                {
                    if (IsOdd(i))
                    {

                        dg.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(190, 216, 234);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }



        public static void GenerateColumnButton(DataGridView dg, int index, string name)
        {
            if (dg.Columns.Contains(name) == false)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dg.Columns.Insert(index, btn);
                btn.HeaderText = name;
                btn.Name = name;
                btn.UseColumnTextForButtonValue = true;
                btn.Width = 64;
            }
        }

        public static void AddColumnButton(DataGridViewCellPaintingEventArgs e, string btn, Int32 colsidx)
        {
            if (e.ColumnIndex == colsidx)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = 44; //Properties.Resources.SomeImage.Width;
                var h = 44; //Properties.Resources.SomeImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                var path = System.IO.Directory.GetCurrentDirectory();
                String icondir = path + "\\icons\\" + btn + ".png";
                System.Drawing.Image img = System.Drawing.Image.FromFile(icondir, true);
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        public static void AddColumnDeleteButton(DataGridViewCellPaintingEventArgs e, Int32 colsidx)
        {
            if (e.ColumnIndex == colsidx)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = 44; //Properties.Resources.SomeImage.Width;
                var h = 44; //Properties.Resources.SomeImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                var path = System.IO.Directory.GetCurrentDirectory();
                String icondir = path + "\\icons\\delete.png";
                System.Drawing.Image img = System.Drawing.Image.FromFile(icondir, true);
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        public static void AddColumnUpdateButton(DataGridViewCellPaintingEventArgs e, Int32 colsidx)
        {
            if (e.ColumnIndex == colsidx)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = 44; //Properties.Resources.SomeImage.Width;
                var h = 44; //Properties.Resources.SomeImage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                var path = System.IO.Directory.GetCurrentDirectory();
                String icondir = path + "\\icons\\edit.png";
                System.Drawing.Image img = System.Drawing.Image.FromFile(icondir, true);
                e.Graphics.DrawImage(img, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
