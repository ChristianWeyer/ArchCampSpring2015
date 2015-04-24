using System.ComponentModel;

namespace DataContracts
{
    public class SpeakerDto : ModelBase, IEditableObject
    {
        public int Id { get; set; }

        private string _firstName;
        private string _firstNameOrg;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; this.OnPropertyChanged(); }
        }

        private string _lastName;
        private string _lastNameOrg;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; this.OnPropertyChanged(); }
        }

        public void BeginEdit()
        {
            _firstNameOrg = _firstName;
            _lastNameOrg = _lastName;
        }

        public void CancelEdit()
        {
            this.FirstName = _firstNameOrg;
            this.LastName = _lastNameOrg;
        }

        public void EndEdit()
        {
            _firstNameOrg = null;
            _lastNameOrg = null;
        }
    }
}
