using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultipleFileUpload.Models
{
    public class VisaApplication
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string SureName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string MotherName { get; set; }
        public string Nationality { get; set; }
        public string DateOfbirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string EmployerAddress { get; set; }
        public string Occupation { get; set; }
        public string Employer { get; set; }
        public bool option1 { get; set; }
        public DateTime date { get; set; }
        public int Status { get; set; }
        public string Nationality2 { get; set; }
        public string Occupation2 { get; set; }
        public string DOB { get; set; }
        public string SpouseName { get; set; }
        public string PhoneNo { get; set; }
        public string Sate { get; set; }
        public string City { get; set; }
        public string NeighbourHood { get; set; }
        public string Street { get; set; }
        public string Expirydate{get;set;}
        public string IssueDate { get; set; }
        public string issueAtcity { get; set; }
        public string typeOfNo { get; set; }
        public int Durationv { get; set; }
        public string Exarrivale { get; set; }
        public string PurposeVisit { get; set; }
        public string KnownAs { get; set; }
        public string JordanNo { get; set; }
        public string AddressInJordan { get; set; }
        public string Durationv1 { get; set; }
        public string Exarrivale2 { get; set; }
        public string PurposeVisit3 { get; set; }

        public virtual ICollection<Mfiles> Mfiles { get; set; }

    }
}