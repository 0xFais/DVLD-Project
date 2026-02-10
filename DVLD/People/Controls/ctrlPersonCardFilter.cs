using System;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardFilter : UserControl
    {
        public int _PersonID { get; private set; }
        public event Action<int> OnSearchComplete;
        protected virtual void SearchComplete(int personID)
        {
            Action<int> handler = OnSearchComplete;
            if (handler != null)
            {
                handler(personID);
            }
        }

        public ctrlPersonCardFilter()
        {
            InitializeComponent();
            _PersonID = -1;
        }
        private bool _LoadPersonPersonID(int PersonID)
        {
            if (ctrlPersonCard1.LoadPersonInfoByPersonID(PersonID))
            {
                _PersonID = PersonID;
                return true;
            }
            return false;
        }
        private bool _LoadPersonNationlNo(string NationalNumber)
        {
            int ID = -1;
            if (ctrlPersonCard1.LoadPersonInfoByNationalNo(NationalNumber, ref ID))
            {
                _PersonID = ID;
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search 
            if (cbFilters.Text == "Person ID")
            {
                if (int.TryParse(txtPersonID.Text, out int ID))
                {
                    _PersonID = ID;
                    if (!_LoadPersonPersonID(_PersonID))
                    {
                        MessageBox.Show("Didn't found any person with that this " + txtPersonID.Text + " ID ");
                    }
                }
                else
                {
                    MessageBox.Show("Please inter a valid number as ID");
                    return;

                }
            }
            else if (cbFilters.Text == "National No.")
            {
                if (!_LoadPersonNationlNo(txtPersonID.Text))
                {
                    MessageBox.Show("Didn't found any person with that this National nubmer");
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += GetPersonID;
            frm.ShowDialog();
        }
        public void GetPersonID(object sender, int PersonID)
        {
            _PersonID = PersonID;
            txtPersonID.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfoByPersonID(_PersonID);
        }
        public bool LoadPersonValuesByID(int PersonID)
        {
            if (_LoadPersonPersonID(PersonID))
            {
                txtPersonID.Text = PersonID.ToString();
                return true;
            }

            return false;
        }

        public bool LoadPersonValuesByNationalNo(string NationalNumber)
        {
            if (_LoadPersonNationlNo(NationalNumber))
            {
                txtPersonID.Text = NationalNumber;
                return true;
            }

            return false;
        }

        public void FilterEnable(bool key)
        {
            groupBox1.Enabled = key;
        }
        private void ctrlPersonCardFilter_Load(object sender, EventArgs e)
        {
            cbFilters.Items.Add("Person ID");
            cbFilters.Items.Add("National No.");
            cbFilters.SelectedIndex = 0;

        }
    }
}
