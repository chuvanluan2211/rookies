using Buoi6_MVC_3.Models;

namespace Buoi6_MVC_3.Services
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> _people = new List<PersonModel>
    {
        new PersonModel
        {
            FirstName = "Tien",
            LastName =  "Nguyen",
            Gender = "Male",
            DOB = new DateTime(2000 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Ha Noi",
            IsGraduated = false,
        },
        new PersonModel
        {
            FirstName = "Luan",
            LastName =  "Chu Van",
            Gender = "Male",
            DOB = new DateTime(2001 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Hung Yen",
            IsGraduated = false,
        },
        new PersonModel
        {
            FirstName = "Vinh",
            LastName =  "Nguyen",
            Gender = "Male",
            DOB = new DateTime(1999 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Ha Noi",
            IsGraduated = false,
        },
        new PersonModel
        {
            FirstName = "Ha",
            LastName =  "Nguyen",
            Gender = "FeMale",
            DOB = new DateTime(1989 , 11 , 13),
            PhoneNumber = "093213222",
            BirthDay = "Ha Noi",
            IsGraduated = false,
        },

    };

        public PersonModel Create(PersonModel model)
        {
           _people.Add(model);

           return model;
        }

        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                _people.RemoveAt(index);
                return person;
            }

            return null;
        }

        public List<PersonModel> GetAll()
        {
            return _people;
        }

        public PersonModel? GetOne(int index)
        {
           throw new NotImplementedException();
        }

        public PersonModel? Update(int index, PersonModel model)
        {
             if (index >= 0 && index < _people.Count)
            {
                _people[index] = model;
                return model;
            }

            return null;
        }
    }
}