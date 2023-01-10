using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSSA.VIEW
{
    public partial class UCShift : UserControl
    {
        TblShift TblShift;
        
        public UCShift(TblShift shift)
        {
            InitializeComponent();
            TblShift = shift;
            refreshData(shift);
        }
        public void refreshData(TblShift tblShift)
        {
            if (tblShift!=null)
            {
                lblShiftName.Text = tblShift.shiftName;
                lblShiftDate.Text = ((DateTime)tblShift.startDate).ToString("dd / MM / yyyy");
                lblSiftTime.Text = DateTime.Today.Add((TimeSpan)tblShift.startTime).ToString("hh:mm tt");
            }
          
        }
        public TblShift getCurrentShift()
        {
            return TblShift;

        }
    }
}
