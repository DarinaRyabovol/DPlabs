using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DPMatrForm
{
    public partial class MatrixForm : Form
    {
        private IVisitor Visitor;
        private IPainter painter1;
        private IPainter painter2;
        private static OriginMatrix m1;
        private static SparceMatrix m2;
        private Decorator origDecorator;
        private Decorator sparceDecorator;
        private int x1 = 200;
        private int x2 = 470;
        private int y = 40;
        private int sizeM = 4;
        private int notNull = 12;
        private int maxInt = 20;

        public MatrixForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }


        private void InitPainter()
        {
            foreach (Control cnt in themGroup.Controls)
            {
                RadioButton rb = cnt as RadioButton;
                if (rb.Checked)
                {
                    switch (rb.Text)
                    {
                        case "Цветная":
                            InitColorPainters();
                            break;
                        case "Цветная с тенью":
                            InitColorPaintersWithShadow();
                            break;
                        case "Черно-белая":
                            InitBlackPainters();
                            break;
                        case "Черно-белая с тенью":
                            InitBlackPaintersWithShadow();
                            break;
                    }
                }
            }
        }

        private void UpdateMe()
        {
            if (m1 == null)
                return;
            List<BorderOfMatrix> controls = new List<BorderOfMatrix>(0);
            foreach (System.Windows.Forms.Control cnt in this.Controls)
            {
                if (cnt.GetType() == typeof(BorderOfMatrix))
                {
                    controls.Add(cnt as BorderOfMatrix);
                }
            }
            foreach (BorderOfMatrix bm in controls)
            {
                this.Controls.Remove(bm);
            }
            InitPainter();

            Visitor = new DrawVisitor(painter1);
            if (origDecorator != null)
            {
                origDecorator.accept(Visitor);
            }
            else
            {
                m1.accept(Visitor);
            }
            Visitor = new DrawVisitor(painter2);
            if (sparceDecorator != null)
            {
                sparceDecorator.accept(Visitor);
            }
            else
            {
                m2.accept(Visitor);
            }
        }

        private void InitColorPainters()
        {
            painter1 = new ColoredPainter(this, x1, y);
            painter2 = new ColoredPainter(this, x2, y);
        }

        private void InitColorPaintersWithShadow()
        {
            painter1 = new ColoredPainterWithShadow(this, x1, y);
            painter2 = new ColoredPainterWithShadow(this, x2, y);
        }

        private void InitBlackPainters()
        {
            painter1 = new BlackPainter(this, x1, y);
            painter2 = new BlackPainter(this, x2, y);
        }

        private void InitBlackPaintersWithShadow()
        {
            painter1 = new BlackPainterWithShadow(this, x1, y);
            painter2 = new BlackPainterWithShadow(this, x2, y);
        }

        private void MatrixForm_Load(object sender, EventArgs e)
        {
        }

        private void genButton_Click(object sender, EventArgs e)
        {
            Visitor = null;
            origDecorator = null;
            sparceDecorator = null;
            cancelButton.Enabled = false;
            clearButton.Enabled = false;
            renumberRowsButton.Enabled = true;
            renumberColsButton.Enabled = true;
            transpButton.Enabled = true;
            m1 = new OriginMatrix(sizeM, sizeM);
            m2 = new SparceMatrix(sizeM, sizeM);
            InitMatrix.Init(m1, notNull, maxInt);
            InitMatrix.Init(m1, m2);
            UpdateMe();
        }

        private void coloredRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (coloredRadioButton.Checked && (m1 != null))
            {
                InitColorPainters();
                UpdateMe();
            }
        }

        private void coloredWithSahdowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (coloredWithSahdowRadioButton.Checked && (m1 != null))
            {
                InitColorPaintersWithShadow();
                UpdateMe();
            }
        }

        private void blackRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (blackRadioButton.Checked && (m1 != null))
            {
                InitBlackPainters();
                UpdateMe();
            }
        }

        private void blackWithShadowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (blackWithShadowRadioButton.Checked && (m1 != null))
            {
                InitBlackPaintersWithShadow();
                UpdateMe();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (origDecorator.Matrix == m1)
            {
                cancelButton.Enabled = false;
                origDecorator = null;
                sparceDecorator = null;
                clearButton.Enabled = false;
            }
            else
            {
                origDecorator = (Decorator)origDecorator.Matrix;
                sparceDecorator = (Decorator)sparceDecorator.Matrix;
            }
            UpdateMe();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
            cancelButton.Enabled = false;
            origDecorator = null;
            sparceDecorator = null;

            UpdateMe();
        }

        private void renumberRowsButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            clearButton.Enabled = true;
            if (origDecorator == null)
            {
                origDecorator = new RenumberRowsDecorator(m1);
                sparceDecorator = new RenumberRowsDecorator(m2);
            }
            else
            {
                origDecorator = new RenumberRowsDecorator(origDecorator);
                sparceDecorator = new RenumberRowsDecorator(sparceDecorator);
            }
            UpdateMe();
        }

        private void renumberColsButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            clearButton.Enabled = true;
            if (origDecorator == null)
            {
                origDecorator = new RenumberColsDecorator(m1);
                sparceDecorator = new RenumberColsDecorator(m2);
            }
            else
            {
                origDecorator = new RenumberColsDecorator(origDecorator);
                sparceDecorator = new RenumberColsDecorator(sparceDecorator);
            }
            UpdateMe();
        }

        private void transpButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = true;
            clearButton.Enabled = true;
            if (origDecorator == null)
            {
                origDecorator = new TransposeDecorator(m1);
                sparceDecorator = new TransposeDecorator(m2);
            }
            else
            {
                origDecorator = new TransposeDecorator(origDecorator);
                sparceDecorator = new TransposeDecorator(sparceDecorator);
            }

            UpdateMe();
        }


    }
}
