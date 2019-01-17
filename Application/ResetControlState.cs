using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;

namespace Application
{
    class ResetControlState
    {
        public void Teacher_ResetAllControlState(AddTeacherForm Controls)
        {
            Controls.SubmitButton.Select();
            Controls.FirstNameTextbox.ResetText();
            Controls.MiddleNameTextbox.ResetText();
            Controls.LastNameTextbox.ResetText();

            Controls.BirthdayPicker.Value = DateTime.Now;
            Controls.GenderDropdown.selectedIndex = 0;
            Controls.BloodTypeTextbox.ResetText();

            Controls.PresentAddressTextbox.ResetText();
            Controls.ReligionTextbox.ResetText();
            Controls.EmailAddressTextbox.ResetText();
            Controls.MobileNumberTextbox.ResetText();

            Controls.English_CheckBox.Checked = false;
            Controls.Science_CheckBox.Checked = false;
            Controls.Math_CheckBox.Checked = false;

            Controls.Filipino_CheckBox.Checked = false;
            Controls.AP_CheckBox.Checked = false;
            Controls.Mapeh_CheckBox.Checked = false;

            Controls.TLE_CheckBox.Checked = false;
            Controls.ESP_CheckBox.Checked = false;

            Controls.AccountPhoto.Image = Application.Properties.Resources.user;
            Controls.UserNameTextbox.ResetText();
            Controls.PasswordTextbox.ResetText();

            Controls.AccountTypeDropdown.selectedIndex = 0;
            Controls.ConfirmPasswordTextbox.ResetText();
        }

        public void Student_ResetAllControlState(AddStudentForm Controls)
        {
            Controls.SubmitButton.Select();
            Controls.LRNTextbox.ResetText();
            Controls.FirstNameTextbox.ResetText();
            Controls.MiddleNameTextbox.ResetText();
            Controls.LastNameTextbox.ResetText();

            Controls.GenderDropdown.selectedIndex = 0;
            Controls.BirthdayPicker.Value = DateTime.Now;
            Controls.PresentAddressTextbox.ResetText();

            Controls.PlaceOfBirthTextbox.ResetText();
            Controls.BloodTypeTextbox.ResetText();
            Controls.ReligionTextbox.ResetText();

            Controls.IndiginousGroupTextbox.ResetText();
            Controls.EmailAddressTextbox.ResetText();
            Controls.MobileNumberTextbox.ResetText();

            Controls.FathersNameTextbox.ResetText();
            Controls.FathersOccupationTextbox.ResetText();
            Controls.FathersContactNumberTextbox.ResetText();
            Controls.FathersAddressTextbox.ResetText();

            Controls.MothersNameTextbox.ResetText();
            Controls.MothersOccupationTextbox.ResetText();
            Controls.MothersContactNumberTextbox.ResetText();
            Controls.MothersAddressTextbox.ResetText();

            Controls.GradeLevelDropdown.selectedIndex = 0;
            Controls.SectionDropdown.selectedIndex = 0;

            Controls.UsernameTextbox.ResetText();
            Controls.PasswordTextbox.ResetText();
            Controls.ConfirmPasswordTextbox.ResetText();
        }

        public void Update_Student_Details_Reset_Controls(StudentEditDetailsForm Controls)
        {
            Controls.CloseFlatButton.Select();
            Controls.AccountPicture.Image.Dispose();
            
            if (Controls.Gender.Equals("Male")) {
                Controls.GenderDropdown.selectedIndex = 0;
            }

            else {
                Controls.GenderDropdown.selectedIndex = 1;
            }

            Controls.BirthDatepicker.Value = DateTime.Parse(Controls.BirthDate);
        }
    }
}
