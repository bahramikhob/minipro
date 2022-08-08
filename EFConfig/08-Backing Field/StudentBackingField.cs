using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConfig._08_Backing_Field
{
    public class StudentBackingField
    {
        public int Id { get; set; }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }


        private string _myBackingFieldForLastName;
        public string LastName
        {
            get
            {
                return _myBackingFieldForLastName;
            }
            set
            {
                _myBackingFieldForLastName = value;
            }
        }

        private string _studentNumber;
        public void SetStudentNumber(string studentNumber)
        {
            _studentNumber = studentNumber;
        }
        public string GetStudentNumber()
        {
            return _studentNumber;
        }
    }
}
