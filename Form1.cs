using System;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Data.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using MathNet.Spatial.Euclidean;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //------Calculate buttons
        //---3D Best Fit
        private void button1_Click(object sender, EventArgs e)
        {
            
            //Delimeter [.] or [,]
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            if (DotCheck.Checked)
            {
                nfi.NumberDecimalSeparator = ".";
            }
            else
            {
                nfi.NumberDecimalSeparator = ",";
            }


            // Check if path is not empty

            if (!string.IsNullOrEmpty(FixedBox.Text) && !string.IsNullOrEmpty(MovingBox.Text))
            {
                // Calculate angles function
                double RadianToDegree(double angle)
                {
                    return angle * (180.0 / Math.PI);
                }
                double Reverse(double a)
                {
                    double z = 0;
                    double x = z - a;
                    return x;
                }

                // FIXED
                // Create empty array
                string[] fixed_lines = FixedBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] fixed_arr = new double[fixed_lines.Length, 3];

                // Check if textBox is dot delimeted [.]
                bool fixed_is_dot = FixedBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < fixed_lines.Length; i++)
                {
                    fixed_lines[i] = fixed_lines[i].Trim();
                    string[] splitedlines = Regex.Split(fixed_lines[i], @"\s+");
                    for (int j = 0; j < splitedlines.Length; j++)
                    {
                        if (fixed_is_dot == true)
                        {
                            fixed_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            fixed_arr[i, j] = Double.Parse(splitedlines[j]);
                        }
                    }
                }
                
                //MOVING
                // Create empty array
                string[] moving_lines = MovingBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] moving_arr = new double[moving_lines.Length, 3];

                // Check if textBox is dot delimeted [.]
                bool moving_is_dot = MovingBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < moving_lines.Length; i++)
                {
                    moving_lines[i] = moving_lines[i].Trim();
                    string[] splitedlines = Regex.Split(moving_lines[i], @"\s+");
                    for (int j = 0; j < splitedlines.Length; j++)
                    {
                        if (moving_is_dot == true)
                        {
                            moving_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            moving_arr[i, j] = Double.Parse(splitedlines[j]);
                        }
                    }
                }
                Matrix<double> fixed_tra = Matrix<double>.Build.DenseOfArray(fixed_arr);
                Matrix<double> moving_tra = Matrix<double>.Build.DenseOfArray(moving_arr);

                // Run Transform3D
                Transform3D person = new Transform3D(fixed_tra, moving_tra);
                person.CalcTransform(fixed_tra, moving_tra);
                ConvertBox.AppendText(DenseMatrix.OfArray(person.TransformMatrix).ToMatrixString("F4", nfi).Trim());
                TransformMatrixBox.AppendText(DenseMatrix.OfArray(person.TransformMatrix).ToMatrixString("F4", nfi).Trim());

                OutputBox.AppendText("TransformMatrix: \r\n");
                OutputBox.AppendText(DenseMatrix.OfArray(person.TransformMatrix).ToString("F4", nfi) + "\r\n");

                OutputBox.AppendText("Reversed Siemens 6VOF:\r\nx_tra\ty_tra\tz_tra\tx_rot\ty_rot\tz_rot\r\n");
                OutputBox.AppendText(Reverse(person.TransformSiemens6DOFVectorSeparate[0]).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(person.TransformSiemens6DOFVectorSeparate[1]).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(person.TransformSiemens6DOFVectorSeparate[2]).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[5])).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[4])).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[3])).ToString("F2", nfi) + "\r\n\r\n");

                OutputBox.AppendText("ERROR RMS: \r\n");
                OutputBox.AppendText(person.ErrorRMS.ToString("F2", nfi) + "\r\n\r\n");

                if (BestFitAdditionalCheck.Checked)
                {
                    OutputBox.AppendText("---\r\nAdditional Calculations:\r\n");
                    OutputBox.AppendText("Inversed TransformMatrix: \r\n");
                    OutputBox.AppendText(DenseMatrix.OfArray(person.TransformMatrix).Inverse().ToString("F4", nfi) + "\r\n");

                    OutputBox.AppendText("RotationMatrix: \r\n");
                    OutputBox.AppendText(DenseMatrix.OfArray(person.RotationMatrix).ToString("F4", nfi) + "\r\n");

                    OutputBox.AppendText("TranslationMatrix: \r\n");
                    OutputBox.AppendText(DenseMatrix.OfArray(person.TranslationMatrix).ToString("F4", nfi) + "\r\n");


                    OutputBox.AppendText("Standard 6VOF:\r\n");
                    OutputBox.AppendText(person.Transform6DOFVector[0].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVector[1].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVector[2].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.Transform6DOFVector[5]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.Transform6DOFVector[4]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.Transform6DOFVector[3]).ToString("F2", nfi) + "\r\n\r\n");

                    OutputBox.AppendText("Standard Siemens 6VOF: \r\n");
                    OutputBox.AppendText(person.TransformSiemens6DOFVector[0].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.TransformSiemens6DOFVector[1].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.TransformSiemens6DOFVector[2].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVector[5]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVector[4]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVector[3]).ToString("F2", nfi) + "\r\n\r\n");

                    OutputBox.AppendText("Reversed 6VOF:\r\n");
                    OutputBox.AppendText(person.Transform6DOFVector[0].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVector[1].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVector[2].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(person.Transform6DOFVector[5])).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(person.Transform6DOFVector[4])).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(person.Transform6DOFVector[3])).ToString("F2", nfi) + "\r\n\r\n");

                    //--- Separate Calculations
                    OutputBox.AppendText("----\r\nSeparate calculations (Trasnform Matrix + Rotation Matrix): \r\n");
                    OutputBox.AppendText("Standard 6VOF:\r\n");
                    OutputBox.AppendText(person.Transform6DOFVectorSeparate[0].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVectorSeparate[1].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVectorSeparate[2].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.Transform6DOFVectorSeparate[5]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.Transform6DOFVectorSeparate[4]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.Transform6DOFVectorSeparate[3]).ToString("F2", nfi) + "\r\n\r\n");

                    OutputBox.AppendText("Standard Siemens 6VOF: \r\n");
                    OutputBox.AppendText(person.TransformSiemens6DOFVectorSeparate[0].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.TransformSiemens6DOFVectorSeparate[1].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.TransformSiemens6DOFVectorSeparate[2].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[5]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[4]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[3]).ToString("F2", nfi) + "\r\n\r\n");

                    OutputBox.AppendText("Reversed:\r\n");
                    OutputBox.AppendText(person.Transform6DOFVectorSeparate[0].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVectorSeparate[1].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(person.Transform6DOFVectorSeparate[2].ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(person.Transform6DOFVectorSeparate[5])).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(person.Transform6DOFVectorSeparate[4])).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(person.Transform6DOFVectorSeparate[3])).ToString("F2", nfi) + "\r\n\r\n");

                    OutputBox.AppendText("Reversed Siemens: \r\n");
                    OutputBox.AppendText(Reverse(person.TransformSiemens6DOFVectorSeparate[0]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(person.TransformSiemens6DOFVectorSeparate[1]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(person.TransformSiemens6DOFVectorSeparate[2]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[5]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[4]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(RadianToDegree(person.TransformSiemens6DOFVectorSeparate[3]).ToString("F2", nfi) + "\r\n\r\n");

                    OutputBox.AppendText("ERROR RMS: \r\n");
                    OutputBox.AppendText(person.ErrorRMS.ToString("F2", nfi) + "\r\n\r\n");
                }


            }
            else
            {
                MessageBox.Show("Browse booth files first.", "Missing Input Error");
            }

        }

        //---Convert 4x4 Matrix to 6VOF
        private void button6_Click(object sender, EventArgs e)
        {
            //Delimeter [.] or [,]
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            if (DotCheck.Checked)
            {
                nfi.NumberDecimalSeparator = ".";
            }
            else
            {
                nfi.NumberDecimalSeparator = ",";
            }

            double[] TransformMatrixTo6DOFVector(Matrix<double> TransformMatrix)
            {
                Vector<double> tempVector = new DenseVector(6);

                //Set the X,Y, and Z translation components of the transform vector
                tempVector[0] = TransformMatrix[0, 3];  //X translation
                tempVector[1] = TransformMatrix[1, 3];  //Y translation
                tempVector[2] = TransformMatrix[2, 3];  //Z translation

                //Set the Z, Y, and X rotation components of the transform vector - see equation derivation at page 5 of http://www.usna.edu/Users/cs/taylor/courses/si475/class/3dkinematics.pdf
                double beta = Math.Atan2(-TransformMatrix[2, 0], Math.Sqrt(Math.Pow(TransformMatrix[0, 0], 2) + Math.Pow(TransformMatrix[1, 0], 2)));    //Y rotation - beta
                double gamma = Math.Atan2(TransformMatrix[1, 0] / Math.Cos(beta), TransformMatrix[0, 0] / Math.Cos(beta));   //Z rotation - gamma
                double alpha = Math.Atan2(TransformMatrix[2, 1] / Math.Cos(beta), TransformMatrix[2, 2] / Math.Cos(beta));   //X rotation - alpha

                tempVector[3] = gamma;      //Z rotation - kappa
                tempVector[4] = beta;       //Y rotation - phi
                tempVector[5] = alpha;      //X rotation - omega

                return tempVector.ToArray();

            }
            double[] TransformMatrixToSiemens6DOFVector(Matrix<double> TransformMatrix)
            {
                Vector<double> tempVector = new DenseVector(6);

                //Set the X,Y, and Z translation components of the transform vector for Siemens convention
                //Translation components in Siemens convention is simply the negative of the typical translation components
                tempVector[0] = -TransformMatrix[0, 3];  //X translation
                tempVector[1] = -TransformMatrix[1, 3];  //Y translation
                tempVector[2] = -TransformMatrix[2, 3];  //Z translation

                //Set the Z, Y, and X rotation components of the transform vector - see equation derivation at page 5 of http://www.usna.edu/Users/cs/taylor/courses/si475/class/3dkinematics.pdf
                //Siemens convention was determined experimentally.  To find the typical 3X3 rotation matrix (RotationMatrix in this class), the following matrix multiplication order is used -> Rz*Ry*Rx
                //To achieve the same rotation matrix with angles provided by Siemens MEAFrame, the following matrix multiplication must be used -> transpose(Rx)*transpose(Ry)*transpose(Rz)
                double beta = Math.Atan2(-TransformMatrix[0, 2], Math.Sqrt(Math.Pow(TransformMatrix[0, 0], 2) + Math.Pow(TransformMatrix[0, 1], 2)));    //Y rotation - beta
                double gamma = Math.Atan2(TransformMatrix[0, 1] / Math.Cos(beta), TransformMatrix[0, 0] / Math.Cos(beta));   //Z rotation - gamma
                double alpha = Math.Atan2(TransformMatrix[1, 2] / Math.Cos(beta), TransformMatrix[2, 2] / Math.Cos(beta));   //X rotation - alpha

                tempVector[3] = gamma;      //Z rotation - kappa
                tempVector[4] = beta;       //Y rotation - phi
                tempVector[5] = alpha;      //X rotation - omega

                return tempVector.ToArray();

            }
            double RadianToDegree(double angle)
            {
                return angle * (180.0 / Math.PI);
            }
            double Reverse(double a)
            {
                double z = 0;
                double x = z - a;
                return x;
            }
            //Init variable
            double[] MatrixTo6VOFResult;
            double[] MatrixTo6VOFResultSiemens;

            //If not empty
            if (!string.IsNullOrEmpty(ConvertBox.Text))
            {
                // Create empty array            
                string[] lines = ConvertBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] arr = new double[4, 4];

                // Check if textBox is dot delimeted [.]
                bool tra_is_dot = ConvertBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Trim();
                    string[] splitedlines = Regex.Split(lines[i], @"\s+");
                    for (int j = 0; j < splitedlines.Length; j++)
                    {
                        if (tra_is_dot == true)
                        {
                            arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            arr[i, j] = Double.Parse(splitedlines[j]);
                        }

                    }

                }
                if (arr != null)
                {

                    Matrix<double> tra = Matrix<double>.Build.DenseOfArray(arr);
                    OutputBox.AppendText(tra.ToString("F4", nfi) + "\r\n");

                    //Calculate
                    MatrixTo6VOFResult = TransformMatrixTo6DOFVector(tra);
                    MatrixTo6VOFResultSiemens = TransformMatrixToSiemens6DOFVector(tra);

                    //Results

                    OutputBox.AppendText("Reversed Siemens 6VOF:\r\nx_tra\ty_tra\tz_tra\tx_rot\ty_rot\tz_rot\r\n");
                    OutputBox.AppendText(Reverse(MatrixTo6VOFResultSiemens[0]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(MatrixTo6VOFResultSiemens[1]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(MatrixTo6VOFResultSiemens[2]).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResultSiemens[5])).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResultSiemens[4])).ToString("F2", nfi) + "\t");
                    OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResultSiemens[3])).ToString("F2", nfi) + "\r\n\r\n");

                    //Additional Calculations
                    if (ConvertAdditionalCheck.Checked)
                    {
                        OutputBox.AppendText("Inversed TransformMatrix: \r\n");
                        OutputBox.AppendText(tra.Inverse().ToString("F4", nfi) + "\r\n");

                        OutputBox.AppendText("Standard 6VOF:\r\n");
                        OutputBox.AppendText(MatrixTo6VOFResult[0].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[1].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[2].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResult[5]).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResult[4]).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResult[3]).ToString("F2", nfi) + "\r\n\r\n");

                        OutputBox.AppendText("Standard Siemens 6VOF: \r\n");
                        OutputBox.AppendText(MatrixTo6VOFResultSiemens[0].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResultSiemens[1].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResultSiemens[2].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResultSiemens[5]).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResultSiemens[4]).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResultSiemens[3]).ToString("F2", nfi) + "\r\n\r\n");

                        OutputBox.AppendText("Reversed 6VOF:\r\n");
                        OutputBox.AppendText(MatrixTo6VOFResult[0].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[1].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[2].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResult[5])).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResult[4])).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResult[3])).ToString("F2", nfi) + "\r\n\r\n");

                        OutputBox.AppendText("Standard 6VOF:\r\n");
                        OutputBox.AppendText(MatrixTo6VOFResult[0].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[1].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[2].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResult[5]).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResult[4]).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(RadianToDegree(MatrixTo6VOFResult[3]).ToString("F2", nfi) + "\r\n\r\n");

                        OutputBox.AppendText("Reversed 6VOF:\r\n");
                        OutputBox.AppendText(MatrixTo6VOFResult[0].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[1].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(MatrixTo6VOFResult[2].ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResult[5])).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResult[4])).ToString("F2", nfi) + "\t");
                        OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResult[3])).ToString("F2", nfi) + "\r\n\r\n");
                    }
                }
            }
            else
            {
                MessageBox.Show("Paste or Browse input to convert", "Conversion Error");
            }
        }
        //---Cloud Of Points Transform
        private void button11_Click(object sender, EventArgs e)
        {
            //Delimeter [.] or [,]
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            if (DotCheck.Checked)
            {
                nfi.NumberDecimalSeparator = ".";
            }
            else
            {
                nfi.NumberDecimalSeparator = ",";
            }
            // Check if data is filled
            if (!string.IsNullOrEmpty(TransformInputBox.Text) && !string.IsNullOrEmpty(TransformMatrixBox.Text))
            {
                //Input 
                // Create empty array
                string[] input_lines = TransformInputBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] input_arr = new double[input_lines.Length, 4];

                // Check if textBox is dot delimeted [.]
                bool fixed_is_dot = TransformInputBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < input_lines.Length; i++)
                {
                    input_lines[i] = input_lines[i].Trim();
                    string[] splitedlines = Regex.Split(input_lines[i], @"\s+");
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 3)
                        {
                            //Last as vector (1 instead of 0)
                            input_arr[i, j] = Double.Parse("1");
                        }
                        else
                        {
                            if (fixed_is_dot == true)
                            {
                                input_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                            }
                            else
                            {
                                input_arr[i, j] = Double.Parse(splitedlines[j]);
                            }
                        }

                    }
                }

                //Matrix
                // Create empty array
                string[] matrix_lines = TransformMatrixBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] matrix_arr = new double[4, 4];

                // Check if textBox is dot delimeted [.]
                bool matrix_is_dot = TransformMatrixBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < matrix_lines.Length; i++)
                {
                    matrix_lines[i] = matrix_lines[i].Trim();
                    string[] splitedlines = Regex.Split(matrix_lines[i], @"\s+");
                    for (int j = 0; j < splitedlines.Length; j++)
                    {
                        if (matrix_is_dot == true)
                        {
                            matrix_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            matrix_arr[i, j] = Double.Parse(splitedlines[j]);
                        }
                    }
                }

                //Vector<double> point = new DenseVector(new[] { -79.366, 59.349, 8.815, 1.0 });
                //Vector<double> point2 = tra.Multiply(point);

                Matrix<double> input_tra = Matrix<double>.Build.DenseOfArray(input_arr);
                Matrix<double> matrix_tra = Matrix<double>.Build.DenseOfArray(matrix_arr);
                Matrix<double> tra_final = matrix_tra.Multiply(input_tra.Transpose());
                

                //Inverse checkbox
                
                if (InverseCheck.Checked)
                {
                    OutputBox.AppendText("Transformation Matrix:\r\n");
                    OutputBox.AppendText(matrix_tra.ToString("F2", nfi) + "\r\n");
                    OutputBox.AppendText("Inversed Transformation Matrix:\r\n");
                    OutputBox.AppendText(matrix_tra.Inverse().ToString("F2", nfi) + "\r\n");
                }
                else
                {
                    OutputBox.AppendText("Transformation Matrix:\r\n");
                    OutputBox.AppendText(matrix_tra.ToString("F2", nfi) + "\r\n");
                }

                OutputBox.AppendText("Cloud Of Points Input:\r\n");
                OutputBox.AppendText(input_tra.RemoveColumn(3).ToString("F2", nfi) + "\r\n");

                OutputBox.AppendText("Cloud Of Points Output:\r\n");
                OutputBox.AppendText(tra_final.Transpose().RemoveColumn(3).ToString("F2", nfi) + "\r\n\r\n");
                

            }
            else
            {
                MessageBox.Show("Fill all inputs", "Input Error");
            }
        }
        //---Matrix Multipliction

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            //Delimeter [.] or [,]
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            if (DotCheck.Checked)
            {
                nfi.NumberDecimalSeparator = ".";
            }
            else
            {
                nfi.NumberDecimalSeparator = ",";
            }
            //Matrix1
            // Create empty array
            string[] matrix1_lines = MultiplyBox1.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            double[,] matrix1_arr = new double[4, 4];

            // Check if textBox is dot delimeted [.]
            bool matrix1_is_dot = MultiplyBox1.Text.Contains(".") ? true : false;

            for (int i = 0; i < matrix1_lines.Length; i++)
            {
                matrix1_lines[i] = matrix1_lines[i].Trim();
                string[] splitedlines = Regex.Split(matrix1_lines[i], @"\s+");
                for (int j = 0; j < splitedlines.Length; j++)
                {
                    if (matrix1_is_dot == true)
                    {
                        matrix1_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    }
                    else
                    {
                        matrix1_arr[i, j] = Double.Parse(splitedlines[j]);
                    }
                }
            }

            //Matrix2
            // Create empty array
            string[] matrix2_lines = MultiplyBox2.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            double[,] matrix2_arr = new double[4, 4];

            // Check if textBox is dot delimeted [.]
            bool matrix2_is_dot = MultiplyBox2.Text.Contains(".") ? true : false;

            for (int i = 0; i < matrix2_lines.Length; i++)
            {
                matrix2_lines[i] = matrix2_lines[i].Trim();
                string[] splitedlines = Regex.Split(matrix2_lines[i], @"\s+");
                for (int j = 0; j < splitedlines.Length; j++)
                {
                    if (matrix2_is_dot == true)
                    {
                        matrix2_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    }
                    else
                    {
                        matrix2_arr[i, j] = Double.Parse(splitedlines[j]);
                    }
                }
            }

            Matrix<double> matrix1 = Matrix<double>.Build.DenseOfArray(matrix1_arr);
            Matrix<double> matrix2 = Matrix<double>.Build.DenseOfArray(matrix2_arr);
            Matrix<double> matrix_final = matrix1.Multiply(matrix2);

            OutputBox.AppendText("First Matrix:\r\n");
            OutputBox.AppendText(matrix1.ToString("F2", nfi) + "\r\n");
            OutputBox.AppendText("Second Matrix:\r\n");
            OutputBox.AppendText(matrix1.ToString("F2", nfi) + "\r\n");
            OutputBox.AppendText("Multiplified Matrix:\r\n");
            OutputBox.AppendText(matrix_final.ToString("F2", nfi) + "\r\n");            
            OutputBox.AppendText("Multiplified Inversed Matrix:\r\n");
            OutputBox.AppendText(matrix_final.Inverse().ToString("F2", nfi) + "\r\n");
        }
        //---Automatic
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Delimeter [.] or [,]
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            if (DotCheck.Checked)
            {
                nfi.NumberDecimalSeparator = ".";
            }
            else
            {
                nfi.NumberDecimalSeparator = ",";
            }


            // Check if path is not empty

            if (!string.IsNullOrEmpty(FixedBox.Text) && !string.IsNullOrEmpty(MovingBox.Text))
            {
                // FIXED
                // Create empty array
                string[] fixed_lines = FixedBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] fixed_arr = new double[fixed_lines.Length, 3];

                // Check if textBox is dot delimeted [.]
                bool fixed_is_dot = FixedBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < fixed_lines.Length; i++)
                {
                    fixed_lines[i] = fixed_lines[i].Trim();
                    string[] splitedlines = Regex.Split(fixed_lines[i], @"\s+");
                    for (int j = 0; j < splitedlines.Length; j++)
                    {
                        if (fixed_is_dot == true)
                        {
                            fixed_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            fixed_arr[i, j] = Double.Parse(splitedlines[j]);
                        }
                    }
                }

                //MOVING
                // Create empty array
                string[] moving_lines = MovingBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                double[,] moving_arr = new double[moving_lines.Length, 3];

                // Check if textBox is dot delimeted [.]
                bool moving_is_dot = MovingBox.Text.Contains(".") ? true : false;

                for (int i = 0; i < moving_lines.Length; i++)
                {
                    moving_lines[i] = moving_lines[i].Trim();
                    string[] splitedlines = Regex.Split(moving_lines[i], @"\s+");
                    for (int j = 0; j < splitedlines.Length; j++)
                    {
                        if (moving_is_dot == true)
                        {
                            moving_arr[i, j] = Double.Parse(splitedlines[j], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            moving_arr[i, j] = Double.Parse(splitedlines[j]);
                        }
                    }
                }
                Matrix<double> fixed_input = Matrix<double>.Build.DenseOfArray(fixed_arr);
                Matrix<double> moving_input = Matrix<double>.Build.DenseOfArray(moving_arr);

                //+++Registration
                //Remove last 3 rows
                Matrix<double> fixed_femur = fixed_input.RemoveRow(3);
                fixed_femur = fixed_femur.RemoveRow(3);
                fixed_femur = fixed_femur.RemoveRow(3);

                Matrix<double> moving_femur = moving_input.RemoveRow(3);
                moving_femur = moving_femur.RemoveRow(3);
                moving_femur = moving_femur.RemoveRow(3);

                //+Calculate Registration Matrix
                Transform3D person = new Transform3D(fixed_femur, moving_femur);
                person.CalcTransform(fixed_femur, moving_femur);
                Matrix<double> registration_matrix = DenseMatrix.OfArray(person.TransformMatrix);

                OutputBox.AppendText(" \r\nRegistration Matrix: \r\n");
                OutputBox.AppendText(registration_matrix.ToString("F2", nfi) + "\r\n");

                //+Registered tibia
                //Remove first 3 rows
                Matrix<double> moving_tibia = moving_input.RemoveRow(0);
                moving_tibia = moving_tibia.RemoveRow(0);
                moving_tibia = moving_tibia.RemoveRow(0);

                //Add Column for matrix multipiplification
                Matrix<double> moving_tibia_plus_column = moving_tibia.InsertColumn(3, new DenseVector(new[] { 1.0, 1.0, 1.0 }));
                Matrix<double> tibia_registered = registration_matrix.Inverse().Multiply(moving_tibia_plus_column.Transpose());

                //+++Translation matrix of moving tibial points

                Matrix<double> fixed_tibia = fixed_input.RemoveRow(0);
                fixed_tibia = fixed_tibia.RemoveRow(0);
                fixed_tibia = fixed_tibia.RemoveRow(0);

                Transform3D final = new Transform3D(fixed_tibia, tibia_registered.Transpose().RemoveColumn(3));
                final.CalcTransform(fixed_tibia, tibia_registered.Transpose().RemoveColumn(3));
                Matrix<double> final_matrix = DenseMatrix.OfArray(final.TransformMatrix);

                OutputBox.AppendText("Final Translation Matrix: \r\n");
                OutputBox.AppendText(final_matrix.ToString("F2", nfi) + "\r\n");

                OutputBox.AppendText("ERROR RMS: \r\n");
                OutputBox.AppendText(final.ErrorRMS.ToString("F2", nfi) + "\r\n\r\n");

                double[] TransformMatrixToSiemens6DOFVector(Matrix<double> TransformMatrix)
                {
                    Vector<double> tempVector = new DenseVector(6);

                    //Set the X,Y, and Z translation components of the transform vector for Siemens convention
                    //Translation components in Siemens convention is simply the negative of the typical translation components
                    tempVector[0] = -TransformMatrix[0, 3];  //X translation
                    tempVector[1] = -TransformMatrix[1, 3];  //Y translation
                    tempVector[2] = -TransformMatrix[2, 3];  //Z translation

                    //Set the Z, Y, and X rotation components of the transform vector - see equation derivation at page 5 of http://www.usna.edu/Users/cs/taylor/courses/si475/class/3dkinematics.pdf
                    //Siemens convention was determined experimentally.  To find the typical 3X3 rotation matrix (RotationMatrix in this class), the following matrix multiplication order is used -> Rz*Ry*Rx
                    //To achieve the same rotation matrix with angles provided by Siemens MEAFrame, the following matrix multiplication must be used -> transpose(Rx)*transpose(Ry)*transpose(Rz)
                    double beta = Math.Atan2(-TransformMatrix[0, 2], Math.Sqrt(Math.Pow(TransformMatrix[0, 0], 2) + Math.Pow(TransformMatrix[0, 1], 2)));    //Y rotation - beta
                    double gamma = Math.Atan2(TransformMatrix[0, 1] / Math.Cos(beta), TransformMatrix[0, 0] / Math.Cos(beta));   //Z rotation - gamma
                    double alpha = Math.Atan2(TransformMatrix[1, 2] / Math.Cos(beta), TransformMatrix[2, 2] / Math.Cos(beta));   //X rotation - alpha

                    tempVector[3] = gamma;      //Z rotation - kappa
                    tempVector[4] = beta;       //Y rotation - phi
                    tempVector[5] = alpha;      //X rotation - omega

                    return tempVector.ToArray();

                }
                double RadianToDegree(double angle)
                {
                    return angle * (180.0 / Math.PI);
                }
                double Reverse(double a)
                {
                    double z = 0;
                    double x = z - a;
                    return x;
                }
                //Calculate
                //double[] MatrixTo6VOFResult = TransformMatrixTo6DOFVector(matrix_final);
                double[] MatrixTo6VOFResultSiemens = TransformMatrixToSiemens6DOFVector(final_matrix);

                //Results

                OutputBox.AppendText("Reversed Siemens 6VOF:\r\nx_tra\ty_tra\tz_tra\tx_rot\ty_rot\tz_rot\r\n");
                OutputBox.AppendText(Reverse(MatrixTo6VOFResultSiemens[0]).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(MatrixTo6VOFResultSiemens[1]).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(MatrixTo6VOFResultSiemens[2]).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResultSiemens[5])).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResultSiemens[4])).ToString("F2", nfi) + "\t");
                OutputBox.AppendText(Reverse(RadianToDegree(MatrixTo6VOFResultSiemens[3])).ToString("F2", nfi) + "\t\r\n\r\n");



                //+++ Matrix multiplification for check

                Matrix<double> matrix_multiplified = registration_matrix.Multiply(final_matrix);

                OutputBox.AppendText("Multiplified (Registration Matrix * Translation Matrix): \r\n");
                OutputBox.AppendText(matrix_multiplified.ToString("F2", nfi) + "\r\n");


                //+++ Tibia Point to Point distance
                //+pPCL
                //Create matrix for points
                double[,] pcl_point_moving_arr = { { moving_input[4, 0], moving_input[4, 1], moving_input[4, 2], 1 } };
                double[,] pcl_point_fixed_arr = { { fixed_input[4, 0], fixed_input[4, 1], fixed_input[4, 2], 1 } };

                //PCL moving poitn operations
                Matrix<double> pcl_point_moving_temp = Matrix<double>.Build.DenseOfArray(pcl_point_moving_arr);
                Matrix<double> pcl_point_fixed = Matrix<double>.Build.DenseOfArray(pcl_point_fixed_arr);
                Matrix<double> pcl_point_moving_registered = registration_matrix.Inverse().Multiply(pcl_point_moving_temp.Transpose());
                Matrix<double> pcl_point_moving = pcl_point_moving_registered.Transpose().RemoveColumn(3);

                double pcl_distance = Math.Sqrt(Math.Pow(pcl_point_moving[0, 0] - pcl_point_fixed[0, 0], 2)+ Math.Pow(pcl_point_moving[0, 1] - pcl_point_fixed[0, 1], 2)+ Math.Pow(pcl_point_moving[0, 2] - pcl_point_fixed[0, 2], 2));
                OutputBox.AppendText("Tibia PCL Point 3D distance | 2D distance (YZ plane): \r\n");
                OutputBox.AppendText(pcl_distance.ToString("F2", nfi) + "\r\n");

                //2D - YZ Plane
                double pcl_distance_2D = Math.Sqrt(Math.Pow(pcl_point_moving[0, 1] - pcl_point_fixed[0, 1], 2) + Math.Pow(pcl_point_moving[0, 2] - pcl_point_fixed[0, 2], 2));
                OutputBox.AppendText(pcl_distance_2D.ToString("F2", nfi) + "\r\n");

                //+pF - Fibula
                //Create matrix for points
                double[,] pf_point_moving_arr = { { moving_input[3, 0], moving_input[3, 1], moving_input[3, 2], 1 } };
                double[,] pf_point_fixed_arr = { { fixed_input[3, 0], fixed_input[3, 1], fixed_input[3, 2], 1 } };

                // moving poitn operations
                Matrix<double> pf_point_moving_temp = Matrix<double>.Build.DenseOfArray(pf_point_moving_arr);
                Matrix<double> pf_point_fixed = Matrix<double>.Build.DenseOfArray(pf_point_fixed_arr);
                Matrix<double> pf_point_moving_registered = registration_matrix.Inverse().Multiply(pf_point_moving_temp.Transpose());
                Matrix<double> pf_point_moving = pf_point_moving_registered.Transpose().RemoveColumn(3);

                double pf_distance = Math.Sqrt(Math.Pow(pf_point_moving[0, 0] - pf_point_fixed[0, 0], 2) + Math.Pow(pf_point_moving[0, 1] - pf_point_fixed[0, 1], 2) + Math.Pow(pf_point_moving[0, 2] - pf_point_fixed[0, 2], 2));
                OutputBox.AppendText("Fibula Point 3D distance | 2D distance (YZ plane): \r\n");
                OutputBox.AppendText(pf_distance.ToString("F2", nfi) + "\r\n");

                //2D - YZ Plane
                double pf_distance_2D = Math.Sqrt(Math.Pow(pf_point_moving[0, 1] - pf_point_fixed[0, 1], 2) + Math.Pow(pf_point_moving[0, 2] - pf_point_fixed[0, 2], 2));
                OutputBox.AppendText(pf_distance_2D.ToString("F2", nfi) + "\r\n");

                //+pPL - Fibula
                //Create matrix for points
                double[,] pPL_point_moving_arr = { { moving_input[5, 0], moving_input[5, 1], moving_input[5, 2], 1 } };
                double[,] pPL_point_fixed_arr = { { fixed_input[5, 0], fixed_input[5, 1], fixed_input[5, 2], 1 } };

                //PCL moving poitn operations
                Matrix<double> pPL_point_moving_temp = Matrix<double>.Build.DenseOfArray(pPL_point_moving_arr);
                Matrix<double> pPL_point_fixed = Matrix<double>.Build.DenseOfArray(pPL_point_fixed_arr);
                Matrix<double> pPL_point_moving_registered = registration_matrix.Inverse().Multiply(pPL_point_moving_temp.Transpose());
                Matrix<double> pPL_point_moving = pPL_point_moving_registered.Transpose().RemoveColumn(3);

                double pPL_distance = Math.Sqrt(Math.Pow(pPL_point_moving[0, 0] - pPL_point_fixed[0, 0], 2) + Math.Pow(pPL_point_moving[0, 1] - pPL_point_fixed[0, 1], 2) + Math.Pow(pPL_point_moving[0, 2] - pPL_point_fixed[0, 2], 2));
                OutputBox.AppendText("Patella ligament Point 3D distance | 2D distance (YZ plane): \r\n");
                OutputBox.AppendText(pPL_distance.ToString("F2", nfi) + "\r\n");

                //2D - YZ Plane
                double pPL_distance_2D = Math.Sqrt(Math.Pow(pPL_point_moving[0, 1] - pPL_point_fixed[0, 1], 2) + Math.Pow(pPL_point_moving[0, 2] - pPL_point_fixed[0, 2], 2));
                OutputBox.AppendText(pPL_distance_2D.ToString("F2", nfi) + "\r\n");

                //+Centroids distance
                Vector<double> GetCentroid(Matrix<double> matrix)
                {
                    return matrix.ColumnSums() / matrix.RowCount;
                }

                Matrix<double> fixed_centroid = GetCentroid(fixed_tibia).ToRowMatrix();
                Matrix<double> registered_centroid = GetCentroid(tibia_registered.Transpose().RemoveColumn(3)).ToRowMatrix();

                double centroid_distance = Math.Sqrt(Math.Pow(registered_centroid[0, 0] - fixed_centroid[0, 0], 2) + Math.Pow(registered_centroid[0, 1] - fixed_centroid[0, 1], 2) + Math.Pow(registered_centroid[0, 2] - fixed_centroid[0, 2], 2));
                OutputBox.AppendText("Centroid 3D distance | 2D distance (YZ plane): \r\n");
                OutputBox.AppendText(centroid_distance.ToString("F2", nfi) + "\r\n");

                //2D - YZ Plane
                double centroid_distance_2D = Math.Sqrt(Math.Pow(registered_centroid[0, 1] - fixed_centroid[0, 1], 2) + Math.Pow(registered_centroid[0, 2] - fixed_centroid[0, 2], 2));
                OutputBox.AppendText(centroid_distance_2D.ToString("F2", nfi) + "\r\n");

            }
        }

        //------Browse Buttons
        //---Browse Fixed button
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Delimeter [.] or [,]
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    if (DotCheck.Checked)
                    {
                        nfi.NumberDecimalSeparator = ".";
                    }
                    else
                    {
                        nfi.NumberDecimalSeparator = ",";
                    }

                    string path;
                    Matrix<double> matrix_cloud;

                    //Get the path of specified file
                    path = openFileDialog.FileName;
                    OutputBox.AppendText("Moving input file:" + path + "\r\n");
                    MovingFile.Text = String.Empty;
                    MovingFile.AppendText(path);

                    if (new System.IO.FileInfo(path).Length > 0)
                    {
                        //Check if it is dot [.] delimeted
                        bool nf_is_dot = System.IO.File.ReadAllText(path).Contains(".") ? true : false;
                        if (nf_is_dot == true)
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false);
                        }

                        MovingBox.AppendText(matrix_cloud.ToMatrixString("F4", nfi));
                    }
                }
            }
        }

        //---Browse Moving button
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Delimeter [.] or [,]
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    if (DotCheck.Checked)
                    {
                        nfi.NumberDecimalSeparator = ".";
                    }
                    else
                    {
                        nfi.NumberDecimalSeparator = ",";
                    }

                    string path;
                    Matrix<double> matrix_cloud;

                    //Get the path of specified file
                    path = openFileDialog.FileName;
                    OutputBox.AppendText("Fixed input file:" + path + "\r\n");
                    FixedFile.Text = String.Empty;
                    FixedFile.AppendText(path);

                    if (new System.IO.FileInfo(path).Length > 0)
                    {
                        //Check if it is dot [.] delimeted
                        bool nf_is_dot = System.IO.File.ReadAllText(path).Contains(".") ? true : false;
                        if (nf_is_dot == true)
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false);
                        }

                        FixedBox.AppendText(matrix_cloud.ToMatrixString("F4", nfi));
                    }
                }
            }
        }
        //---Browse file for 6DOF
        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Delimeter [.] or [,]
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    if (DotCheck.Checked)
                    {
                        nfi.NumberDecimalSeparator = ".";
                    }
                    else
                    {
                        nfi.NumberDecimalSeparator = ",";
                    }

                    string path;
                    Matrix<double> matrix_cloud;

                    //Get the path of specified file
                    path = openFileDialog.FileName;
                    OutputBox.AppendText("Convert matrix file:" + path + "\r\n");
                    ConvertFile.Text = String.Empty;
                    ConvertFile.AppendText(path);

                    if (new System.IO.FileInfo(path).Length > 0)
                    {
                        //Check if it is dot [.] delimeted
                        bool nf_is_dot = System.IO.File.ReadAllText(path).Contains(".") ? true : false;
                        if (nf_is_dot == true)
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false);
                        }

                        ConvertBox.AppendText(matrix_cloud.ToMatrixString("F4", nfi));
                    }
                }
            }
        }
        //---Browse file for transform input
        private void TransformInputBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Delimeter [.] or [,]
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    if (DotCheck.Checked)
                    {
                        nfi.NumberDecimalSeparator = ".";
                    }
                    else
                    {
                        nfi.NumberDecimalSeparator = ",";
                    }

                    string path;
                    Matrix<double> matrix_cloud;

                    //Get the path of specified file
                    path = openFileDialog.FileName;
                    OutputBox.AppendText("Input file:" + path + "\r\n");
                    TransformInputFile.Text = String.Empty;
                    TransformInputFile.AppendText(path);

                    if (new System.IO.FileInfo(path).Length > 0)
                    {
                        //Check if it is dot [.] delimeted
                        bool nf_is_dot = System.IO.File.ReadAllText(path).Contains(".") ? true : false;
                        if (nf_is_dot == true)
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false);
                        }

                        TransformInputBox.AppendText(matrix_cloud.ToMatrixString("F4", nfi));
                    }
                }
            }
        }
        //---Browse file for transform matrix
        private void TransformMatrixBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Delimeter [.] or [,]
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    if (DotCheck.Checked)
                    {
                        nfi.NumberDecimalSeparator = ".";
                    }
                    else
                    {
                        nfi.NumberDecimalSeparator = ",";
                    }

                    string path;
                    Matrix<double> matrix_cloud;

                    //Get the path of specified file
                    path = openFileDialog.FileName;
                    OutputBox.AppendText("Transform matrix file:" + path + "\r\n");
                    TransformMatrixFile.Text = String.Empty;
                    TransformMatrixFile.AppendText(path);

                    if (new System.IO.FileInfo(path).Length > 0)
                    {
                        //Check if it is dot [.] delimeted
                        bool nf_is_dot = System.IO.File.ReadAllText(path).Contains(".") ? true : false;
                        if (nf_is_dot == true)
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else
                        {
                            matrix_cloud = DelimitedReader.Read<double>(path, false, @"\s", false);
                        }

                        TransformMatrixBox.AppendText(matrix_cloud.ToMatrixString("F4", nfi));
                    }
                }
            }
        }
        //-----Parameters
        //---Save as ... button
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.FileName = "Calc";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, String.Empty);
                System.IO.File.WriteAllText(saveFileDialog1.FileName, OutputBox.Text);
            }
        }
        //---Clear All Button
        private void button5_Click_1(object sender, EventArgs e)
        {
            OutputBox.Text = String.Empty;
            MultiplyBox1.Text = String.Empty;
            MultiplyBox2.Text = String.Empty;
            FixedFile.Text = String.Empty;
            FixedBox.Text = String.Empty;
            MovingFile.Text = String.Empty;
            MovingBox.Text = String.Empty;
            ConvertFile.Text = String.Empty;
            ConvertBox.Text = String.Empty;
            TransformInputFile.Text = String.Empty;
            TransformInputBox.Text = String.Empty;
            TransformMatrixFile.Text = String.Empty;
            TransformMatrixBox.Text = String.Empty;
        }
        //---CLear Input Button
        private void ClearInput_Click(object sender, EventArgs e)
        {
            MultiplyBox1.Text = String.Empty;
            MultiplyBox2.Text = String.Empty;
            FixedFile.Text = String.Empty;
            FixedBox.Text = String.Empty;
            MovingFile.Text = String.Empty;
            MovingBox.Text = String.Empty;
            ConvertFile.Text = String.Empty;
            ConvertBox.Text = String.Empty;
            TransformInputFile.Text = String.Empty;
            TransformInputBox.Text = String.Empty;
            TransformMatrixFile.Text = String.Empty;
            TransformMatrixBox.Text = String.Empty;
        }
        //---Clear output button
        private void button5_Click(object sender, EventArgs e)
        {
            OutputBox.Text = String.Empty;
        }

        
        //------Open location Buttons
        //---Open location of Fixed file
        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + FixedFile.Text);
        }
        //---Open location of Moving file
        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + MovingFile.Text);
        }
        //---Open location of Convert file
        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + ConvertFile.Text);
        }
        //---Open location of  Transform Input
        private void TransformInputExplorer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + TransformInputFile.Text);
        }
        //---Open location of Transform Matrix
        private void TransformMatrixExplorer_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + TransformMatrixFile.Text);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
