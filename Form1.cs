using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Method_of_calculation_4
{
    public partial class Main_Form : Form
    {
        double accurateZ = 10.5844484649508098;
        double alpha = 1.1;
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Result_btn_Click(object sender, EventArgs e)
        {
            int n = 2;
            double[] sums = new double[17];
            double[] third = new double[17];
            double[] cetvert = new double[17];
            double[] deltan = new double[17];
            double[] schestoy = new double[17];
            double[] deltan1 = new double[17];
            int iter = 0;
            while (n <= 131072)
            {
                sums[iter] = Summa(n) - accurateZ;
                third[iter] = Summa(n) - extrapolate(Summa(n), Summa(n / 2), (alpha - 1));
                cetvert[iter] = extrapolate(Summa(n), Summa(n / 2), (alpha - 1)) - accurateZ;
                deltan[iter] = cetvert[iter] / sums[iter];
                if (n == 2)
                {
                    dataGridView.Rows.Add(n, sums[iter], third[iter], cetvert[iter], deltan[iter], "-", "-");
                }
                else
                {
                    double val = extrapolate(Summa(n), Summa(n / 2), (alpha - 1));
                    double val2 = extrapolate(Summa(n / 2), Summa(n / 4), (alpha - 1));
                    schestoy[iter] = extrapolate(val, val2, (alpha)) - accurateZ;
                    deltan1[iter] = schestoy[iter] / cetvert[iter];
                    dataGridView.Rows.Add(n, sums[iter], third[iter], cetvert[iter], deltan[iter], schestoy[iter], deltan1[iter]);
                }
                n *= 2;
            }
        }
        double Summa(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
                sum += (1 / Math.Pow(i, alpha));
            return sum;
        }
        double extrapolate(double zn, double znq, double k)
        {
            return (zn + ((zn - znq) / (Math.Pow(2, k) - 1)));
        }

    }
}
