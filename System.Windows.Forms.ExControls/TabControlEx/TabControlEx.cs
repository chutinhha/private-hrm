using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms.ExControls
{
    [ToolboxBitmap(typeof(TabControlEx))]
    /// <summary>
    /// Summary description for DraggableTabPage.
    /// </summary>
    public partial class TabControlEx : System.Windows.Forms.TabControl
    {
      
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /* A handle of a font used for custom drawing. We do not use this native font directly, but tab control
             * adjusts size of tabs and tab scroller basing on the size of that font.*/
        private IntPtr fSysFont = IntPtr.Zero;

        //This field tells us whether custom drawing is turned on.
        private bool fCustomDraw;

        /* We have to remember the index of last hot tab for our native updown hook to overdraw that tab as
             * normal when the mouse is moving over it.*/
        private int lastHotIndex = -1;

        //a reference to our hook
        private NativeUpDown fUpDown;

        private ContextMenuStrip contextMenuStrip;

        #region Some overridden properties

        public TabControlEx()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            AllowDrop = true;
            this.HotTrack = true;
            // TODO: Add any initialization after the InitForm call

            // create contextMenu

            contextMenuStrip = new ContextMenuStrip()
            {
                Name = "contextMenuStrip",
                Size = new System.Drawing.Size(177, 70)
            };
            // 
            // mnuCloseMe
            // 
            ToolStripMenuItem mnuCloseMe = new ToolStripMenuItem()
            {
                Name = "mnuCloseMe",
                Size = new System.Drawing.Size(176, 22),
                Text = "Close"
            };

            mnuCloseMe.Click += delegate(object sender, EventArgs e)
            {
                if (MessageBox.Show("Chắc chắn bạn muốn đóng cửa sổ này?", "Thông báo",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.TabPages.Remove(this.SelectedTab);
                }
            };
            // 
            // mnuCloseAllButMe
            // 
            ToolStripMenuItem mnuCloseAllButMe = new ToolStripMenuItem()
            {
                Name = "mnuCloseAllButMe",
                Size = new System.Drawing.Size(176, 22),
                Text = "Close other tab(s)..."
            };

            mnuCloseAllButMe.Click += delegate(object sender, EventArgs e)
            {
                if (MessageBox.Show("Chắc chắn bạn muốn đóng (các) cửa sổ khác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    while (this.TabPages.Count != 1)
                    {
                        if (!object.Equals(this.TabPages[0], this.SelectedTab))
                        {
                            this.TabPages.Remove(this.TabPages[0]);
                        }
                        else
                        {
                            this.TabPages.Remove(this.TabPages[1]);
                        }
                    }
                }
            };

            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                                                        mnuCloseMe,
                                                                                        mnuCloseAllButMe
                                                                                     });

            this.ContextMenuStrip = contextMenuStrip;
            // create contextMenu

            fUpDown = new NativeUpDown(this);

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (this.fSysFont != System.IntPtr.Zero)
            {
                NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = System.IntPtr.Zero;
            }
            fUpDown.ReleaseHandle();
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion


        [Browsable(true), DefaultValue(TabAlignment.Top)]
        new public TabAlignment Alignment
        {
            get { return base.Alignment; }
            set { if (value <= TabAlignment.Bottom) base.Alignment = value; }
        }

        [Browsable(true), DefaultValue(true)]
        new public bool HotTrack
        {
            get { return base.HotTrack; }
            set { base.HotTrack = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabAppearance Appearance
        {
            get { return base.Appearance; }
            set { if (value == TabAppearance.Normal) base.Appearance = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        new public TabDrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { if (value == TabDrawMode.Normal) base.DrawMode = value; }
        }

        #endregion

        /// <summary>
        /// Turns custom drawing on/off and sets native font for the control (it's required for tabs to
        /// adjust their size correctly). If one doesn't install native font manually then Windows will
        /// install an ugly system font for the control.
        /// </summary>
        private void InitializeDrawMode()
        {
            this.fCustomDraw = Application.RenderWithVisualStyles && TabRenderer.IsSupported;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque, this.fCustomDraw);
            this.UpdateStyles();
            if (this.fCustomDraw) //custom drawing will be used
            {
                if (this.fSysFont == IntPtr.Zero) this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
            else //default drawing will be used
            {
                /* Note, that in the SendMessage call below we do not delete HFONT passed to the control. If we do
                                     * so we will see an ugly system font. I think in this case the control deletes this font by itself
                                     * when disposing or finalizing.*/
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.Font.ToHfont(), (IntPtr)1);
                //but we need to delete the font(if any) created when being in custom drawing mode
                if (this.fSysFont != IntPtr.Zero)
                {
                    NativeMethods.DeleteObject(this.fSysFont);
                    this.fSysFont = IntPtr.Zero;
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            //after the control has been created we should turn custom drawing on/off etc.
            InitializeDrawMode();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (this.fCustomDraw)
            {
                /* The control is being custom drawn and managed font size is changed. We should inform the system
                                     * about such a great event for it to adjust tabs' sizes. And indeed, we have to create a new
                                     * native font from managed one.*/
                if (this.fSysFont != IntPtr.Zero) NativeMethods.DeleteObject(this.fSysFont);
                this.fSysFont = this.Font.ToHfont();
                NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETFONT, this.fSysFont, (IntPtr)1);
            }
        }

        protected override void WndProc(ref Message m)
        {
            /* If a visual theme changes we have to reinitialize drawing mode to prevent an exception from being
                             * thrown by TabRenderer when switching from visual style to "Windows Classic" and vise versa.*/
            if (m.Msg == NativeMethods.WM_THEMECHANGED) InitializeDrawMode();
            else if (m.Msg == NativeMethods.WM_PARENTNOTIFY && (m.WParam.ToInt32() & 0xffff) == NativeMethods.WM_CREATE)
            {
                /* Tab scroller has been created (there are too many tabs to display and the control is not multiline), so
                                     * let's attach our hook to it.*/
                StringBuilder className = new StringBuilder(16);
                if (NativeMethods.RealGetWindowClass(m.LParam, className, 16) > 0 && className.ToString() == "msctls_updown32")
                {
                    fUpDown.ReleaseHandle();
                    fUpDown.AssignHandle(m.LParam);
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Draws our tab control.
        /// </summary>
        /// <param name="g">The <see cref="T:System.Drawing.Graphics"/> object used to draw the tab control.</param>
        /// <param name="clipRect">The <see cref="T:System.Drawing.Rectangle"/> that specifies the clipping rectangle
        /// of the control.</param>
        private void DrawCustomTabControl(Graphics g, Rectangle clipRect)
        {
            /* In this method we draw only those parts of the control which intersect with the
             * clipping rectangle. It's some kind of optimization.*/
            if (!this.Visible) return;

            //selected tab index and rectangle
            int iSel = this.SelectedIndex;
            Rectangle selRect = iSel != -1 ? this.GetTabRect(iSel) : Rectangle.Empty;

            Rectangle rcPage = this.ClientRectangle;
            //correcting page rectangle
            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    int trunc = selRect.Height * this.RowCount + 2;
                    rcPage.Y += trunc; rcPage.Height -= trunc;
                    break;
                case TabAlignment.Bottom:
                    rcPage.Height -= selRect.Height * this.RowCount + 1;
                    break;
            }

            //draw page itself
            if (rcPage.IntersectsWith(clipRect)) TabRenderer.DrawTabPage(g, rcPage);

            int tabCount = this.TabCount;
            if (tabCount == 0) return;

            //drawing unselected tabs
            this.lastHotIndex = HitTest();//hot tab
            VisualStyleRenderer tabRend = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
            for (int iTab = 0; iTab < tabCount; iTab++)
                if (iTab != iSel)
                {
                    Rectangle tabRect = this.GetTabRect(iTab);
                    if (tabRect.Right >= 3 && tabRect.IntersectsWith(clipRect))
                    {
                        TabItemState state = iTab == this.lastHotIndex ? TabItemState.Hot : TabItemState.Normal;
                        tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)state);
                        DrawTabItem(g, iTab, tabRect, tabRend);
                    }
                }

            /* Drawing of a selected tab. We'll also increase the selected tab's rectangle. It should be a little
                     * bigger than other tabs.*/
            selRect.Inflate(2, 2);
            if (iSel != -1 && selRect.IntersectsWith(clipRect))
            {
                tabRend.SetParameters(tabRend.Class, tabRend.Part, (int)TabItemState.Selected);
                DrawTabItem(g, iSel, selRect, tabRend);
            }
        }

        private Rectangle GetTabRect(int tabIndex, Graphics g)
        {
            Rectangle rec = Rectangle.Empty;

            rec.Height = 19;
            if (tabIndex == SelectedIndex)
            {
                rec.Y = 0;
            }
            if (tabIndex == 0)
            {
                rec.Y = 2;
            }

            if (tabIndex == 0)
            {
                rec.X = 2;
            }
            else
            {
                int widthPadding = 0;
                for (var i = 0; i < TabPages.Count; i++)
                {
                    widthPadding = 20; // 2 pixel margin right + 16 pixel close button + 2px margin left
                    widthPadding += (int)Math.Floor(g.MeasureString(TabPages[tabIndex].Text, this.Font).Width);
                    if (this.ImageList != null)
                    {
                        if (GetImageByIndexOrKey(TabPages[tabIndex].ImageIndex, TabPages[tabIndex].ImageKey) != null)
                        {
                            widthPadding += 24;
                        }
                    }

                }
                rec.X = widthPadding;
            }

            rec.Width = 20; // 2 pixel margin right + 16 pixel close button + 2px margin left
            rec.Width += (int)Math.Floor(g.MeasureString(TabPages[tabIndex].Text, this.Font).Width);
            if (this.ImageList != null)
            {
                if (GetImageByIndexOrKey(TabPages[tabIndex].ImageIndex, TabPages[tabIndex].ImageKey) != null)
                {
                    rec.Width += 24;
                }
            }
            return rec;


            //rec.X = 0;
            //rec.Y = 2;
            //rec.Width = 2 + 16; // 2 pixel margin right + 16 pixel close button
            //rec.Width += 16;
            //rec.Height = ClientRectangle.Height - 5;

        }

        /// <summary>
        /// Draws a single tab.
        /// </summary>
        /// <param name="g">A <see cref="T:System.Drawing.Graphics"/> object used to draw the tab control.</param>
        /// <param name="index">An index of the tab being drawn.</param>
        /// <param name="tabRect">A <see cref="T:System.Drawing.Rectangle"/> object specifying tab's bounds.</param>
        /// <param name="rend">A <see cref="T:System.Windows.Forms.VisualStyles.VisualStyleRenderer"/> object for rendering the tab.</param>
        private void DrawTabItem(Graphics g, int index, Rectangle tabRect, VisualStyleRenderer rend)
        {
            //if the scroller is visible and the tab is fully placed under it, we don't need to draw such tab
            if (fUpDown.X > 0 && tabRect.X >= fUpDown.X) return;

            bool tabSelected = rend.State == (int)TabItemState.Selected;
            // We will draw our tab on a bitmap and then transfer image to the control's graphic context.
            using (GDIMemoryContext memGDI = new GDIMemoryContext(g, tabRect.Width, tabRect.Height))
            {
                Rectangle drawRect = new Rectangle(0, 0, tabRect.Width, tabRect.Height);
                rend.DrawBackground(memGDI.Graphics, drawRect);
                if (tabSelected && tabRect.X == 0)
                {
                    int corrY = memGDI.Height - 1;
                    memGDI.SetPixel(0, corrY, memGDI.GetPixel(0, corrY - 1));
                }
                /* An important moment. If tabs alignment is bottom, we should flip the image to display the tab
                             * correctly.*/
                if (this.Alignment == TabAlignment.Bottom) memGDI.FlipVertical();

                TabPage pg = this.TabPages[index];//tab page whose tab we're drawing
                //trying to get a tab image if any
                Image pagePict = this.GetImageByIndexOrKey(pg.ImageIndex, pg.ImageKey);
                if (pagePict != null)
                {
                    //If tab image is present we should draw it.
                    Point imgLoc = new Point(tabSelected ? 8 : 6, 2);
                    int imgRight = imgLoc.X + pagePict.Width;

                    if (this.Alignment == TabAlignment.Bottom)
                        imgLoc.Y = drawRect.Bottom - pagePict.Height - (tabSelected ? 4 : 2);
                    if (RightToLeftLayout) imgLoc.X = drawRect.Right - imgRight;
                    memGDI.Graphics.DrawImageUnscaled(pagePict, imgLoc);
                    //Correcting rectangle for drawing text.
                    drawRect.X += imgRight; drawRect.Width -= imgRight;
                }
                //drawing tab text
                TextRenderer.DrawText(memGDI.Graphics, pg.Text, this.Font, drawRect, rend.GetColor(ColorProperty.TextColor),
                    TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                //If the tab has part under scroller we shouldn't draw that part.
                if (fUpDown.X > 0 && fUpDown.X >= tabRect.X && fUpDown.X < tabRect.Right)
                    tabRect.Width -= tabRect.Right - fUpDown.X;
                memGDI.DrawContextClipped(g, tabRect);


            }
        }

        /// <summary>
        /// This function attempts to get a tab image by index first, or, if not set, then by key.
        /// </summary>
        /// <param name="index">An index of tab image in tab control image list.</param>
        /// <param name="key">A key of tab image in tab control image list.</param>
        /// <returns><see cref="T:System.Drawing.Image"/> that represents image of the tab or null, if not set.</returns>
        private Image GetImageByIndexOrKey(int index, string key)
        {
            if (this.ImageList == null) return null;
            else if (index > -1) return this.ImageList.Images[index];
            else if (key.Length > 0) return this.ImageList.Images[key];
            else return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            /* Sort of a trick: we paint the parent control's background on this control. To do that right,
             * we're going to transform "e" into the parent's coordinate system and after we're done, we'll reset it back.*/
            Point offsetPoint = this.Location;
            e.Graphics.TranslateTransform(-offsetPoint.X, -offsetPoint.Y);
            InvokePaintBackground(this.Parent, e);
            e.Graphics.TranslateTransform(offsetPoint.X, offsetPoint.Y);

            // Now we're going to draw the tab control itself.
            DrawCustomTabControl(e.Graphics, e.ClipRectangle);
        }

        /// <summary>
        /// Gets hot tab index.
        /// </summary>
        /// <returns>Index of the tab over that the mouse is hovering or -1 if the mouse isn't over any tab.</returns>
        private unsafe int HitTest()
        {
            NativeMethods.TCHITTESTINFO hti = new NativeMethods.TCHITTESTINFO();
            Point mousePos = this.PointToClient(TabControl.MousePosition);
            hti.pt.x = mousePos.X; hti.pt.y = mousePos.Y;
            return (int)NativeMethods.SendMessage(this.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, (IntPtr)(&hti));
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
        }

        protected override void OnDragOver(System.Windows.Forms.DragEventArgs e)
        {
            base.OnDragOver(e);

            Point pt = new Point(e.X, e.Y);
            //We need client coordinates.
            pt = PointToClient(pt);

            //Make sure there is a TabPage being dragged.
            if (e.Data.GetDataPresent(typeof(TabPage)))
            {
                //Get the tab we are dragging.
                TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));

                //Get the tab we are hovering over.
                TabPage hoverTab = GetTabPageByTab(pt, dragTab); // watch the drag_tab extra param
                //Make sure we are on a tab.
                if (hoverTab != null)
                {
                    e.Effect = DragDropEffects.Move;

                    int itemDragIndex = FindIndex(dragTab);
                    int dropLocationIndex = FindIndex(hoverTab);

                    //Don't do anything if we are hovering over ourself.
                    if (itemDragIndex != dropLocationIndex)
                    {
                        this.SuspendLayout();

                        TabPages[dropLocationIndex] = dragTab;
                        TabPages[itemDragIndex] = hoverTab;

                        //Make sure the drag tab is selected.
                        SelectedTab = dragTab;
                        this.ResumeLayout();
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Finds the TabPage whose tab is containing the given point.
        /// When DragTab.Width is smaller than HoverTab.Width, a blind zone (HoverTab.Width - DragTab.Width) is taken into account.
        /// </summary>
        /// <param name="pt">The point (given in client coordinates) to look for a TabPage.</param>
        /// <param name="dragTab">The TabPage to drag.</param>
        /// <returns>The TabPage whose tab is at the given point (null if there isn't one).</returns>
        private TabPage GetTabPageByTab(Point pt, TabPage dragTab)
        {
            TabPage tp = null;

            // The bounding rectangle for the drag tab
            Rectangle dragTabRect = GetTabRect(FindIndex(dragTab));

            for (int i = 0; i < TabPages.Count; i++)
            {
                // The bounding rectangle for the hover tab
                Rectangle hoverTabRect = GetTabRect(i);

                // Avoid flickering when DragTab Width is smaller then HoverTab Width
                if (dragTabRect.Width < hoverTabRect.Width)
                {
                    if (dragTabRect.X < hoverTabRect.X)
                        // Hover directions is to the right
                        hoverTabRect.X += hoverTabRect.Width - dragTabRect.Width;
                    else
                        // Hover direction is to the left
                        hoverTabRect.Width -= hoverTabRect.Width - dragTabRect.Width;
                }

                // Test if point is within modified HoverTab
                if (hoverTabRect.Contains(pt))
                {
                    tp = TabPages[i];
                    break;
                }
            }

            return tp;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point pt = new Point(e.X, e.Y);
            TabPage tp = GetTabPageByTab(pt);

            if (e.Button == MouseButtons.Left)
            {
                if (tp != null)
                {
                    DoDragDrop(tp, DragDropEffects.All);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (tp != null)
                {
                    SelectedTab = tp;
                }
            }
        }

        /// <summary>
        /// Finds the TabPage whose tab is contains the given point.
        /// </summary>
        /// <param name="pt">The point (given in client coordinates) to look for a TabPage.</param>
        /// <returns>The TabPage whose tab is at the given point (null if there isn't one).</returns>
        private TabPage GetTabPageByTab(Point pt)
        {
            TabPage tp = null;

            for (int i = 0; i < TabPages.Count; i++)
            {
                if (GetTabRect(i).Contains(pt))
                {
                    tp = TabPages[i];
                    break;
                }
            }

            return tp;
        }

        /// <summary>
        /// Loops over all the TabPages to find the index of the given TabPage.
        /// </summary>
        /// <param name="page">The TabPage we want the index for.</param>
        /// <returns>The index of the given TabPage(-1 if it isn't found.)</returns>
        private int FindIndex(TabPage page)
        {
            for (int i = 0; i < TabPages.Count; i++)
            {
                if (TabPages[i] == page)
                    return i;
            }

            return -1;
        }

            
    }
}
