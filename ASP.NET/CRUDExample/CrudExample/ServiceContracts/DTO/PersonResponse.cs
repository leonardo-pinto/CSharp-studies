﻿using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO class that is used as return
    /// type of most methods of Persons Service
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }

        public string? Country { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public double? Age { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(PersonResponse))
            {
                return false;
            }

            PersonResponse person = (PersonResponse)obj;

            return PersonID == person.PersonID 
                && PersonName == person.PersonName
                && Email == person.Email 
                && DateOfBirth == person.DateOfBirth 
                && Gender == person.Gender
                && Address == person.Address 
                && CountryID == person.CountryID
                && ReceiveNewsLetters == person.ReceiveNewsLetters;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    // method extension for Person
    public static class PersonExtensions
    {
        /// <summary>
        /// An extension method to convert an object of Person class into PersonResponse class
        /// </summary>
        /// <param name="person">The Person object to convert</param>
        /// <returns>Returns the converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person) => new PersonResponse()
        {
            PersonID = person.PersonID,
            PersonName = person.PersonName,
            Email = person.Email,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender,
            Address = person.Address,
            CountryID = person.CountryID,
            ReceiveNewsLetters = person.ReceiveNewsLetters,
            Age = (person.DateOfBirth != null)
                ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25)
                : null
        };
    }
}