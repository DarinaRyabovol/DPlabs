using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPlab1;
namespace DPMatrForm
{
    public partial class MatrixForm : Form
    {
        private DrawingMatrix origM;
        private DrawingMatrix sparM;
        private IPainter painter1;
        private IPainter painter2;
        private static OriginMatrix m1;
        private static SparceMatrix m2;
        private int x1 = 200;
        private int x2 = 470;
        private int y = 20;
        private int sizeM = 4;
        private Decorator origDecorator;
        private Decorator sparceDecorator;

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
            if (origM == null)
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
            origM.SetPainter(painter1);
            sparM.SetPainter(painter2);
            origM.Paint();
            sparM.Paint();
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
            origM = null;
            sparM = null;
            origDecorator = null;
            sparceDecorator = null;
            cancelButton.Enabled = false;
            clearButton.Enabled = false;
            renumberRowsButton.Enabled = true;
            renumberColsButton.Enabled = true;
            transpButton.Enabled = true;
            m1 = new OriginMatrix(sizeM, sizeM);
            m2 = new SparceMatrix(sizeM, sizeM);
            InitMatrix.Init(m1, 10, 20);
            InitMatrix.Init(m1, m2);
            InitPainter();
            origM = new OriginDrawingMatrix(m1, painter1);
            sparM = new SparceDrawingMatrix(m2, painter2);
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
                origM = new OriginDrawingMatrix(m1, painter1);
                sparM = new SparceDrawingMatrix(m2, painter2);
                clearButton.Enabled = false;
            }
            else
            {
                origDecorator = (Decorator)origDecorator.Matrix;
                sparceDecorator = (Decorator)sparceDecorator.Matrix;
                origM = new OriginDrawingMatrix(origDecorator, painter1);
                sparM = new SparceDrawingMatrix(sparceDecorator, painter2);
            }
            InitPainter();
            UpdateMe();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
            cancelButton.Enabled = false;
            InitPainter();
            origDecorator = null;
            sparceDecorator = null;
            origM = new OriginDrawingMatrix(m1, painter1);
            sparM = new SparceDrawingMatrix(m2, painter2);
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
            InitPainter();
            origM = new OriginDrawingMatrix(origDecorator, painter1);
            sparM = new SparceDrawingMatrix(sparceDecorator, painter2);
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
            InitPainter();
            origM = new OriginDrawingMatrix(origDecorator, painter1);
            sparM = new SparceDrawingMatrix(sparceDecorator, painter2);
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
            InitPainter();
            origM = new OriginDrawingMatrix(origDecorator, painter1);
            sparM = new SparceDrawingMatrix(sparceDecorator, painter2);
            UpdateMe();
        }


    }
}
